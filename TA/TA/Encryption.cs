using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

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
            streamImage = img;

            //permutation
            Permutation p = new Permutation(ref img);


            //Embending


        }


    }
}
