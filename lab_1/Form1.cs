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
    public partial class Form1 : Form
    {
        Bitmap image;
        Form2.MMCore mmCore = new Form2.MMCore();
        public Form1()
        {
            InitializeComponent();
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Image files| *.png;*.jpg;*.bmp|All files(*.*)|*.*";
            if(dialog.ShowDialog() == DialogResult.OK)
            {
                image = new Bitmap(dialog.FileName);
                pictureBox1.Image = image;
                pictureBox1.Refresh();
            }
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "Image files| *.png;*.jpg;*.bmp|All files(*.*)|*.*";
            dialog.FileName = "NewImage.jpg";
            dialog.RestoreDirectory = true;
            if (dialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            if (image != null)
            {
                image.Save(dialog.FileName);
            }
        }

        private void инверсияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new InvertFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            Bitmap newImage = ((Filters)e.Argument).processImage(image, backgroundWorker1);
            if(backgroundWorker1.CancellationPending!= true)
            {
                image = newImage;
            }
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar2.Value = e.ProgressPercentage;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (!e.Cancelled)
            {
                pictureBox1.Image = image;
                pictureBox1.Refresh();
            }
            progressBar2.Value = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            backgroundWorker1.CancelAsync();
        }

        private void размытиеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new BlurFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void фильрГаусаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new GaussianFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void серыйМирToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new GrayScaleFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void серыйМирToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Filters filter = new GrayWorld();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void идеальныйОтражательToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new Reflector();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void задатьСтруктурныйЭлементToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 newForm = new Form2(mmCore);
            newForm.Show();
        }

        private void расширениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new Dilation(mmCore);
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void сужениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new Erosion(mmCore);
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void открытиеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new Opening(mmCore);
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void закрытиеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new Closing(mmCore);
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void gradToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new Grad(mmCore);
            backgroundWorker1.RunWorkerAsync(filter);
        }

        
    }
}
