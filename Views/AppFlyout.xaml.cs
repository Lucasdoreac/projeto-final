using appClassePessoaBD.Views;

namespace appClassePessoaBD.Views
{
    public partial class AppFlyout : FlyoutPage
    {
        public AppFlyout()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            // Conectar o menu com a navegação
            flyoutMenu.MenuSelected += (sender, page) =>
            {
                Detail = new NavigationPage(page);
                IsPresented = false; // Fechar menu após seleção
            };
        }
    }
}
