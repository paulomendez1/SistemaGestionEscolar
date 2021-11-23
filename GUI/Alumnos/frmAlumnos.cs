using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using BLL;
using Common;
using Controller;
using GUI.Alumnos;
using GUI.Clases_y_Materias.Clases.Asistencia;

namespace GUI
{
    public partial class frmAlumnos : Form
    {
        private readonly AlumnoController _alumnoController = new();
        private readonly SecurityController _securityController = new();
        const int pageSize = 10;
        private int pageNumber = 1;
        public frmAlumnos()
        {
            InitializeComponent();
            LlenarDGV();
            if (SessionCache.Rol == 3)
            {
                txtBuscar.Enabled = false;
                btnAgregar.Enabled = false;
                btnAgregar.BackColor = Color.Red;
                btnEliminar.Enabled = false;
                btnEliminar.BackColor = Color.Red;
            }
            if (SessionCache.Rol == 2)
            {
                btnAgregar.Enabled = false;
                btnAgregar.BackColor = Color.Red;
                btnEliminar.Enabled = false;
                btnEliminar.BackColor = Color.Red;
                btnModificar.Enabled = false;
                btnModificar.BackColor = Color.Red;
            }

        }
        public void LlenarDGV()
        {
            if (SessionCache.Rol != 3)
            {
                dgvAlumnos.DataSource = _alumnoController.GetALumnos(pageNumber, pageSize);
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

            else
            {
                dgvAlumnos.DataSource = _alumnoController.GetAlumnoByUserId(SessionCache.Id);
                this.dgvAlumnos.Columns[Configuration.ID].Visible = false;
            }
            this.dgvAlumnos.Columns[Configuration.ID].Visible = false;
            this.dgvAlumnos.Columns[Configuration.FULLNAME].Visible = false;
       }
        private void dgvAlumnos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            foreach (DataGridViewRow item in dgvAlumnos.Rows)
            {
                int asistencia;
                if (int.TryParse(item.Cells[4].Value.ToString(), out asistencia))
                {
                    if (asistencia > 60)
                    {
                        item.Cells[4].Style.ForeColor = Color.Green;
                        item.Cells[4].Style.SelectionForeColor = Color.Green; 
                    }
                    else
                    {
                        item.Cells[4].Style.ForeColor = Color.Red;
                        item.Cells[4].Style.SelectionForeColor = Color.Red;
                    }
                }
                int promedio;
                if (int.TryParse(item.Cells[3].Value.ToString(), out promedio))
                {
                    if (promedio > 6)
                    {
                        item.Cells[3].Style.ForeColor = Color.Green;
                        item.Cells[3].Style.SelectionForeColor = Color.Green;
                    }
                    else if (promedio <6 && promedio>4)
                    {
                        item.Cells[3].Style.ForeColor = Color.Yellow;
                        item.Cells[3].Style.SelectionForeColor = Color.Yellow;
                    }
                    else
                    {
                        item.Cells[3].Style.ForeColor = Color.Red;
                        item.Cells[3].Style.SelectionForeColor = Color.Red;
                    }
                }
            }
        }


        private void btnAgregar_Click_1(object sender, EventArgs e)
        {

                frmCUAAlumno C = new frmCUAAlumno(null);
                C = new frmCUAAlumno(null);
                C.ShowDialog();
                LlenarDGV();
           
        }

        private void nextPage_Click_1(object sender, EventArgs e)
        {
            pageNumber++;
            dgvAlumnos.DataSource = _alumnoController.GetALumnos(pageNumber, pageSize);
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

        private void txtBuscar_TextChanged_1(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtBuscar.Text))
            {
                dgvAlumnos.DataSource = _alumnoController.GetAlumnoByName(txtBuscar.Text);
            }
            else
            {
                LlenarDGV();
            }
        }

        private void firstPage_Click_1(object sender, EventArgs e)
        {
            pageNumber = 1;
            dgvAlumnos.DataSource = _alumnoController.GetALumnos(1, pageSize);
            actualPage.Text = 1.ToString();
            previousPage.Enabled = false;
            firstPage.Enabled = false;

        }

        private void previousPage_Click_1(object sender, EventArgs e)
        {
            pageNumber--;
            dgvAlumnos.DataSource = _alumnoController.GetALumnos(pageNumber, pageSize);
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

        private void btnCancelar_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnModificar_Click_1(object sender, EventArgs e)
        {
            int id = int.Parse(dgvAlumnos.Rows[dgvAlumnos.CurrentRow.Index].Cells[Configuration.ID].Value.ToString());
            frmCUAAlumno frmCUAlumno = new frmCUAAlumno(id);
            frmCUAlumno.ShowDialog();
            LlenarDGV();
        }

        private void btnEliminar_Click_1(object sender, EventArgs e)
        {
            int id = int.Parse(dgvAlumnos.Rows[dgvAlumnos.CurrentRow.Index].Cells[Configuration.ID].Value.ToString());
            var alumno = _alumnoController.GetAlumno(id);
            DialogResult dr = MessageBox.Show($"Estas seguro que desea eliminar al alumno: {alumno.Apellido}, {alumno.Nombre}", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                _alumnoController.DeleteAlumno(id);
                _securityController.DeleteUser(alumno.UsuarioId);
            }
            LlenarDGV();
        }

        private void lastPage_Click_1(object sender, EventArgs e)
        {
            pageNumber = 1;
            dgvAlumnos.DataSource = _alumnoController.GetALumnos(pageNumber, pageSize);
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

        private void btnCalificaciones_Click_1(object sender, EventArgs e)
        {
            int id = int.Parse(dgvAlumnos.Rows[dgvAlumnos.CurrentRow.Index].Cells[Configuration.ID].Value.ToString());
            frmEvaluaciones fre = new frmEvaluaciones(id, "A");
            fre.ShowDialog();
        }

        private void dgvAlumnos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            frmAlumnosHelp frmah = new frmAlumnosHelp();
            frmah.ShowDialog();
        }

        private void btnAsistencia_Click(object sender, EventArgs e)
        {
            int id = int.Parse(dgvAlumnos.Rows[dgvAlumnos.CurrentRow.Index].Cells[Configuration.ID].Value.ToString());
            frmAsistencia frmA = new frmAsistencia(id,null);
            frmA.ShowDialog();
        }
    }
}