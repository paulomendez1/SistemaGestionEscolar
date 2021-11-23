using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using BLL;
using Common;
using Controller;

namespace GUI
{
    public partial class frmAdministradores : Form
    {
        private readonly AdminController _adminController = new();
        private readonly SecurityController _securityController = new();
        const int pageSize = 10;
        private int pageNumber = 1;
        public frmAdministradores()
        {
            InitializeComponent();
            LlenarDGV();
            //if (SessionCache.Nombre=="admin")
            //{
            //    btnAgregar.Enabled = false;
            //    btnAgregar.BackColor = Color.Red;
            //    btnEliminar.Enabled = false;
            //    btnEliminar.BackColor = Color.Red;
            //}

        }
        public void LlenarDGV()
        {
                dgvAlumnos.DataSource = _adminController.GetAdmins(pageNumber, pageSize);
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


        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmCUAdministrador C = new frmCUAdministrador(null);
            C = new frmCUAdministrador(null);
            C.ShowDialog();
            LlenarDGV();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int id = int.Parse(dgvAlumnos.Rows[dgvAlumnos.CurrentRow.Index].Cells[Configuration.ID].Value.ToString());
            var admin = _adminController.GetAdmin(id);
            var adminUser = _securityController.MergeUserReturnUser(admin.UsuarioId);
            if (adminUser.Email == "admin")
            {
                MessageBox.Show("No se puede eliminar al administrador general!", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                DialogResult dr = MessageBox.Show($"Estas seguro que desea eliminar al administrador: {admin.Apellido}, {admin.Nombre}", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    _adminController.DeleteAdmin(id);
                    _securityController.DeleteUser(admin.UsuarioId);
                }
            }
            LlenarDGV();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            int id = int.Parse(dgvAlumnos.Rows[dgvAlumnos.CurrentRow.Index].Cells[Configuration.ID].Value.ToString());
            frmCUAdministrador frmCUAdministrador = new frmCUAdministrador(id);
            frmCUAdministrador.ShowDialog();
            LlenarDGV();
        }



        private void nextPage_Click(object sender, EventArgs e)
        {
            pageNumber++;
            dgvAlumnos.DataSource = _adminController.GetAdmins(pageNumber, pageSize);
            actualPage.Text = pageNumber.ToString();
            previousPage.Enabled = true;
            firstPage.Enabled = true;
        }

        private void lastPage_Click(object sender, EventArgs e)
        {
            pageNumber = -1;
            dgvAlumnos.DataSource = _adminController.GetAdmins(pageNumber, pageSize);
            actualPage.Text = pageNumber.ToString();
        }

        private void previousPage_Click(object sender, EventArgs e)
        {
            pageNumber--;
            dgvAlumnos.DataSource = _adminController.GetAdmins(pageNumber, pageSize);
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
            dgvAlumnos.DataSource = _adminController.GetAdmins(1, pageSize);
            actualPage.Text = 1.ToString();
            previousPage.Enabled = false;
            firstPage.Enabled = false;
        }

        private void btnAgregar_MouseHover(object sender, EventArgs e)
        {
     
        }
    }
}