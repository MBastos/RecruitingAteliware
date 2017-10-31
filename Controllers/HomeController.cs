using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RecruitingAteliware.Context;
using RecruitingAteliware.Forms;
using RecruitingAteliware.Models;
using Microsoft.Extensions.DependencyInjection;

namespace RecruitingAteliware.Controllers
{
    public class HomeController : Controller
    {
        private readonly AteliwareContext _ateliwareContext;        

        public HomeController(AteliwareContext ateliwareContext)
        {
            _ateliwareContext = ateliwareContext;
        }

        public IActionResult Index()
        {   
            ExecutarConsultas();
            return View();
        }
        
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private void ExecutarConsultas()
        {
            ViewBag.Linguagens = new SelectListItem[]
           {
               new SelectListItem
               {
                   Text = "C#",
                   Value="csharp"                   
               },
               new SelectListItem
               {
                   Text = "Java",
                   Value="java"                   
               },
               new SelectListItem
               {
                   Text = "C",
                   Value="c"                   
               },
               new SelectListItem
               {
                   Text = "PHP",
                   Value="php"                   
               },
               new SelectListItem
               {
                   Text = "Python",
                   Value="python"                   
               },
           };
        }

        [HttpPost]
        public JsonResult Salvar(string linguagem, Item[] repositorios)
        {   
            SalvarRepositorios(linguagem, repositorios);
            return Json(new
            {
                responseText = "Dados Cadastrados com sucesso!"
            });
        }

        private void SalvarRepositorios(string linguagem, Item[] repositorios)
        {
            int i=1;
            foreach(Item item in repositorios){
                var repositorio = new Repositorio
                {                    
                    RepositorioId = item.id,
                    Ordem = i,
                    Linguagem = linguagem,
                    Nome = item.name,
                    Descricao = item.description,
                    Proprietario = item.Owner.login,
                    DataCriacao = item.created_at,
                    DataAtualizacao = item.updated_at
                };
                _ateliwareContext.Repositorios.Add(repositorio);
                i++;
            }
            _ateliwareContext.SaveChanges();
        }
    }
}
