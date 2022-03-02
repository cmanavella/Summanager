using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CustomExceptions;
using Data;
using Entities;

namespace Summanager
{
    public partial class FrmInicioSesion : Summanager.FrmAbm
    {
        private string msjeValido;

        public FrmInicioSesion()
        {
            InitializeComponent();

            this.lblTitulo.Text = "Iniciar Sesión";
        }

        private bool _valido()
        {
            bool retorno = true;
            this.msjeValido = String.Empty;

            if (this.txtNombre.IsMaskared)
            {
                retorno = false;
                this.msjeValido += "- El campo 'Nombre de Usuario' es obligatorio.";
            }
            if (this.txtContraseña.IsMaskared)
            {
                retorno = false;
                if (this.msjeValido.Length > 0) this.msjeValido += "\n";
                this.msjeValido += "- El campo 'Contraseña' es obligatorio.";
            }

            return retorno;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            //Pruebo iniciar sesión.
            try
            {
                //Primero valido los campos.
                if (_valido())
                {
                    DBUsers.LogIn(this.txtNombre.Text, this.txtContraseña.Text);

                    MessageBox.Show("Bienvenido a SumManager. Sesión iniciada como: '" + User.Nombre + "'", Application.ProductName + " " + 
                        Application.ProductVersion, MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.Close();
                }
                else
                {
                    MessageBox.Show(this.msjeValido, Application.ProductName + " " + Application.ProductVersion,
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (LogInException ex)
            {
                //Si las credenciales no son correctas mustro mensaje.
                MessageBox.Show(ex.Message, Application.ProductName + " " + Application.ProductVersion,
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch(Exception ex)
            {
                //Si hubo algún otro error lo muestro.
                MessageBox.Show(ex.Message, Application.ProductName + " " + Application.ProductVersion,
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtContraseña_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) btnGuardar_Click(null, null);
        }
    }
}
