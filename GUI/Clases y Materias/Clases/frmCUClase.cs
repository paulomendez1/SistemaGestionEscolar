using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using Common;
using Controller;

namespace GUI
{
    public partial class frmCUClase : Form
    {
        private int? _id;
        private readonly DocenteController _docenteController = new();
        private readonly AlumnoController _alumnoController = new();
        private readonly AsistenciaController _asistenciaController = new();
        private readonly ClaseController _claseController = new();
        private int AlumnosCount;
        private int Asistio = 0;

        public frmCUClase(int? ID)
        {
            InitializeComponent();
            _id = ID;
            if (_id != null)
            {
                cargarDatos((int)_id);
            }
            LlenarDGV();
            cargarDocente();
            lblFecha.Text = DateTime.Now.ToString("dd-MM-yyyy");
            AlumnosCount = dgvAlumnos.Rows.Count;
        }


        public void LlenarDGV()
        {
            dgvAlumnos.DataSource = _alumnoController.GetALumnos(null, null);
            this.dgvAlumnos.Columns[Configuration.ID].Visible = false;
            this.dgvAlumnos.Columns[Configuration.FULLNAME].Visible = false;
            DataGridViewCheckBoxColumn Chk = new DataGridViewCheckBoxColumn();
            Chk.HeaderText = "Asistio?";
            dgvAlumnos.Columns.Add(Chk);


        }
        private void cargarDocente()
        {

            cmbDocente.DataSource = _docenteController.GetDocentesCMB();
            cmbDocente.DisplayMember = "FullName";
            cmbDocente.ValueMember = "id";

        }

        private void cargarDatos(int _id)
        {

        }


        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {

                if (_id != null)
                {
                    IDictionary<string, string> oClase = new Dictionary<string, string>
            {
                { Configuration.ID, _id.ToString() },
                { Configuration.FECHA, DateTime.Now.ToString("dd-MM-yyyy") },
                { Configuration.DOCENTEID, cmbDocente.SelectedValue.ToString() },
                  };
                    //_claseController.Update(oAlumno);
                }
                else
                {
                    IDictionary<string, string> oClase = new Dictionary<string, string>
            {
                { Configuration.FECHA, DateTime.Now.ToString("dd-MM-yyyy") },
                { Configuration.DOCENTEID, cmbDocente.SelectedValue.ToString() }
            };
                    _claseController.AddClase(oClase);

                foreach (DataGridViewRow item in dgvAlumnos.Rows)
                    {
                        if (Convert.ToBoolean(item.Cells[0].Value) == true)
                        {
                            Asistio = 1;
                        }
                        else
                        {
                            Asistio = 0;
                        }
                        IDictionary<string, string> oAsistencia = new Dictionary<string, string>
            {
                { Configuration.ALUMNOID, Convert.ToInt32(item.Cells["Id"].Value).ToString() },
                { Configuration.CLASEID, _claseController.GetIdLastClase().ToString() },
                { Configuration.ASISTIO, Asistio.ToString()},
            };
                        _asistenciaController.AddAsistencia(oAsistencia);
                    }
           
                }
                this.DialogResult = DialogResult.OK;
                this.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            //try
            //{
            //    if (Id == null)
            //    {

            //        oClase.Fecha = Fecha;
            //        oClase.DocenteId = cmbDocente.SelectedValue.ToString();
            //        oClase.Alumnos = dgvAlumnos;
            //        ClaseBLL.Agregar(oClase);
            //        this.Close();
            //    }
            //    else
            //    {
            //        oClase.Id = (int)Id;
            //        oClase.Fecha = Fecha;
            //        oClase.DocenteId = cmbDocente.SelectedValue.ToString();
            //                oClase.Alumnos = dgvAlumnos;
            //                ClaseBLL.Modificar(oClase);
            //        this.Close();
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
            //cargarData();
            //this.Close();
        }
    }
}
