using appClassePessoaBD.Views;

namespace appClassePessoaBD.Views
{
    public partial class FlyoutMenuPage : ContentPage
    {
        // Evento para notificar quando um item do menu for selecionado
        public event EventHandler<Page> MenuSelected;

        public FlyoutMenuPage()
        {
            InitializeComponent();

            // Configurar itens do menu
            var menuItems = new List<MenuItem>
            {
                new MenuItem { Icon = "👥", Title = "Lista de Pessoas", PageType = typeof(TelaListaPessoa) },
                new MenuItem { Icon = "⚙️", Title = "Configurações", PageType = typeof(TelaConfiguracoes) },
                new MenuItem { Icon = "📊", Title = "Estatísticas", PageType = typeof(TelaEstatisticas) },
                new MenuItem { Icon = "ℹ️", Title = "Sobre", PageType = typeof(TelaSobre) }
            };

            menuListView.ItemsSource = menuItems;
            menuListView.ItemTapped += OnMenuItemTapped;
        }

        private void OnMenuItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item is MenuItem menuItem)
            {
                // Criar instância da página selecionada
                var page = (Page)Activator.CreateInstance(menuItem.PageType);

                // Disparar evento com a página selecionada
                MenuSelected?.Invoke(this, page);

                // Deselecionar item
                menuListView.SelectedItem = null;
            }
        }

        // Classe para representar itens do menu
        private class MenuItem
        {
            public string Icon { get; set; } = string.Empty;
            public string Title { get; set; } = string.Empty;
            public Type PageType { get; set; } = null!;
        }
    }
}
