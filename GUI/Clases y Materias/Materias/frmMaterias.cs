using BLL;
using Common;
using Controller;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace GUI
{
    public partial class frmMaterias : Form
    {

        private readonly MateriaController _materiaController = new();
        private readonly DocenteController _docenteController = new();
        const int pageSize = 10;
        private int pageNumber = 1;

        public frmMaterias()
        {
            InitializeComponent();

            if (SessionCache.Rol != 1)
                {
                btnAgregar.Enabled = false;
                btnAgregar.BackColor = Color.Red;
                btnEliminar.Enabled = false;
                btnEliminar.BackColor = Color.Red;
                btnModificar.Enabled = false;
                btnModificar.BackColor = Color.Red;
            }
            if (SessionCache.Rol == 3)
            {
                btnCalificaciones.Visible = false;
                pictureBox1.Visible = false;
            }
                llenarDGV();

        }
        public void llenarDGV()
        {
            dgvMaterias.DataSource = _materiaController.GetMaterias(pageNumber, pageSize);
            this.dgvMaterias.Columns[Configuration.ID].Visible = false;

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmCUMateria C = new frmCUMateria(null);
            C.ShowDialog();
            llenarDGV();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            int? id = int.Parse(dgvMaterias.Rows[dgvMaterias.CurrentRow.Index].Cells[Configuration.ID].Value.ToString());
            if (id != null)
            {
                frmCUMateria U = new frmCUMateria(id);
                U.ShowDialog();
            }
            llenarDGV();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int id = int.Parse(dgvMaterias.Rows[dgvMaterias.CurrentRow.Index].Cells[Configuration.ID].Value.ToString());
            var materia = _materiaController.GetMateria(id);
            DialogResult dr = MessageBox.Show($"Estas seguro que desea eliminar la materia: {materia.Nombre}", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                _materiaController.DeleteMateria(id);
            }
            llenarDGV();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void btnCalificaciones_Click(object sender, EventArgs e)

        {
            int id = int.Parse(dgvMaterias.Rows[dgvMaterias.CurrentRow.Index].Cells[Configuration.ID].Value.ToString());
            var materia = _materiaController.GetMateria(id);
            var docente = _docenteController.GetDocente(materia.DocenteId);
            if (SessionCache.Rol != 1 && docente.UsuarioId != SessionCache.Id)
            {
                MessageBox.Show("No tiene permisos para acceder");
            }
            else
            {
                frmEvaluaciones fre = new frmEvaluaciones(id, "M");
                fre.ShowDialog();
            }
           
        }

        private void nextPage_Click(object sender, EventArgs e)
        {

        }
    }
}