using appClassePessoaBD.Model;
using appClassePessoaBD.ViewModels;
using appClassePessoaBD.Services;

namespace appClassePessoaBD.Views
{
    public partial class TelaEstatisticas : ContentPage
    {
        private readonly EstatisticasViewModel _viewModel;

        public TelaEstatisticas()
        {
            InitializeComponent();

            // Criar Service e ViewModel manualmente
            var pessoaService = new PessoaService(App.Database);
            _viewModel = new EstatisticasViewModel(pessoaService);
            BindingContext = _viewModel;
        }

        protected async override void OnAppearing()
        {
            await _viewModel.CarregarEstatisticasAsync();
        }
    }
}
