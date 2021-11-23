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
    public partial class frmListDocentes : Form
    {
        private readonly DocenteController _docenteController = new();
        const int pageSize = 10;
        private int pageNumber = 1;
        public frmListDocentes()
        {
            InitializeComponent();

                llenarDGV();
            if (SessionCache.Rol != 1)
            {
                txtBuscar.Enabled = false;
                btnAgregar.Enabled = false;
                btnAgregar.BackColor = Color.Red;
                btnEliminar.Enabled = false;
                btnEliminar.BackColor = Color.Red;
            }
        }

        public void llenarDGV()
        {
            if (SessionCache.Rol == 1)
            {
                dgvDocente.DataSource = _docenteController.GetDocentes(pageNumber, pageSize);
         
            }
            else
            {
                dgvDocente.DataSource = _docenteController.GetDocenteByUserId(SessionCache.Id);
            }
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
            this.dgvDocente.Columns[Configuration.ID].Visible = false;
            this.dgvDocente.Columns[Configuration.FULLNAME].Visible = false;
        }

        public void DGVDocente()
        {
            

        }

        private void btnCancelar_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAgregar_Click_1(object sender, EventArgs e)
        {
            frmCUDocente frmCUDocente = new frmCUDocente(null);
            frmCUDocente.ShowDialog();
        }

        private void btnModificar_Click_1(object sender, EventArgs e)
        {
            int id = int.Parse(dgvDocente.Rows[dgvDocente.CurrentRow.Index].Cells[Configuration.ID].Value.ToString());
            frmCUDocente frmCUDocente = new frmCUDocente(id);
            frmCUDocente.ShowDialog();
        }

        private void btnEliminar_Click_1(object sender, EventArgs e)
        {
            int id = int.Parse(dgvDocente.Rows[dgvDocente.CurrentRow.Index].Cells[Configuration.ID].Value.ToString());
            var docente = _docenteController.GetDocente(id);
            DialogResult dr = MessageBox.Show($"Estas seguro que desea eliminar al docente: {docente.Apellido}, {docente.Nombre}", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                _docenteController.DeleteDocente(id);
            }
            llenarDGV();
        }

        private void txtBuscar_TextChanged_1(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtBuscar.Text))
            {
                dgvDocente.DataSource= _docenteController.GetDocenteByName(txtBuscar.Text);
            }
            else
            {
                llenarDGV();
            }


        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            
        }

        private void btnMaterias_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            pageNumber --;
            dgvDocente.DataSource = _docenteController.GetDocentes(pageNumber, pageSize);
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
        }

        private void firstPage_Click(object sender, EventArgs e)
        {
            pageNumber = 1;
            dgvDocente.DataSource = _docenteController.GetDocentes(1, pageSize);
            actualPage.Text = 1.ToString();
            previousPage.Enabled = false;
            firstPage.Enabled = false;
        }

        private void nextPage_Click(object sender, EventArgs e)
        {
            pageNumber ++;
            dgvDocente.DataSource = _docenteController.GetDocentes(pageNumber, pageSize);
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
        }

        private void lastPage_Click(object sender, EventArgs e)
        {
            pageNumber = 1;
            dgvDocente.DataSource = _docenteController.GetDocentes(pageNumber, pageSize);
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
        }
    }
}