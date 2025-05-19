using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ControlAccesoEdificio.Services;
using ControlAccesoEdificio.Entities; 

namespace ControlAccesoEdificio.Forms
{
    public partial class Login : Form
    {
        private readonly AuthService authService = new AuthService();
        public Login()
        {
            InitializeComponent();
        }

        private void txtIngresar_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text.Trim();
            string contraseña = txtContraseña.Text.Trim();

            Empleado emp = authService.Login(usuario, contraseña);

            if(string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(contraseña))
            {
                MessageBox.Show("Ingrese usuario y contraseña", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if(emp != null)
            {
                MessageBox.Show($"Bienvenido {emp.Nombre} ({emp.Rol})", "Login Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Credenciales inválidas", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
