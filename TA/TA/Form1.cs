using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace TA
{
    public partial class Form1 : Form
    {
        DateTime dt;
        Bitmap g;
        Iimage imgOri, imgClone;
        public Form1()
        {
            InitializeComponent();
            dt = DateTime.Now;
            tbDate.Text = dt.ToString();
            
        }

        private void tbDate_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = " Image Files(*.jpg;*.bmp;*.jpeg;*.png)|*.jpg;*.bmp;*.jpeg;*.png";
            if(open.ShowDialog() == DialogResult.OK)
            {
                pbLoad.Image = new Bitmap(open.FileName);
                g = (Bitmap) pbLoad.Image;
            }

            // menampilkan value perpixel
            

            imgOri = new Iimage(g);
            imgClone = imgOri;
            Encryption E = new Encryption("123123", ref imgClone);
            pbShow.Image = imgClone.Image;
            
            
            Console.WriteLine("g size {0} ",g.Size);
        }
    }
}
