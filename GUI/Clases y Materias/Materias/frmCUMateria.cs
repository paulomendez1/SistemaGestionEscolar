using BLL;
using Common;
using Controller;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace GUI
{
    public partial class frmCUMateria : Form
    {
        private readonly MateriaController _materiaController = new();
        private readonly DocenteController _docenteController = new();
        private readonly SecurityController _securityController = new();
        private int? _id;

        public frmCUMateria(int? ID)
        {
            InitializeComponent();
            _id = ID;
            if (_id != null)
            {
                cargarDatos(_id);
            }
            cargarDocente();
        }

        private void cargarDatos(int? _id)
        {
            var materia = _materiaController.GetMateria((int)_id);
            txtNombre.Text = materia.Nombre;
            cmbDocente.SelectedValue = _docenteController.GetDocente(materia.DocenteId);
        }

        private void cargarDocente()
        {
            cmbDocente.DataSource = _docenteController.GetDocentesCMB();
            cmbDocente.DisplayMember = "FullName";
            cmbDocente.ValueMember = "id";

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                string Nombre = "";


                if (!string.IsNullOrEmpty(txtNombre.Text)) Nombre = txtNombre.Text;
                else MessageBox.Show("Ingrese el Nombre!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                if (Nombre == "")
                {
                    MessageBox.Show("La materia no fue agregado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (_id != null)
                    {
                        var materia = _materiaController.GetMateria((int)_id);
                        IDictionary<string, string> oMateria = new Dictionary<string, string>
            {
                { Configuration.ID, _id.ToString() },
                { Configuration.NOMBRE, txtNombre.Text },
                { Configuration.DOCENTEID, cmbDocente.SelectedValue.ToString() }
                  };
                        _materiaController.UpdateMateria(oMateria);
                    }
                    else
                    {
                        IDictionary<string, string> oMateria = new Dictionary<string, string>
            {
                { Configuration.NOMBRE, txtNombre.Text },
                { Configuration.DOCENTEID, cmbDocente.SelectedValue.ToString() }
            };
                        _materiaController.AddMateria(oMateria);
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
    }
}