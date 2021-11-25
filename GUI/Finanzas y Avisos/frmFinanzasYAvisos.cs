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
    public partial class frmFinanzasYAvisos : Form
    {
        public frmFinanzasYAvisos()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAvisos_Click(object sender, EventArgs e)
        {
            frmAviso aviso = new frmAviso();
            aviso.Show();

        }

        private void btnFinanzas_Click(object sender, EventArgs e)
        {
            frmFinanzas finanza = new frmFinanzas();
            finanza.Show();
        }
    }
}
