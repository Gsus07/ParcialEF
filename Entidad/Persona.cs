using System.Data.Common;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entidad
{
    public class Persona
    {
        [Key]
        [MaxLength(10)]
        public string Identificacion { get; set; }
        [MaxLength(20)]
        public string Nombre { get; set; }
        [MaxLength(2)]
        public string Sexo { get; set; }
        
        public int Edad { get; set; }     
        [MaxLength(15)]   
        public string Departamento { get; set; }
        [MaxLength(15)]
        public string Ciudad { get; set;}
        
        
        public Apoyo Apoyo { get; set; }
    }
}
