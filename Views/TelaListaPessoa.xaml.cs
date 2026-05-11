using appClassePessoaBD.Model;
using appClassePessoaBD.ViewModels;
using appClassePessoaBD.Services;

namespace appClassePessoaBD.Views
{
    public partial class TelaListaPessoa : ContentPage
    {
        private readonly ListaPessoasViewModel _viewModel;

        public TelaListaPessoa()
        {
            InitializeComponent();

            // Criar Service e ViewModel manualmente (sem DI container)
            var pessoaService = new PessoaService(App.Database);
            _viewModel = new ListaPessoasViewModel(pessoaService);
            BindingContext = _viewModel;
        }

        protected async override void OnAppearing()
        {
            await _viewModel.CarregarPessoasAsync();
        }

        private async void OnIncluirClicked(object sender, EventArgs e)
        {
            try
            {
                await Navigation.PushAsync(new TelaIncluirPessoa());
            }
            catch (Exception ex)
            {
                await DisplayAlert("Erro", $"Erro ao abrir tela: {ex.Message}\n\n{ex.StackTrace}", "OK");
            }
        }

        private async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;

            var pessoa = e.SelectedItem as Pessoa;
            await Navigation.PushAsync(new TelaAlterarPessoa(pessoa));

            lstPessoas.SelectedItem = null;
        }

        private async void OnExcluirClicked(object sender, EventArgs e)
        {
            try
            {
                var menuItem = sender as MenuItem;
                if (menuItem?.CommandParameter is Pessoa pessoa)
                {
                    bool confirmar = await DisplayAlert("Confirmação", $"Deseja excluir {pessoa.pesNome}?", "Sim", "Não");
                    if (confirmar)
                    {
                        await App.Database.Delete(pessoa.pesID);
                        _viewModel.Pessoas.Remove(pessoa);
                    }
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Erro", $"Erro ao excluir: {ex.Message}", "OK");
            }
        }
    }
}
