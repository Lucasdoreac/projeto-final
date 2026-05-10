using Microsoft.Extensions.Logging;
using appClassePessoaBD.DAL;

namespace appClassePessoaBD;

public partial class App : Application
{
    static crudSQLite? database;

    public static crudSQLite Database
    {
        get
        {
            if (database == null)
            {
                string path = Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                    "pessoas.db3"
                );
                database = new crudSQLite(path);
            }
            return database;
        }
    }

    public App()
    {
        InitializeComponent();
    }

    protected override Window CreateWindow(IActivationState? activationState)
    {
        // .NET MAUI 10.0 com VS 18 (2025) exige CreateWindow
        var navigationPage = new NavigationPage(new Views.TelaListaPessoa());
        return new Window(navigationPage);
    }
}
