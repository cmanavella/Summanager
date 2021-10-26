using Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Summanager
{
    public partial class FrmExportando : Summanager.FrmEmergente
    {
        private string filePath;
        private DataTable dataSource;
        private Estadistica estadistica;

        public Exception Exception { get; set; }
        public bool Error { get; set; }

        public FrmExportando(string filePath, DataTable dataSource, Estadistica estadistica)
        {
            InitializeComponent();
            this.filePath = filePath;
            this.dataSource = dataSource;
            this.estadistica = estadistica;

            this.Exception = null;
            this.Error = false;
        }

        private void FrmExportando_Shown(object sender, EventArgs e)
        {
            //Si el BackGround Worker no está ocupado lo pongo a funcionar.
            if (!worker.IsBusy) worker.RunWorkerAsync();
        }

        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                IO.File.exportExcelFile(this.filePath, this.dataSource, this.estadistica);
            }
            catch(Exception ex)
            {
                this.Error = true;
                this.Exception = ex;
            }
        }

        private void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //Cuando el BGW termina, cierro el Form.
            this.Close();
        }
    }
}
