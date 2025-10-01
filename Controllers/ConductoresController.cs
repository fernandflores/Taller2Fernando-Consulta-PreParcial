using APIRest.Services;
using Microsoft.AspNetCore.Mvc;

namespace APIRest_2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ConductoresController : ControllerBase
    {
        private readonly IAccesoADatos _accesoDatos;
        private List<Conductores> _conductores;
        public ConductoresController()
        {
            _accesoDatos = new AccesoADatos();
            _conductores = _accesoDatos.LeerArchivo();
        }

        // arrancando con endpoints

        [HttpGet]
        [Route("Conducotes/getConductores")]
        public ActionResult<List<Conductores>> GetConductores()
        {
            return Ok(_conductores);
        }

        [HttpGet]
        [Route("Conductores/GetConductor/{id}")]

        public ActionResult<Conductores> GetConductor(int id)
        {
            var conductor = _conductores.Find(f => f.Id == id);
            if (conductor == null) return NotFound("no existe un conductor con ese id");
            return Ok(conductor);
        }


        [HttpPost]
        [Route("Conductores/AddConductor")]
        public ActionResult<Conductores> AddConductor(string nombre, string vehiculo, DateTime fechaIngreso)
        {
            int id = _conductores.Max(c => c.Id) + 1;
            var conductor = new Conductores(id, nombre, vehiculo, fechaIngreso);
            _conductores.Add(conductor);
            _accesoDatos.GuardarArchivo(_conductores);
            return Ok(conductor);
        }

        [HttpPut]
        [Route("Conductores/AddCalificacion")]
        public ActionResult<Conductores> AddCalificacion (int idConductor, int punt, string comentario)
        {
            // paso 1: control de existencia del conductor: caso de no existir devuelve 404
            if (_conductores.Find(f => f.Id == idConductor) == null) return NotFound("no existe un conductor con ese id");
            // control de puntuacion: devuelve 400 (la puntuacion debe ir de 1 a 5)
            if (punt > 5 || punt < 1) return BadRequest("puntuacion fuera del rango");
            var calificacion = new Calificacion(punt, comentario);
            var conductor = _conductores.Find(f => f.Id == idConductor);
            conductor.Calificaciones.Add(calificacion);
            _accesoDatos.GuardarArchivo(_conductores);
            return Ok(conductor);
        }

        [HttpDelete]
        [Route("Conductores/BajaConductor/{id}")]
        public ActionResult<Conductores> BajaConductor(int id)
        {
            var conductor = _conductores.Find(f => f.Id == id);
            if (conductor == null) return NotFound("no existe un conductor con ese id");
            _conductores.Remove(conductor);
            _accesoDatos.GuardarArchivo(_conductores);
            return Ok(conductor);
        }
    }
}
