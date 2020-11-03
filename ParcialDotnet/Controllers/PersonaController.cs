using Datos;
using Entidad;
using Logica;
using Microsoft.AspNetCore.Mvc;
using presentacion.Models;
using System.Collections.Generic;
using System.Linq;
namespace ParcialDotnet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonaController : ControllerBase
    {
        private readonly PersonaService personaService;
        public PersonaController(ParcialContext context)
        {
            personaService = new PersonaService(context);
        }

        //POST: api/Persona
        [HttpPost]
        public ActionResult<PersonaViewModel> Post(PersonaInputModel personaInput)
        {
            Persona persona = Mapear(personaInput);
            ServiceResponse response = personaService.Guardar(persona);
            if (response.Error)
            {
                return BadRequest(response.Message);
            }
            return new PersonaViewModel(response.Persona);
        }
        private Persona Mapear(PersonaInputModel personaInput)
        {
            Persona persona = new Persona
            {
                Identificacion = personaInput.Identificacion,
                Nombre = personaInput.Nombre,
                Sexo = personaInput.Sexo,
                Edad = personaInput.Edad,
                Departamento = personaInput.Departamento,
                Ciudad = personaInput.Ciudad,

                Apoyo = new Apoyo
                {
                    ValorApoyo = personaInput.Apoyo.ValorApoyo,
                    ModalidadApoyo = personaInput.Apoyo.ModalidadApoyo,
                    Fecha = personaInput.Apoyo.Fecha
                }
            };

            return persona;
        }

        [HttpGet("{identificacion}")]
        public ActionResult<PersonaViewModel> GetPersona(string identificacion)
        {
            ServiceResponse response = personaService.GetPersona(identificacion);
            if (response.Persona == null) return NotFound("La persona no ha sido encontrada");
            PersonaViewModel p = new PersonaViewModel(response.Persona);

            return Ok(p);
        }

        // GET: api/Persona
        [HttpGet]

        public ActionResult<IEnumerable<PersonaViewModel>> Get()
        {
            ConsultaResponse response = personaService.GetConsulta();
            if (response.Personas == null)
            {
                BadRequest(response.Message);
            }
            IEnumerable<PersonaViewModel> personas = response.Personas.Select(p => new PersonaViewModel(p));
            return Ok(response.Personas);
        }
    }
}