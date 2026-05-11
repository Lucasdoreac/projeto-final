using appClassePessoaBD.ViewModels;
using appClassePessoaBD.Services;

namespace appClassePessoaBD.Views
{
    public partial class TelaConfiguracoes : ContentPage
    {
        private readonly ConfiguracoesViewModel _viewModel;

        public TelaConfiguracoes()
        {
            InitializeComponent();

            // Criar Service e ViewModel manualmente (sem DI container)
            var pessoaService = new PessoaService(App.Database);
            _viewModel = new ConfiguracoesViewModel(pessoaService);
            BindingContext = _viewModel;
        }
    }
}
