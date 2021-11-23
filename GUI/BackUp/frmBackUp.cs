using BLL;
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

namespace GUI
{
    public partial class frmBackUp : Form
    {
        private readonly BackUpController _backUpController = new();
        public frmBackUp()
        {
            InitializeComponent();
            LlenarDGV();
        }

        private void LlenarDGV()
        {
            dgvBackUp.DataSource = _backUpController.GetBackUps();
            this.dgvBackUp.Columns[Configuration.ID].Visible = false;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRestaurar_Click(object sender, EventArgs e)
        {
            int id = int.Parse(dgvBackUp.Rows[dgvBackUp.CurrentRow.Index].Cells[Configuration.ID].Value.ToString());
            try
            {
                _backUpController.RestoreBackUp(id);
                MessageBox.Show("El BackUp se restauro correctamente, reinicie la aplicacion para ver los cambios");
            }
            catch (Exception)
            {
                MessageBox.Show("La restauracion fallo!, intente nuevamente");
            }
            LlenarDGV();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int id = int.Parse(dgvBackUp.Rows[dgvBackUp.CurrentRow.Index].Cells[Configuration.ID].Value.ToString());
            DialogResult dr = MessageBox.Show($"Estas seguro que desea eliminar el BackUp?", "Eliminar", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                _backUpController.DeleteBackUp(id);
            }
                LlenarDGV();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LlenarDGV();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            dgvBackUp.DataSource = _backUpController.GetBackUpByDate(dateTimePicker1.Value);
        }
    }
}
