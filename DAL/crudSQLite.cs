/*
 * Arquivo Model para criação da Tabela e Transporte de Dados
 */
using appClassePessoaBD.Model;

/*
 * Classes da Biblioteca do SQLite para acesso aos dados e criação da estrutura da tabela.
 */
using SQLite;

namespace appClassePessoaBD.DAL
{
    /*
     * Definição da classe crudSQLite que funciona como uma abstração de acesso ao arquivo db3 do SQLite.
     * A classe contém as informações de "conexão" e os métodos para realizar o CRUD (Create, Read, Update e Delete).
     * Observe que na classe todos os métodos são Async, isso significa que todos são executados via Threads
     * o que, em teoria, não trava a interface do app enquanto os dados são lidos/gravados no arquivo db3.
     */
    public class crudSQLite
    {
        /*
         * Campo da classe que armazena a "conexão" com o arquivo db3.
         * Isso significa que o arquivo db3 é aberto e armazenado aqui para que
         * essa classe possa usar os métodos da classe do SQLite para gravar
         * e ler dados das pessoas cadastradas.
         */
        readonly SQLiteAsyncConnection _conexao;
        bool _initialized = false;

        /*
         * Método construtor da classe que recebe um parâmetro chamado path para
         * "conectar" ao arquivo db3.
         */
        public crudSQLite(string path)
        {
            /*
             * Abrindo uma nova "conexão" com o arquivo db3 através do caminho recebido.
             * note a utilização da biblioteca SQLite "instalada" no projeto via pacote Nuget
             */
            _conexao = new SQLiteAsyncConnection(path);

            /*
             * NOTA: Lazy initialization para evitar deadlock na UI thread no Windows.
             * A tabela será criada na primeira chamada de qualquer método CRUD.
             */
        }

        private async Task InitializeAsync()
        {
            if (!_initialized)
            {
                await _conexao.CreateTableAsync<Pessoa>();
                _initialized = true;
            }
        }

        /*
         * Método que faz a inserção de um novo registro na tabela. Veja que o método recebe uma Model
         * preenchida com os dados a serem inseridos. Observem que o método tem um retorno do tipo int
         * (número de linhas inseridas) sendo executado via Task (tarefa sendo executada de forma assíncrona).
         */
        public Task<int> Insert(Pessoa pessoa1)
        {
            return _conexao.InsertAsync(pessoa1);
        }

        /*
         * Método implementado com uso da estratégia de escrever o código SQL. Neste método podemos
         * ver a abstração que o SQLite faz, onde podemos digitar código SQL para manipulação do
         * arquivo db3. O método também recebe uma model preenchida para atualizar no db3 e o retorno
         * em forma de Task é uma lista de todos os registros atualizados.
         */
        public Task<List<Pessoa>> Update(Pessoa pessoa1)
        {
            string sql = "UPDATE Pessoa SET pesNome=?, pesIdade=? WHERE pesID=? ";
            return _conexao.QueryAsync<Pessoa>(sql, pessoa1.pesNome, pessoa1.pesIdade, pessoa1.pesID);
        }

        /*
         * Método que faz o retorno de todas as linhas contidas no arquivo db3 referentes
         * a tabela Pessoa. Veja que o método executa a listagem de forma assíncrona.
         */
        public Task<List<Pessoa>> GetAll()
        {
            return _conexao.Table<Pessoa>().ToListAsync();
        }

        /*
         * Método que remove um registro do arquivo db3 de forma assíncrona. Este método recebe
         * como parâmetro o campo pesID do registro a ser removido. Observe o uso da LINQ no processo de
         * remoção.
         */
        public Task<int> Delete(int idPes)
        {
            return _conexao.Table<Pessoa>().DeleteAsync(i => i.pesID == idPes);
        }

        /*
         * Método para realizar uma busca na tabela com base em uma string. O método recebe um
         * parâmetro do tipo string e por meio do SQL faz uma busca em um determinado campo
         * É retornada uma Lista de Pessoas por meio de uma Task. A execução do SQL segue a mesma
         * linha utilizada no método update.
         */
        public Task<List<Pessoa>> Search(string buscaPesssoa)
        {
            string sql = "SELECT * FROM Pessoa WHERE pesNome LIKE '%" + buscaPesssoa + "%' ";
            return _conexao.QueryAsync<Pessoa>(sql);
        }
    }
}
