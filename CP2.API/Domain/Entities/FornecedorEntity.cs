using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CP2.API.Domain.Entities
{
    [Table("tb_fornecedor")]
    public class FornecedorEntity
    {
        [Key]
        public int id { get; set; }
        public string nome { get; set; } = string.Empty;
        [Required]
        public string cnpj { get; set; } = string.Empty;
        public string endereco { get; set; } = string.Empty;
        [Required]
        public string telefone { get; set; } = string.Empty;
        [Required]
        public string email { get; set; } = string.Empty;
        public DateTime criadoEm { get; set; }
    }
}
