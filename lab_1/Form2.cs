using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab_1
{
    public partial class Form2 : Form
    {
       public class MMCore
        {
            public float[,] core { get; set; }
            public int coreSize { get; set; }

        }
        MMCore mmCore;

        protected Form2()
        {
            InitializeComponent();
        }
        public Form2(MMCore mmCore)
        {
            InitializeComponent();
            this.mmCore = mmCore;
            this.mmCore.core = null;
            this.mmCore.coreSize = 0;
        }

        private void regenCore(int coreSize)
        {
            string core_string = this.textBox1.Text;
            mmCore.core = new float[coreSize, coreSize];
            int pos = 0;
            for(int i = 0; i < coreSize; i++)
            {
                for(int j = 0; j < coreSize; j++)
                {
                    mmCore.core[i, j] = core_string[pos] - 48;
                    pos++;
                }
                pos += 2;
            }
            mmCore.coreSize = coreSize;
        }

        private int Clamp(int value, int min, int max)
        {
            if (value < min)
                return min;
            if (value > max)
                return max;
            return value;
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            regenCore(3);
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            regenCore(5);
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            regenCore(7);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
