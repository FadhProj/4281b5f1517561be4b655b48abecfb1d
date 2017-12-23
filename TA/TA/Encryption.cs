using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace TA
{
    class Encryption
    {
        private Iimage streamImage, permutedImage, embenImage;
        public Encryption(String Key,ref Iimage img)
        {
            //streamEncryption
            StreamChipper sc = new StreamChipper(Key);
            sc.PRGA(ref img);
            streamImage = new Iimage(img.Image);

            //permutation
            Permutation p = new Permutation(ref img);
            permutedImage = new Iimage(img.Image); ;


            //Embending
            


        }

        internal Iimage StreamImage { get => streamImage; set => streamImage = value; }
        internal Iimage PermutedImage { get => permutedImage; set => permutedImage = value; }
        internal Iimage EmbenImage { get => embenImage; set => embenImage = value; }
    }
}
