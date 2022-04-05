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
    public class EspecialidadesController : ControllerBase
    {
        private readonly ClinicaDbContext _db;
        public EspecialidadesController(ClinicaDbContext db)
        {
            _db = db;
        }

        [HttpGet(Name = "GetEspecialidades")]
        public IEnumerable<Especialidad> Get()
        {
            var especialidades = _db.Especialidades.FromSqlRaw<Especialidad>("exec SelectEspecialidad").ToArray();

            return especialidades;
        }

        [HttpPost]
        public IActionResult Post(Especialidad especialidad)
        {
            if (ModelState.IsValid)
            {
                var nombreespecialidad = new SqlParameter("@NombreEspecialidad", especialidad.NombreEspecialidad);

                _db.Database.ExecuteSqlRaw("exec InsertEspecialidad @NombreEspecialidad", nombreespecialidad);
                return Ok();
            }
            return BadRequest();
        }

        [HttpPut]
        public IActionResult Put(Especialidad especialidad)
        {
            if (ModelState.IsValid)
            {
                var _especialidad = _db.Especialidades.Find(especialidad.Id);

                if (_especialidad != null)
                {
                    var id = new SqlParameter("@Id", especialidad.Id);
                    var nombreespecialidad = new SqlParameter("@NombreEspecialidad", especialidad.NombreEspecialidad);

                    _db.Database.ExecuteSqlRaw("exec UpdateEspecialidad @Id, @NombreEspecialidad", id, nombreespecialidad);
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
                var _especialidad = _db.Especialidades.Find(Id);

                if (_especialidad != null)
                {
                    var id = new SqlParameter("@Id", Id);
                    _db.Database.ExecuteSqlRaw("exec DeleteEspecialidad @Id", id);
                    return Ok();
                }
            }
            return BadRequest();
        }
    }
}
