using System;
using System.Windows.Forms;
using Common;
using BLL;
using System.Collections.Generic;
using Controller;

namespace GUI
{
    public partial class frmNuevoUsuario : Form
    {
        private readonly string Email;
        private readonly string Contraseña;
        private readonly SecurityController _securityController = new();

        public frmNuevoUsuario(IDictionary<string,string> oUsuario)
        {
            InitializeComponent();
            this.Email = oUsuario["Email"];
            this.Contraseña = oUsuario["Contraseña"];

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            IDictionary<string, string> oUsuario = new Dictionary<string, string>
                    {
                    { Configuration.EMAIL, Email },
                    { Configuration.CONTRASEÑA, Contraseña }
                    };
            var UserMerge = _securityController.IsValidUser(oUsuario).Item2;
            if (txtPW1.Text == txtPW2.Text)
            {
                if (CommonValidations.ValidatePW(txtPW2.Text))
                {
                    IDictionary<string, string> oUsuarioMod = new Dictionary<string, string>
                    {
                    { Configuration.ID, UserMerge.Id.ToString() },
                    { Configuration.EMAIL, UserMerge.Email },
                    { Configuration.CONTRASEÑA, Encryption.EncriptarPW(txtPW2.Text) },
                    { Configuration.ROL, UserMerge.RolId.ToString() }
                    };
                    _securityController.UpdateUser(oUsuarioMod);
                    frmLogIn main = new frmLogIn();
                    main.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("La contraseña debe contener al menos 8 caracteres, incluyendo al menos una mayuscula, una minuscula y un numero ");
                }
            }
            else
            {
                MessageBox.Show("Las contraseñas no coinciden");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}