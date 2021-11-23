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

namespace GUI.Clases_y_Materias.Clases.Asistencia
{
    public partial class frmAsistencia : Form
    {
        private readonly AsistenciaController _asistenciaController = new();
        private int? _alumnoId;
        private int? _claseId;
        public frmAsistencia(int? alumnoId, int? claseId)
        {
            InitializeComponent();
            _alumnoId = alumnoId;
            _claseId = claseId;
            LlenarDGV();
        }

        public void LlenarDGV()
        {
            if (_alumnoId != null)
            {
                dgvAlumnos.DataSource = _asistenciaController.GetAsistenciaByAlumno((int)_alumnoId);
            }
            else
            {
                dgvAlumnos.DataSource = _asistenciaController.GetAsistenciaByClase((int)_claseId);
            }
            this.dgvAlumnos.Columns[Configuration.ID].Visible = false;

        }

        private void dgvAlumnos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            foreach (DataGridViewRow item in dgvAlumnos.Rows)
            {
                string asistencia = item.Cells[3].Value.ToString();

                    if (asistencia == "1" || asistencia == "SI")
                    {
                        item.Cells[3].Value = "SI";
                        item.Cells[3].Style.ForeColor = Color.Green;
                        item.Cells[3].Style.SelectionForeColor = Color.Green;
                    }
                    else
                    {
                        item.Cells[3].Value = "NO";
                        item.Cells[3].Style.ForeColor = Color.Red;
                        item.Cells[3].Style.SelectionForeColor = Color.Red;
                    }
               
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvAlumnos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {

        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LlenarDGV();
        }
    }
}
