using BLL;
using Common;
using Controller;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GUI
{
    public partial class frmUServicio : Form
    {
        private readonly FinanzaController _finanzaController = new();
        public frmUServicio()
        {
            InitializeComponent();
            cargarDatos();
        }

        private void cargarDatos()
        {

            txtNombre.Text = _finanzaController.GetFinanza(1).ValorServicio.ToString();

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAgregar_Click_1(object sender, EventArgs e)
        {
            try
            {
                decimal Servicio = 0;

                if (!string.IsNullOrEmpty(txtNombre.Text))
                {
                    if (decimal.TryParse(txtNombre.Text, out Servicio))
                    {
                        var finanza = _finanzaController.GetFinanza(1);
                        IDictionary<string, string> oFinanza = new Dictionary<string, string>
                        {
                            { Configuration.ID, finanza.Id.ToString()},
                            { Configuration.VALORSERVICIO, Servicio.ToString() },
                            { Configuration.VALORCUOTA, finanza.ValorCuota.ToString() },
                        };
                        _finanzaController.UpdateFinanza(oFinanza);
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("El costo de servicio debe ser numerico!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else MessageBox.Show("Ingrese el Costo de Servicio!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);

              
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            }

        }
    }
