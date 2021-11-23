using Controller;
using GUI;
using System;
using System.Windows.Forms;

namespace GUI
{
    public partial class frmLoadingForm : Form
    {
        public frmLoadingForm()
        {
            InitializeComponent();
        }
        private readonly AdminController adminController = new();
        private readonly AlumnoController alumnoController = new();
        private readonly AsistenciaController asistenciaController = new();
        private readonly BackUpController backUpController = new();
        private readonly ClaseController claseController = new();
        private readonly DocenteController docenteController = new();
        private readonly EvaluacionController evaluacionController = new();
        private readonly MateriaController materiaController = new();
        private readonly SecurityController securityController = new();
        int pageNumber = 1;
        int pageSize = 10;

        private int puntoPartida = 0;

        private void timer1_Tick(object sender, EventArgs e)
        {
            puntoPartida += 3;
            progressBar.Value = puntoPartida;
            porcentajeLbl.Text = puntoPartida + "%";
            if (progressBar.Value == 99)
            {
                progressBar.Value = 0;
                timer1.Stop();
                try
                {
                    adminController.GetAdmins(pageNumber, pageSize);
                    alumnoController.GetALumnos(pageNumber, pageSize);
                    asistenciaController.GetAsistencias(pageNumber, pageSize);
                    backUpController.GetBackUps();
                    claseController.GetClases(pageNumber, pageSize);
                    docenteController.GetDocentes(pageNumber, pageSize);
                    evaluacionController.GetEvaluaciones(pageNumber, pageSize);
                    materiaController.GetMaterias(pageNumber, pageSize);
                    frmLogIn login = new frmLogIn();
                    this.Hide();
                    login.Show();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hubo un problema al iniciar la aplicacion!");
                    MessageBox.Show($"MENSAJE DE ERROR: {ex.Message}");
                    var BackUp = backUpController.GetUltimoBackUpId();
                    DialogResult dr = MessageBox.Show($"Desea restaurar la base de datos a un punto anterior donde la aplicacion funcionaba? (Ultimo BackUp: {BackUp.Fecha.ToString()})", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dr == DialogResult.Yes)
                    {
                        try
                        {
                            backUpController.RestoreBackUp(BackUp.Id);
                            MessageBox.Show("Se restauro el punto anterior correctamente!, vuelva a iniciar la aplicacion");
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Hubo un problema al restaurar la version anterior!");
                        }
                    }
                    Application.Exit();
                }
            }
        }

        private void LoadingForm_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void porcentajeLbl_Click(object sender, EventArgs e)
        {
        }
    }
}