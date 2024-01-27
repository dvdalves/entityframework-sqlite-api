namespace CrudAPI_Sqlite.Models
{
    public class Pessoa
    {
        public int Id { get; set; }
        public required string Nome { get; set; }
        public DateTime DataCadastro { get; set; } = DateTime.Now;
        public bool Ativo { get; set; }
    }
}
