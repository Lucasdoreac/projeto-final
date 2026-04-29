using SQLite;

namespace appClassePessoaBD.Model
{
    [Table("Pessoa")]
    public class Pessoa
    {
        [PrimaryKey, AutoIncrement, Unique, NotNull]
        public int pesID { get; set; }

        [MaxLength(1000)]
        public string? pesNome { get; set; }

        [MaxLength(3)]
        public int pesIdade { get; set; }
    }
}
