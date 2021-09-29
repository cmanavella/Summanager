using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using IO;

namespace Summanager
{
    public partial class FrmConfiguracion : Summanager.FrmContenido
    {
        private bool automatizo;
        private int periodo;

        public FrmConfiguracion()
        {
            //Cargo los valores almacenados en el Configuration Manager en variables locales.
            this.automatizo = File.getActualizacionEstados();
            this.periodo = File.getPeriodo();

            InitializeComponent();
            _cargarCombo(); //Cargo el Combo Período

            //Cargo el valor de Automatizo en el CheckBox.
            this.chkAutomatico.Checked = this.automatizo;

            //Solo si el valor del CheckBox es True, selecciono el Item correspondiente del Combo Período.
            if (this.chkAutomatico.Checked)
            {
                this.cmbPeriodo.SelectItem(this.periodo, true);
            }
        }

        /// <summary>
        /// Carga el Combo Período con todas las opciones de Período disponibles.
        /// </summary>
        private void _cargarCombo()
        {
            //Cargo el Combo Periodo
            this.cmbPeriodo.Add(0, "-- Seleccione --");
            this.cmbPeriodo.Add(1, "1 minuto");
            this.cmbPeriodo.Add(2, "5 minutos");
            this.cmbPeriodo.Add(3, "10 minutos");
            this.cmbPeriodo.Add(4, "20 minutos");
            this.cmbPeriodo.Add(5, "30 minutos");
            this.cmbPeriodo.Add(6, "1 hora");
            this.cmbPeriodo.Add(7, "2 horas");
            this.cmbPeriodo.Add(8, "6 horas");
            this.cmbPeriodo.Add(9, "12 horas");
            this.cmbPeriodo.Add(10, "1 día");
        }

        private void chkAutomatico_CheckedChanged(object sender, EventArgs e)
        {
            //Activo o desactivo el Combo Período según esté o no activado el CheckBox Automatizo.
            if (chkAutomatico.Checked)
            {
                this.cmbPeriodo.Enabled = true;
            }
            else
            {
                this.cmbPeriodo.Enabled = false;
            }
        }

        /// <summary>
        /// Almacena en el Configuration Manager los cambios realizados.
        /// </summary>
        private void _guardar()
        {
            try
            {
                File.setActualizacionEstados(this.chkAutomatico.Checked);
                File.setPeriodo(this.cmbPeriodo.SelectedItem().Value);

                MessageBox.Show("Configuración guardada con éxito.");
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnAceptar_MouseClick(object sender, MouseEventArgs e)
        {
            //Para guardar los cambios debo validar primero que el CheckBox Automatizo esté activado y que el Combo Período 
            //tenga un valor seleccionado.
            if (this.chkAutomatico.Checked  && this.cmbPeriodo.SelectedItem().Value > 0)
            {
                _guardar();
                    
            }
            //Si no se cumple cualquiera de las dos condiciones anteriores, verifico solo que el CheckBox no esté activado para guardar.
            else if (!this.chkAutomatico.Checked)
            {
                this.cmbPeriodo.SelectItem(0, true);
                _guardar();
            }
            //Si llego hasta acá, significa que el CheckBox no está activado y que no se ha seleccionado ningún Item del Combo Período.
            else
            {
                MessageBox.Show("Debe definir un período.");
            }
        }

        private void btnCancelar_MouseClick(object sender, MouseEventArgs e)
        {
            //Usando las variables locales las comparo con el CheckBox y el Combo para, en caso de que estos cambien, vuelvan al estado que tienen en 
            //Configuration Manager.

            //Valido que el CheckBox haya cambiado.
            if (this.automatizo != this.chkAutomatico.Checked)
            {
                //Cambio el estado del CheckBox
                this.chkAutomatico.Checked = this.automatizo;

                //Si el CheckBox está activado y el Combo Período cambió, lo vuelvo a su estado.
                if (this.automatizo && (this.periodo != this.cmbPeriodo.SelectedItem().Value))
                {
                    this.cmbPeriodo.SelectItem(this.periodo, true);
                }else if (!this.automatizo) //Si el CheckBox no está activado, el Combo debe estar en estado "Seleccione".
                {
                    this.cmbPeriodo.SelectItem(0, true);
                }
            }else if (this.periodo != this.cmbPeriodo.SelectedItem().Value) //Si el CheckBox no cambió, me fijo si el Combo lo ha hecho y lo cambio.
            {
                this.cmbPeriodo.SelectItem(this.periodo, true);
            }
            _guardar();  //Guardo los cambios.
        }

        private void botonHijo1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Hijo Verde");
        }

        private void botonHijoCeleste1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Hijo Celeste");
        }
    }
}
