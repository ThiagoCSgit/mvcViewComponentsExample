using Microsoft.AspNetCore.Mvc;
using WebApplication2.Data;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class TesteEFController : Controller
    {
        public AppDbContext Db { get; set; }

        //assim que eu conecto a minha controller ao dbContext
        public TesteEFController(AppDbContext db)
        {
            Db = db;
        }

        public IActionResult Index()
        {
            var aluno = new Aluno()
            {
                Nome = "thiago",
                Email = "teste",
                EmailConfirmacao = "teste.com",
                DataNascimento = new DateTime(2001, 04, 05),
                Avaliacao = 5,
                Ativo = true
            };
            Db.Alunos.Add(aluno);
            Db.SaveChanges();

            var alunoChange = Db.Alunos.FirstOrDefault(a => a.Nome.Contains("thiago"));
            alunoChange.Nome = "Thiago Santos";
            
            Db.Alunos.Update(alunoChange);
            Db.SaveChanges();

            Db.Alunos.Remove(alunoChange);
            Db.SaveChanges();
            return View();
        }
    }
}