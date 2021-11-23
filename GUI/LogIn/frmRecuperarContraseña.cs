using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using BLL;
using Common;
using Controller;

namespace GUI
{
    public partial class frmRecuperarContraseña : Form
    {
        private readonly SecurityController _securityController = new();

        public frmRecuperarContraseña()
        {
            InitializeComponent();
        }

        private void btnRecuperar_Click(object sender, EventArgs e)
        {
            string email = "";

            if (!string.IsNullOrEmpty(txtEmail.Text)) email = txtEmail.Text;
            else MessageBox.Show("Ingrese el email!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            IDictionary<string, string> oUsuario = new Dictionary<string, string>
            {
                { Configuration.EMAIL, txtEmail.Text }
            };

            if(_securityController.RecoverPw(oUsuario).Item1)
            {
                MessageBox.Show("La contraseña se ha enviado a su correo electronico!");
            }
            else
            {
                MessageBox.Show("No se encontro la direccion ingresada", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            frmLogIn login = new frmLogIn();
            this.Hide();
            login.Show();
            
        }
    }
}