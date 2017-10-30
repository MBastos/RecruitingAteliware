using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RecruitingAteliware.Forms;
using RecruitingAteliware.Models;

namespace RecruitingAteliware.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ExecutarConsultas();
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

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
        public JsonResult Salvar2(FormularioDeLinguagens formularioDeLinguagens)
        {
            //ExecutarConsultas();
            return Json(new
            {
                responseText = "Dados Cadastrados com sucesso " + formularioDeLinguagens.Linguagem
            });
        }
        

        [HttpPost]
        public JsonResult Salvar(string linguagem, [FromBody]object[] repositorios)
        {
            //ExecutarConsultas();
            return Json(new
            {
                responseText = "Dados Cadastrados com sucesso " + linguagem
            });
        }
    }
}
