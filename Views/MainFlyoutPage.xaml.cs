using appClassePessoaBD.Views;

namespace appClassePessoaBD.Views;

public partial class MainFlyoutPage : FlyoutPage
{
    public MainFlyoutPage() => InitializeComponent();

    private void OnIrParaLista(object sender, EventArgs e) 
    { 
        Detail = new NavigationPage(new TelaListaPessoa()); 
        IsPresented = false; 
    }

    private void OnIrParaConfig(object sender, EventArgs e) 
    { 
        Detail = new NavigationPage(new TelaConfiguracoes()); 
        IsPresented = false; 
    }

    private void OnIrParaSobre(object sender, EventArgs e) 
    { 
        Detail = new NavigationPage(new TelaSobre()); 
        IsPresented = false; 
    }
}
