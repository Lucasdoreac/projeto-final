using appClassePessoaBD.ViewModels;
using appClassePessoaBD.Services;

namespace appClassePessoaBD.Views;

	public partial class TelaIncluirPessoa : ContentPage
	{
		private readonly IncluirPessoaViewModel _viewModel;

		public TelaIncluirPessoa()
		{
			InitializeComponent();

			// Criar Service e ViewModel manualmente (sem DI container)
			var pessoaService = new PessoaService(App.Database);
			_viewModel = new IncluirPessoaViewModel(pessoaService);
			BindingContext = _viewModel;

			// Carregar último nome salvo (Preferences)
			_viewModel.CarregarUltimoNome();
		}
	}
