﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TropicalClock
{
    public partial class FormTropicalClock : Form
    {
        public FormTropicalClock()
        {
            InitializeComponent();
        }

        private void timerDateTime_Tick(object sender, EventArgs e)
        {
            labelTime.Text = DateTime.Now.ToString("HH:mm:ss.ff");
        }
    }
}
