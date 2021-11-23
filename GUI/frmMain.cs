using BLL;
using Common;
using Controller;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GUI
{
    public partial class Main : Form
    {
        private readonly BackUpController _backUpController = new();
        public Main()
        {
            InitializeComponent();
            sToolStripMenuItem.Text = $"Hola {SessionCache.Nombre} {SessionCache.Apellido}!";
            if (SessionCache.Rol != 1)
            {
                crearBackUpToolStripMenuItem.Visible = false;
                manejarAdminsToolStripMenuItem.Visible = false;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmAlumnos alms = new frmAlumnos();
            alms.Show();
        }

        private void btnDocentes_Click(object sender, EventArgs e)
        {
            if (SessionCache.Rol == 3)
            {
                MessageBox.Show("No tiene permiso para acceder");
            }
            else
            {
                frmListDocentes dcnte = new frmListDocentes();
            dcnte.Show();
            }
        }

        private void btnFinanzas_Click(object sender, EventArgs e)
        {
            if (SessionCache.Rol != 1)
            {
                MessageBox.Show("No tiene permiso para acceder");
            }
            else
            {
                frmFinanzas fnz = new frmFinanzas();
                fnz.Show();
            }
        }

        private void Main_Load(object sender, EventArgs e)
        {

        }

        private void btnMaterias_Click(object sender, EventArgs e)
        {
            if (SessionCache.Rol == 3)
            {
                MessageBox.Show("No tiene permiso para acceder");
            }
            else
            {
                frmMatYAsist frd = new frmMatYAsist();
                this.Hide();
                frd.ShowDialog();
                this.Show();
            }
        }

        private void sToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void configuracionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LogIn.frmNuevoPwoEmail frmLogin = new LogIn.frmNuevoPwoEmail();
            frmLogin.Show();
        }

        private void cerrarSesiónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAdministradores frmAdministradores = new frmAdministradores();
            frmAdministradores.Show();
        }

        private void crearBackUpToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void crearBackUpToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                _backUpController.CreateBackUp(DateTime.Now.ToString("dd-MM-yyyy"));
                MessageBox.Show("Se ha creado el punto de restauracion correctamente!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }

        private void recuperarVersionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBackUp frmBackUp = new frmBackUp();
            frmBackUp.Show();
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SessionCache.Email = null;
            SessionCache.Contraseña = null;
            SessionCache.Rol = 0;
            frmLogIn frmLogin = new frmLogIn();
            this.Close();
            frmLogin.Show();
        }
    }
}