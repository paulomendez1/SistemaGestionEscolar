using System;
using System.Windows.Forms;
using BLL;
using System.Data;
using Common;
using System.Collections.Generic;
using Controller;

namespace GUI
{
    public partial class frmCUDocente : Form
    {
        private readonly DocenteController _docenteController = new();
        private readonly SecurityController _securityController = new();
        private int? _id;
        public frmCUDocente(int? id)
        {
            _id = id;
            InitializeComponent();
            if (_id != null)
            {
                CargarDatos(_id);
            }
        }

        private void CargarDatos(int? id)
        {
            var docente = _docenteController.GetDocente((int)id);
            var docenteMerge = _securityController.MergeUserReturnUser(docente.UsuarioId);
            txtNombre.Text = docente.Nombre;
            txtApellido.Text = docente.Apellido;
            txtEmail.Text = docenteMerge.Email;
            txtSueldo.Text = docente.Sueldo.ToString();
        }
        private void frmCUDocente_Load(object sender, EventArgs e)
        {
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try 
            { 
            string Nombre = "";
            string Apellido = "";
            string Email = "";
            int Sueldo = -1;

            if (!string.IsNullOrEmpty(txtNombre.Text)) Nombre = txtNombre.Text;
            else MessageBox.Show("Ingrese el Nombre!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            if (!string.IsNullOrEmpty(txtApellido.Text)) Apellido = txtApellido.Text;
            else MessageBox.Show("Ingrese el apellido!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            if (!string.IsNullOrEmpty(txtEmail.Text)) Email = txtEmail.Text;
            else MessageBox.Show("Ingrese el email!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            if (!string.IsNullOrEmpty(txtSueldo.Text))
            {
                try
                {
                    Sueldo = Convert.ToInt32(txtSueldo.Text);
                }
                catch
                {
                    MessageBox.Show("El formato del sueldo es incorrecto, ingrese solo numeros!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else MessageBox.Show("Ingrese el sueldo!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            if (Nombre == "" || Apellido == "" || Sueldo < 0)
            {
                MessageBox.Show("El Docente no fue agregado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (_id != null)
                {
                    var user = _docenteController.GetDocente((int)_id);
                    var userMerge = _securityController.MergeUserReturnUser(user.UsuarioId);
                    IDictionary<string, string> oDocente = new Dictionary<string, string>
            {
                { Configuration.ID, _id.ToString() },
                { Configuration.NOMBRE, txtNombre.Text },
                { Configuration.APELLIDO, txtApellido.Text },
                { Configuration.EMAIL, txtEmail.Text },
                { Configuration.CONTRASEÑA, userMerge.Contraseña },
                { Configuration.ROL, userMerge.Rol.ToString() },
                { Configuration.SUELDO, txtSueldo.Text }
                  };
                    _docenteController.UpdateDocente(oDocente);
                }
                else
                {
                    IDictionary<string, string> oDocente = new Dictionary<string, string>
            {
                { Configuration.NOMBRE, txtNombre.Text },
                { Configuration.APELLIDO, txtApellido.Text },
                { Configuration.EMAIL, txtEmail.Text },
                { Configuration.CONTRASEÑA, Encryption.RandomPW(4) },
                { Configuration.SUELDO, txtSueldo.Text }
            };
                    _docenteController.AddDocente(oDocente);
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
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}