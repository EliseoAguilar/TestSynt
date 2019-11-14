using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TestSyntCli.Models
{
    public class AppModel
    {
        [Required(ErrorMessage = "El {0} es requerido.")]
        [Display(Name = "Código")]
        public string Id { get; set; }


        [Required(ErrorMessage = "El {0} es requerido.")]
        [Display(Name = "Nombre")]
        public string Name { get; set; }

        [Required(ErrorMessage = "La {0} es requerida.")]
        [Display(Name = "URL")]
        public string URL { get; set; }
    }
}
