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
    public partial class frmAviso : Form
    {
        private readonly AvisoController _avisoController = new();

        public frmAviso()
        {
            InitializeComponent();
            llenarDGV();
        }

        public void llenarDGV()
        {
            dgvMaterias.DataSource = _avisoController.GetAvisos(Configuration.NUMEROPAGINA, Configuration.TAMAÑOPAGINA);
            this.dgvMaterias.Columns[Configuration.ID].Visible = false;

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {

                frmCUAviso C = new frmCUAviso(null);
                C.ShowDialog();
                llenarDGV();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int id = int.Parse(dgvMaterias.Rows[dgvMaterias.CurrentRow.Index].Cells[Configuration.ID].Value.ToString());
            var materia = _avisoController.GetAviso(id);
            DialogResult dr = MessageBox.Show($"Estas seguro que desea eliminar el aviso?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                _avisoController.DeleteAviso(id);
            }
            llenarDGV();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
