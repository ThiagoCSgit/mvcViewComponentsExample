using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace WebApplication2.Controllers
{
    [Route("minha-conta", Order = 1)]
    [Route("gestao-minha-conta", Order = 0)] // Order = 0 indica que essa rota tem a preferencia, porém as duas funcionam
    public class TesteController : Controller
    {
        [Route("inicio")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("inicio/{id}/param/{id2?}")] //eu posso passar um parametro que não está especificado na rota, só preciso colocar o nome dele na query string
        //também posso passar parametro não especificados na Action, porém eles serão ignorados, mas a tela não quebra.
        public IActionResult Details(int id, string teste, int id2=1)
        {
            return View(id);
        }
    }
}
