using System;
using System.Windows.Forms;

namespace GUI
{
    public partial class frmMatYAsist : Form
    {
        public frmMatYAsist()
        {
            InitializeComponent();
        }

        private void btnAsistencia_Click(object sender, EventArgs e)
        {
            //if (oUsuario.RolId==3)
            //{
            //    MessageBox.Show("No tiene permiso para acceder");
            //}
            //else
            //{
                frmClase ast = new frmClase();
                ast.Show();
            //}
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMaterias_Click(object sender, EventArgs e)
        {
            frmMaterias mat = new frmMaterias();
            mat.Show();
        }
    }
}