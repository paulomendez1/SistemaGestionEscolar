using System;
using System.Windows.Forms;
using BLL;
using System.Data;
using Common;
using Controller;
using System.Collections.Generic;

namespace GUI
{
    public partial class frmCUAAlumno : Form
    {
        private readonly AlumnoController _alumnoController = new();
        private readonly SecurityController _securityController = new();
        private int? _id;
        

        public frmCUAAlumno(int? id)
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
            var alumno = _alumnoController.GetAlumno((int)_id);
            var alumnoMerge = _securityController.MergeUserReturnUser(alumno.UsuarioId);
            txtNombre.Text = alumno.Nombre;
            txtApellido.Text = alumno.Apellido;
            txtEmail.Text = alumnoMerge.Email;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                string Nombre = "";
                string Apellido = "";
                string Email = "";

                if (!string.IsNullOrEmpty(txtNombre.Text)) Nombre = txtNombre.Text;
                else MessageBox.Show("Ingrese el Nombre!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                if (!string.IsNullOrEmpty(txtApellido.Text)) Apellido = txtApellido.Text;
                else MessageBox.Show("Ingrese el apellido!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                if (!string.IsNullOrEmpty(txtEmail.Text)) Email = txtEmail.Text;
                else MessageBox.Show("Ingrese el email!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                if (!CommonValidations.ValidateEmail(txtEmail.Text))
                {
                    Email = "";
                    MessageBox.Show("El formato de la direccion de correo electronico es invalido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }

                if (Nombre == "" || Apellido == "" || Email == "")
                {
                    MessageBox.Show("El Alumno no fue agregado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (_id != null)
                    {
                        var user = _alumnoController.GetAlumno((int)_id);
                        var userMerge = _securityController.MergeUserReturnUser(user.UsuarioId);
                        IDictionary<string, string> oAlumno = new Dictionary<string, string>
            {
                { Configuration.ID, _id.ToString() },
                { Configuration.NOMBRE, txtNombre.Text },
                { Configuration.APELLIDO, txtApellido.Text },
                { Configuration.EMAIL, txtEmail.Text },
                { Configuration.CONTRASEÑA, userMerge.Contraseña },
                { Configuration.ROL, userMerge.RolId.ToString() },
                { Configuration.USUARIOID, userMerge.Id.ToString() }
                  };
                        _alumnoController.UpdateAlumno(oAlumno);
                    }
                    else
                    {
                        IDictionary<string, string> oAlumno = new Dictionary<string, string>
            {
                { Configuration.NOMBRE, txtNombre.Text },
                { Configuration.APELLIDO, txtApellido.Text },
                { Configuration.EMAIL, txtEmail.Text },
                { Configuration.CONTRASEÑA, Encryption.RandomPW(4) }
            };
                        _alumnoController.AddAlumno(oAlumno);
                    }
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

}

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void txtApellido_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}