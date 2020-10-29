using System.Data.Common;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entidad
{
    public class Persona
    {
        [Key]
        [Column(TypeName="varchar(12)")]
        public string Identificacion { get; set; }
        [Column(TypeName="varchar(20)")]
        public string Nombre { get; set; }
        [Column(TypeName="varchar(2)")]
        public string Sexo { get; set; }
        [Column(TypeName="decimal")]
        public int Edad { get; set; }     
        [Column(TypeName="varchar(15)")]   
        public string Departamento { get; set; }
        [Column(TypeName="varchar(15)")]
        public string Ciudad { get; set;}
        [Column("IdApoyo",TypeName="varchar(5)")]
        public Apoyo Apoyo { get; set; }

    }
}
