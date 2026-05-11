using appClassePessoaBD.Model;
using appClassePessoaBD.ViewModels;
using appClassePessoaBD.Services;

namespace appClassePessoaBD.Views;

	public partial class TelaAlterarPessoa : ContentPage
	{
		private readonly AlterarPessoaViewModel _viewModel;

		public TelaAlterarPessoa(Pessoa pessoa)
		{
			InitializeComponent();

			// Criar Service e ViewModel manualmente (sem DI container)
			var pessoaService = new PessoaService(App.Database);
			_viewModel = new AlterarPessoaViewModel(pessoaService);

			// Definir a pessoa a ser alterada
			_viewModel.DefinirPessoa(pessoa);
			BindingContext = _viewModel;
		}
	}
