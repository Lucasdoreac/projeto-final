using appClassePessoaBD.Views;

namespace appClassePessoaBD.Views
{
    public partial class AppFlyout : FlyoutPage
    {
        private bool _eventRegistered = false;

        public AppFlyout()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            // Conectar o menu com a navegação (apenas uma vez)
            if (!_eventRegistered)
            {
                flyoutMenu.MenuSelected += OnMenuSelected;
                _eventRegistered = true;
            }
        }

        private void OnMenuSelected(object? sender, Page page)
        {
            try
            {
                Detail = new NavigationPage(page);
                IsPresented = false; // Fechar menu após seleção
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error navigating to page: {ex.Message}");
            }
        }
    }
}
