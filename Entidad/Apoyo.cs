using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entidad
{
    public class Apoyo
    {
        
        [Key]
        [Column(TypeName="varchar(5)")]
        public string IdApoyo { get; set; }
        [Column(TypeName="decimal")]
        public decimal ValorApoyo { get; set; }
        [Column(TypeName="varchar(17)")]
        public string ModalidadApoyo { get; set; }
        [Column(TypeName="Date")]
        public DateTime Fecha { get; set; }
    }
}