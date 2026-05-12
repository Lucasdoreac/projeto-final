using System.Windows.Input;
using Microsoft.Maui.Storage;
using appClassePessoaBD.Services;

namespace appClassePessoaBD.ViewModels
{
    public class ConfiguracoesViewModel : BaseViewModel
    {
        private readonly IPessoaService _pessoaService;
        private bool _salvarUltimoNome;
        private string _mensagemSucesso = string.Empty;
        private string _mensagemErro = string.Empty;

        public bool SalvarUltimoNome
        {
            get => _salvarUltimoNome;
            set => SetProperty(ref _salvarUltimoNome, value);
        }

        public string MensagemSucesso
        {
            get => _mensagemSucesso;
            set => SetProperty(ref _mensagemSucesso, value);
        }

        public string MensagemErro
        {
            get => _mensagemErro;
            set => SetProperty(ref _mensagemErro, value);
        }

        public ICommand SalvarCommand { get; }
        public ICommand LimparDadosCommand { get; }

        public ConfiguracoesViewModel(IPessoaService pessoaService)
        {
            _pessoaService = pessoaService;
            SalvarCommand = new Command(async () => await SalvarAsync());
            LimparDadosCommand = new Command(async () => await LimparDadosAsync());

            CarregarConfiguracoes();
        }

        private void CarregarConfiguracoes()
        {
            SalvarUltimoNome = Preferences.Get("SalvarUltimoNome", true);
        }

        private async Task SalvarAsync()
        {
            if (IsBusy)
                return;

            try
            {
                IsBusy = true;
                MensagemSucesso = string.Empty;

                Preferences.Set("SalvarUltimoNome", SalvarUltimoNome);

                MensagemSucesso = "Configurações salvas com sucesso!";

                await Task.Delay(2000);
                MensagemSucesso = string.Empty;

                var mainPage = Application.Current?.MainPage;
                if (mainPage != null)
                {
                    await mainPage.Navigation.PopAsync();
                }
            }
            finally
            {
                IsBusy = false;
            }
        }

        private async Task LimparDadosAsync()
        {
            if (IsBusy)
                return;

            try
            {
                var mainPage = Application.Current?.MainPage;
                if (mainPage == null)
                {
                    MensagemErro = "MainPage não disponível.";
                    return;
                }

                bool confirmar = await mainPage.DisplayAlert(
                    "Confirmação",
                    "Tem certeza que deseja apagar TODOS os dados? Esta ação não pode ser desfeita.",
                    "Sim",
                    "Não"
                );

                if (!confirmar)
                    return;

                IsBusy = true;

                // Obter todas as pessoas
                var pessoas = await _pessoaService.GetAll();

                // Deletar uma por uma
                foreach (var pessoa in pessoas)
                {
                    await _pessoaService.Delete(pessoa.pesID);
                }

                if (mainPage != null)
                {
                    await mainPage.DisplayAlert(
                        "Sucesso",
                        $"Foram apagadas {pessoas.Count} pessoas.",
                        "OK"
                    );
                }
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
