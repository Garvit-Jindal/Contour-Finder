
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.UI;

using Emgu.CV.Structure;
using Emgu.CV.CvEnum;
using System.Windows;
namespace ContourFinder
{
    public partial class Form1 : Form
    {
        Image<Bgr, byte> imgInput;
        public Form1()
        {
            InitializeComponent();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                imgInput = new Image<Bgr, byte>(ofd.FileName);
                pictureBox1.Image = imgInput.Bitmap;
            }
        }

        private void findContoursToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Image<Gray, byte> imgOutput = imgInput.Convert<Gray, byte>().ThresholdBinary(new Gray(100), new Gray(255));
            Emgu.CV.Util.VectorOfVectorOfPoint contours = new Emgu.CV.Util.VectorOfVectorOfPoint();
            Mat hier = new Mat();

            Image<Gray, byte> imgout = new Image<Gray, byte>(imgInput.Width, imgInput.Height, new Gray(0));

            CvInvoke.FindContours(imgOutput, contours, hier, Emgu.CV.CvEnum.RetrType.External, Emgu.CV.CvEnum.ChainApproxMethod.ChainApproxSimple);
            CvInvoke.DrawContours(imgout, contours, -1, new MCvScalar(255, 0, 0));

            pictureBox2.Image = imgout.Bitmap;

        }
    }
}
