using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProcessSA.Modelo
{
    public class RechazoSubTarea
    {
        private int ID_SubTarea;
        private string Motivo;
        private DateTime Fecha_Hoy;

        public int ID_SubTarea1 { get => ID_SubTarea; set => ID_SubTarea = value; }
        public string Motivo1 { get => Motivo; set => Motivo = value; }
        public DateTime Fecha_Hoy1 { get => Fecha_Hoy; set => Fecha_Hoy = value; }
    }
}