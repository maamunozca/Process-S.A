using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProcessSA.Modelo
{
    public class Detalle_Tarea
    {
        private int ID_Flujo_Tarea;
        private int ID_Tarea;
        private string Run;

        public int ID_Flujo_Tarea1 { get => ID_Flujo_Tarea; set => ID_Flujo_Tarea = value; }
        public int ID_Tarea1 { get => ID_Tarea; set => ID_Tarea = value; }
        public string Run1 { get => Run; set => Run = value; }
    }
}