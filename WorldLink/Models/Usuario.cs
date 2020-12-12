using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WorldLink.Models
{
    [Table("Tb_Usuario")]
    public class Usuario
    {
        [Column("Id")]
        public int UsuarioId { get; set; }

        [Required(ErrorMessage = "Informe o nome de usuário para fazer login")]
        [Display(Name ="Usuário")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Informe a senha para fazer o login!")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }

    }
}
