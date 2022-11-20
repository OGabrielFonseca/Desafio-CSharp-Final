using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Projeto.Models;
using Projeto.Context;
using Projeto.Models.ViewModel;
using Microsoft.EntityFrameworkCore;
using System.Dynamic;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;

namespace Projeto.Controllers
{

    public class VendaController : Controller
    {
        public readonly VendaContext _context;

        public VendaController (VendaContext context)
        {   
            _context = context;
        }

        public IActionResult Index()
        {   
            var vendas = _context.Vendas.ToList();
            var model = new List<DisplayViewModel>();
            foreach (var venda in vendas)
            {
                var dataVenda = new DisplayViewModel();
                dataVenda.Venda = venda;
                dataVenda.Vendedor = _context.Vendedores.Find(Int32.Parse(venda.IdVendedor)); 
                model.Add(dataVenda);
            }

            return View(model);
        }
        public IActionResult DetalhesDaVenda(int id)
        {   var venda = new Venda();
            venda.Produtos = new List<Produto>();
            var model = new DisplayViewModel();
            
            venda = _context.Vendas.Find(id);
            venda.Produtos = _context.Produtos
                    .Where(b => b.VendaId == id).ToList();
            
            model.Venda = venda;
            model.Vendedor = _context.Vendedores.Find(Int32.Parse(venda.IdVendedor));
            return View(model);
        }

         public IActionResult CadastrarVendedor()
        {   
            return View();
        }

        public IActionResult CadastrarVenda()
        {   
            var statusData = StatusVenda.GetAll();
            var model = new CadastrarVendaViewModel();
            model.StatusSelectedList = new List<SelectListItem>();

            foreach (var s in statusData)
            {
                model.StatusSelectedList.Add(new SelectListItem { Text = s, Value = s});
            }

            var vendedoresData = _context.Vendedores.ToList();
            model.VendedorSelectedList = new List<SelectListItem>();

            foreach (var v in vendedoresData)
            {
                model.VendedorSelectedList.Add(new SelectListItem { Text = v.Nome, Value = v.Id.ToString()});
            }

            return View(model);
        }

        public IActionResult AtualizarVenda(int id)
        {   
            var vendaBanco = _context.Vendas.Find(id);

            if(vendaBanco == null){
                return RedirectToAction(nameof(Index)); 
            }

            var model = new AtualizarViewModel();

            model.Venda = vendaBanco;

            model.StatusSelectedList = new List<SelectListItem>();

            var statusData = StatusVenda.GetEditStatus(model.Venda.Status);

            foreach (var s in statusData)
            {
                model.StatusSelectedList.Add(new SelectListItem { Text = s, Value = s});
            }

            model.IdVenda = vendaBanco.Id;
            return View(model);
        }



        [HttpPost]
        public IActionResult AtualizarVenda(int id, string status)
        {   
            
            var vendaBanco = new Venda();
            vendaBanco = _context.Vendas.Find(id);
            if(vendaBanco == null){
                return RedirectToAction(nameof(CadastrarVendedor)); 
            }
        
            vendaBanco.Status = status;
            _context.Vendas.Update(vendaBanco);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index)); 
        }



        [HttpPost]
        public IActionResult CadastrarVendedor(Vendedor vendedor)
        {   
            _context.Vendedores.Add(vendedor);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index)); 
        }


        [HttpPost]
        public IActionResult CadastrarVenda(CadastrarVendaViewModel vendaCadastrada)
        {   
            foreach (var produto in vendaCadastrada.Venda.Produtos)
            {
                produto.VendaId = vendaCadastrada.Venda.Id;
            }
            _context.Vendas.Add(vendaCadastrada.Venda);
            _context.SaveChanges();
            
            return RedirectToAction(nameof(Index)); 

        }

        
        
    }
}