using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projeto.Models
{
    public class Vendedor
    {   
        [Display(Name = "Id do Vendedor")]
        public int Id {get; set;}
        [Required]
        [StringLength(50)]
        [Display(Name = "Nome do Vendedor")]
        public string Nome {get;set;}
        [Display(Name = "CPF")]
        public string CPF {get;set;}
        [Display(Name = "Telefone")]
        public string Telefone {get;set;}
        [Display(Name = "Email")]
        public string Email {get;set;}

    }
}