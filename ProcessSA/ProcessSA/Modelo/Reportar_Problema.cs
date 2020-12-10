using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProcessSA.Modelo
{
    public class Reportar_Problema
    {
        private int ID_PROBLEMA;
        private int ID_TAREA;
        private string Motivo;
        private DateTime FechaHoy;

        public int ID_PROBLEMA1 { get => ID_PROBLEMA; set => ID_PROBLEMA = value; }
        public int ID_TAREA1 { get => ID_TAREA; set => ID_TAREA = value; }
        public string Motivo1 { get => Motivo; set => Motivo = value; }
        public DateTime FechaHoy1 { get => FechaHoy; set => FechaHoy = value; }
    }
}