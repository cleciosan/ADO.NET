using System.ComponentModel.DataAnnotations;

namespace eCommerce.API.Models
{
    public class EnderecoEntrega
    {
        public int Id { get; set; }

        public int UsuarioId { get; set; }

        [Required]
        [MaxLength(100)]
        public string NomeEndereco { get; set; }

        [Required]
        [MaxLength(10)]
        public string CEP { get; set; }

        [Required]
        [MaxLength(2)]
        public string Estado { get; set; }

        [Required]
        [MaxLength(200)]
        public string Cidade { get; set; }

        [Required]
        [MaxLength(200)]
        public string Bairro { get; set; }

        [Required]
        [MaxLength(200)]
        public string Endereco { get; set; }

        [MaxLength(20)]
        public string Numero { get; set; }

        [MaxLength(30)]
        public string Complemento { get; set; }



        public Usuario Usuario { get; set; }
    }
}
