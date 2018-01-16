using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace TA
{
    class StreamChipper
    {
        private int[] K;
        private int[] S;

        //Construtor Class StreamChipper
        public StreamChipper(string key)
        {
            K = new int[256];
            S = new int[256];
            initStateArray(key);
            keySchedullingAlgorithm();
        }

        //Procedure Pertukaran Array S
        public void swap(int val1, int val2)
        {
            int temp = S[val1];
            S[val1] = S[val2];
            S[val2] = temp;
        }

        //Procedure Inisialisasi State Array K dan Array S
        public void initStateArray(string key)
        {
            for (int i = 0; i < 256; i++)
            {
                K[i] = key[i % key.Length];
                S[i] = i % 9;
            }
        }

        //Prosedura Penjadwalan Kunci menggunakan RC4
        public void keySchedullingAlgorithm()
        {
            int j = 0;
            for (int i = 0; i < 256; i++)
            {
                j = (j + S[i] + K[i]) % 256;
                swap(i, j);
            }
        }

        //Prosedure Pembangkitan Kunci Random
        public void PRGA(ref Iimage img)
        {
            int i = 0;
            int j = 0;
            int key;
            for (int n = 0; n < img.Blok; n++) //perlu di ubah!!
            {
                i = (j + 1) % 256;
                j = (j + S[i]) % 256;
                swap(i, j);
                key = S[(S[i] + S[j]) % 256];
                //XOR blok
                xorBlok(ref img, key, n);
            }
            Console.WriteLine("+++");

        }

        public void xorBlok(ref Iimage img, int key, int n)
        {
            int R, G, B, a = 0;
            //string ke = Convert.ToString(key, 2);
            //Console.WriteLine(ke);
            //Console.WriteLine(ke[a]);
            Console.WriteLine("Xor Blok");
            for (int i = img.DefBlok[n].N; i < img.DefBlok[n].N +3 ; i++)
            {
                for (int j = img.DefBlok[n].M; j < img.DefBlok[n].M +3 ; j++)
                {
                    R = img.Image.GetPixel(j, i).R;
                    G = img.Image.GetPixel(j, i).G;
                    B = img.Image.GetPixel(j, i).B;
                    
                    Console.Write("st X {0} Y {1} R {2} G {3} B {4} Key {5} || ",j,i, R, G, B,key);
                    R = img.Image.GetPixel(j, i).R ^ key;//ke[a % ke.Length] - 48;
                    G = img.Image.GetPixel(j, i).G ^ key;//ke[a % ke.Length] - 48;
                    B = img.Image.GetPixel(j, i).B ^ key;//ke[a % ke.Length] - 48;
                    //Console.WriteLine("2 {0} {1} {2}", R, G, B);

                    img.Image.SetPixel(j, i, Color.FromArgb((byte)R, (byte)G, (byte)B));
                    a++;
                }
                Console.WriteLine("");
            }
            Console.WriteLine("===");

        }

    }
}
