using System.Windows.Input;
using appClassePessoaBD.Model;
using appClassePessoaBD.Services;

namespace appClassePessoaBD.ViewModels
{
    public class IncluirPessoaViewModel : BaseViewModel
    {
        private readonly IPessoaService _pessoaService;
        private string _nome = string.Empty;
        private int _idade;
        private string _mensagemErro = string.Empty;

        public string Nome
        {
            get => _nome;
            set => SetProperty(ref _nome, value);
        }

        public int Idade
        {
            get => _idade;
            set => SetProperty(ref _idade, value);
        }

        public string MensagemErro
        {
            get => _mensagemErro;
            set => SetProperty(ref _mensagemErro, value);
        }

        public ICommand SalvarCommand { get; }

        public IncluirPessoaViewModel(IPessoaService pessoaService)
        {
            _pessoaService = pessoaService;
            SalvarCommand = new Command(async () => await SalvarAsync());
        }

        private async Task SalvarAsync()
        {
            if (IsBusy)
                return;

            try
            {
                IsBusy = true;
                MensagemErro = string.Empty;

                // Validações
                if (string.IsNullOrWhiteSpace(Nome))
                {
                    MensagemErro = "O campo Nome é obrigatório.";
                    return;
                }

                if (Nome.Trim().Length < 3)
                {
                    MensagemErro = "O nome deve ter pelo menos 3 caracteres.";
                    return;
                }

                if (Idade <= 0)
                {
                    MensagemErro = "A idade deve ser maior que zero.";
                    return;
                }

                if (Idade > 150)
                {
                    MensagemErro = "A idade deve ser menor que 150 anos.";
                    return;
                }

                var pessoa = new Pessoa
                {
                    pesNome = Nome.Trim().ToUpper(),
                    pesIdade = Idade
                };

                await _pessoaService.Insert(pessoa);

                // Limpar formulário
                Nome = string.Empty;
                Idade = 0;
            }
            finally
            {
                IsBusy = false;
            }
        }

        public void CarregarUltimoNome()
        {
            var ultimoNome = Microsoft.Maui.Storage.Preferences.Default.Get("ultimo_usuario_cadastrado", "");
            if (!string.IsNullOrWhiteSpace(ultimoNome))
            {
                Nome = ultimoNome;
            }
        }
    }
}
