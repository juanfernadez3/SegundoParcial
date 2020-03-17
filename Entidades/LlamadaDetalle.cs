using System;
using System.Collections.Generic;
using System.Text;
using SegundoParcial.Entidades;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SegundoParcial.Entidades
{
    public class LlamadaDetalle
    {
        [Key]
        public int Id { get; set; }
        public string Problema { get; set; }
        public string Solucion { get; set; }

        public LlamadaDetalle()
        {
            Id = 0;
            Problema = string.Empty;
            Solucion = string.Empty;
        }
    }
}
