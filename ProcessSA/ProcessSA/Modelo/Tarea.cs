using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProcessSA.Modelo
{
    public class Tarea
    {
        private int ID_Tarea;
        private string Nombre_Tarea;
        private string Desc_Tarea;
        private int ID_Estado;
        private int ID_Tipo_Tarea;
        private int ID_Departamento;
        private double porcentaje;

        public int ID_Tarea1 { get => ID_Tarea; set => ID_Tarea = value; }
        public string Nombre_Tarea1 { get => Nombre_Tarea; set => Nombre_Tarea = value; }
        public string Desc_Tarea1 { get => Desc_Tarea; set => Desc_Tarea = value; }
        public int ID_Estado1 { get => ID_Estado; set => ID_Estado = value; }
        public int ID_Tipo_Tarea1 { get => ID_Tipo_Tarea; set => ID_Tipo_Tarea = value; }
        public int ID_Departamento1 { get => ID_Departamento; set => ID_Departamento = value; }
        public double Porcentaje { get => porcentaje; set => porcentaje = value; }
    }
}