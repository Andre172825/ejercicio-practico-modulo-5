using ejercicio_practico_modulo_5.Data;
using ejercicio_practico_modulo_5.Models;
using Microsoft.AspNetCore.Mvc;

namespace ejercicio_practico_modulo_5.Controllers
{
    public class LibrosController : Controller
    {
        public IActionResult Index()
        {
            using(var _context = new AppDbContext())
            {
                var libros = _context.Libros.ToList();
                return View(libros);
            }            
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Libro libro)
        {
            using(var _context = new AppDbContext())
            {
                _context.Libros.Add(libro);
                _context.SaveChanges();
                TempData["confirmacion"] = "Libro guardado correctamente";
                return View();
            }
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            using(var _context = new AppDbContext())
            {
                var libro = _context.Libros.FirstOrDefault(x => x.Id == id);
                return View(libro);
            }            
        }

        [HttpPost]
        public IActionResult Edit(Libro libro)
        {
            using( var _context = new AppDbContext())
            {
                var libroAEditar = _context.Libros.FirstOrDefault(x => x.Id == libro.Id);
                libroAEditar.Titulo = libro.Titulo;
                libroAEditar.Autor = libro.Autor;
                libroAEditar.FechaPublicacion = libro.FechaPublicacion;
                libroAEditar.Genero = libro.Genero;
                _context.SaveChanges();

                return RedirectToAction("Index");
            }
        }
    }
}
