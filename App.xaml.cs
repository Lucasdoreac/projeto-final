using appClassePessoaBD.DAL;
using appClassePessoaBD.Views;
using System.Diagnostics;

namespace appClassePessoaBD
{
    public partial class App : Application
    {
        /*
         * Campo estático que contém a instância da classe que abstrai os métodos de gerenciamento
         * do SQLite.
         */
        static crudSQLite? database;

        /*
         * Propriedade que define a forma de acesso a instância de crudSQLite. A propriedade
         * é somente leitura, isto é, não é possível atribuir um valor a este campo. No momento que
         * o campo é chamado uma instância de crudSQLite é criada (implementação get).
         */
        public static crudSQLite Database
        {
            get
            {
                /*
                 * Se o campo database for nulo, significa que ainda não foi atribuída uma instância de
                 * crudSQLite a ele, então uma nova instância será criada e esta mesma será usada
                 * em todo tempo de execução do arquivo.
                 */
                if (database == null)
                {
                    /*
                     * Para criar uma instância de crudSQLite devemos dizer qual o caminho do arquivo db3
                     * (arquivo que contém as definições "DDL" e os dados propriamente ditos) no SQLite).
                     * Devemos notar que essa abstração é necessária pois estamos em uma ferramenta
                     * multiplataforma e isso significa que há um caminho diferente no Windows, Android
                     * e iOS e com o uso das classes do System.IO podemos abstrair esse caminho.
                     */
                    string path = Path.Combine(
                        Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                        "pessoas.db3"
                    );

                    /*
                     * Criando uma instância de crudSQLite como caminho até o arquivo db3 mencionado acima.
                     */
                    database = new crudSQLite(path);
                }
                return database;
            }
        }

        public App()
        {
            InitializeComponent();

            /* Habilitando o recurso de navegação entre páginas com FlyoutPage (Menu Lateral).
             * A página inicial é TelaListaPessoa, mas o usuário pode navegar usando o menu lateral.*/

            MainPage = new AppFlyout();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            Window window = base.CreateWindow(activationState);

            return window;
        }
    }
}
