using Common;
using Controller;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GUI
{
    public partial class frmLogIn : Form
    {
        private readonly SecurityController _securityController = new();
        int seconds;
        public frmLogIn()
        {
            InitializeComponent();
            lblFail.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string email = "";
            string contraseña = "";

            if (!string.IsNullOrEmpty(txtEmail.Text)) email = txtEmail.Text;
            else MessageBox.Show("Ingrese el email!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            if (!string.IsNullOrEmpty(txtPw.Text)) contraseña = txtPw.Text;
            else MessageBox.Show("Ingrese la contraseña!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            IDictionary<string, string> oUsuario = new Dictionary<string, string>
            {
                { Configuration.EMAIL, txtEmail.Text },
                { Configuration.CONTRASEÑA, Encryption.EncriptarPW(txtPw.Text) }
            };

            if (_securityController.IsValidUser(oUsuario).Item1)
            {
                if (txtPw.Text.Length < 5)
                {
                    var user = _securityController.IsValidUser(oUsuario).Item2;
                    SessionCache.Id = user.Id;
                    SessionCache.Email = user.Email;
                    SessionCache.Contraseña = user.Contraseña;
                    SessionCache.Rol = user.RolId;
                    this.Hide();
                    frmNuevoUsuario nu = new frmNuevoUsuario(oUsuario);
                    nu.Show();
                }
                else
                {
                    var user = _securityController.IsValidUser(oUsuario).Item2;
                    oUsuario.Add(Configuration.USUARIOID, user.Id.ToString());
                    var userMerge = _securityController.MergeUser(user.Id);
                    SessionCache.Id = user.Id;
                    SessionCache.Email = user.Email;
                    SessionCache.Contraseña = user.Contraseña;
                    SessionCache.Rol = user.RolId;
                    if (user.RolId == 2)
                    {
                        SessionCache.Nombre= userMerge.Item2.Nombre;
                        SessionCache.Apellido = userMerge.Item2.Apellido;
                    }
                    if (user.RolId == 3)
                    {
                        SessionCache.Nombre = userMerge.Item3.Nombre;
                        SessionCache.Apellido = userMerge.Item3.Apellido;
                    }
                    if (user.RolId == 1)
                    {
                        SessionCache.Nombre = userMerge.Item1.Nombre;
                        SessionCache.Apellido = userMerge.Item1.Apellido;
                    }
                    

                    this.Hide();
                    Main main = new Main();
                    main.Show();
                }
            }
            else
            {
                MessageBox.Show("Usuario o Contraseña incorrectos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                SessionCache.FailAttempts ++;
                if (SessionCache.FailAttempts == 3)
                {
                    seconds = 30;
                    countdownTimer.Start();
                    if (seconds>0)
                    {
                        btnIngresar.Enabled = false;
                        lblFail.Visible = true;
                    }
                    else
                    {
                        countdownTimer.Stop();
                    }
                }
            }
        }

        private void countdownTimer_Tick(object sender, EventArgs e)
        {
            lblFail.Text = $"Debera esperar {seconds--} segundos para volver a intentarlo!";
            if (seconds<=0)
            {
                countdownTimer.Stop();
                lblFail.Visible = false;
                SessionCache.FailAttempts = 0;
                btnIngresar.Enabled = true;
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmRecuperarContraseña recovery = new frmRecuperarContraseña();
            this.Hide();
            recovery.Show();
        }

        private void label5_Click(object sender, EventArgs e)
        {
        }
    }
}