using Microsoft.AspNetCore.Mvc;
using WebAppEmprestimos.Dto;

namespace WebAppEmprestimos.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Registrar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Registrar(UsuarioRegisterDto usuarioRegisterDto)
        {
            return View(usuarioRegisterDto);
        }
    }
}
