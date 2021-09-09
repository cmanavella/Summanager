using System;
using System.Collections.Generic;
using System.ComponentModel;
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
            this.automatizo = File.getActualizacionEstados();
            this.periodo = File.getPeriodo();

            InitializeComponent();
            _cargarCombo();

            this.chkAutomatico.Checked = this.automatizo;

            if (this.chkAutomatico.Checked)
            {
                this.cmbPeriodo.SelectItem(this.periodo, true);
            }
        }

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
            if (chkAutomatico.Checked)
            {
                cmbPeriodo.Enabled = true;
            }
            else
            {
                cmbPeriodo.Enabled = false;
            }
        }

        private void btnAceptar_MouseClick(object sender, MouseEventArgs e)
        {
            if (this.chkAutomatico.Checked)
            {
                if (this.cmbPeriodo.SelectedItem().Value > 0)
                {
                    this.automatizo = this.chkAutomatico.Checked;
                    this.periodo = this.cmbPeriodo.SelectedItem().Value;

                    File.setActualizacionEstados(this.automatizo);
                    File.setPeriodo(this.periodo);

                    MessageBox.Show("Configuración guardada con éxito.");
                }
                else
                {
                    MessageBox.Show("Debe definir un período.");
                }
            }
            else
            {
                this.automatizo = this.chkAutomatico.Checked;
                this.periodo = 0;

                File.setActualizacionEstados(this.automatizo);
                File.setPeriodo(this.periodo);

                MessageBox.Show("Configuración guardada con éxito.");
            }
        }
    }
}
