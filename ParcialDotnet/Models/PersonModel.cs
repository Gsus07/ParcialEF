using System.Runtime.CompilerServices;
using System.Reflection.PortableExecutable;
using System.Reflection.Metadata.Ecma335;
using Entidad;
using System;

namespace presentacion.Models
{
    public class ApoyoModel
    {
        public string IdApoyo { get; set; }
        public decimal ValorApoyo { get; set; }
        public string ModalidadApoyo{ get; set; }
        public DateTime Fecha { get; set; }
    }
    public class PersonaInputModel
    {
        public string Identificacion { get; set; }
        public string Nombre { get; set; }
        public string Sexo { get; set; }
        public int Edad { get; set; }
        public string Departamento { get; set; }
        public string Ciudad { get; set; }
        public ApoyoModel Apoyo { get; set; }

    }

    public class PersonaViewModel : PersonaInputModel
    {
        public PersonaViewModel(){}

        public PersonaViewModel(Persona persona)
        {
            Identificacion = persona.Identificacion;
            Nombre = persona.Nombre;
            Sexo = persona.Sexo;
            Edad = persona.Edad;
            Departamento = persona.Departamento;
            Ciudad = persona.Ciudad;
            Apoyo =  new ApoyoModel();
            Apoyo.IdApoyo = persona.Apoyo.IdApoyo;
            Apoyo.ValorApoyo = persona.Apoyo.ValorApoyo;
            Apoyo.ModalidadApoyo = persona.Apoyo.ModalidadApoyo;
            Apoyo.Fecha = persona.Apoyo.Fecha;
        }
       
    } 
}