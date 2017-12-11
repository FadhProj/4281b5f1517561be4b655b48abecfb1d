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
            BitmapData data = g.LockBits(new Rectangle(0, 0, g.Width, g.Height), ImageLockMode.ReadWrite, g.PixelFormat);
            unsafe
            {
                Console.WriteLine(Bitmap.GetPixelFormatSize(g.PixelFormat) / 8);

                byte* ptr = (byte*)data.Scan0;
                for (int j = 0; j < data.Height; j++)
                {
                    Console.Write("Baris ke {0} : ", j);
                    for (int i = 0; i < data.Width; i++)
                    {

                        Console.Write(" K : {0} ; pix : {1} ", i, ptr[i]);
                        //Console.Write(ptr[i]);

                    }
                    Console.WriteLine();
                }
            }

            g.UnlockBits(data);
            Console.WriteLine(g.Size);
        }
    }
}
