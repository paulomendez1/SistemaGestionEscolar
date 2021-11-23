using BLL;
using System.Windows.Forms;

using System;
using Controller;
using Common;
using System.Drawing;

namespace GUI
{
    public partial class frmEvaluaciones : Form
    {
        private int _id;
        private string _parameter;
        private readonly EvaluacionController _evaluacionController = new();
        private readonly AlumnoController _alumnoController = new();
        private readonly MateriaController _materiaController = new();
        const int pageSize = 10;
        private int pageNumber = 1;

        public frmEvaluaciones(int id, string parameter)
        {
            InitializeComponent();
            _id = id;
            _parameter = parameter;
            if (SessionCache.Rol == 3)
            {
                btnAgregar.Enabled = false;
                btnAgregar.BackColor = Color.Red;
                btnEliminar.Enabled = false;
                btnEliminar.BackColor = Color.Red;
            }
            if (_parameter == "M")
            {
                lblForm.Text = "Buscar por Alumno:";
            }
            if (_parameter == "A")
            {
                lblForm.Text = "Buscar por Materia:";
            }
            llenarDGV();
            llenarCMB();
        }


        public void llenarDGV()
        {
            if (_parameter == "M")
            {
                dgvAlumnos.DataSource = _evaluacionController.GetEvalacionByMateria(_id);
            }
            if (_parameter == "A")
            {
                dgvAlumnos.DataSource = _evaluacionController.GetEvalacionByAlumno(_id);
                btnAgregar.Visible = false;
                btnAgregar.Enabled = false;
                btnAgregar.BackColor = Color.Red;
                btnEliminar.Visible = false;
                btnEliminar.Enabled = false;
                btnEliminar.BackColor = Color.Red;
            }
            this.dgvAlumnos.Columns[Configuration.ID].Visible = false;
        }
        public void llenarCMB()
        {
            if (_parameter == "M")
            {
                cmbForm.DataSource = _alumnoController.GetALumnos(pageNumber, pageSize);
                cmbForm.DisplayMember = "FullName";
                cmbForm.ValueMember = "id";
            }
            if (_parameter == "A")
            {
                cmbForm.DataSource = _materiaController.GetMaterias(pageNumber, pageSize);
                cmbForm.DisplayMember = "Nombre";
                cmbForm.ValueMember = "id";
            }
            
        }

        private void btnCancelar_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void btnAgregar_Click(object sender, System.EventArgs e)
        {
                frmCUEvaluacion cue = new frmCUEvaluacion(_id);
                cue.ShowDialog();
                llenarDGV();
        }

        private void btnEliminar_Click(object sender, System.EventArgs e)
        {
            int id = int.Parse(dgvAlumnos.Rows[dgvAlumnos.CurrentRow.Index].Cells[Configuration.ID].Value.ToString());
            DialogResult dr = MessageBox.Show($"Estas seguro que desea eliminar la evaluacion?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                _evaluacionController.DeleteEvaluacion(id);
            }
            llenarDGV();

        }

        private void btnBuscar_Click(object sender, System.EventArgs e)
        {
            string fecha = dateTimePicker1.Value.ToString("dd-MM-yyyy");
            dgvAlumnos.DataSource = _evaluacionController.GetEvaluacionByFecha(fecha);
          
        }

        private void btnBuscarCMB_Click(object sender, EventArgs e)
        {
            if (_parameter == "M")
            {
                int id = Convert.ToInt32(cmbForm.SelectedValue);
                dgvAlumnos.DataSource = _evaluacionController.GetEvalacionByAlumno(id);
            }
            if (_parameter == "A")
            {
                int id = Convert.ToInt32(cmbForm.SelectedValue);
                dgvAlumnos.DataSource = _evaluacionController.GetEvaluacionByAlumnoMateria(_id,id);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            llenarDGV();
        }
    }
}