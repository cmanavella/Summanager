﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CustomControls
{
    public partial class BotonHijoVerde : CustomControls.BotonPadre
    {
        public BotonHijoVerde()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.OnClick(e);
        }
    }
}
