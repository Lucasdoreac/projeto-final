using System.Windows.Input;
using Microsoft.Maui.Storage;
using appClassePessoaBD.Services;

namespace appClassePessoaBD.ViewModels
{
    public class ConfiguracoesViewModel : BaseViewModel
    {
        private readonly IPessoaService _pessoaService;
        private bool _salvarUltimoNome;
        private bool _ativarSons;
        private string _mensagemSucesso = string.Empty;

        public bool SalvarUltimoNome
        {
            get => _salvarUltimoNome;
            set => SetProperty(ref _salvarUltimoNome, value);
        }

        public bool AtivarSons
        {
            get => _ativarSons;
            set => SetProperty(ref _ativarSons, value);
        }

        public string MensagemSucesso
        {
            get => _mensagemSucesso;
            set => SetProperty(ref _mensagemSucesso, value);
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
            AtivarSons = Preferences.Get("AtivarSons", true);
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
                Preferences.Set("AtivarSons", AtivarSons);

                MensagemSucesso = "Configurações salvas com sucesso!";

                await Task.Delay(2000);
                MensagemSucesso = string.Empty;

                await Application.Current.MainPage.Navigation.PopAsync();
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
                bool confirmar = await Application.Current.MainPage.DisplayAlert(
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

                await Application.Current.MainPage.DisplayAlert(
                    "Sucesso",
                    $"Foram apagadas {pessoas.Count} pessoas.",
                    "OK"
                );
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
