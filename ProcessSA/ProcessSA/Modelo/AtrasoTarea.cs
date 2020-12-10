using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProcessSA.Modelo
{
    public class AtrasoTarea
    {

        private int ID_Tarea;
        private string Motivo;
        private DateTime Fecha_Hoy;

        public int ID_Tarea1 { get => ID_Tarea; set => ID_Tarea = value; }
        public string Motivo1 { get => Motivo; set => Motivo = value; }
        public DateTime Fecha_Hoy1 { get => Fecha_Hoy; set => Fecha_Hoy = value; }
    }
}