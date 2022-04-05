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
    public class DoctoresController : ControllerBase
    {
        private readonly ClinicaDbContext _db;
        public DoctoresController(ClinicaDbContext db)
        {
            _db = db;
        }

        [HttpGet(Name = "GetDoctores")]
        public IEnumerable<Doctor> Get()
        {
            var doctores = _db.Doctores.FromSqlRaw<Doctor>("exec SelectDoctor").ToArray();

            return doctores;
        }

        [HttpPost]
        public IActionResult Post(Doctor doctor)
        {
            if (ModelState.IsValid)
            {
                var IdTrabajador = new SqlParameter("@IdTrabajador", doctor.IdTrabajador);
                var IdEspecialidad = new SqlParameter("@IdEspecialidad", doctor.IdEspecialidad);

                _db.Database.ExecuteSqlRaw("exec InsertDoctor @IdTrabajador, @IdEspecialidad", IdTrabajador, IdEspecialidad);
                return Ok();
            }
            return BadRequest();
        }

        [HttpPut]
        public IActionResult Put(Doctor doctor)
        {
            if (ModelState.IsValid)
            {
                var _doctor = _db.Doctores.Find(doctor.Id);

                if (_doctor != null)
                {
                    var id = new SqlParameter("@Id", doctor.Id);
                    var IdTrabajador = new SqlParameter("@IdTrabajador", doctor.IdTrabajador);
                    var IdEspecialidad = new SqlParameter("@IdEspecialidad", doctor.IdEspecialidad);

                    _db.Database.ExecuteSqlRaw("exec UpdateDoctor @Id, @IdTrabajador, @IdEspecialidad", id, IdTrabajador, IdEspecialidad);
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
                var _doctor = _db.Doctores.Find(Id);

                if (_doctor != null)
                {
                    var id = new SqlParameter("@Id", Id);
                    _db.Database.ExecuteSqlRaw("exec DeleteDoctor @Id", id);
                    return Ok();
                }
            }
            return BadRequest();
        }
    }
}
