using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Clinica.Data;
using Clinica.Models;
using Microsoft.Data.SqlClient;

namespace Clinica.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrabajadoresController : ControllerBase
    {
        private readonly ClinicaDbContext _db;

        public TrabajadoresController(ClinicaDbContext db)
        {
            _db = db;
        }

        [HttpGet(Name = "GetTrabajadores")]
        public IEnumerable<Trabajador> Get()
        {
            var trabajadores = _db.Trabajadores.FromSqlRaw<Trabajador>("exec SelectTrabajador").ToArray();

            return trabajadores;
        }

        [HttpPost]
        public IActionResult Post(Trabajador trabajador)
        {
            if (ModelState.IsValid)
            {
                var nombre = new SqlParameter("@Nombre", trabajador.Nombre);
                var apellido = new SqlParameter("@Apellido", trabajador.Apellido);

                _db.Database.ExecuteSqlRaw("exec InsertTrabajador @Nombre, @Apellido", nombre, apellido);
                return Ok();
            }
            return BadRequest();
        }

        [HttpPut]
        public IActionResult Put(Trabajador trabajador)
        {
            if (ModelState.IsValid)
            {
                var _trabajador = _db.Trabajadores.Find(trabajador.Id);

                if(_trabajador != null)
                {
                    var id = new SqlParameter("@Id", trabajador.Id);
                    var nombre = new SqlParameter("@Nombre", trabajador.Nombre);
                    var apellido = new SqlParameter("@Apellido", trabajador.Apellido);

                    _db.Database.ExecuteSqlRaw("exec UpdateTrabajador @Id, @Nombre, @Apellido", id, nombre, apellido);
                    return Ok();
                }                
            }
            return BadRequest();
        }

        [HttpDelete]
        public IActionResult Delete(int Id)
        {
            if (Id > 0)
            {
                var _trabajador = _db.Trabajadores.Find(Id);

                if (_trabajador != null)
                {
                    var id = new SqlParameter("@Id", Id);
                    _db.Database.ExecuteSqlRaw("exec DeleteTrabajador @Id", id);
                    return Ok();
                }                
            }
            return BadRequest();
        }
    }
}
