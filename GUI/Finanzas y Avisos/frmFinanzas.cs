using BLL;
using Controller;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace GUI
{
    public partial class frmFinanzas : Form
    {
        private readonly FinanzaController _finanzaController = new();
        public frmFinanzas()
        {
            InitializeComponent();
            Calculo();
        }

        private void Calculo()
        {
            lblAlumno.Text = _finanzaController.GetTotalAlumnos().ToString();
            lblCuota.Text = _finanzaController.GetFinanza(1).ValorCuota.ToString();
            lblDocente.Text = _finanzaController.GetTotalDocentes().ToString();
            lblSueldoDoc.Text = $"$ { _finanzaController.GetTotalSueldoDocentes().ToString()}";
            lblServicio.Text = $"$ {_finanzaController.GetFinanza(1).ValorServicio.ToString()}";
            lblIngreso.Text = $"$ {_finanzaController.GetTotalIngresos().ToString()}";
            lblEgreso.Text = $"$ {_finanzaController.GetTotalEgresos().ToString()}";
            lblTotal.Text = $"$ {_finanzaController.GetTotal().ToString()}";
            if (_finanzaController.GetTotal()>=0)
            {
                lblTotal.ForeColor = Color.Green;
            }
            else
            {
                lblTotal.ForeColor = Color.Red;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCuota_Click(object sender, EventArgs e)
        {
            frmUCuota frmC = new frmUCuota();
            frmC.ShowDialog();
            Calculo();
        }

        private void btnCosto_Click(object sender, EventArgs e)
        {
            frmUServicio frmS = new frmUServicio();
            frmS.ShowDialog();
            Calculo();
        }
    }
}