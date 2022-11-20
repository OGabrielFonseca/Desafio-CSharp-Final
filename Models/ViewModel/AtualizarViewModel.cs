using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Projeto.Models.ViewModel
{
    public class AtualizarViewModel
    {
        public Venda Venda{get;set;}
        public int IdVenda{get;set;}
        public List<SelectListItem> StatusSelectedList {get; set;}
    }
}