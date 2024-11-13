using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;

namespace WebApplication2.ViewComponents
{
    public class SaudacaoAlunoViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(int idade)
        {
            var aluno = new Aluno() { Nome = "Thiago"};
            return View(aluno);
        }
    }
}
