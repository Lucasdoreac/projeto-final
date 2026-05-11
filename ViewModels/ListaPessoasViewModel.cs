using System.Collections.ObjectModel;
using System.Windows.Input;
using appClassePessoaBD.Model;
using appClassePessoaBD.Services;

namespace appClassePessoaBD.ViewModels
{
    public class ListaPessoasViewModel : BaseViewModel
    {
        private readonly IPessoaService _pessoaService;
        private string _textoBusca;

        public ObservableCollection<Pessoa> Pessoas { get; set; }

        public string TextoBusca
        {
            get => _textoBusca;
            set
            {
                if (SetProperty(ref _textoBusca, value))
                {
                    _ = BuscarAsync();
                }
            }
        }

        public ICommand CarregarPessoasCommand { get; }
        public ICommand IncluirCommand { get; }
        public ICommand ExcluirCommand { get; }
        public ICommand BuscarCommand { get; }
        public ICommand RefreshCommand { get; }
        public ICommand SelecionarCommand { get; }

        public ListaPessoasViewModel(IPessoaService pessoaService)
        {
            _pessoaService = pessoaService;
            Pessoas = new ObservableCollection<Pessoa>();
            _textoBusca = string.Empty;

            CarregarPessoasCommand = new Command(async () => await CarregarPessoasAsync());
            IncluirCommand = new Command(async () => await IncluirAsync());
            ExcluirCommand = new Command<Pessoa>(async (p) => await ExcluirAsync(p));
            BuscarCommand = new Command(async () => await BuscarAsync());
            RefreshCommand = new Command(async () => await RefreshAsync());
            SelecionarCommand = new Command<Pessoa>(async (p) => await SelecionarAsync(p));
        }

        public async Task CarregarPessoasAsync()
        {
            if (IsBusy)
                return;

            try
            {
                IsBusy = true;
                Pessoas.Clear();

                var pessoas = await _pessoaService.GetAll();
                foreach (var pessoa in pessoas)
                {
                    Pessoas.Add(pessoa);
                }
            }
            finally
            {
                IsBusy = false;
            }
        }

        private async Task IncluirAsync()
        {
            // Será implementado via navegação
            await Task.CompletedTask;
        }

        private async Task ExcluirAsync(Pessoa pessoa)
        {
            // Será implementado via navegação
            await Task.CompletedTask;
        }

        private async Task BuscarAsync()
        {
            if (IsBusy)
                return;

            try
            {
                IsBusy = true;
                Pessoas.Clear();

                var pessoas = await _pessoaService.Search(_textoBusca);
                foreach (var pessoa in pessoas)
                {
                    Pessoas.Add(pessoa);
                }
            }
            finally
            {
                IsBusy = false;
            }
        }

        private async Task RefreshAsync()
        {
            await CarregarPessoasAsync();
        }

        private async Task SelecionarAsync(Pessoa pessoa)
        {
            // Será implementado via navegação
            await Task.CompletedTask;
        }
    }
}
