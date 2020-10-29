using Datos;
using Entidad;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Logica
{
    public class PersonaService
    {
        private readonly ParcialContext context;
        public PersonaService(ParcialContext parcialContext)
        {
            context = parcialContext;
        }
        public ServiceResponse Guardar(Persona persona)
        {
            try
            {
                context.Personas.Add(persona);
                context.SaveChanges();
                return new ServiceResponse(persona);

            }
            catch (Exception e)
            {
                return new ServiceResponse($"Error del aplicacion: {e.Message}");
            }
        }
        public ApoyoResponse GetSumaApoyo()
        {
            try
            {
                decimal sumaSupport = context.Personas.
                FromSqlRaw("SELECT * FROM  Persons p JOIN Support s ON p.SupportIdSupport = s.IdSupport").
                Sum(p => p.Apoyo.ValorApoyo);

                return new ApoyoResponse(sumaSupport);
            }
            catch (Exception e)
            {
                return new ApoyoResponse($"Error de la Aplicacion: {e.Message}");
            }
        }
        /*public bool Guardar(Persona persona)
        {
            try
            {
                conexion.Open();
                repositorio.Guardar(persona);
                conexion.Close();
                return true;
            }
            catch (Exception e)
            { return false; }
            finally { conexion.Close(); }
        }*/
        public ConsultaResponse GetConsulta()
        {
            try
            {
                IList<Persona> personas = context.Personas.Include(s => s.Apoyo).ToList();
                return new ConsultaResponse(personas);
            }
            catch (Exception e)
            {
                return new ConsultaResponse($"Error de aplicacion: {e.Message}");
            }
        }
        public ServiceResponse GetPersona(string identificacion)
        {
            try
            {

                Persona persona = context.Personas.Where(s => s.Identificacion == identificacion)
                                                .Include(s => s.Apoyo)
                                                .FirstOrDefault();

                return new ServiceResponse(persona);
            }
            catch (Exception e)
            {

                return new ServiceResponse($"Error de la Aplicacion: {e.Message}");
            }
        }

    }

    public class ServiceResponse
    {
        public ServiceResponse(Persona persona)
        {
            Error = false;
            Persona = persona;
        }

        public ServiceResponse(string message)
        {
            Error = true;
            Message = message;
        }

        public bool Error { get; set; }
        public string Message { get; set; }
        public Persona Persona { get; set; }
    }

    public class ConsultaResponse
    {
        public ConsultaResponse(IList<Persona> personas)
        {
            Error = false;
            Personas = personas;
        }

        public ConsultaResponse(string message)
        {
            Error = true;
            Message = message;
        }

        public bool Error { get; set; }
        public string Message { get; set; }
        public IList<Persona> Personas { get; set; }
    }
    public class ApoyoResponse
    {
        public ApoyoResponse(decimal sumaApoyo)
        {
            Error = false;
            SumaApoyo = sumaApoyo;
        }

        public ApoyoResponse(string message)
        {
            Error = true;
            Message = message;
        }

        public bool Error { get; set; }
        public string Message { get; set; }
        public decimal SumaApoyo { get; set; }
    }
    
}
