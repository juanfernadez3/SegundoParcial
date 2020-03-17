using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;

namespace SegundoParcial.Entidades
{
    public class Llamadas
    {
        [Key]
        public int LlamadaId { get; set; }
        public String Descripcion { get; set; }

        [ForeignKey("LlamadaId")]
        public  virtual List<LlamadaDetalle> Llamada { get; set; }
        public Llamadas()
        {
            LlamadaId = 0;
            Descripcion = string.Empty;
            Llamada = new List<LlamadaDetalle>();
        }
    }
}
