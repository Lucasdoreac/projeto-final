using appClassePessoaBD.Views;

namespace appClassePessoaBD.Views
{
    public partial class FlyoutMenuPage : ContentPage
    {
        // Evento para notificar quando um item do menu for selecionado
        public event EventHandler<Page>? MenuSelected;

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

        private void OnMenuItemTapped(object? sender, ItemTappedEventArgs e)
        {
            try
            {
                if (e.Item is MenuItem menuItem)
                {
                    // Criar instância da página selecionada
                    var pageInstance = Activator.CreateInstance(menuItem.PageType);
                    if (pageInstance is Page page)
                    {
                        // Disparar evento com a página selecionada
                        MenuSelected?.Invoke(this, page);

                        // Deselecionar item
                        menuListView.SelectedItem = null;
                    }
                    else
                    {
                        System.Diagnostics.Debug.WriteLine($"Failed to create page: {menuItem.PageType.Name}");
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error in OnMenuItemTapped: {ex.Message}");
                // Não propagar exceção para não crashar o app
            }
        }

        // Classe para representar itens do menu
        public class MenuItem
        {
            public string Icon { get; set; } = string.Empty;
            public string Title { get; set; } = string.Empty;
            public Type PageType { get; set; } = null!;
        }
    }
}
