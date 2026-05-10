using appClassePessoaBD.Model;
using SQLite;

namespace appClassePessoaBD.DAL
{
    public class crudSQLite
    {
        readonly SQLiteAsyncConnection _conexao;
        bool _initialized = false;

        public crudSQLite(string path)
        {
            _conexao = new SQLiteAsyncConnection(path);
            // REMOVIDO: .Wait() causava deadlock na UI thread
            // A tabela será criada de forma lazy (assíncrona) no primeiro uso
        }

        private async Task InitializeAsync()
        {
            if (!_initialized)
            {
                await _conexao.CreateTableAsync<Pessoa>();
                _initialized = true;
            }
        }

        public async Task<int> Insert(Pessoa pessoa1)
        {
            await InitializeAsync();
            return await _conexao.InsertAsync(pessoa1);
        }

        public async Task<List<Pessoa>> Update(Pessoa pessoa1)
        {
            await InitializeAsync();
            string sql = "UPDATE Pessoa SET pesNome=?, pesIdade=? WHERE pesID=? ";
            return await _conexao.QueryAsync<Pessoa>(sql, pessoa1.pesNome, pessoa1.pesIdade, pessoa1.pesID);
        }

        public async Task<List<Pessoa>> GetAll()
        {
            await InitializeAsync();
            return await _conexao.Table<Pessoa>().ToListAsync();
        }

        public async Task<int> Delete(int idPes)
        {
            await InitializeAsync();
            return await _conexao.Table<Pessoa>().DeleteAsync(i => i.pesID == idPes);
        }

        public async Task<List<Pessoa>> Search(string buscaPesssoa)
        {
            await InitializeAsync();
            string sql = "SELECT * FROM Pessoa WHERE pesNome LIKE '%" + buscaPesssoa + "%' ";
            return await _conexao.QueryAsync<Pessoa>(sql);
        }
    }
}
