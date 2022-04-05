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
    public class CitasController : ControllerBase
    {
        private readonly ClinicaDbContext _db;
        public CitasController(ClinicaDbContext db)
        {
            _db = db;
        }

        [HttpGet(Name = "GetCitas")]
        public IEnumerable<Cita> Get()
        {
            var citas = _db.Citas.FromSqlRaw<Cita>("exec SelectCita").ToArray();

            return citas;
        }

        [HttpPost]
        public IActionResult Post(Cita cita)
        {
            if (ModelState.IsValid)
            {
                var FechaHora = new SqlParameter("@FechaHora", cita.FechaHora);
                var IdDoctor = new SqlParameter("@IdDoctor", cita.IdDoctor);
                var IdPaciente = new SqlParameter("@IdPaciente", cita.IdPaciente);

                _db.Database.ExecuteSqlRaw("exec InsertCita @FechaHora, @IdDoctor, @IdPaciente", FechaHora, IdDoctor, IdPaciente);
                return Ok();
            }
            return BadRequest();
        }

        [HttpPut]
        public IActionResult Put(Cita cita)
        {
            if (ModelState.IsValid)
            {
                var _cita = _db.Citas.Find(cita.Id);

                if (_cita != null)
                {
                    var id = new SqlParameter("@Id", cita.Id);
                    var FechaHora = new SqlParameter("@FechaHora", cita.FechaHora);
                    var IdDoctor = new SqlParameter("@IdDoctor", cita.IdDoctor);
                    var IdPaciente = new SqlParameter("@IdPaciente", cita.IdPaciente);

                    _db.Database.ExecuteSqlRaw("exec UpdateCita @Id, @FechaHora, @IdDoctor, @IdPaciente", id, FechaHora, IdDoctor, IdPaciente);
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
                var _cita = _db.Citas.Find(Id);

                if (_cita != null)
                {
                    var id = new SqlParameter("@Id", Id);

                    _db.Database.ExecuteSqlRaw("exec DeleteCita @Id", id);
                    return Ok();
                }
            }
            return BadRequest();
        }
    }
}
