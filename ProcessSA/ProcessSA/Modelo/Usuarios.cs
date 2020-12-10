using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProcessSA.Modelo
{
    public class Usuarios
    {
        private string Run;
        private string Nombre_Usuario;
        private string Apellido_Usuario;
        private int Numero_Usuario;
        private string Email_Usuario;
        private string Clave_Usuario;
        private int ID_Rol;

        public string Run1 { get => Run; set => Run = value; }
        public string Nombre_Usuario1 { get => Nombre_Usuario; set => Nombre_Usuario = value; }
        public string Apellido_Usuario1 { get => Apellido_Usuario; set => Apellido_Usuario = value; }
        public int Numero_Usuario1 { get => Numero_Usuario; set => Numero_Usuario = value; }
        public string Email_Usuario1 { get => Email_Usuario; set => Email_Usuario = value; }
        public string Clave_Usuario1 { get => Clave_Usuario; set => Clave_Usuario = value; }
        public int ID_Rol1 { get => ID_Rol; set => ID_Rol = value; }
    }
}