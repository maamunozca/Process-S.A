using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProcessSA.Modelo
{
    public class RechazoTarea
    {
        private int ID_TAREA;
        private string Motivo;
        private DateTime FechaRechazo;

        public int ID_TAREA1 { get => ID_TAREA; set => ID_TAREA = value; }
        public string Motivo1 { get => Motivo; set => Motivo = value; }
        public DateTime FechaRechazo1 { get => FechaRechazo; set => FechaRechazo = value; }
    }
}