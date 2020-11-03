using Entidad;
using System;

namespace presentacion.Models
{
    public class ApoyoModel
    {
        public int Id { get; set; }
        public decimal ValorApoyo { get; set; }
        public string ModalidadApoyo { get; set; }
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
        public PersonaViewModel() { }

        public PersonaViewModel(Persona persona)
        {
            Identificacion = persona.Identificacion;
            Nombre = persona.Nombre;
            Sexo = persona.Sexo;
            Edad = persona.Edad;
            Departamento = persona.Departamento;
            Ciudad = persona.Ciudad;
            Apoyo = new ApoyoModel
            {
                Id = persona.Apoyo.Id,
                ValorApoyo = persona.Apoyo.ValorApoyo,
                ModalidadApoyo = persona.Apoyo.ModalidadApoyo,
                Fecha = persona.Apoyo.Fecha
            };
        }

    }
}