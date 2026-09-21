using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Inventario_Discoteca.Entidades
{
    public class Eventos
    {
        [Key]
        public int IdEvento { get; set; }
        public int IdEncargado { get; set; }
        public string? DetalleEvento { get; set; }
        public DateTime FechaEvento { get; set; }
        public DateTime HoraInicio { get; set; }
        public DateTime HoraFin { get; set; }

        [ForeignKey("IdEncargado")]
        public Empleados? _Encargado { get; set; }
    }
}
