using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entidad
{
    public class Apoyo
    {
        [Key]
        public int Id { get; set; }
        public decimal ValorApoyo { get; set; }
        [MaxLength(17)]
        public string ModalidadApoyo { get; set; }
        
        [DataType(DataType.Date)]
        public DateTime Fecha { get; set; }
    }
}