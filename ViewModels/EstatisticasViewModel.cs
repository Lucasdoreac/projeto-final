using System.Windows.Input;
using System.Linq;
using appClassePessoaBD.Model;
using appClassePessoaBD.Services;

namespace appClassePessoaBD.ViewModels
{
    public class EstatisticasViewModel : BaseViewModel
    {
        private readonly IPessoaService _pessoaService;
        private int _totalPessoas;
        private double _mediaIdade;
        private string _pessoaMaisVelha = "N/A";
        private string _pessoaMaisNova = "N/A";
        private string _mensagemErro = string.Empty;
        private bool _temErro;

        public int TotalPessoas
        {
            get => _totalPessoas;
            set => SetProperty(ref _totalPessoas, value);
        }

        public double MediaIdade
        {
            get => _mediaIdade;
            set => SetProperty(ref _mediaIdade, value);
        }

        public string PessoaMaisVelha
        {
            get => _pessoaMaisVelha;
            set => SetProperty(ref _pessoaMaisVelha, value);
        }

        public string PessoaMaisNova
        {
            get => _pessoaMaisNova;
            set => SetProperty(ref _pessoaMaisNova, value);
        }

        public string MensagemErro
        {
            get => _mensagemErro;
            set => SetProperty(ref _mensagemErro, value);
        }

        public bool TemErro
        {
            get => _temErro;
            set => SetProperty(ref _temErro, value);
        }

        public ICommand CarregarEstatisticasCommand { get; }

        public EstatisticasViewModel(IPessoaService pessoaService)
        {
            _pessoaService = pessoaService;
            CarregarEstatisticasCommand = new Command(async () => await CarregarEstatisticasAsync());
        }

        public async Task CarregarEstatisticasAsync()
        {
            if (IsBusy)
                return;

            try
            {
                IsBusy = true;
                MensagemErro = string.Empty;
                TemErro = false;

                // Buscar todas as pessoas
                var pessoas = await _pessoaService.GetAll();

                if (!pessoas.Any())
                {
                    MensagemErro = "Nenhuma pessoa cadastrada.";
                    TemErro = true;

                    TotalPessoas = 0;
                    MediaIdade = 0;
                    PessoaMaisVelha = "N/A";
                    PessoaMaisNova = "N/A";
                    return;
                }

                // Calcular estatísticas
                TotalPessoas = pessoas.Count;
                MediaIdade = pessoas.Average(p => p.pesIdade);

                var maisVelha = pessoas.OrderByDescending(p => p.pesIdade).First();
                var maisNova = pessoas.OrderBy(p => p.pesIdade).First();

                PessoaMaisVelha = $"{maisVelha.pesNome} ({maisVelha.pesIdade} anos)";
                PessoaMaisNova = $"{maisNova.pesNome} ({maisNova.pesIdade} anos)";
            }
            catch (Exception ex)
            {
                MensagemErro = $"Erro ao carregar estatísticas: {ex.Message}";
                TemErro = true;
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
