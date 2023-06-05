using Educa.Repository;
using Educa.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Educa.Controllers
{
    public class HistoriaController : Controller
    {
        private readonly IUsuarioRepository _context;
        private readonly ICookieAuthService _cookieAuthService;
        private readonly IDatosRepository _repository;
        public HistoriaController(IUsuarioRepository _context, ICookieAuthService _cookieAuthService, IDatosRepository _repository)
        {
            this._context = _context;
            this._cookieAuthService = _cookieAuthService;
            this._repository = _repository;
            _cookieAuthService.SetHttpContext(HttpContext);
        }
        public IActionResult HistoriaIndex()
        {
            _cookieAuthService.SetHttpContext(HttpContext);
            var nombre = _cookieAuthService.LoggedUser().User;
            ViewBag.Libros = _repository.LibrosU(nombre);
            ViewBag.Avatar = _context.AvatarUsuario(nombre);
            return View();
        }
        public IActionResult PreHistoria(string libro)
        {
            _cookieAuthService.SetHttpContext(HttpContext);
            ViewBag.Libro = libro;
            return View();
        }
        public IActionResult Tomas()
        {
            _cookieAuthService.SetHttpContext(HttpContext);
            return View();
        }
        public IActionResult ElPollitoAventurero()
        {
            _cookieAuthService.SetHttpContext(HttpContext);
            return View();
        }
    }
}
