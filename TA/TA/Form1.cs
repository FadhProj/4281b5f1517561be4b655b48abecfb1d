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
using System.Collections;

namespace TA
{
    public partial class Form1 : Form
    {
        DateTime dt;
        Bitmap g;
        Iimage imgOri, imgClone,imageDec;
        ArrayList L = new ArrayList();

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

        private void btDecrypt_Click(object sender, EventArgs e)
        {
            imageDec = new Iimage(imgClone.Image);
            Decryption D = new Decryption();
            pbLoad.Image = (Image)g;//imgOri.Image;
            pbShow.Image = D.decryptImage("123123", imageDec,L).Image;

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
            imgClone = new Iimage(imgOri.Image);
            Encryption E = new Encryption("123123", ref imgClone);
            L = E.L1;
            pbShow.Image = imgClone.Image;
            
            
            Console.WriteLine("g size {0} ",g.Size);
        }
    }
}
