using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TareasAPI.Models;
namespace TareasAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeluchesController : ControllerBase
    {
        //Creamos nuestra variable de contexto de BD
        private readonly DbpeluchesContext _baseDatos;
        public PeluchesController(DbpeluchesContext baseDatos)
        {
            _baseDatos = baseDatos;
        }

        //Método GET Lista de peluches
        [HttpGet]
        [Route("ListaPeluches")]
        public async Task<IActionResult> Lista()
        {
            var listaPeluches = await _baseDatos.Peluches
                .Select(p => new
                {
                    IdPeluche = p.IdPeluche,
                    Nombre = p.Nombre,
                    Precio = p.Precio,
                    Descripcion = p.Descripcion,
                    Imagen = p.Imagen,
                    Categoria = p.Categoria.Nombre  // Accede al nombre de la categoría
                })
                .ToListAsync();

            return Ok(listaPeluches);

        }

        // Método GET Lista de peluches por id de categoría
        [HttpGet]
        [Route("ListaPeluches/{idCategoria}")]
        public async Task<IActionResult> Lista(int idCategoria)
        {
            try
            {
                var listaPeluches = await _baseDatos.Peluches
                    .Where(p => p.IdCategoria == idCategoria)
                    .Select(p => new
                    {
                        IdPeluche = p.IdPeluche,
                        Nombre = p.Nombre,
                        Precio = p.Precio,
                        Descripcion = p.Descripcion,
                        Imagen = p.Imagen,
                        Categoria = p.Categoria.Nombre  // Accede al nombre de la categoría
                    })
                    .ToListAsync();

                if (listaPeluches == null || listaPeluches.Count == 0)
                {
                    return NotFound($"No se encontraron peluches para la categoría con id {idCategoria}.");
                }

                return Ok(listaPeluches);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al obtener los peluches para la categoría con id {idCategoria}: {ex.Message}");
            }
        }



    }
}