using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WorldLink.Models
{
    [Table("Tb_Contato")]
    public class Contato
    {
        [Column("Id")]
        public int ContatoId { get; set; }

        [Required(ErrorMessage = "O nome é necessário!")]
        [Display(Name = "Insira seu nome:")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O email é necessário!")]
        [EmailAddress(ErrorMessage = "Insira um e-mail válido!")]
        [Display(Name = "Insira seu E-mail:")]
        public string Email { get; set; }

    }
}
