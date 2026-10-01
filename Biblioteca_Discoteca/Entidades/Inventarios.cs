using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Inventario_Discoteca.Entidades
{
    public class Inventarios
    {
        [Key]
        public int IdInventario { get; set; }
        public List<ElementosInternos>? _ElementoInternos { get; set; }
        public List<Productos>? _Productos { get; set; }
        public List<MovimientoInventarios>? _MovimientoInventarios { get; set; }
    }
}
