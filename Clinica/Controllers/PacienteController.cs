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
    public class PacienteController : ControllerBase
    {
        private readonly ClinicaDbContext _db;

        public PacienteController(ClinicaDbContext db)
        {
            _db = db;
        }

        [HttpGet(Name = "GetPacientes")]
        public IEnumerable<Paciente> Get()
        {
            var pacientes = _db.Pacientes.FromSqlRaw<Paciente>("exec SelectPaciente").ToArray();

            return pacientes;
        }

        [HttpPost]
        public IActionResult Post(Paciente paciente)
        {
            if (ModelState.IsValid)
            {
                var nombre = new SqlParameter("@Nombre", paciente.Nombre);
                var apellido = new SqlParameter("@Apellido", paciente.Apellido);
                var fechanacimiento = new SqlParameter("@FechaNacimiento", paciente.FechaNacimiento);

                _db.Database.ExecuteSqlRaw("exec InsertPaciente @Nombre, @Apellido, @FechaNacimiento", nombre, apellido, fechanacimiento);
                return Ok();
            }
            return BadRequest();
        }

        [HttpPut]
        public IActionResult Put(Paciente paciente)
        {
            if (ModelState.IsValid)
            {
                var _paciente = _db.Pacientes.Find(paciente.Id);

                if (_paciente != null)
                {
                    var id = new SqlParameter("@Id", paciente.Id);
                    var nombre = new SqlParameter("@Nombre", paciente.Nombre);
                    var apellido = new SqlParameter("@Apellido", paciente.Apellido);
                    var fechanacimiento = new SqlParameter("@FechaNacimiento", paciente.FechaNacimiento);

                    _db.Database.ExecuteSqlRaw("exec UpdatePaciente @Id, @Nombre, @Apellido, @FechaNacimiento", id, nombre, apellido, fechanacimiento);
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
                var _paciente = _db.Pacientes.Find(Id);

                if (_paciente != null)
                {
                    var id = new SqlParameter("@Id", Id);

                    _db.Database.ExecuteSqlRaw("exec DeletePaciente @Id", id);
                    return Ok();
                }
            }
            return BadRequest();
        }
    }
}
