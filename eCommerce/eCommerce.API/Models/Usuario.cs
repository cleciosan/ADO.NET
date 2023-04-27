using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerce.API.Models
{
    public class Usuario
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(70)]
        public string Nome { get; set; }

        [Required]
        [MaxLength(100)]
        public string Email { get; set; }

        [MaxLength(1)]
        public string Sexo { get; set; }

        [MaxLength(15)]
        public string RG { get; set; }

        [MaxLength(14)]
        public string CPF { get; set; }

        [MaxLength(70)]
        public string NomeMae { get; set; }

        [Required]
        [MaxLength(1)]
        public string SituacaoCadastro { get; set; }

        [Required]
        public DateTimeOffset DataCadastro { get; set; }



        public Contato Contato { get; set; }

        public ICollection<EnderecoEntrega> EnderecosEntrega { get; set; }

        public ICollection<Departamento> Departamentos { get; set; }



    }
}
