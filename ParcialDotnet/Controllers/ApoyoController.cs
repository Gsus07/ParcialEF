using Logica;
using Entidad;
using Microsoft.AspNetCore.Mvc;
using presentacion.Models;
using System.Collections.Generic;
using System.Linq;
using Datos;

namespace ParcialDotnet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApoyoController: ControllerBase
    {
        private readonly PersonaService personaService;
        public ApoyoController(ParcialContext context)
        {
            personaService = new PersonaService(context);
        }

        [HttpGet]
        public ActionResult<decimal> Get()
        {
             ApoyoResponse response = personaService.GetSumaApoyo();
            if(response.Error) {
                BadRequest(response.Message);
            }
            return Ok(response.SumaApoyo);
        }
    }
}