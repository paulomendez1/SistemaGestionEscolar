using BLL;
using Common;
using Controller;
using GUI.Finanzas_y_Avisos;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GUI
{
    public partial class Main : Form
    {
        private readonly BackUpController _backUpController = new();
        private readonly AvisoController _avisoController = new();
        private int Notificaciones;
        public Main()
        {
            InitializeComponent();
            dataGridView1.Visible = false;
            sToolStripMenuItem.Text = $"Hola {SessionCache.Nombre} {SessionCache.Apellido}!";
            if (SessionCache.Rol != 1)
            {
                crearBackUpToolStripMenuItem.Visible = false;
                manejarAdminsToolStripMenuItem.Visible = false;
            }
            if (SessionCache.Rol == 1)
            {
                btnAvisos.Visible = false;
                btnNotificaciones.Visible = false;
            }
            Notifies(SessionCache.Rol);
        }

        private void Notifies(int id)
        {
            if (id == 2)
            {
                dataGridView1.DataSource = _avisoController.GetAvisos(null, null);
                foreach (DataGridViewRow item in dataGridView1.Rows)
                {
                    if (item.Cells[3].Value.ToString() == "Docentes")
                    {
                        if (DateTime.ParseExact(item.Cells[2].Value.ToString(), "dd-MM-yyyy", null) > DateTime.Now.Date.AddDays(-3))
                        {
                            Notificaciones++;
                        }
                    }
                }
                if (Notificaciones == 0)
                {
                    btnNotificaciones.Visible = false;
                }
                else
                {
                    btnNotificaciones.Text = Notificaciones.ToString();
                }
            }
            else
            {
                dataGridView1.DataSource = _avisoController.GetAvisos(null, null);
                foreach (DataGridViewRow item in dataGridView1.Rows)
                {
                    if (item.Cells[3].Value.ToString() == "Alumnos")
                    {
                        if (DateTime.ParseExact(item.Cells[2].Value.ToString(), "dd-MM-yyyy", null) > DateTime.Now.Date.AddDays(-3))
                        {
                            Notificaciones++;
                        }
                    }
                }
                if (Notificaciones == 0)
                {
                    btnNotificaciones.Visible = false;
                }
                else
                {
                    btnNotificaciones.Text = Notificaciones.ToString();
                }
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
                frmFinanzasYAvisos fnz = new frmFinanzasYAvisos();
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

        private void btnAvisos_Click(object sender, EventArgs e)
        {
            Notificaciones not = new Notificaciones();
            not.Show();
        }
    }
}