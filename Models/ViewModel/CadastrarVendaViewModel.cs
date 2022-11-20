using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Projeto.Models.ViewModel
{
    public class CadastrarVendaViewModel
    {   
        public Venda Venda{get;set;}
        public List<SelectListItem> StatusSelectedList {get; set;}
        public List<SelectListItem> VendedorSelectedList {get; set;}

    }
}