using Educa.BD;
using Educa.Models;
using Microsoft.EntityFrameworkCore;
namespace Educa.Repository
{
    public interface IDatosRepository
    {
        public void RegistrarPrimerCuestionario(string a, string b, string c, string d, string e, string f, string nombre);
        public void RegistroTablasUsuario(string user);
        public void RegistroTablasPruebas(string user);
        public string NombrePaginaLeccion(int IdLeccion, int user);
        public void PagCompletado(string LinkPag, int user);
        public bool PagCompleta(string LinkPag, int user);
        public bool ExamCompleto(int IdPrueba, int user);
        public void EjercicioCompletado(string LinkEj, int user, int puntos);
        public bool EjCompleta(string LinkEJ, int user);
        public void ActualizarNotaExam(int IdPrueba, int user, int puntos);
        public void ActualizarPorcentajesLeccion(int user, int IdLeccion);
        public void ActualizarLeccionTerminado(int user, int IdLeccion);
        public void ActualizarEstadoSiguienteLeccion(int user, int IdLeccion);
        public void ActualizarEstadoSiguienteSubtema(int user, int IdSubtema);
        public void ActualizarEstadoSubtemaActual(int user, int IdSubtema);
        public void ActualizarEstadosExamenesSubtemaActual(int user, int IdSubtema);
        public void ActualizarSubtemaTerminado(int IdSubtema, int user);
        public void ActualizarTodosPorcentajeSubtema(int user);
        public void ActualizarTodosPorcentajeTema(int user);
        public void ActualizarTodosPorcentajeCurso(int user);
        public void ActualizarCursoActual(int user, int IdCurso);
        public void ActualizarTemaActual(int user, int IdTema);
        public void ActualizarSubtemaActual(int user, int IdSubtema);
        public string ObtenerNombreCurso(int id);
        public string ObtenerNombreTema(int id);
        public string ObtenerNombreSubtema(int id);
        public string ObtenerNombreLeccion(int id);
        public int NumeroCursos();
        public int NumeroTemas(int id);
        public int NumeroSubtemas(int id);
        public int NumeroLecciones(int id);
        public int NumeroCursosEnProgreso(string user);
        public int NumeroTemasEnProgreso(string user, int id);
        public int NumerosubtemasEnProgreso(string user, int id);
        public int NumeroLeccionesEnProgreso(string user, int id);
        List<UsuarioCurso> CursosU(string user);
        List<UsuarioTema> TodosTemasU(string user);
        List<UsuarioTema> TemasU(string user, int id);
        List<UsuarioSubtema> SubtemasU(string user, int id);
        List<UsuarioSubtema> TodosSubtemasU(string user);
        List<UsuarioLeccion> LeccionesU(string user, int id);
        List<UsuarioLeccion> TodosLeccionesU(string user);
        List<UsuarioLibro> LibrosU(string user);
        List<UsuarioSubtemaPregunta> PruebasSubtemaU(string user, int idSubtema);

    }
    public class DatosRepository : IDatosRepository
    {
        private EducaContext _context;
        private IUsuarioRepository _usuario;
        public DatosRepository(EducaContext context, IUsuarioRepository _usuario)
        {
            _context = context;
            this._usuario = _usuario;
        }
        public void RegistrarPrimerCuestionario(string a, string b, string c, string d, string e, string f, string nombre)
        {
            int Id = _usuario.EncontrarIdUsuario(nombre);
            List<string> Respuestas = new List<string>() {
                a, b, c,d,e,f};
            var preguntas = _context._cuestionarioPregunta.Where(o => o.IdCuestionario == 1).ToList();
            for (int i = 0; i < 6; i++)
            {
                UsuarioCuPregunta user = new UsuarioCuPregunta();
                user.IdCuestionarioPregunta = preguntas[i].Id;
                user.IdUsuario = Id;
                user.Respuesta = Respuestas[i];
                _context._usuarioCuPregunta.Add(user);
                _context.SaveChanges();
            }
        }
        public void RegistroTablasUsuario(string user)
        {
            int Id = _usuario.EncontrarIdUsuario(user);
            var cursos = _context._curso.ToList();
            var temas = _context._tema.ToList();
            var subtemas = _context._subtema.ToList();
            var lecciones = _context._leccion.ToList();
            var pagLecciones = _context._pagLeccion.ToList();//
            var ejercicios = _context._ejercicio.ToList();
            var libros = _context._libro.ToList();
            DateTime fecha = DateTime.Now;
            //string FechaFormateada = fecha.ToString("MMMM", new System.Globalization.CultureInfo("es-ES")) + " " + fecha.ToString("dd", new System.Globalization.CultureInfo("es-ES")) + ", " + fecha.ToString("yyyy", new System.Globalization.CultureInfo("es-ES"));
            //FechaFormateada = char.ToUpper(FechaFormateada[0]) + FechaFormateada.Substring(1);
            for (int i = 0; i < cursos.Count; i++)
            {
                UsuarioCurso curso = new UsuarioCurso();
                curso.IdCurso = cursos[i].Id;
                curso.IdUsuario = Id;
                if (i == 0)
                {
                    curso.EstadoCurso = "Habilitado";
                }
                else
                {
                    curso.EstadoCurso = "Inhabilitado";
                }
                curso.NotaPrueba = 0;
                curso.PorcentajeAvance = 0;
                curso.UltFechaModif = fecha;
                _context._usuarioCurso.Add(curso);
                _context.SaveChanges();
            }
            for (int i = 0; i < temas.Count; i++)
            {
                UsuarioTema tema = new UsuarioTema();
                tema.IdUsuario = Id;
                tema.IdTema = temas[i].Id;
                if (i == 0)
                {
                    tema.EstadoTema = "Habilitado";
                }
                else
                {
                    tema.EstadoTema = "Inhabilitado";
                }
                tema.NotaPrueba = 0;
                tema.PuntosTema = 0;
                tema.PorcentajeAvance = 0;
                tema.UltFechaModif = fecha;
                _context._usuarioTema.Add(tema);
                _context.SaveChanges();
            }
            for (int i = 0; i < subtemas.Count; i++)
            {
                UsuarioSubtema subtema = new UsuarioSubtema();
                subtema.IdUsuario = Id;
                subtema.IdSubtema = subtemas[i].Id;
                if (i == 0)
                {
                    subtema.EstadoSubtema = "Habilitado";
                }
                else
                {
                    subtema.EstadoSubtema = "Inhabilitado";
                }
                subtema.NotaPrueba = 0;
                subtema.PuntosSubtema = 0;
                subtema.PorcentajeAvance = 0;
                subtema.UltFechaModif = fecha;
                _context._usuarioSubtema.Add(subtema);
                _context.SaveChanges();
            }
            for (int i = 0; i < lecciones.Count; i++)
            {
                UsuarioLeccion leccion = new UsuarioLeccion();
                leccion.IdUsuario = Id;
                leccion.IdLeccion = lecciones[i].Id;
                if (i == 0)
                {
                    leccion.EstadoLeccion = "Habilitado";
                }
                else
                {
                    leccion.EstadoLeccion = "Inhabilitado";
                }
                leccion.NotaLeccion = 0;
                leccion.PuntosLeccion = 0;
                leccion.PorcentajeAvance = 0;
                leccion.UltFechaModif = fecha;
                _context._usuarioLeccion.Add(leccion);
                _context.SaveChanges();
            }
            for (int i = 0; i < pagLecciones.Count; i++)
            {
                UsuarioLeccionPag usuarioLeccionPag = new UsuarioLeccionPag();
                usuarioLeccionPag.IdUsuario = Id;
                usuarioLeccionPag.IdPagLeccion = pagLecciones[i].Id;
                usuarioLeccionPag.Estado = "Incompleto";
                _context._usuarioLeccionPag.Add(usuarioLeccionPag);
                _context.SaveChanges();
            }
            for (int i = 0; i < ejercicios.Count; i++)
            {
                UsuarioEjercicio ejercicio = new UsuarioEjercicio();
                ejercicio.IdUsuario = Id;
                ejercicio.IdEjercicio = ejercicios[i].Id;
                ejercicio.EstadoUsuarioEjercicio = "Incompleto";
                ejercicio.NotaUsuarioEjercicio = 0;
                _context._usuarioEjercicio.Add(ejercicio);
                _context.SaveChanges();
            }
            for (int i = 0; i < libros.Count; i++)
            {
                UsuarioLibro usuarioLibro = new UsuarioLibro();
                usuarioLibro.IdUsuario = Id;
                usuarioLibro.IdLibro = libros[i].Id;
                usuarioLibro.EstadoUsuarioLibro = "Incompleto";
                _context._usuarioLibro.Add(usuarioLibro);
                _context.SaveChanges();
            }
        }
        public void RegistroTablasPruebas(string user)
        {
            int Id = _usuario.EncontrarIdUsuario(user);
            var userSubtema = _context._usuarioSubtema.Where(o => o.IdUsuario == Id).ToList();
            var userLibro = _context._usuarioLibro.Where(o => o.IdUsuario == Id).ToList();
            for (int i = 0; i < userSubtema.Count; i++)
            {
                var pruebas = _context._prueba.Where(o => o.IdSubtema == userSubtema[i].IdSubtema && o.Tipo == 1).ToList();
                for (var j = 0; j < pruebas.Count; j++)
                {
                    UsuarioSubtemaPregunta usuarioPrueba = new UsuarioSubtemaPregunta();
                    usuarioPrueba.IdUsuarioSubtema = userSubtema[i].Id;
                    usuarioPrueba.IdPrueba = pruebas[j].Id;
                    usuarioPrueba.Estado = "Inhabilitado";
                    usuarioPrueba.Nota = 0;
                    _context._usuarioSubtemaPregunta.Add(usuarioPrueba);
                    _context.SaveChanges();
                }
            }
            for (int i = 0; i < userLibro.Count; i++)
            {
                var pruebas = _context._prueba.Where(o => o.IdSubtema == userLibro[i].IdLibro && o.Tipo == 2).ToList();
                for (var j = 0; j < pruebas.Count; j++)
                {
                    UsuarioLibroPregunta usuarioLibro = new UsuarioLibroPregunta();
                    usuarioLibro.IdUsuarioLibro = userLibro[i].Id;
                    usuarioLibro.IdPrueba = pruebas[j].Id;
                    _context._usuarioLibroPregunta.Add(usuarioLibro);
                    _context.SaveChanges();
                }
            }

        }
        public string NombrePaginaLeccion(int IdLeccion, int user)
        {
            var nombre = "";
            var PagLecciones = _context._usuarioLeccionPag.Where(o => o.IdUsuario == user && o.PagLecciones.IdLeccion == IdLeccion && o.Estado == "Incompleto").ToList();
            if (PagLecciones.Count == 0)
            {
                var Ejercicios = _context._usuarioEjercicio.Where(o => o.IdUsuario == user && o.Ejercicios.IdLeccion == IdLeccion && o.EstadoUsuarioEjercicio == "Incompleto").ToList();
                if (Ejercicios.Count == 0)
                {
                    return "Completado";
                }
                else
                {
                    var ej = _context._usuarioEjercicio.Where(o => o.IdUsuario == user && o.Ejercicios.IdLeccion == IdLeccion && o.EstadoUsuarioEjercicio == "Incompleto").FirstOrDefault();
                    int Ejercicio = ej.IdEjercicio;
                    var ejer = _context._ejercicio.Where(z => z.Id == Ejercicio).FirstOrDefault();
                    nombre = ejer.LinkEjercicio.ToString();
                    return nombre;
                }

            }
            else
            {
                var pag = _context._usuarioLeccionPag.Where(o => o.IdUsuario == user && o.PagLecciones.IdLeccion == IdLeccion && o.Estado == "Incompleto").FirstOrDefault();
                int pagLecioon = pag.IdPagLeccion;
                var leccion = _context._pagLeccion.Where(z => z.Id == pagLecioon).FirstOrDefault();
                nombre = leccion.LinkPagLeccion.ToString();
                return nombre;
            }
            return nombre;
        }
        public bool PagCompleta(string LinkPag, int user)
        {
            var PagLeccion = _context._pagLeccion.FirstOrDefault(o => o.LinkPagLeccion == LinkPag);
            int IdPagLeccion = PagLeccion.Id;
            var PagLeccionUsuario = _context._usuarioLeccionPag.FirstOrDefault(z => z.IdUsuario == user && z.IdPagLeccion == IdPagLeccion);
            if (PagLeccionUsuario.Estado == "Completo")
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        public void PagCompletado(string LinkPag, int user)
        {
            var PagLeccion = _context._pagLeccion.FirstOrDefault(o => o.LinkPagLeccion == LinkPag);
            int IdPagLeccion = PagLeccion.Id;
            var PagLeccionUsuario = _context._usuarioLeccionPag.FirstOrDefault(z => z.IdUsuario == user && z.IdPagLeccion == IdPagLeccion);
            PagLeccionUsuario.Estado = "Completo";
            _context._usuarioLeccionPag.Update(PagLeccionUsuario);
            _context.SaveChanges();
        }
        public bool EjCompleta(string LinkEJ, int user)
        {
            var EjLeccion = _context._ejercicio.FirstOrDefault(o => o.LinkEjercicio == LinkEJ);
            int IdPagEjercicio = EjLeccion.Id;
            var EjLeccionUsuario = _context._usuarioEjercicio.FirstOrDefault(z => z.IdUsuario == user && z.IdEjercicio == IdPagEjercicio);
            if (EjLeccionUsuario.EstadoUsuarioEjercicio == "Completo")
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        public bool ExamCompleto(int IdPrueba, int user)
        {
            var exam = _context._usuarioSubtemaPregunta.FirstOrDefault(z => z.UsuarioSubtemas.IdUsuario == user && z.IdPrueba == IdPrueba);
            if (exam.Estado == "Habilitado")
            {
                return true;
            }else if (exam.Estado == "Terminado")
            {
                return false;
            }
            else
            {
                return false;
            }

        }
       
        public void ActualizarNotaExam(int IdPrueba, int user, int puntos)
        {
            var exam = _context._usuarioSubtemaPregunta.FirstOrDefault(z => z.UsuarioSubtemas.IdUsuario == user && z.IdPrueba == IdPrueba);
            exam.Nota = puntos;
            exam.Estado = "Terminado";
            _context._usuarioSubtemaPregunta.Update(exam);
            _context.SaveChanges();
        }
        public void ActualizarSubtemaTerminado(int IdSubtema, int user)
        {
            var Subtema = _context._usuarioSubtema.FirstOrDefault(s => s.IdSubtema == IdSubtema && s.IdUsuario == user);
            var Exam = _context._usuarioSubtemaPregunta.Where(e => e.UsuarioSubtemas.IdUsuario == user && e.UsuarioSubtemas.IdSubtema == IdSubtema).ToList();
            DateTime fecha = DateTime.Now;
            int SumaExamNotas = 0;
            for (int i = 0; i < Exam.Count; i++)
            {
                SumaExamNotas += Exam[i].Nota;
            }
            int NotaFinal = (20 * ((SumaExamNotas * 100) / (Exam.Count * 20))) / 100;
            Subtema.NotaPrueba = NotaFinal;
            Subtema.PorcentajeAvance = 100;
            Subtema.UltFechaModif = fecha;
            Subtema.EstadoSubtema = "TerminadoTodo";
            _context._usuarioSubtema.Update(Subtema);
            _context.SaveChanges();
        }
        
        public void EjercicioCompletado(string LinkEj, int user, int puntos)
        {
            var EjEjercicio = _context._ejercicio.FirstOrDefault(o => o.LinkEjercicio == LinkEj);
            int IdPagEjercicio = EjEjercicio.Id;
            var EjLeccionUsuario = _context._usuarioEjercicio.FirstOrDefault(z => z.IdUsuario == user && z.IdEjercicio == IdPagEjercicio);
            EjLeccionUsuario.EstadoUsuarioEjercicio = "Completo";
            EjLeccionUsuario.NotaUsuarioEjercicio = puntos;
            _context._usuarioEjercicio.Update(EjLeccionUsuario);
            _context.SaveChanges();
        }
        public void ActualizarPorcentajesLeccion(int user, int IdLeccion)
        {
            int TotalLecciones = _context._usuarioLeccionPag.Where(z => z.IdUsuario == user && z.PagLecciones.IdLeccion == IdLeccion).Count();
            int TotalLeccionesCompletas = _context._usuarioLeccionPag.Where(z => z.IdUsuario == user && z.PagLecciones.IdLeccion == IdLeccion && z.Estado == "Completo").Count();
            int TotalEjercicios = _context._usuarioEjercicio.Where(y => y.IdUsuario == user && y.Ejercicios.IdLeccion == IdLeccion).Count();
            int TotalEjerciciosCompletos = _context._usuarioEjercicio.Where(y => y.IdUsuario == user && y.Ejercicios.IdLeccion == IdLeccion && y.EstadoUsuarioEjercicio == "Completo").Count();
            var Leccion = _context._usuarioLeccion.FirstOrDefault(z => z.IdUsuario == user && z.IdLeccion == IdLeccion);
            int porecentajeNuevo = (100 * (TotalLeccionesCompletas + TotalEjerciciosCompletos)) / (TotalLecciones + TotalEjercicios);
            Leccion.PorcentajeAvance = porecentajeNuevo;
            _context._usuarioLeccion.Update(Leccion);
            _context.SaveChanges();
        }
        public void ActualizarTodosPorcentajeCurso(int user)
        {
            var cursos = _context._usuarioCurso.Where(o => o.IdUsuario == user).ToList();
            for (int i = 0; i < cursos.Count; i++)
            {
                var curso = _context._usuarioCurso.FirstOrDefault(y => y.IdCurso == cursos[i].IdCurso);
                int TotalTemas = _context._usuarioTema.Where(o => o.IdUsuario == user && o.Temas.IdCurso == cursos[i].Id).Count();
                var Temas = _context._usuarioTema.Where(x => x.IdUsuario == user && x.Temas.IdCurso == cursos[i].Id).ToList();
                int SumaPorcentajesTemas = 0;
                for(int j = 0; j < Temas.Count; j++)
                {
                   SumaPorcentajesTemas += Temas[j].PorcentajeAvance; 
                }
                curso.PorcentajeAvance = SumaPorcentajesTemas / Temas.Count;
                _context._usuarioCurso.Update(curso);
                _context.SaveChanges();
            }
        }
        public void ActualizarCursoActual(int user, int IdCurso)

        {
            var curso = _context._usuarioCurso.FirstOrDefault(o => o.IdCurso == IdCurso && o.IdUsuario == user);
            var Temas = _context._usuarioTema.Where(o => o.Temas.IdCurso == IdCurso && o.IdUsuario == user).ToList();
            int SumaPorcentajeTemas = 0;
            for (int j = 0; j < Temas.Count; j++)
            {
                SumaPorcentajeTemas += Temas[j].PorcentajeAvance;
            }
            curso.PorcentajeAvance = SumaPorcentajeTemas / Temas.Count;
            _context._usuarioCurso.Update(curso);
            _context.SaveChanges();
        }
        public void ActualizarTodosPorcentajeTema(int user)
        {
            var temas = _context._usuarioTema.Where(o => o.IdUsuario == user).ToList();
            for(int i = 0; i < temas.Count; i++)
            {
                var tema = _context._usuarioTema.FirstOrDefault(y => y.IdTema == temas[i].Id);
                int TotalSubtemas = _context._usuarioSubtema.Where(z => z.IdUsuario == user && z.Subtemas.IdTema == temas[i].Id).Count();
                var Subtemas = _context._usuarioSubtema.Where(z => z.IdUsuario == user && z.Subtemas.IdTema == temas[i].Id).ToList();
                int SumaPorcentajesSubtemas = 0;
                for(int j = 0; j < Subtemas.Count; j++)
                {
                    SumaPorcentajesSubtemas += Subtemas[j].PorcentajeAvance;
                }
                tema.PorcentajeAvance = SumaPorcentajesSubtemas / TotalSubtemas;
                _context._usuarioTema.Update(tema);
                _context.SaveChanges();
            }
        }
        public void ActualizarTemaActual(int user, int IdTema)

        {
            var Tema = _context._usuarioTema.FirstOrDefault(o => o.IdTema == IdTema && o.IdUsuario == user);
            var Subtemas = _context._usuarioSubtema.Where(o => o.Subtemas.IdTema == IdTema && o.IdUsuario == user).ToList();
            int SumaPorcentajeSubtemas = 0;
            for (int j = 0; j < Subtemas.Count; j++)
            {
                SumaPorcentajeSubtemas += Subtemas[j].PorcentajeAvance;
            }
            Tema.PorcentajeAvance = SumaPorcentajeSubtemas / Subtemas.Count;
            _context._usuarioTema.Update(Tema);
            _context.SaveChanges();
        }
        public void ActualizarSubtemaActual(int user, int IdSubtema)
        {
            var Subtema = _context._usuarioSubtema.FirstOrDefault(o => o.IdSubtema == IdSubtema && o.IdUsuario == user);
            var Lecciones = _context._usuarioLeccion.Where(y => y.Lecciones.IdSubtema == IdSubtema && y.IdUsuario == user).ToList();
            int SumaPorcentajeLecciones = 0;
            for (int j = 0; j < Lecciones.Count; j++)
            {
                SumaPorcentajeLecciones += Lecciones[j].PorcentajeAvance;
            }
            var pruebas = _context._usuarioSubtemaPregunta.Where(x => x.UsuarioSubtemas.IdSubtema == IdSubtema && x.UsuarioSubtemas.IdUsuario == user).ToList();
            int SumaPorcentajeExamenes = 0;
            for(int j = 0; j < pruebas.Count; j++)
            {
                if(pruebas[j].Estado == "Terminado")
                {
                    SumaPorcentajeExamenes += 100;
                }
            }
            Subtema.PorcentajeAvance = (SumaPorcentajeExamenes + SumaPorcentajeLecciones) / (pruebas.Count + Lecciones.Count);
            _context._usuarioSubtema.Update(Subtema);
            _context.SaveChanges();
        }
        public void ActualizarTodosPorcentajeSubtema(int user)
        {
            var subtemas = _context._usuarioSubtema.Where(o => o.IdUsuario == user).ToList();
            for (int i = 0; i < subtemas.Count; i++)
            {
                var subtema = _context._usuarioSubtema.FirstOrDefault(z => z.IdSubtema == subtemas[i].Id);
                int TotalLecciones = _context._usuarioLeccion.Where(y => y.IdUsuario == user && y.Lecciones.IdSubtema == subtemas[i].Id).Count();
                var Lecciones = _context._usuarioLeccion.Where(y => y.IdUsuario == user && y.Lecciones.IdSubtema == subtemas[i].Id).ToList();
                int SumaPorcentajesLecciones = 0;
                for(int j = 0; j < Lecciones.Count; j++)
                {
                    SumaPorcentajesLecciones += Lecciones[j].PorcentajeAvance;
                }
                var Examenes = _context._usuarioSubtemaPregunta.Where(x => x.UsuarioSubtemas.IdUsuario == user && x.UsuarioSubtemas.IdSubtema == subtemas[i].Id).ToList();
                int SumaPorcentajesExamenes = 0;
                for(var j = 0; j < Examenes.Count; j++)
                {
                    if(Examenes[j].Estado == "Habilitado")
                    {
                        SumaPorcentajesExamenes += 100; 
                    }
                }
                subtema.PorcentajeAvance = (SumaPorcentajesLecciones) / TotalLecciones;//Agregar suma de Examenes
                _context._usuarioSubtema.Update(subtema);
                _context.SaveChanges();
            }
        }
        public void ActualizarLeccionTerminado(int user, int IdLeccion)
        {
            var Leccion = _context._usuarioLeccion.FirstOrDefault(z => z.IdUsuario == user && z.IdLeccion == IdLeccion);
            int TotalEjercicios = _context._usuarioEjercicio.Where(y => y.IdUsuario == user && y.Ejercicios.IdLeccion == IdLeccion).Count();
            var Ejercicios = _context._usuarioEjercicio.Where(y => y.IdUsuario == user && y.Ejercicios.IdLeccion == IdLeccion).ToList();
            int NotaMaxima = TotalEjercicios * 5;
            int sumaPuntosEjercicios = 0;
            DateTime fecha = DateTime.Now;
            for (int i = 0; i < Ejercicios.Count; i++)
            {
                sumaPuntosEjercicios += Ejercicios[i].NotaUsuarioEjercicio;
            }
            int NotaPorcentajeLeccion = (sumaPuntosEjercicios * 100) / NotaMaxima;
            int NotaFinalLeccion = (NotaPorcentajeLeccion * 20) / 100;
            Leccion.NotaLeccion = NotaFinalLeccion;
            Leccion.PuntosLeccion = sumaPuntosEjercicios;
            Leccion.EstadoLeccion = "Terminado";
            Leccion.UltFechaModif = fecha;
            Leccion.PorcentajeAvance = 100;
            _context._usuarioLeccion.Update(Leccion);
            _context.SaveChanges();
        }
        
        public void ActualizarEstadoSiguienteLeccion(int user, int IdLeccion)
        {
            var Leccion = _context._usuarioLeccion.FirstOrDefault(z => z.IdUsuario == user && z.IdLeccion == IdLeccion);
            Leccion.EstadoLeccion = "Habilitado";
            _context._usuarioLeccion.Update(Leccion);
            _context.SaveChanges();

        }
        public void ActualizarEstadoSiguienteSubtema(int user, int IdSubtema)
        {
            var Subtema = _context._usuarioSubtema.FirstOrDefault(z => z.IdSubtema == IdSubtema && z.IdUsuario == user);
            Subtema.EstadoSubtema = "Habilitado";
            _context._usuarioSubtema.Update(Subtema);
            _context.SaveChanges();
        }
        public void ActualizarEstadoSubtemaActual(int user, int IdSubtema)
        {
            var Subtema = _context._usuarioSubtema.FirstOrDefault(z => z.IdSubtema == IdSubtema && z.IdUsuario == user);
            Subtema.EstadoSubtema = "TerminadoContenido";
            _context._usuarioSubtema.Update(Subtema);
            _context.SaveChanges();
        }
        public void ActualizarEstadosExamenesSubtemaActual(int user, int IdSubtema)
        {
            var Examenes = _context._usuarioSubtemaPregunta.Where(z => z.UsuarioSubtemas.IdSubtema == IdSubtema && z.UsuarioSubtemas.IdUsuario == user).ToList();
            for (int i = 0; i < Examenes.Count; i++)
            {
                Examenes[i].Estado = "Habilitado";
                _context._usuarioSubtemaPregunta.Update(Examenes[i]);
                _context.SaveChanges();
            }
        }
        public string ObtenerNombreCurso(int id)
        {
            var curso = _context._curso.Where(o => o.Id == id).FirstOrDefault();
            return curso.NombreCurso;
        }
        public string ObtenerNombreTema(int id)
        {
            var tema = _context._tema.Where(o => o.Id == id).FirstOrDefault();
            return tema.TituloTema;
        }
        public string ObtenerNombreSubtema(int id)
        {
            var subtema = _context._subtema.Where(o => o.Id == id).FirstOrDefault();
            return subtema.TituloSubtema;
        }
        public string ObtenerNombreLeccion(int id)
        {
            var leccion = _context._leccion.Where(o => o.Id == id).FirstOrDefault();
            return leccion.TituloLeccion;
        }
        public int NumeroCursos()
        {
            int num = _context._curso.ToList().Count();
            return num;
        }
        public int NumeroTemas(int id)
        {
            int num = _context._tema.Where(s => s.IdCurso == id).ToList().Count();
            return num;
        }
        public int NumeroSubtemas(int id)
        {
            int num = _context._subtema.Where(s => s.IdTema == id).ToList().Count();
            return num;
        }
        public int NumeroLecciones(int id)
        {
            int num = _context._leccion.Where(s => s.IdSubtema == id).ToList().Count();
            return num;
        }
        public int NumeroCursosEnProgreso(string user)
        {
            int Id = _usuario.EncontrarIdUsuario(user);
            int num = _context._usuarioCurso.Where(o => o.IdUsuario == Id && o.EstadoCurso == "Terminado").ToList().Count();
            return num;
        }
        public int NumeroTemasEnProgreso(string user, int id)
        {
            int Id = _usuario.EncontrarIdUsuario(user);
            int num = _context._usuarioTema.Where(o => o.IdUsuario == Id && o.EstadoTema == "Terminado" && o.Temas.IdCurso == id).ToList().Count();
            return num;
        }
        public int NumerosubtemasEnProgreso(string user, int id)
        {
            int Id = _usuario.EncontrarIdUsuario(user);
            int num = _context._usuarioSubtema.Where(o => o.IdUsuario == Id && o.EstadoSubtema == "TerminadoTodo" && o.Subtemas.IdTema == id).ToList().Count();
            return num;
        }
        public int NumeroLeccionesEnProgreso(string user, int id)
        {
            int Id = _usuario.EncontrarIdUsuario(user);
            int num = _context._usuarioLeccion.Where(o => o.IdUsuario == Id && o.EstadoLeccion == "Terminado" && o.Lecciones.IdSubtema == id).ToList().Count();
            return num;
        }
        public List<UsuarioCurso> CursosU(string user)
        {
            int Id = _usuario.EncontrarIdUsuario(user);
            return _context._usuarioCurso.Where(s => s.IdUsuario == Id).Include(s => s.Cursos.Colores).ToList();
        }
        public List<UsuarioTema> TemasU(string user, int id)
        {
            int Id = _usuario.EncontrarIdUsuario(user);
            return _context._usuarioTema.Where(s => s.IdUsuario == Id && s.Temas.IdCurso == id).Include(s => s.Temas.Colores).ToList();
        }
        public List<UsuarioTema> TodosTemasU(string user)
        {
            int Id = _usuario.EncontrarIdUsuario(user);
            return _context._usuarioTema.Where(s => s.IdUsuario == Id).Include(s => s.Temas.Cursos).ToList();
        }
        public List<UsuarioSubtema> SubtemasU(string user, int id)
        {
            int Id = _usuario.EncontrarIdUsuario(user);
            return _context._usuarioSubtema.Where(s => s.IdUsuario == Id && s.Subtemas.IdTema == id).Include(s => s.Subtemas.Colores).ToList();
        }
        public List<UsuarioSubtema> TodosSubtemasU(string user)
        {
            int Id = _usuario.EncontrarIdUsuario(user);
            return _context._usuarioSubtema.Where(s => s.IdUsuario == Id).Include(s => s.Subtemas.Temas).ToList();
        }
        public List<UsuarioLeccion> LeccionesU(string user, int id)
        {
            int Id = _usuario.EncontrarIdUsuario(user);
            return _context._usuarioLeccion.Where(s => s.IdUsuario == Id && s.Lecciones.IdSubtema == id).Include(s => s.Lecciones.Colores).ToList();
        }
        public List<UsuarioLeccion> TodosLeccionesU(string user)
        {
            int Id = _usuario.EncontrarIdUsuario(user);
            return _context._usuarioLeccion.Where(s => s.IdUsuario == Id).Include(s => s.Lecciones.Subtemas).ToList();
        }
        public List<UsuarioLibro> LibrosU(string user)
        {
            int Id = _usuario.EncontrarIdUsuario(user);
            return _context._usuarioLibro.Where(s => s.IdUsuario == Id).Include(s => s.Libros).ToList();
        }
        public List<UsuarioSubtemaPregunta> PruebasSubtemaU(string user, int idSubtema)
        {
            int Id = _usuario.EncontrarIdUsuario(user);
            return _context._usuarioSubtemaPregunta.Where(s => s.UsuarioSubtemas.IdUsuario == Id && s.Pruebas.IdSubtema == idSubtema && (s.Estado == "Habilitado" || s.Estado == "Terminado")).Include(s => s.Pruebas).ToList();
        }

    }
}
