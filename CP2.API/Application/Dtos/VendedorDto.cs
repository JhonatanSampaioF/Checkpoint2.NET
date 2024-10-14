using System.ComponentModel.DataAnnotations;

namespace CP2.API.Application.Dtos
{
    public class VendedorDto
    {
        [Required]
        public string nome { get; set; }
        [Required]
        public string email { get; set; }
        [Required]
        public string telefone { get; set; }
        public DateTime dataNascimento { get; set; }
        public string endereco { get; set; }
        public DateTime dataContratacao { get; set; }
        public decimal comissaoPercentual { get; set; }
        public decimal metaMensal { get; set; }
        public DateTime criadoEm { get; set; }
    }
}
