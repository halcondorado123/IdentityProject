using Identidad.Helpers;
using Identidad.Models;
using Identidad.Models.ModelUsuario;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Identidad.Controllers
{
    public class DropDownListsController : Controller
    {

        public readonly IdentidadDbContext _context;
        //private readonly DropDownListHelper _helper;

        public DropDownListsController(IdentidadDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerTipoDocumento()
        {
            try
            {
                var tipoDocumentos = await _context.TiposDocumentos.ToListAsync();
                return Json(tipoDocumentos);
            }
            catch (Exception ex)
            {
                // Registro del error
                Console.WriteLine(ex.Message);  // Puedes registrar el error en un archivo o consola
                return StatusCode(500, "Ocurrió un error en el servidor: " + ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerTipoRH()
        {
            try
            {
                var tipoSangres = await _context.GrupoSanguineos.ToListAsync();
                return Json(tipoSangres);
            }
            catch (Exception ex)
            {
                // Registro del error
                Console.WriteLine(ex.Message);  // Puedes registrar el error en un archivo o consola
                return StatusCode(500, "Ocurrió un error en el servidor: " + ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerEstadoCivil()
        {
            try
            {
                var estadosCiviles = await _context.EstadoCivil.ToListAsync();
                return Json(estadosCiviles);
            }
            catch (Exception ex)
            {
                // Registro del error
                Console.WriteLine(ex.Message);  // Puedes registrar el error en un archivo o consola
                return StatusCode(500, "Ocurrió un error en el servidor: " + ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerPaisUsuario()
        {
            try
            {
                var estadosCiviles = await _context.Paises.ToListAsync();
                return Json(estadosCiviles);
            }
            catch (Exception ex)
            {
                // Registro del error
                Console.WriteLine(ex.Message);  // Puedes registrar el error en un archivo o consola
                return StatusCode(500, "Ocurrió un error en el servidor: " + ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerDepartamentoUsuario(int paisId)
        {
            try
            {
                var departamentos = await _context.Departamentos
                    .Where(d => d.PaisId == paisId)
                    .ToListAsync();

                return Json(departamentos);
            }
            catch (Exception ex)
            {
                // Registro del error
                Console.WriteLine(ex.Message);  // Puedes registrar el error en un archivo o consola
                return StatusCode(500, "Ocurrió un error en el servidor: " + ex.Message);
            }
        }
        public async Task<IActionResult> ObtenerMunicipioUsuario(int departamentoId)
        {
            try
            {
                // Filtrar los municipios por el país y departamento seleccionados
                var municipios = await _context.Municipios
                    .Where(m => m.DepartamentoId == departamentoId)
                    .ToListAsync();

                // Devolver los municipios en formato JSON
                return Json(municipios);
            }
            catch (Exception ex)
            {
                // Manejo del error
                Console.WriteLine(ex.Message);  // Puedes cambiar esto por un registro en un log
                return StatusCode(500, "Ocurrió un error en el servidor: " + ex.Message);
            }
        }
    }
}
