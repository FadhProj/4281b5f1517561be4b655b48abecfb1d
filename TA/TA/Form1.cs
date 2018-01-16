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
using TA;

namespace TA
{
    public partial class win1 : Form
    {
        DateTime dt;
        Bitmap g;
        Iimage imgOri, imgClone,imageDec;
        ArrayList L = new ArrayList();
        string key,ext;
        Save s;
        

        public win1()
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

        private void btEncrypt_Click(object sender, EventArgs e)
        {
            imgOri = new Iimage(g);
            s.saveImage(imgOri.Image, "OriginalImage4Encrypt.jpg");
            imgClone = imgOri;
            Encryption E = new Encryption(key, ref imgClone);
            s.saveImage(E.StreamImage, @"..\StreamImage.jpg");
            s.saveImage(E.PermutedImage, @"..\EncryptedImage.jpg");
            s.saveImage(E.EmbenImage, @"..\EmbendedImage.jpg");
            s.saveImage(imgClone.Image, @"..\MarkedEncryptedImage.jpg");
            L = E.L1;
            pbShow.Image = imgClone.Image;


            Console.WriteLine("g size {0} ", g.Size);
        }

        private void btDecrypt_Click(object sender, EventArgs e)
        {
            //imageDec = new Iimage(imgClone.Image);
             imageDec = imgClone;
            Decryption D = new Decryption();
            pbLoad.Image = imageDec.Image;//(Image)g;//imgOri.Image;
            pbShow.Image = D.decryptImage(key, imageDec, L,false).Image;
            s.saveImage(D.OriginalImage, @"..\OriginalImageAfterDecrypt.jpg");
        }

        private void btOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = " Image Files(*.jpg;*.bmp;*.jpeg;*.png)|*.jpg;*.bmp;*.jpeg;*.png";
            dt = DateTime.Now;
            if (open.ShowDialog() == DialogResult.OK)
            {
                pbLoad.Image = new Bitmap(open.FileName);
                ext = open.DefaultExt;
                g = (Bitmap) pbLoad.Image;
            }
            if (txKey.Text.Equals(""))
                key = "198563";
            else
                key = txKey.Text;
            Console.WriteLine(key);
            
            PropertyItem[] prop = g.PropertyItems;
            int count = 0;
            Console.WriteLine(prop.Length);
            foreach(PropertyItem p in prop)
            {
                Console.WriteLine("Property Item " + count.ToString());

                Console.WriteLine("iD: 0x" + p.Id.ToString("x"));
                Console.WriteLine("len: " + p.Len.ToString());
                Console.WriteLine("type: " + p.Type.ToString());

                count++;

                //Console.WriteLine("{0} {1} {2} {3} ",p.Id,p.Len,p.Type,p.Value[0].GetType());
                //p.Value[1] = Convert.ToByte("10000");
                //foreach (var item in p.Value)
                //{
                //    Console.WriteLine("{0} ",Encoding.ASCII.GetString(item));
                //    //Console.WriteLine("p ");
                //}
                Console.Write("{0} ");
                

            }
            /*Console.WriteLine("{0} {1} ", g.Width, g.Height);
            imgOri = new Iimage(g);
            pbShow.Image = imgOri.Image;
            Console.WriteLine("{0} {1} ", imgOri.Image.Width, imgOri.Image.Height);*/
            s = new Save (dt);



        }
    }
}
