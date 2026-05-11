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

        private async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;

            var pessoa = e.SelectedItem as Pessoa;
            await Navigation.PushAsync(new TelaAlterarPessoa(pessoa));

            lstPessoas.SelectedItem = null;
        }
    }
}
