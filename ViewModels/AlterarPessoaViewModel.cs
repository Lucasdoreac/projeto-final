using System.Windows.Input;
using appClassePessoaBD.Model;
using appClassePessoaBD.Services;

namespace appClassePessoaBD.ViewModels
{
    public class AlterarPessoaViewModel : BaseViewModel
    {
        private readonly IPessoaService _pessoaService;
        private Pessoa _pessoaOriginal;
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

        public AlterarPessoaViewModel(IPessoaService pessoaService)
        {
            _pessoaService = pessoaService;
            SalvarCommand = new Command(async () => await SalvarAsync());
        }

        public void DefinirPessoa(Pessoa pessoa)
        {
            _pessoaOriginal = pessoa;
            Nome = pessoa.pesNome ?? string.Empty;
            Idade = pessoa.pesIdade;
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
                    pesID = _pessoaOriginal.pesID,
                    pesNome = Nome.Trim().ToUpper(),
                    pesIdade = Idade
                };

                await _pessoaService.Update(pessoa);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
