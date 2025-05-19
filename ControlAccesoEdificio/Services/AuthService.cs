using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using ControlAccesoEdificio.Entities;
using ControlAccesoEdificio.Utils;

namespace ControlAccesoEdificio.Services
{
    public class AuthService
    {
        public Empleado Login(String usuario, string contraseña)
        {
            var conn = DbConnectionSingleton.Instancia;
            var cmd = new SqlCommand("SELECT * FROM Empleados WHERE Usuario = @Usuario AND Contraseña = @Contraseña", conn);
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.Parameters.AddWithValue("@Usuario", usuario);
            cmd.Parameters.AddWithValue("@Contraseña", contraseña);
            conn.Open();
            var reader = cmd.ExecuteReader();
            Empleado emp = null;
            if (reader.Read())
            {
                emp = new Empleado
                {
                    EmpleadoId = Convert.ToInt32(reader["EmpleadoID"]),
                    Nombre = reader["Nombre"].ToString(),
                    Usuario = reader["Usuario"].ToString(),
                    Contraseña = reader["Contraseña"].ToString(),
                    Rol = reader["Rol"].ToString(),
                    ZonaAcceso = Convert.ToInt32(reader["ZonaAcceso"])
                };
            }
            conn.Close();
            return emp; 
        }
    }
}
