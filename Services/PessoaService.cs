using appClassePessoaBD.Model;
using appClassePessoaBD.DAL;
using System.Text;

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

        public async Task<string> ExportToCsvAsync()
        {
            var pessoas = await GetAll();

            var csv = new StringBuilder();
            csv.AppendLine("ID,Nome,Idade");

            foreach (var pessoa in pessoas)
            {
                csv.AppendLine($"{pessoa.pesID},{pessoa.pesNome},{pessoa.pesIdade}");
            }

            return csv.ToString();
        }
    }
}
