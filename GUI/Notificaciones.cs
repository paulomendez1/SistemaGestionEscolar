using Common;
using Controller;
using GUI.Finanzas_y_Avisos;
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
    public partial class Notificaciones : Form
    {
        private readonly AvisoController _avisoController = new();
        public Notificaciones()
        {
            InitializeComponent();
            llenarDGV();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void llenarDGV()
        {
            if (SessionCache.Rol==3)
            {
                dgvMaterias.DataSource = _avisoController.GetAvisosAlumnos(Configuration.NUMEROPAGINA, Configuration.TAMAÑOPAGINA);
                this.dgvMaterias.Columns[Configuration.ID].Visible = false;
            }
            else
            {
                dgvMaterias.DataSource = _avisoController.GetAvisosDocentes(Configuration.NUMEROPAGINA, Configuration.TAMAÑOPAGINA);
                this.dgvMaterias.Columns[Configuration.ID].Visible = false;
            }
            

        }

        private void btnExpandir_Click(object sender, EventArgs e)
        {
            int id = int.Parse(dgvMaterias.Rows[dgvMaterias.CurrentRow.Index].Cells[Configuration.ID].Value.ToString());
            frmCUAviso aviso = new frmCUAviso(id);
            aviso.Show();
        }
    }
}
