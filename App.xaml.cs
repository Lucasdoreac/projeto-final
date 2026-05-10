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
        // Igual ao appUsandoEntry que funciona - página direta
        return new Window(new Views.TelaListaPessoa());
    }
}
