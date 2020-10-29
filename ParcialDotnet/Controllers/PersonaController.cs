using Logica;
using Entidad;
using Microsoft.AspNetCore.Mvc;
using presentacion.Models;
using System.Collections.Generic;
using System.Linq;
using Datos;
using System;
namespace ParcialDotnet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonaController: ControllerBase
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
            Persona persona  = Mapear(personaInput);
            var response = personaService.Guardar(persona);
            if(response.Error)
            {
                return BadRequest(response.Message);
            }
            return Ok(response.Persona);
        }
        private Persona Mapear(PersonaInputModel personaInput)
        {
            var persona = new Persona();

            persona.Identificacion = personaInput.Identificacion;
            persona.Nombre = personaInput.Nombre;
            persona.Sexo = personaInput.Sexo;
            persona.Edad = personaInput.Edad;
            persona.Departamento = personaInput.Departamento;
            persona.Ciudad = personaInput.Ciudad;

            persona.Apoyo = new Apoyo();
            persona.Apoyo.IdApoyo = personaInput.Apoyo.IdApoyo;
            persona.Apoyo.ValorApoyo = personaInput.Apoyo.ValorApoyo;
            persona.Apoyo.ModalidadApoyo = personaInput.Apoyo.ModalidadApoyo;
            persona.Apoyo.Fecha = personaInput.Apoyo.Fecha;

            return persona;
        }

        [HttpGet("{identificacion}")]
        public ActionResult<PersonaViewModel> GetPersona(string identificacion)
        {
            ServiceResponse response =  personaService.GetPersona(identificacion);
            if(response.Persona == null) return NotFound("La persona no ha sido encontrada");
            var p =  new PersonaViewModel(response.Persona);

            return Ok(p);
        }

        // GET: api/Persona
        [HttpGet]

        public ActionResult<IEnumerable<PersonaViewModel>> Get()
        {
            ConsultaResponse response = personaService.GetConsulta();
            if(response.Personas == null) {
                BadRequest(response.Message);
            }
            var personas = response.Personas.Select(p => new PersonaViewModel(p));
            return Ok(response.Personas);
        }
    }
}