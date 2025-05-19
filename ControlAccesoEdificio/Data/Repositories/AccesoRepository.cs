using System;
using System.Data;
using System.Data.SqlClient;
using ControlAccesoEdificio.Utils;

namespace ControlAccesoEdificio.AccesoDatos
{
    public class AccesoRepository
    {
        public void RegistrarAcceso(int? empleadoId, int? visitanteId, int zonaId)
        {
            using (var conexion = DbConnectionSingleton.Instancia)
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("SP_RegistrarAcceso", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@EmpleadoID", (object)empleadoId ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@VisitanteID", (object)visitanteId ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@ZonaAcceso", zonaId);

                cmd.ExecuteNonQuery();
                conexion.Close();
            }
        }
        public void RegistrarSalida(int? empleadoId, int? visitanteId)
        {
            using (var conexion = DbConnectionSingleton.Instancia)
            {
                conexion.Open();

                SqlCommand cmd;

                if (empleadoId.HasValue)
                {
                    cmd = new SqlCommand(
                        "UPDATE Accesos SET FechaHoraSalida = GETDATE() WHERE EmpleadoID = @EmpleadoID AND FechaHoraSalida IS NULL",
                        conexion);
                    cmd.Parameters.AddWithValue("@EmpleadoID", empleadoId.Value);
                }
                else
                {
                    cmd = new SqlCommand(
                        "UPDATE Accesos SET FechaHoraSalida = GETDATE() WHERE VisitanteID = @VisitanteID AND FechaHoraSalida IS NULL",
                        conexion);
                    cmd.Parameters.AddWithValue("@VisitanteID", visitanteId.Value);
                }

                cmd.ExecuteNonQuery();
                conexion.Close();
            }
        }
        public void GenerarAlerta(int empleadoId, string tipoAlerta, string descripcion)
        {
            using (var conexion = DbConnectionSingleton.Instancia)
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("SP_GenerarAlerta", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@EmpleadoID", empleadoId);
                cmd.Parameters.AddWithValue("@TipoAlerta", tipoAlerta);
                cmd.Parameters.AddWithValue("@Descripcion", descripcion);

                cmd.ExecuteNonQuery();
                conexion.Close();
            }
        }
        public DataTable ObtenerHistorialAccesos()
        {
            DataTable tabla = new DataTable();

            using (var conexion = DbConnectionSingleton.Instancia)
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("SP_ObtenerHistorialAccesos", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(tabla);
                conexion.Close();
            }

            return tabla;
        }
        public DataTable ObtenerAccesosInusuales()
        {
            DataTable tabla = new DataTable();

            using (var conexion = DbConnectionSingleton.Instancia)
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("SP_ReporteAccesosInusuales", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(tabla);
                conexion.Close();
            }

            return tabla;
        }
        public void ActualizarAcceso(int accesoId, int zonaAcceso, DateTime fechaSalida)
        {
            using (var conexion = DbConnectionSingleton.Instancia)
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand(
                    "UPDATE Accesos SET ZonaAcceso = @ZonaAcceso, FechaHoraSalida = @FechaHoraSalida WHERE AccesoID = @AccesoID",
                    conexion);

                cmd.Parameters.AddWithValue("@ZonaAcceso", zonaAcceso);
                cmd.Parameters.AddWithValue("@FechaHoraSalida", fechaSalida);
                cmd.Parameters.AddWithValue("@AccesoID", accesoId);

                cmd.ExecuteNonQuery();
                conexion.Close();
            }
        }
        public void EliminarAcceso(int accesoId)
        {
            using (var conexion = DbConnectionSingleton.Instancia)
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM Accesos WHERE AccesoID = @AccesoID", conexion);
                cmd.Parameters.AddWithValue("@AccesoID", accesoId);
                cmd.ExecuteNonQuery();
                conexion.Close();
            }
        }
    }
}

