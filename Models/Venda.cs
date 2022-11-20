using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projeto.Models
{
    public class Venda
    {   
        
        public int Id {get; set;}

        [Display(Name = "Id do Vendedor")]
        public string IdVendedor {get; set;}

        
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]  
        [DataType(DataType.Date, ErrorMessage="Data em formato inválido")]
        public DateTime DataVenda {get;set;}

        [Required]
        [Display(Name = "Produtos")]
        public List<Produto> Produtos {get;set;}

        [Display(Name = "Status da Venda")]
        public string Status {get;set;}

    }
    
}