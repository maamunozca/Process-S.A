using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProcessSA.Modelo
{
    public class Plazos
    {
        private int ID_Plazo;
        private DateTime Fecha_Inicio;
        private DateTime Fecha_Termino;
        private int ID_TAREA;

        public int ID_Plazo1 { get => ID_Plazo; set => ID_Plazo = value; }
        public DateTime Fecha_Inicio1 { get => Fecha_Inicio; set => Fecha_Inicio = value; }
        public DateTime Fecha_Termino1 { get => Fecha_Termino; set => Fecha_Termino = value; }
        public int ID_TAREA1 { get => ID_TAREA; set => ID_TAREA = value; }
    }
}