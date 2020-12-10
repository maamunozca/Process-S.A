using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Oracle.DataAccess.Client;

namespace ProcessSA.Controlador
{
    public class Conexion
    {
        public OracleConnection getConn()
        {
            OracleConnection conn = new OracleConnection("DATA SOURCE = xe; PASSWORD = 123; USER ID = portafolio;");
            return conn;
        }

    }
}