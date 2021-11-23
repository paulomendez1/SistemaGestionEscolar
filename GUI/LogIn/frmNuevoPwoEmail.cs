using Common;
using Controller;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GUI.LogIn
{
    public partial class frmNuevoPwoEmail : Form
    {
        private readonly SecurityController _securityController = new();
        public frmNuevoPwoEmail()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtPW1.Text == txtPW2.Text)
            {
                if (CommonValidations.ValidatePW(txtPW2.Text))
               {
                    IDictionary<string, string> oUsuario = new Dictionary<string, string>
                    {
                    { Configuration.EMAIL, SessionCache.Email },
                    { Configuration.CONTRASEÑA, SessionCache.Contraseña }
                    };
                    var UserMerge = _securityController.IsValidUser(oUsuario).Item2;
                    IDictionary<string, string> oUsuarioMod = new Dictionary<string, string>
                    {
                    { Configuration.ID, UserMerge.Id.ToString() },
                    { Configuration.EMAIL, UserMerge.Email },
                    { Configuration.CONTRASEÑA, Encryption.EncriptarPW(txtPW2.Text) },
                    { Configuration.ROL, UserMerge.RolId.ToString() }
                    };
                    _securityController.UpdateUser(oUsuarioMod);
                    MessageBox.Show("La contraseña fue modificada correctamente!");
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

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                if (CommonValidations.ValidateEmail(txtEmail.Text))
                {
                    IDictionary<string, string> oUsuario = new Dictionary<string, string>
                    {
                    { Configuration.EMAIL, SessionCache.Email },
                    { Configuration.CONTRASEÑA, SessionCache.Contraseña }
                    };
                    var UserMerge = _securityController.IsValidUser(oUsuario).Item2;
                    IDictionary<string, string> oUsuarioMod = new Dictionary<string, string>
                    {
                    { Configuration.ID, UserMerge.Id.ToString() },
                    { Configuration.EMAIL, txtEmail.Text },
                    { Configuration.CONTRASEÑA, UserMerge.Contraseña },
                    { Configuration.ROL, UserMerge.RolId.ToString() }
                    };
                    _securityController.UpdateUser(oUsuarioMod);
                    MessageBox.Show("El correo electronico fue modificado correctamente");
                }
                else
                {
                    MessageBox.Show("El formato ingresado no corresponde a un correo electronico");
                }
            }

            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
          
        }
    }
}
