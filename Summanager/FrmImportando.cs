using CustomControls;
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
    public partial class FrmImportando : Summanager.FrmEmergente
    {
        private string filePath;

        public Exception Exception { get; set; }
        public bool Error { get; set; }
        public List<Printer> Printers { get; set; }

        public FrmImportando(string filePath)
        {
            InitializeComponent();
            this.filePath = filePath;
            this.Printers = new List<Printer>();

            this.Exception = null;
            this.Error = false;
        }

        private void FrmImportando_Shown(object sender, EventArgs e)
        {
            //Si el BackGround Worker no está ocupado lo pongo a funcionar.
            if (!worker.IsBusy) worker.RunWorkerAsync();
        }

        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                this.Printers = IO.File.importExcelFile(filePath);
            }catch(Exception ex)
            {
                this.Error = true;
                this.Exception = ex;
                this.Printers = null;
                this.Close();
            }
        }

        private void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //Cuando termino cierro el form.
            this.Close();
        }
    }
}
