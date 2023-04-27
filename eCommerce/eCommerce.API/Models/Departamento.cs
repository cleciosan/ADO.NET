using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace eCommerce.API.Models
{
    public class Departamento
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Nome { get; set; }


        public ICollection<Usuario> Usuarios { get; set; }
    }
}
