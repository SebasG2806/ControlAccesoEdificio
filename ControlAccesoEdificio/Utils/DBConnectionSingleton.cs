using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

namespace ControlAccesoEdificio.Utils
{
        public sealed class DbConnectionSingleton
        {
            private static SqlConnection _conexion;
            private static readonly object _lock = new object();

            private DbConnectionSingleton() { }

            public static SqlConnection Instancia
            {
                get
                {
                    if (_conexion == null ||
                        _conexion.State == System.Data.ConnectionState.Broken ||
                        _conexion.State == System.Data.ConnectionState.Closed)
                    {
                        lock (_lock)
                        {
                            if (_conexion == null ||
                                _conexion.State == System.Data.ConnectionState.Broken ||
                                _conexion.State == System.Data.ConnectionState.Closed)
                            {
                                string cadena = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                                _conexion = new SqlConnection(cadena);
                            }
                        }
                    }
                    return _conexion;
                }
            }
        }
    
}
