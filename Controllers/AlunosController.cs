using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Data;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class AlunosController : Controller
    {
        private readonly AppDbContext Db;

        public AlunosController(AppDbContext db)
        {
            Db = db;
        }

        public async Task<IActionResult> Index()
        {
            //return View(await Db.Alunos.ToListAsync());
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        //Usando o Bind() eu poss especificar quais campos a minha controller vai receber, ao invés de pegar todos que são enviados
        public async Task<IActionResult> Create([Bind("Id,Nome, DataNascimento,Email,EmailConfirmacao,Avaliacao,Ativo")]Aluno aluno)
        {
            if (ModelState.IsValid)
            {
                Db.Alunos.Add(aluno);
                await Db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(aluno);
        }

        public async Task<IActionResult> Details(int id)
        {
            var aluno = await Db.Alunos.FirstOrDefaultAsync(x => x.Id == id);
            return View(aluno);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var aluno = await Db.Alunos.FindAsync(id);
            return View(aluno);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        //Usando o Bind() eu poss especificar quais campos a minha controller vai receber, ao invés de pegar todos que são enviados
        public async Task<IActionResult> Edit(int id, [Bind("Id, Nome, DataNascimento, Email, Avaliacao, Ativo")] Aluno aluno)
        {
            if(id != aluno.Id)
            {
                return NotFound();
            }
            //assim o campo EmailConfirmacao não será mais considerado para o ModelState.IsValid
            ModelState.Remove("EmailConfirmacao");
            if (ModelState.IsValid)
            {
                Db.Alunos.Update(aluno);
                await Db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(aluno);
        }
    }
}
