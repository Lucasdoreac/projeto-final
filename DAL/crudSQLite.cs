using appClassePessoaBD.Model;
using SQLite;

namespace appClassePessoaBD.DAL
{
    public class crudSQLite
    {
        readonly SQLiteAsyncConnection _conexao;

        public crudSQLite(string path)
        {
            _conexao = new SQLiteAsyncConnection(path);
            _conexao.CreateTableAsync<Pessoa>().Wait();
        }

        public Task<int> Insert(Pessoa pessoa1)
        {
            return _conexao.InsertAsync(pessoa1);
        }

        public Task<List<Pessoa>> Update(Pessoa pessoa1)
        {
            string sql = "UPDATE Pessoa SET pesNome=?, pesIdade=? WHERE pesID=? ";
            return _conexao.QueryAsync<Pessoa>(sql, pessoa1.pesNome, pessoa1.pesIdade, pessoa1.pesID);
        }

        public Task<List<Pessoa>> GetAll()
        {
            return _conexao.Table<Pessoa>().ToListAsync();
        }

        public Task<int> Delete(int idPes)
        {
            return _conexao.Table<Pessoa>().DeleteAsync(i => i.pesID == idPes);
        }

        public Task<List<Pessoa>> Search(string buscaPesssoa)
        {
            string sql = "SELECT * FROM Pessoa WHERE pesNome LIKE '%" + buscaPesssoa + "%' ";
            return _conexao.QueryAsync<Pessoa>(sql);
        }
    }
}
