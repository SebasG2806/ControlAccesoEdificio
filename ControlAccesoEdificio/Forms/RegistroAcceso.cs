using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ControlAccesoEdificio.AccesoDatos;

namespace ControlAccesoEdificio.Forms
{
    public partial class RegistroAcceso : Form
    {
        private readonly AccesoRepository accesoRepo = new AccesoRepository();
        private int? accesoSeleccionadoId = null;
        public RegistroAcceso()
        {
            InitializeComponent();
            CargarAccesos();
        }
        private void CargarAccesos()
        {
            dgvAccesos.DataSource = accesoRepo.ObtenerHistorialAccesos();
        }
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (accesoSeleccionadoId == null)
            {
                MessageBox.Show("Selecciona un acceso del listado.");
                return;
            }

            int zonaNueva = int.Parse(txtZonaAcceso.Text);
            DateTime fechaSalida = dtpSalida.Value;

            accesoRepo.ActualizarAcceso(accesoSeleccionadoId.Value, zonaNueva, fechaSalida);
            MessageBox.Show("Acceso actualizado correctamente.");
            CargarAccesos();
            LimpiarCampos();
        }


        private void LimpiarCampos()
        {
            accesoSeleccionadoId = null;
            txtZonaAcceso.Clear();
            dtpSalida.Value = DateTime.Now;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (accesoSeleccionadoId == null)
            {
                MessageBox.Show("Selecciona un acceso del listado.");
                return;
            }

            accesoRepo.EliminarAcceso(accesoSeleccionadoId.Value);
            MessageBox.Show("Acceso eliminado correctamente.");
            CargarAccesos();
            LimpiarCampos();
        }
    }
}
