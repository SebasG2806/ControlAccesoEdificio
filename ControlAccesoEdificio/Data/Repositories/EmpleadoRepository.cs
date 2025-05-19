using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControlAccesoEdificio.Entities;
using System.Data.SqlClient;
using ControlAccesoEdificio.Utils;
using ControlAccesoEdificio.Data.Repositories;

namespace ControlAccesoEdificio.AccesoDatos
{
        public class EmpleadoRepository : IEmpleadoRepository
        {
            private readonly SqlConnection _conexion;

            public EmpleadoRepository()
            {
                _conexion = DbConnectionSingleton.Instancia;
            }

            public List<Empleado> ObtenerTodos()
            {
                List<Empleado> lista = new List<Empleado>();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Empleados", _conexion);

                _conexion.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    lista.Add(new Empleado
                    {
                        EmpleadoId = Convert.ToInt32(dr["EmpleadoID"]),
                        Nombre = dr["Nombre"].ToString(),
                        Rol = dr["Rol"].ToString(),
                        Usuario = dr["Usuario"].ToString(),
                        Contraseña = dr["Contraseña"].ToString(),
                        ZonaAcceso = Convert.ToInt32(dr["ZonaAcceso"])
                    });
                }
                _conexion.Close();
                return lista;
            }

            public Empleado ObtenerPorId(int id)
            {
                Empleado emp = null;
                SqlCommand cmd = new SqlCommand("SELECT * FROM Empleados WHERE EmpleadoID = @EmpleadoID", _conexion);
                cmd.Parameters.AddWithValue("@EmpleadoID", id);

                _conexion.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    emp = new Empleado
                    {
                        EmpleadoId = Convert.ToInt32(dr["EmpleadoID"]),
                        Nombre = dr["Nombre"].ToString(),
                        Rol = dr["Rol"].ToString(),
                        Usuario = dr["Usuario"].ToString(),
                        Contraseña = dr["Contraseña"].ToString(),
                        ZonaAcceso = Convert.ToInt32(dr["ZonaAcceso"])
                    };
                }
                _conexion.Close();
                return emp;
            }

            public void Agregar(Empleado emp)
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO Empleados (Nombre, Rol, Usuario, Contraseña, ZonaAcceso) VALUES (@Nombre, @Rol, @Usuario, @Contraseña, @ZonaAcceso)", _conexion);
                cmd.Parameters.AddWithValue("@Nombre", emp.Nombre);
                cmd.Parameters.AddWithValue("@Rol", emp.Rol);
                cmd.Parameters.AddWithValue("@Usuario", emp.Usuario);
                cmd.Parameters.AddWithValue("@Contraseña", emp.Contraseña);
                cmd.Parameters.AddWithValue("@ZonaAcceso", emp.ZonaAcceso);

                _conexion.Open();
                cmd.ExecuteNonQuery();
                _conexion.Close();
            }

            public void Actualizar(Empleado emp)
            {
                SqlCommand cmd = new SqlCommand("UPDATE Empleados SET Nombre = @Nombre, Rol = @Rol, Usuario = @Usuario, Contraseña = @Contraseña, ZonaAcceso = @ZonaAcceso WHERE EmpleadoID = @EmpleadoID", _conexion);
                cmd.Parameters.AddWithValue("@EmpleadoID", emp.EmpleadoId);
                cmd.Parameters.AddWithValue("@Nombre", emp.Nombre);
                cmd.Parameters.AddWithValue("@Rol", emp.Rol);
                cmd.Parameters.AddWithValue("@Usuario", emp.Usuario);
                cmd.Parameters.AddWithValue("@Contraseña", emp.Contraseña);
                cmd.Parameters.AddWithValue("@ZonaAcceso", emp.ZonaAcceso);

                _conexion.Open();
                cmd.ExecuteNonQuery();
                _conexion.Close();
            }

            public void Eliminar(int id)
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM Empleados WHERE EmpleadoID = @EmpleadoID", _conexion);
                cmd.Parameters.AddWithValue("@EmpleadoID", id);

                _conexion.Open();
                cmd.ExecuteNonQuery();
                _conexion.Close();
            }
        }
}


