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
    public partial class frmCUEvaluacion : Form
    {
        //Materia oMateria = new Materia();
        //Docente oDocente = new Docente();
        //Usuario oUsuario = new Usuario();
        //Evaluacion oEvaluacion = new Evaluacion();
        //EvaluacionBLL EvaluacionBLL = new EvaluacionBLL();
        private readonly DocenteController _docenteController = new();
        private readonly MateriaController _materiaController = new();
        private readonly AlumnoController _alumnoController = new();
        private readonly EvaluacionController _evaluacionController = new();
        private int _id;
        public frmCUEvaluacion(int id)
        {
            InitializeComponent();
            _id = id;
            var materia = _materiaController.GetMateria(_id);
            if (SessionCache.Rol == 1)
            {
                lblDocente.Text = "Administrador";
            }
            else
            {

                lblDocente.Text = $"{_docenteController.GetDocente(materia.DocenteId).Nombre} {_docenteController.GetDocente(materia.DocenteId).Apellido}";
            }
            lblMateria.Text = $"{materia.Nombre}";

            cargarAlumno();

        }

        private void cargarAlumno()
        {

            cmbAlumno.DataSource = _alumnoController.GetALumnos(null, null);
            cmbAlumno.DisplayMember = "FullName";
            cmbAlumno.ValueMember = "id";

        }


        private void btnAgregar_Click(object sender, EventArgs e)
        {

            try
            {

                IDictionary<string, string> oEvaluacion = new Dictionary<string, string>
            {
                { Configuration.FECHA, dateTimePicker1.Value.ToString("dd-MM-yyyy") },
                { Configuration.CALIFICACION, cmbNota.SelectedItem.ToString() },
                { Configuration.ALUMNOID, cmbAlumno.SelectedValue.ToString() },
                { Configuration.MATERIAID, _id.ToString() }
            };
                _evaluacionController.InsertEvaluacion(oEvaluacion);
                this.DialogResult = DialogResult.OK;
                this.Close();
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
