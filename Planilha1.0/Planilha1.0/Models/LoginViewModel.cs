using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Planilha1._0.Models
{
    public class LoginViewModel
    {

        [Required(ErrorMessage = "Informe o usuário")]
        [Display(Name="Usuário ")]
        public string Usuario { get; set; }

        [Required(ErrorMessage = "Informe a senha")]
        [Display(Name="Senha ")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }

        [Display(Name = "Lembre Me")]
        public bool LembrarMe { get; set; }
    }
}