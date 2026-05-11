using appClassePessoaBD.Model;
using appClassePessoaBD.DAL;

namespace appClassePessoaBD.Services
{
    public class PessoaService : IPessoaService
    {
        private readonly crudSQLite _database;

        public PessoaService(crudSQLite database)
        {
            _database = database;
        }

        public Task<int> Insert(Pessoa pessoa)
        {
            return _database.Insert(pessoa);
        }

        public Task<List<Pessoa>> GetAll()
        {
            return _database.GetAll();
        }

        public Task<List<Pessoa>> Update(Pessoa pessoa)
        {
            return _database.Update(pessoa);
        }

        public Task<int> Delete(int id)
        {
            return _database.Delete(id);
        }

        public Task<List<Pessoa>> Search(string nome)
        {
            return _database.Search(nome);
        }
    }
}
