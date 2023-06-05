using Educa.Repository;
using Educa.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Educa.Controllers
{
    public class PaginasController : Controller
    {
        private readonly IUsuarioRepository _context;
        private readonly ICookieAuthService _cookieAuthService;
        private readonly IDatosRepository _repository;
        public PaginasController(IUsuarioRepository _context, ICookieAuthService _cookieAuthService, IDatosRepository _repository)
        {
            this._context = _context;
            this._cookieAuthService = _cookieAuthService;
            this._repository = _repository;
            _cookieAuthService.SetHttpContext(HttpContext);
        }
        public IActionResult Leccion1Pag1()
        {
            _cookieAuthService.SetHttpContext(HttpContext);
            return View();
        }
        public IActionResult Leccion1Pag2()
        {
            _cookieAuthService.SetHttpContext(HttpContext);
            var nombre = _cookieAuthService.LoggedUser().User;
            int id = _context.EncontrarIdUsuario(nombre);
            if (!_repository.PagCompleta("Leccion1Pag1", id)) { _repository.PagCompletado("Leccion1Pag1", id); }
            _repository.ActualizarPorcentajesLeccion(id,1);
            _repository.ActualizarSubtemaActual(id, 1);
            _repository.ActualizarTemaActual(id, 1);
            _repository.ActualizarCursoActual(id, 1);
            return View();
        }
        public IActionResult Leccion1Pag3()
        {
            _cookieAuthService.SetHttpContext(HttpContext);
            var nombre = _cookieAuthService.LoggedUser().User;
            int id = _context.EncontrarIdUsuario(nombre);
            if (!_repository.PagCompleta("Leccion1Pag2", id)) { _repository.PagCompletado("Leccion1Pag2", id); }
            _repository.ActualizarPorcentajesLeccion(id, 1);
            _repository.ActualizarSubtemaActual(id, 1);
            _repository.ActualizarTemaActual(id, 1);
            _repository.ActualizarCursoActual(id, 1);
            return View();
        }
        public IActionResult Leccion1Ej1()
        {
            _cookieAuthService.SetHttpContext(HttpContext);
            var nombre = _cookieAuthService.LoggedUser().User;
            int id = _context.EncontrarIdUsuario(nombre);
            if (!_repository.PagCompleta("Leccion1Pag3", id)) { _repository.PagCompletado("Leccion1Pag3", id); }
            _repository.ActualizarPorcentajesLeccion(id, 1);
            _repository.ActualizarSubtemaActual(id, 1);
            _repository.ActualizarTemaActual(id, 1);
            _repository.ActualizarCursoActual(id, 1);
            return View();
        }
        public IActionResult Leccion1Ej2(int puntos)
        {
            _cookieAuthService.SetHttpContext(HttpContext);
            var nombre = _cookieAuthService.LoggedUser().User;
            int id = _context.EncontrarIdUsuario(nombre);
            if (!_repository.EjCompleta("Leccion1Ej1", id)) { _repository.EjercicioCompletado("Leccion1Ej1", id, puntos); }
            _repository.ActualizarPorcentajesLeccion(id, 1);
            _repository.ActualizarSubtemaActual(id, 1);
            _repository.ActualizarTemaActual(id, 1);
            _repository.ActualizarCursoActual(id, 1);
            return View();
        }
        public IActionResult Leccion1Ej3(int puntos)
        {
            _cookieAuthService.SetHttpContext(HttpContext);
            var nombre = _cookieAuthService.LoggedUser().User;
            int id = _context.EncontrarIdUsuario(nombre);
            if (!_repository.EjCompleta("Leccion1Ej2", id)) { _repository.EjercicioCompletado("Leccion1Ej2", id, puntos); }
            _repository.ActualizarPorcentajesLeccion(id, 1);
            _repository.ActualizarSubtemaActual(id, 1);
            _repository.ActualizarTemaActual(id, 1);
            _repository.ActualizarCursoActual(id, 1);
            return View();
        }
        public IActionResult Leccion1Finish(int puntos)
        {
            _cookieAuthService.SetHttpContext(HttpContext);
            var nombre = _cookieAuthService.LoggedUser().User;
            int id = _context.EncontrarIdUsuario(nombre);
            if (!_repository.EjCompleta("Leccion1Ej3", id)) { _repository.EjercicioCompletado("Leccion1Ej3", id, puntos); }
            _repository.ActualizarLeccionTerminado(id, 1);
            _repository.ActualizarEstadoSiguienteLeccion(id, 2);
            _repository.ActualizarSubtemaActual(id, 1);
            _repository.ActualizarTemaActual(id, 1);
            _repository.ActualizarCursoActual(id, 1);
            return RedirectToAction("Lecciones", "Home", new { subtema = 1 });
        }
        public IActionResult Leccion2Pag1()
        {
            _cookieAuthService.SetHttpContext(HttpContext);
            return View();
        }
        public IActionResult Leccion2Pag2()
        {
            _cookieAuthService.SetHttpContext(HttpContext);
            var nombre = _cookieAuthService.LoggedUser().User;
            int id = _context.EncontrarIdUsuario(nombre);
            if (!_repository.PagCompleta("Leccion2Pag1", id)) { _repository.PagCompletado("Leccion2Pag1", id); }
            _repository.ActualizarPorcentajesLeccion(id, 2);
            _repository.ActualizarSubtemaActual(id, 1);
            _repository.ActualizarTemaActual(id, 1);
            _repository.ActualizarCursoActual(id, 1);
            return View();
        }
        public IActionResult Leccion2Ej1()
        {
            _cookieAuthService.SetHttpContext(HttpContext);
            var nombre = _cookieAuthService.LoggedUser().User;
            int id = _context.EncontrarIdUsuario(nombre);
            if (!_repository.PagCompleta("Leccion2Pag2", id)) { _repository.PagCompletado("Leccion2Pag2", id); }
            _repository.ActualizarPorcentajesLeccion(id, 2);
            _repository.ActualizarSubtemaActual(id, 1);
            _repository.ActualizarTemaActual(id, 1);
            _repository.ActualizarCursoActual(id, 1);
            return View();
        }
        public IActionResult Leccion2Finish(int puntos)
        {
            _cookieAuthService.SetHttpContext(HttpContext);
            var nombre = _cookieAuthService.LoggedUser().User;
            int id = _context.EncontrarIdUsuario(nombre);
            if (!_repository.EjCompleta("Leccion2Ej1", id)) { _repository.EjercicioCompletado("Leccion2Ej1", id, puntos); }
            _repository.ActualizarLeccionTerminado(id, 2);
            _repository.ActualizarEstadoSiguienteLeccion(id, 3);
            _repository.ActualizarSubtemaActual(id, 1);
            _repository.ActualizarTemaActual(id, 1);
            _repository.ActualizarCursoActual(id, 1);
            return RedirectToAction("Lecciones", "Home", new { subtema = 1 });
        }
        
        public IActionResult Leccion3Pag1()
        {
            _cookieAuthService.SetHttpContext(HttpContext);
            
            return View();
        }
        public IActionResult Leccion3Pag2()
        {
            _cookieAuthService.SetHttpContext(HttpContext);
            var nombre = _cookieAuthService.LoggedUser().User;
            int id = _context.EncontrarIdUsuario(nombre);
            if (!_repository.PagCompleta("Leccion3Pag1", id)) { _repository.PagCompletado("Leccion3Pag1", id); }
            _repository.ActualizarPorcentajesLeccion(id, 3);
            _repository.ActualizarSubtemaActual(id, 1);
            _repository.ActualizarTemaActual(id, 1);
            _repository.ActualizarCursoActual(id, 1);
            return View();
        }
        public IActionResult Leccion3Pag3()
        {
            _cookieAuthService.SetHttpContext(HttpContext);
            var nombre = _cookieAuthService.LoggedUser().User;
            int id = _context.EncontrarIdUsuario(nombre);
            if (!_repository.PagCompleta("Leccion3Pag2", id)) { _repository.PagCompletado("Leccion3Pag2", id); }
            _repository.ActualizarPorcentajesLeccion(id, 3);
            _repository.ActualizarSubtemaActual(id, 1);
            _repository.ActualizarTemaActual(id, 1);
            _repository.ActualizarCursoActual(id, 1);
            return View();
        }
        public IActionResult Leccion3Pag4()
        {
            _cookieAuthService.SetHttpContext(HttpContext);
            var nombre = _cookieAuthService.LoggedUser().User;
            int id = _context.EncontrarIdUsuario(nombre);
            if (!_repository.PagCompleta("Leccion3Pag3", id)) { _repository.PagCompletado("Leccion3Pag3", id); }
            _repository.ActualizarPorcentajesLeccion(id, 3);
            _repository.ActualizarSubtemaActual(id, 1);
            _repository.ActualizarTemaActual(id, 1);
            _repository.ActualizarCursoActual(id, 1);
            return View();
        }
        public IActionResult Leccion3Pag5()
        {
            _cookieAuthService.SetHttpContext(HttpContext);
            var nombre = _cookieAuthService.LoggedUser().User;
            int id = _context.EncontrarIdUsuario(nombre);
            if (!_repository.PagCompleta("Leccion3Pag4", id)) { _repository.PagCompletado("Leccion3Pag4", id); }
            _repository.ActualizarPorcentajesLeccion(id, 3);
            _repository.ActualizarSubtemaActual(id, 1);
            _repository.ActualizarTemaActual(id, 1);
            _repository.ActualizarCursoActual(id, 1);
            return View();
        }
        public IActionResult Leccion3Pag6()
        {
            _cookieAuthService.SetHttpContext(HttpContext);
            var nombre = _cookieAuthService.LoggedUser().User;
            int id = _context.EncontrarIdUsuario(nombre);
            if (!_repository.PagCompleta("Leccion3Pag5", id)) { _repository.PagCompletado("Leccion3Pag5", id); }
            _repository.ActualizarPorcentajesLeccion(id, 3);
            _repository.ActualizarSubtemaActual(id, 1);
            _repository.ActualizarTemaActual(id, 1);
            _repository.ActualizarCursoActual(id, 1);
            return View();
        }
        public IActionResult Leccion3Pag7()
        {
            _cookieAuthService.SetHttpContext(HttpContext);
            var nombre = _cookieAuthService.LoggedUser().User;
            int id = _context.EncontrarIdUsuario(nombre);
            if (!_repository.PagCompleta("Leccion3Pag6", id)) { _repository.PagCompletado("Leccion3Pag6", id); }
            _repository.ActualizarPorcentajesLeccion(id, 3);
            _repository.ActualizarSubtemaActual(id, 1);
            _repository.ActualizarTemaActual(id, 1);
            _repository.ActualizarCursoActual(id, 1);
            return View();
        }
        public IActionResult Leccion3Pag8()
        {
            _cookieAuthService.SetHttpContext(HttpContext);
            var nombre = _cookieAuthService.LoggedUser().User;
            int id = _context.EncontrarIdUsuario(nombre);
            if (!_repository.PagCompleta("Leccion3Pag7", id)) { _repository.PagCompletado("Leccion3Pag7", id); }
            _repository.ActualizarPorcentajesLeccion(id, 3);
            _repository.ActualizarSubtemaActual(id, 1);
            _repository.ActualizarTemaActual(id, 1);
            _repository.ActualizarCursoActual(id, 1);
            return View();
        }
        public IActionResult Leccion3Pag9()
        {
            _cookieAuthService.SetHttpContext(HttpContext);
            var nombre = _cookieAuthService.LoggedUser().User;
            int id = _context.EncontrarIdUsuario(nombre);
            if (!_repository.PagCompleta("Leccion3Pag8", id)) { _repository.PagCompletado("Leccion3Pag8", id); }
            _repository.ActualizarPorcentajesLeccion(id, 3);
            _repository.ActualizarSubtemaActual(id, 1);
            _repository.ActualizarTemaActual(id, 1);
            _repository.ActualizarCursoActual(id, 1);
            return View();
        }
        public IActionResult Leccion3Pag10()
        {
            _cookieAuthService.SetHttpContext(HttpContext);
            var nombre = _cookieAuthService.LoggedUser().User;
            int id = _context.EncontrarIdUsuario(nombre);
            if (!_repository.PagCompleta("Leccion3Pag9", id)) { _repository.PagCompletado("Leccion3Pag9", id); }
            _repository.ActualizarPorcentajesLeccion(id, 3);
            _repository.ActualizarSubtemaActual(id, 1);
            _repository.ActualizarTemaActual(id, 1);
            _repository.ActualizarCursoActual(id, 1);
            return View();
        }
        public IActionResult Leccion3Pag11()
        {
            _cookieAuthService.SetHttpContext(HttpContext);
            var nombre = _cookieAuthService.LoggedUser().User;
            int id = _context.EncontrarIdUsuario(nombre);
            if (!_repository.PagCompleta("Leccion3Pag10", id)) { _repository.PagCompletado("Leccion3Pag10", id); }
            _repository.ActualizarPorcentajesLeccion(id, 3);
            _repository.ActualizarSubtemaActual(id, 1);
            _repository.ActualizarTemaActual(id, 1);
            _repository.ActualizarCursoActual(id, 1);
            return View();
        }
        public IActionResult Leccion3Pag12()
        {
            _cookieAuthService.SetHttpContext(HttpContext);
            var nombre = _cookieAuthService.LoggedUser().User;
            int id = _context.EncontrarIdUsuario(nombre);
            if (!_repository.PagCompleta("Leccion3Pag11", id)) { _repository.PagCompletado("Leccion3Pag11", id); }
            _repository.ActualizarPorcentajesLeccion(id, 3);
            _repository.ActualizarSubtemaActual(id, 1);
            _repository.ActualizarTemaActual(id, 1);
            _repository.ActualizarCursoActual(id, 1);
            return View();
        }
        public IActionResult Leccion3Pag13()
        {
            _cookieAuthService.SetHttpContext(HttpContext);
            var nombre = _cookieAuthService.LoggedUser().User;
            int id = _context.EncontrarIdUsuario(nombre);
            if (!_repository.PagCompleta("Leccion3Pag12", id)) { _repository.PagCompletado("Leccion3Pag12", id); }
            _repository.ActualizarPorcentajesLeccion(id, 3);
            _repository.ActualizarSubtemaActual(id, 1);
            _repository.ActualizarTemaActual(id, 1);
            _repository.ActualizarCursoActual(id, 1);
            return View();
        }
        public IActionResult Leccion3Pag14()
        {
            _cookieAuthService.SetHttpContext(HttpContext);
            var nombre = _cookieAuthService.LoggedUser().User;
            int id = _context.EncontrarIdUsuario(nombre);
            if (!_repository.PagCompleta("Leccion3Pag13", id)) { _repository.PagCompletado("Leccion3Pag13", id); }
            _repository.ActualizarPorcentajesLeccion(id, 3);
            _repository.ActualizarSubtemaActual(id, 1);
            _repository.ActualizarTemaActual(id, 1);
            _repository.ActualizarCursoActual(id, 1);
            return View();
        }
        public IActionResult Leccion3Pag15()
        {
            _cookieAuthService.SetHttpContext(HttpContext);
            var nombre = _cookieAuthService.LoggedUser().User;
            int id = _context.EncontrarIdUsuario(nombre);
            if (!_repository.PagCompleta("Leccion3Pag14", id)) { _repository.PagCompletado("Leccion3Pag14", id); }
            _repository.ActualizarPorcentajesLeccion(id, 3);
            _repository.ActualizarSubtemaActual(id, 1);
            _repository.ActualizarTemaActual(id, 1);
            _repository.ActualizarCursoActual(id, 1);
            return View();
        }
        public IActionResult Leccion3Pag16()
        {
            _cookieAuthService.SetHttpContext(HttpContext);
            var nombre = _cookieAuthService.LoggedUser().User;
            int id = _context.EncontrarIdUsuario(nombre);
            if (!_repository.PagCompleta("Leccion3Pag15", id)) { _repository.PagCompletado("Leccion3Pag15", id); }
            _repository.ActualizarPorcentajesLeccion(id, 3);
            _repository.ActualizarSubtemaActual(id, 1);
            _repository.ActualizarTemaActual(id, 1);
            _repository.ActualizarCursoActual(id, 1);
            return View();
        }
        public IActionResult Leccion3Pag17()
        {
            _cookieAuthService.SetHttpContext(HttpContext);
            var nombre = _cookieAuthService.LoggedUser().User;
            int id = _context.EncontrarIdUsuario(nombre);
            if (!_repository.PagCompleta("Leccion3Pag16", id)) { _repository.PagCompletado("Leccion3Pag16", id); }
            _repository.ActualizarPorcentajesLeccion(id, 3);
            _repository.ActualizarSubtemaActual(id, 1);
            _repository.ActualizarTemaActual(id, 1);
            _repository.ActualizarCursoActual(id, 1);
            return View();
        }
        public IActionResult Leccion3Pag18()
        {
            _cookieAuthService.SetHttpContext(HttpContext);
            var nombre = _cookieAuthService.LoggedUser().User;
            int id = _context.EncontrarIdUsuario(nombre);
            if (!_repository.PagCompleta("Leccion3Pag17", id)) { _repository.PagCompletado("Leccion3Pag17", id); }
            _repository.ActualizarPorcentajesLeccion(id, 3);
            _repository.ActualizarSubtemaActual(id, 1);
            _repository.ActualizarTemaActual(id, 1);
            _repository.ActualizarCursoActual(id, 1);
            return View();
        }
        public IActionResult Leccion3Pag19()
        {
            _cookieAuthService.SetHttpContext(HttpContext);
            var nombre = _cookieAuthService.LoggedUser().User;
            int id = _context.EncontrarIdUsuario(nombre);
            if (!_repository.PagCompleta("Leccion3Pag18", id)) { _repository.PagCompletado("Leccion3Pag18", id); }
            _repository.ActualizarPorcentajesLeccion(id, 3);
            _repository.ActualizarSubtemaActual(id, 1);
            _repository.ActualizarTemaActual(id, 1);
            _repository.ActualizarCursoActual(id, 1);
            return View();
        }
        public IActionResult Leccion3Pag20()
        {
            _cookieAuthService.SetHttpContext(HttpContext);
            var nombre = _cookieAuthService.LoggedUser().User;
            int id = _context.EncontrarIdUsuario(nombre);
            if (!_repository.PagCompleta("Leccion3Pag19", id)) { _repository.PagCompletado("Leccion3Pag19", id); }
            _repository.ActualizarPorcentajesLeccion(id, 3);
            _repository.ActualizarSubtemaActual(id, 1);
            _repository.ActualizarTemaActual(id, 1);
            _repository.ActualizarCursoActual(id, 1);
            return View();
        }
        public IActionResult Leccion3Pag21()
        {
            _cookieAuthService.SetHttpContext(HttpContext);
            var nombre = _cookieAuthService.LoggedUser().User;
            int id = _context.EncontrarIdUsuario(nombre);
            if (!_repository.PagCompleta("Leccion3Pag20", id)) { _repository.PagCompletado("Leccion3Pag20", id); }
            _repository.ActualizarPorcentajesLeccion(id, 3);
            _repository.ActualizarSubtemaActual(id, 1);
            _repository.ActualizarTemaActual(id, 1);
            _repository.ActualizarCursoActual(id, 1);
            return View();
        }
        public IActionResult Leccion3Pag22()
        {
            _cookieAuthService.SetHttpContext(HttpContext);
            var nombre = _cookieAuthService.LoggedUser().User;
            int id = _context.EncontrarIdUsuario(nombre);
            if (!_repository.PagCompleta("Leccion3Pag21", id)) { _repository.PagCompletado("Leccion3Pag21", id); }
            _repository.ActualizarPorcentajesLeccion(id, 3);
            _repository.ActualizarSubtemaActual(id, 1);
            _repository.ActualizarTemaActual(id, 1);
            _repository.ActualizarCursoActual(id, 1);
            return View();
        }
        public IActionResult Leccion3Pag23()
        {
            _cookieAuthService.SetHttpContext(HttpContext);
            var nombre = _cookieAuthService.LoggedUser().User;
            int id = _context.EncontrarIdUsuario(nombre);
            if (!_repository.PagCompleta("Leccion3Pag22", id)) { _repository.PagCompletado("Leccion3Pag22", id); }
            _repository.ActualizarPorcentajesLeccion(id, 3);
            _repository.ActualizarSubtemaActual(id, 1);
            _repository.ActualizarTemaActual(id, 1);
            _repository.ActualizarCursoActual(id, 1);
            return View();
        }
        public IActionResult Leccion3Pag24()
        {
            _cookieAuthService.SetHttpContext(HttpContext);
            var nombre = _cookieAuthService.LoggedUser().User;
            int id = _context.EncontrarIdUsuario(nombre);
            if (!_repository.PagCompleta("Leccion3Pag23", id)) { _repository.PagCompletado("Leccion3Pag23", id); }
            _repository.ActualizarPorcentajesLeccion(id, 3);
            _repository.ActualizarSubtemaActual(id, 1);
            _repository.ActualizarTemaActual(id, 1);
            _repository.ActualizarCursoActual(id, 1);
            return View();
        }
        public IActionResult Leccion3Pag25()
        {
            _cookieAuthService.SetHttpContext(HttpContext);
            var nombre = _cookieAuthService.LoggedUser().User;
            int id = _context.EncontrarIdUsuario(nombre);
            if (!_repository.PagCompleta("Leccion3Pag24", id)) { _repository.PagCompletado("Leccion3Pag24", id); }
            _repository.ActualizarPorcentajesLeccion(id, 3);
            _repository.ActualizarSubtemaActual(id, 1);
            _repository.ActualizarTemaActual(id, 1);
            _repository.ActualizarCursoActual(id, 1);
            return View();
        }
        public IActionResult Leccion3Pag26()
        {
            _cookieAuthService.SetHttpContext(HttpContext);
            var nombre = _cookieAuthService.LoggedUser().User;
            int id = _context.EncontrarIdUsuario(nombre);
            if (!_repository.PagCompleta("Leccion3Pag25", id)) { _repository.PagCompletado("Leccion3Pag25", id); }
            _repository.ActualizarPorcentajesLeccion(id, 3);
            _repository.ActualizarSubtemaActual(id, 1);
            _repository.ActualizarTemaActual(id, 1);
            _repository.ActualizarCursoActual(id, 1);
            return View();
        }
        public IActionResult Leccion3Pag27()
        {
            _cookieAuthService.SetHttpContext(HttpContext);
            var nombre = _cookieAuthService.LoggedUser().User;
            int id = _context.EncontrarIdUsuario(nombre);
            if (!_repository.PagCompleta("Leccion3Pag26", id)) { _repository.PagCompletado("Leccion3Pag26", id); }
            _repository.ActualizarPorcentajesLeccion(id, 3);
            _repository.ActualizarSubtemaActual(id, 1);
            _repository.ActualizarTemaActual(id, 1);
            _repository.ActualizarCursoActual(id, 1);
            return View();
        }
        public IActionResult Leccion3Pag28()
        {
            _cookieAuthService.SetHttpContext(HttpContext);
            var nombre = _cookieAuthService.LoggedUser().User;
            int id = _context.EncontrarIdUsuario(nombre);
            if (!_repository.PagCompleta("Leccion3Pag27", id)) { _repository.PagCompletado("Leccion3Pag27", id); }
            _repository.ActualizarPorcentajesLeccion(id, 3);
            _repository.ActualizarSubtemaActual(id, 1);
            _repository.ActualizarTemaActual(id, 1);
            _repository.ActualizarCursoActual(id, 1);
            return View();
        }
        public IActionResult Leccion3Pag29()
        {
            _cookieAuthService.SetHttpContext(HttpContext);
            var nombre = _cookieAuthService.LoggedUser().User;
            int id = _context.EncontrarIdUsuario(nombre);
            if (!_repository.PagCompleta("Leccion3Pag28", id)) { _repository.PagCompletado("Leccion3Pag28", id); }
            _repository.ActualizarPorcentajesLeccion(id, 3);
            _repository.ActualizarSubtemaActual(id, 1);
            _repository.ActualizarTemaActual(id, 1);
            _repository.ActualizarCursoActual(id, 1);
            return View();
        }
        public IActionResult Leccion3Pag30()
        {
            _cookieAuthService.SetHttpContext(HttpContext);
            var nombre = _cookieAuthService.LoggedUser().User;
            int id = _context.EncontrarIdUsuario(nombre);
            if (!_repository.PagCompleta("Leccion3Pag29", id)) { _repository.PagCompletado("Leccion3Pag29", id); }
            _repository.ActualizarPorcentajesLeccion(id, 3);
            _repository.ActualizarSubtemaActual(id, 1);
            _repository.ActualizarTemaActual(id, 1);
            _repository.ActualizarCursoActual(id, 1);
            return View();
        }
        public IActionResult Leccion3Pag31()
        {
            _cookieAuthService.SetHttpContext(HttpContext);
            var nombre = _cookieAuthService.LoggedUser().User;
            int id = _context.EncontrarIdUsuario(nombre);
            if (!_repository.PagCompleta("Leccion3Pag30", id)) { _repository.PagCompletado("Leccion3Pag30", id); }
            _repository.ActualizarPorcentajesLeccion(id, 3);
            _repository.ActualizarSubtemaActual(id, 1);
            _repository.ActualizarTemaActual(id, 1);
            _repository.ActualizarCursoActual(id, 1);
            return View();
        }
        public IActionResult Leccion3Ej1()
        {
            _cookieAuthService.SetHttpContext(HttpContext);
            var nombre = _cookieAuthService.LoggedUser().User;
            int id = _context.EncontrarIdUsuario(nombre);
            if (!_repository.PagCompleta("Leccion3Pag31", id)) { _repository.PagCompletado("Leccion3Pag31", id); }
            _repository.ActualizarPorcentajesLeccion(id, 3);
            _repository.ActualizarSubtemaActual(id, 1);
            _repository.ActualizarTemaActual(id, 1);
            _repository.ActualizarCursoActual(id, 1);
            return View();
        }
        public IActionResult Leccion3Ej2(int puntos)
        {
            _cookieAuthService.SetHttpContext(HttpContext);
            var nombre = _cookieAuthService.LoggedUser().User;
            int id = _context.EncontrarIdUsuario(nombre);
            if (!_repository.EjCompleta("Leccion3Ej1", id)) { _repository.EjercicioCompletado("Leccion3Ej1", id, puntos); }
            _repository.ActualizarPorcentajesLeccion(id, 3);
            _repository.ActualizarSubtemaActual(id, 1);
            _repository.ActualizarTemaActual(id, 1);
            _repository.ActualizarCursoActual(id, 1);
            return View();
        }
        public IActionResult Leccion3Ej3(int puntos)
        {
            _cookieAuthService.SetHttpContext(HttpContext);
            var nombre = _cookieAuthService.LoggedUser().User;
            int id = _context.EncontrarIdUsuario(nombre);
            if (!_repository.EjCompleta("Leccion3Ej2", id)) { _repository.EjercicioCompletado("Leccion3Ej2", id, puntos); }
            _repository.ActualizarPorcentajesLeccion(id, 3);
            _repository.ActualizarSubtemaActual(id, 1);
            _repository.ActualizarTemaActual(id, 1);
            _repository.ActualizarCursoActual(id, 1);
            return View();
        }
        public IActionResult Leccion3Ej4(int puntos)
        {
            _cookieAuthService.SetHttpContext(HttpContext);
            var nombre = _cookieAuthService.LoggedUser().User;
            int id = _context.EncontrarIdUsuario(nombre);
            if (!_repository.EjCompleta("Leccion3Ej3", id)) { _repository.EjercicioCompletado("Leccion3Ej3", id, puntos); }
            _repository.ActualizarPorcentajesLeccion(id, 3);
            _repository.ActualizarSubtemaActual(id, 1);
            _repository.ActualizarTemaActual(id, 1);
            _repository.ActualizarCursoActual(id, 1);
            return View();
        }
        public IActionResult Leccion3Ej5(int puntos)
        {
            _cookieAuthService.SetHttpContext(HttpContext);
            var nombre = _cookieAuthService.LoggedUser().User;
            int id = _context.EncontrarIdUsuario(nombre);
            if (!_repository.EjCompleta("Leccion3Ej4", id)) { _repository.EjercicioCompletado("Leccion3Ej4", id, puntos); }
            _repository.ActualizarPorcentajesLeccion(id, 3);
            _repository.ActualizarSubtemaActual(id, 1);
            _repository.ActualizarTemaActual(id, 1);
            _repository.ActualizarCursoActual(id, 1);
            return View();
        }

        public IActionResult Leccion3Ej6(int puntos)
        {
            _cookieAuthService.SetHttpContext(HttpContext);
            var nombre = _cookieAuthService.LoggedUser().User;
            int id = _context.EncontrarIdUsuario(nombre);
            if (!_repository.EjCompleta("Leccion3Ej5", id)) { _repository.EjercicioCompletado("Leccion3Ej5", id, puntos); }
            _repository.ActualizarPorcentajesLeccion(id, 3);
            _repository.ActualizarSubtemaActual(id, 1);
            _repository.ActualizarTemaActual(id, 1);
            _repository.ActualizarCursoActual(id, 1);
            return View();
        }
        public IActionResult Leccion3Finish(int puntos)
        {
            _cookieAuthService.SetHttpContext(HttpContext);
            var nombre = _cookieAuthService.LoggedUser().User;
            int id = _context.EncontrarIdUsuario(nombre);
            if (!_repository.EjCompleta("Leccion3Ej6", id)) { _repository.EjercicioCompletado("Leccion3Ej6", id, puntos); }
            _repository.ActualizarLeccionTerminado(id, 3);
            _repository.ActualizarEstadoSubtemaActual(id, 1);
            _repository.ActualizarEstadosExamenesSubtemaActual(id, 1);
            _repository.ActualizarSubtemaActual(id, 1);
            _repository.ActualizarTemaActual(id, 1);
            _repository.ActualizarCursoActual(id, 1);
            return RedirectToAction("Lecciones", "Home", new { subtema = 1 });
        }
        public IActionResult Subtema1Exam1()
        {
            _cookieAuthService.SetHttpContext(HttpContext);
            return View();
        }
        public IActionResult Subtema1E1Finish(int puntos)
        {
            _cookieAuthService.SetHttpContext(HttpContext);
            var nombre = _cookieAuthService.LoggedUser().User;
            int id = _context.EncontrarIdUsuario(nombre);
            if (_repository.ExamCompleto(1, id)) { _repository.ActualizarNotaExam(1, id, puntos); }
            _repository.ActualizarSubtemaActual(id, 1);
            _repository.ActualizarTemaActual(id, 1);
            _repository.ActualizarCursoActual(id, 1);
            return RedirectToAction("Lecciones", "Home", new { subtema = 1 });
        }
        public IActionResult Subtema1Exam2()
        {
            _cookieAuthService.SetHttpContext(HttpContext);
            return View();
        }
        public IActionResult Subtema1E2Finish(int puntos)
        {
            _cookieAuthService.SetHttpContext(HttpContext);
            var nombre = _cookieAuthService.LoggedUser().User;
            int id = _context.EncontrarIdUsuario(nombre);
            if (_repository.ExamCompleto(2, id)) { _repository.ActualizarNotaExam(2, id, puntos); }
            _repository.ActualizarSubtemaTerminado(1, id);
            _repository.ActualizarEstadoSiguienteLeccion(id, 4);
            _repository.ActualizarEstadoSiguienteSubtema(id, 2);
            _repository.ActualizarTemaActual(id, 1);
            _repository.ActualizarCursoActual(id, 1);
            return RedirectToAction("Subtemas", "Home", new { tema = 1 });
        }

        public IActionResult Leccion4Pag1()
        {
            _cookieAuthService.SetHttpContext(HttpContext);
            
            return View();
        }
        public IActionResult Leccion4Pag2()
        {
            _cookieAuthService.SetHttpContext(HttpContext);
            var nombre = _cookieAuthService.LoggedUser().User;
            int id = _context.EncontrarIdUsuario(nombre);
            if (!_repository.PagCompleta("Leccion4Pag1", id)) { _repository.PagCompletado("Leccion4Pag1", id); }
            _repository.ActualizarPorcentajesLeccion(id, 4);
            _repository.ActualizarSubtemaActual(id, 2);
            _repository.ActualizarTemaActual(id, 1);
            _repository.ActualizarCursoActual(id, 1);
            return View();
        }
        public IActionResult Leccion4Pag3()
        {
            _cookieAuthService.SetHttpContext(HttpContext);
            var nombre = _cookieAuthService.LoggedUser().User;
            int id = _context.EncontrarIdUsuario(nombre);
            if (!_repository.PagCompleta("Leccion5Pag2", id)) { _repository.PagCompletado("Leccion4Pag2", id); }
            _repository.ActualizarPorcentajesLeccion(id, 4);
            _repository.ActualizarSubtemaActual(id, 2);
            _repository.ActualizarTemaActual(id, 1);
            _repository.ActualizarCursoActual(id, 1);
            return View();
        }
        public IActionResult Leccion4Ej1(int puntos)
        {
            _cookieAuthService.SetHttpContext(HttpContext);
            var nombre = _cookieAuthService.LoggedUser().User;
            int id = _context.EncontrarIdUsuario(nombre);
            if (!_repository.PagCompleta("Leccion4Pag3", id)) { _repository.PagCompletado("Leccion4Pag3", id); }
            _repository.ActualizarPorcentajesLeccion(id, 4);
            _repository.ActualizarSubtemaActual(id, 2);
            _repository.ActualizarTemaActual(id, 1);
            _repository.ActualizarCursoActual(id, 1);
            return View();
        }
        public IActionResult Leccion4Ej2(int puntos)
        {
            _cookieAuthService.SetHttpContext(HttpContext);
            var nombre = _cookieAuthService.LoggedUser().User;
            int id = _context.EncontrarIdUsuario(nombre);
            if (!_repository.EjCompleta("Leccion4Ej1", id)) { _repository.EjercicioCompletado("Leccion4Ej1", id, puntos); }
            _repository.ActualizarPorcentajesLeccion(id, 4);
            _repository.ActualizarSubtemaActual(id, 2);
            _repository.ActualizarTemaActual(id, 1);
            _repository.ActualizarCursoActual(id, 1);
            return View();
        }
        public IActionResult Leccion4Finish(int puntos)
        {
            _cookieAuthService.SetHttpContext(HttpContext);
            var nombre = _cookieAuthService.LoggedUser().User;
            int id = _context.EncontrarIdUsuario(nombre);
            if (!_repository.EjCompleta("Leccion4Ej2", id)) { _repository.EjercicioCompletado("Leccion1Ej2", id, puntos); }
            _repository.ActualizarLeccionTerminado(id, 4);
            _repository.ActualizarEstadoSiguienteLeccion(id, 5);
            _repository.ActualizarSubtemaActual(id, 2);
            _repository.ActualizarTemaActual(id, 1);
            _repository.ActualizarCursoActual(id, 1);
            return RedirectToAction("Lecciones", "Home", new { subtema = 2 });
        }
        public IActionResult Leccion5Pag1()
        {
            _cookieAuthService.SetHttpContext(HttpContext);

            return View();
        }
        public IActionResult Leccion5Pag2()
        {
            _cookieAuthService.SetHttpContext(HttpContext);
            var nombre = _cookieAuthService.LoggedUser().User;
            int id = _context.EncontrarIdUsuario(nombre);
            if (!_repository.PagCompleta("Leccion5Pag1", id)) { _repository.PagCompletado("Leccion5Pag1", id); }
            _repository.ActualizarPorcentajesLeccion(id, 5);
            _repository.ActualizarSubtemaActual(id, 2);
            _repository.ActualizarTemaActual(id, 1);
            _repository.ActualizarCursoActual(id, 1);
            return View();
        }
        public IActionResult Leccion5Ej1(int puntos)
        {
            _cookieAuthService.SetHttpContext(HttpContext);
            var nombre = _cookieAuthService.LoggedUser().User;
            int id = _context.EncontrarIdUsuario(nombre);
            if (!_repository.PagCompleta("Leccion5Pag2", id)) { _repository.PagCompletado("Leccion5Pag2", id); }
            _repository.ActualizarPorcentajesLeccion(id, 5);
            _repository.ActualizarSubtemaActual(id, 2);
            _repository.ActualizarTemaActual(id, 1);
            _repository.ActualizarCursoActual(id, 1);
            return View();
        }
        public IActionResult Leccion5Ej2(int puntos)
        {
            _cookieAuthService.SetHttpContext(HttpContext);
            var nombre = _cookieAuthService.LoggedUser().User;
            int id = _context.EncontrarIdUsuario(nombre);
            if (!_repository.EjCompleta("Leccion5Ej1", id)) { _repository.EjercicioCompletado("Leccion5Ej1", id, puntos); }
            _repository.ActualizarPorcentajesLeccion(id, 5);
            _repository.ActualizarSubtemaActual(id, 2);
            _repository.ActualizarTemaActual(id, 1);
            _repository.ActualizarCursoActual(id, 1);
            return View();
        }
        public IActionResult Leccion5Finish(int puntos)
        {
            _cookieAuthService.SetHttpContext(HttpContext);
            var nombre = _cookieAuthService.LoggedUser().User;
            int id = _context.EncontrarIdUsuario(nombre);
            if (!_repository.EjCompleta("Leccion5Ej2", id)) { _repository.EjercicioCompletado("Leccion5Ej2", id, puntos); }
            _repository.ActualizarLeccionTerminado(id, 5);
            _repository.ActualizarEstadoSubtemaActual(id, 2);
            _repository.ActualizarEstadosExamenesSubtemaActual(id, 2);
            _repository.ActualizarSubtemaActual(id, 2);
            _repository.ActualizarTemaActual(id, 1);
            _repository.ActualizarCursoActual(id, 1);
            return RedirectToAction("Lecciones", "Home", new { subtema = 2 });
        }
        public IActionResult Subtema2Exam1()
        {
            _cookieAuthService.SetHttpContext(HttpContext);
            return View();
        }
        public IActionResult Subtema2E1Finish(int puntos)
        {
            _cookieAuthService.SetHttpContext(HttpContext);
            var nombre = _cookieAuthService.LoggedUser().User;
            int id = _context.EncontrarIdUsuario(nombre);
            if (_repository.ExamCompleto(3, id)) { _repository.ActualizarNotaExam(3, id, puntos); }
            _repository.ActualizarSubtemaTerminado(2, id);
            _repository.ActualizarEstadoSiguienteLeccion(id, 6);
            _repository.ActualizarEstadoSiguienteSubtema(id, 4);
            _repository.ActualizarTemaActual(id, 1);
            _repository.ActualizarCursoActual(id, 1);
            return RedirectToAction("Subtemas", "Home", new { tema = 1 });
        }
        public IActionResult Leccion6Pag1()
        {
            _cookieAuthService.SetHttpContext(HttpContext);

            return View();
        }
        public IActionResult Leccion6Ej1(int puntos)
        {
            _cookieAuthService.SetHttpContext(HttpContext);
            var nombre = _cookieAuthService.LoggedUser().User;
            int id = _context.EncontrarIdUsuario(nombre);
            if (!_repository.PagCompleta("Leccion6Pag1", id)) { _repository.PagCompletado("Leccion6Pag1", id); }
            _repository.ActualizarPorcentajesLeccion(id, 6);
            _repository.ActualizarSubtemaActual(id, 4);
            _repository.ActualizarTemaActual(id, 1);
            _repository.ActualizarCursoActual(id, 1);
            return View();
        }
        public IActionResult Leccion6Finish(int puntos)
        {
            _cookieAuthService.SetHttpContext(HttpContext);
            return RedirectToAction("Lecciones", "Home", new { subtema = 4 });
        }
    }
}
