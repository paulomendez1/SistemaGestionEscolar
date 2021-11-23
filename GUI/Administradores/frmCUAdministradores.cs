using System;
using System.Windows.Forms;
using BLL;
using System.Data;
using Common;
using Controller;
using System.Collections.Generic;

namespace GUI
{
    public partial class frmCUAdministrador : Form
    {
        private readonly AdminController _adminController = new();
        private readonly SecurityController _securityController = new();
        private int? _id;
        

        public frmCUAdministrador(int? id)
        {
            _id = id;
            InitializeComponent();
            if (_id != null)
            {
                CargarDatos(_id);
            }
        }

        private void CargarDatos(int? _id)
        {
            var admin = _adminController.GetAdmin((int)_id);
            var adminMerge = _securityController.MergeUserReturnUser(admin.UsuarioId);
            txtNombre.Text = admin.Nombre;
            txtApellido.Text = admin.Apellido;
            txtEmail.Text = adminMerge.Email;
            txtCargo.Text = admin.Cargo;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string Nombre = "";
            string Apellido = "";
            string Email = "";
            int Sueldo = -1;
            string Cargo = "";

            if (!string.IsNullOrEmpty(txtNombre.Text)) Nombre = txtNombre.Text;
            else MessageBox.Show("Ingrese el Nombre!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            if (!string.IsNullOrEmpty(txtApellido.Text)) Apellido = txtApellido.Text;
            else MessageBox.Show("Ingrese el apellido!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            if (!string.IsNullOrEmpty(txtEmail.Text)) Email = txtEmail.Text;
            else MessageBox.Show("Ingrese el email!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            if (!string.IsNullOrEmpty(txtCargo.Text)) Cargo = txtEmail.Text;
            else MessageBox.Show("Ingrese el cargo!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);


            if (Nombre == "" || Apellido == "" || Email == "" || Cargo == "" || Sueldo <0)
            {
                MessageBox.Show("El Docente no fue agregado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (_id != null)
                {
                    var user = _adminController.GetAdmin((int)_id);
                    var userMerge = _securityController.MergeUserReturnUser(user.UsuarioId);
                    IDictionary<string, string> oAdmin = new Dictionary<string, string>
            {
                { Configuration.ID, _id.ToString() },
                { Configuration.NOMBRE, txtNombre.Text },
                { Configuration.APELLIDO, txtApellido.Text },
                { Configuration.EMAIL, txtEmail.Text },
                { Configuration.CONTRASEÑA, userMerge.Contraseña  },
                { Configuration.ROL, userMerge.RolId.ToString() },
                { Configuration.CARGO, user.Cargo.ToString() },
                { Configuration.USUARIOID, userMerge.Id.ToString() }
                  };
                    _adminController.UpdateAdmin(oAdmin);
                }
                else
                {
                    IDictionary<string, string> oAdmin = new Dictionary<string, string>
            {
                { Configuration.NOMBRE, txtNombre.Text },
                { Configuration.APELLIDO, txtApellido.Text },
                { Configuration.EMAIL, txtEmail.Text },
                { Configuration.CONTRASEÑA, Encryption.RandomPW(4) },
                { Configuration.CARGO, txtCargo.Text },
            };
                    _adminController.AddAdmin(oAdmin);
                }
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}