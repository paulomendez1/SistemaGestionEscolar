using BLL;
using Common;
using Controller;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GUI
{
    public partial class frmUCuota : Form
    {
        private readonly FinanzaController _finanzaController = new();
        public frmUCuota()
        {
            InitializeComponent();
            cargarDatos();
        }

        private void cargarDatos()
        {

            txtNombre.Text = _finanzaController.GetFinanza(1).ValorCuota.ToString();

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                decimal Cuota = 0;

                if (!string.IsNullOrEmpty(txtNombre.Text))
                {
                    if (decimal.TryParse(txtNombre.Text, out Cuota))
                    {
                        var finanza = _finanzaController.GetFinanza(1);
                        IDictionary<string, string> oFinanza = new Dictionary<string, string>
                        {
                            { Configuration.ID, finanza.Id.ToString()},
                            { Configuration.VALORSERVICIO, finanza.ValorServicio.ToString() },
                            { Configuration.VALORCUOTA, Cuota.ToString() },
                        };
                        _finanzaController.UpdateFinanza(oFinanza);
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("El valor de la cuota debe ser numerico!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else MessageBox.Show("Ingrese la cuota!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);

               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

    

    private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}