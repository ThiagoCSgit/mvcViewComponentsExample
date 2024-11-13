using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class ModelsController : Controller
    {
        public IActionResult Index()
        {
            var aluno = new Aluno()
            {
                Nome = "a",
                Email = "teste",
                EmailConfirmacao = "teste.com"
            };
            if (TryValidateModel(aluno))
            {
                return View(aluno);
            }
            var ms = ModelState;

            var erros = ModelState.Select(x => x.Value?.Errors).Where(y => y?.Count > 0).ToList();

            erros.ForEach(r => Console.WriteLine(r?.First().ErrorMessage));
            
            return View("ErrorViewModel");
        }
    }
}
