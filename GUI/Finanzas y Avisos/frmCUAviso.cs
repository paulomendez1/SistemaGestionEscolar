using Common;
using Controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI.Finanzas_y_Avisos
{
    public partial class frmCUAviso : Form
    {
        private readonly AvisoController _avisoController = new();
        public frmCUAviso(int? id)
        {
            InitializeComponent();
            if (SessionCache.Rol != 1)
            {
                btnAgregar.Visible = false;
                txtLeyenda.ReadOnly = true;
                cmbSuscriptores.Visible = false;
                label4.Visible = false;
                dateTimePicker1.Visible = false;
                label2.Visible = false;
            }
            if (id!=null)
            {
                CargarDatos((int)id);
            }
        }
        
        private void CargarDatos(int id)
        {
            var aviso = _avisoController.GetAviso(id);
            txtLeyenda.Text = aviso.Leyenda;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                string Leyenda = "";


                if (!string.IsNullOrEmpty(txtLeyenda.Text)) Leyenda = txtLeyenda.Text;
                else MessageBox.Show("Escribe algo en la leyenda!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                if (Leyenda == "")
                {
                    MessageBox.Show("El aviso no fue mandado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    int Suscriptorid = 9;
                    if (cmbSuscriptores.Text == "Alumnos")
                    {
                        Suscriptorid = 3;
                    }
                    if (cmbSuscriptores.Text == "Docentes")
                    {
                        Suscriptorid = 2;
                    }
                    if (cmbSuscriptores.Text == "Ambos")
                    {
                        IDictionary<string, string> oAviso2 = new Dictionary<string, string>
            {
                { Configuration.LEYENDA, txtLeyenda.Text },
                { Configuration.FECHA, dateTimePicker1.Value.ToString("dd-MM-yyyy")},
                { Configuration.SUSCRIPTORESID, "2" }
            };
                        IDictionary<string, string> oAviso3 = new Dictionary<string, string>
            {
                { Configuration.LEYENDA, txtLeyenda.Text },
                { Configuration.FECHA, dateTimePicker1.Value.ToString("dd-MM-yyyy")},
                { Configuration.SUSCRIPTORESID, "3" }
            };
                        _avisoController.AddAviso(oAviso2);
                        _avisoController.AddAviso(oAviso3);
                    }
                    else
                    {
                        IDictionary<string, string> oAviso = new Dictionary<string, string>
            {
                { Configuration.LEYENDA, txtLeyenda.Text },
                { Configuration.FECHA, dateTimePicker1.Value.ToString("dd-MM-yyyy")},
                { Configuration.SUSCRIPTORESID, Suscriptorid.ToString() }
            };
                        _avisoController.AddAviso(oAviso);
                    }
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
