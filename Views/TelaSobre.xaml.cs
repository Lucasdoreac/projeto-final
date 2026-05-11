namespace appClassePessoaBD.Views
{
    public partial class TelaSobre : ContentPage
    {
        public TelaSobre()
        {
            InitializeComponent();

            // Carregar repositório GitHub no WebView
            webViewGitHub.Source = "https://github.com/ludoc-dev/dotnet-maui";
        }
    }
}
