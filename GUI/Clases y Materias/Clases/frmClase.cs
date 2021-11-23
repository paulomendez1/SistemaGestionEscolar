using BLL;
using Common;
using Controller;
using GUI.Clases_y_Materias.Clases.Asistencia;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace GUI
{
    public partial class frmClase : Form
    {

        private readonly ClaseController _claseController = new();
        private readonly AsistenciaController _asistenciaController = new();
        const int pageSize = 10;
        private int pageNumber = 1;

        public frmClase()
        {
            InitializeComponent();
            llenarDGV();
            if (SessionCache.Rol != 1)
            {
                button2.Enabled = false;
                button2.BackColor = Color.Red;
            }
        }

        public void llenarDGV()
        {
            dgvAlumnos.DataSource = _claseController.GetClases(pageNumber, pageSize);
            actualPage.Text = pageNumber.ToString();
            if (pageNumber == 1)
            {
                previousPage.Enabled = false;
                firstPage.Enabled = false;
            }
            else
            {
                previousPage.Enabled = true;
                firstPage.Enabled = true;
            }
            this.dgvAlumnos.Columns[Configuration.ID].Visible = false;


        }

        private void btnCancelar_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void btnAgregar_Click(object sender, System.EventArgs e)
        {
            string fecha = dateTimePicker1.Value.ToShortDateString();
            frmCUClase CUC = new frmCUClase(null);
            CUC.ShowDialog();
            llenarDGV();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string fecha = dateTimePicker1.Value.ToString("dd-MM-yyyy");
            dgvAlumnos.DataSource = _claseController.GetClaseByDate(fecha);
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            llenarDGV();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int id = int.Parse(dgvAlumnos.Rows[dgvAlumnos.CurrentRow.Index].Cells[Configuration.ID].Value.ToString());
            var clase = _claseController.GetClase(id);
            DialogResult dr = MessageBox.Show($"Estas seguro que desea eliminar la clase de la fecha: {clase.Fecha}", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                _claseController.DeleteClase(id);
            }
            llenarDGV();
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            int id = int.Parse(dgvAlumnos.Rows[dgvAlumnos.CurrentRow.Index].Cells[Configuration.ID].Value.ToString());
            frmAsistencia Asist = new frmAsistencia(null,id);
            Asist.ShowDialog();
        }
    }
}