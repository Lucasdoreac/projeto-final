using appClassePessoaBD.Model;

namespace appClassePessoaBD.Services
{
    public interface IPessoaService
    {
        Task<int> Insert(Pessoa pessoa);
        Task<List<Pessoa>> GetAll();
        Task<List<Pessoa>> Update(Pessoa pessoa);
        Task<int> Delete(int id);
        Task<List<Pessoa>> Search(string nome);
    }
}
