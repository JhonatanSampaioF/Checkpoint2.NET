using System.ComponentModel.DataAnnotations;

namespace CP2.API.Application.Dtos
{
    public class FornecedorDto
    {
        public string nome { get; set; }
        [Required]
        public string cnpj { get; set; }
        public string endereco { get; set; }
        [Required]
        public string telefone { get; set; }
        [Required]
        public string email { get; set; }
        public DateTime criadoEm { get; set; }
    }
}
