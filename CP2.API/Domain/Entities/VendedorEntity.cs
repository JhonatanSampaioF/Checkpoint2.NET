using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CP2.API.Domain.Entities
{
    [Table("tb_vendedor")]
    public class VendedorEntity
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string nome { get; set; } = string.Empty;
        [Required]
        public string email { get; set; } = string.Empty;
        [Required]
        public string telefone { get; set; } = string.Empty;
        public DateTime dataNascimento { get; set; }
        public string endereco { get; set; } = string.Empty;
        public DateTime dataContratacao { get; set; }
        public decimal comissaoPercentual { get; set; }
        public decimal metaMensal { get; set; }
        public DateTime criadoEm { get; set; }
    }
}
