using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControlAccesoEdificio.Entities;

namespace ControlAccesoEdificio.Data.Repositories
{
    public interface IEmpleadoRepository
    {
        List<Empleado> ObtenerTodos();
        Empleado ObtenerPorId(int id);
        void Agregar(Empleado emp);
        void Actualizar(Empleado emp);
        void Eliminar(int id); 
    }
}
