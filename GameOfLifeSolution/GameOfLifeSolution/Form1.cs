using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System;
using System.Windows.Forms;

namespace GameOfLife
{
    public partial class Form1 : Form
    {
        private GridManager gridManager;
        private Timer timer;

        public Form1()
        {
            InitializeComponent();
            gridManager = new GridManager(50, 50);
            timer = new Timer();
            timer.Interval = 100;
            timer.Tick += (s, e) => gridManager.UpdateGrid();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            gridManager.DrawGrid(e.Graphics);
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            timer.Start();
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            timer.Stop();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            gridManager.InitGrid();
            Invalidate();
        }
    }
}

