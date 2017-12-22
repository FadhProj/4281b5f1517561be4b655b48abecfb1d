using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace TA
{
    class Permutation
    {
        int p, a, d;
        public Permutation(ref Iimage image)
        {
            p = primeNumber(image.Blok);

            for (int i = 0; i < image.Blok; i++)
            {
                d = (int)Math.Pow(5, (i + 69) % (image.Blok + 70) ) % p;
                Console.WriteLine("i {0} i + 69 = {1} i + 69 % 256 = {2} pow = {3} ", i, i + 69, (i + 69) % (image.Blok + 70), Math.Pow(5, (i + 69) % (image.Blok + 70)));
                //Console.WriteLine("i {0} d {1} p {2}", i, d,p);
                //swapBlok(i, d, ref image);
            }
        }

        public void swapBlok(int blok1,int blok2,ref Iimage image)
        {
            Color tmp;
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    tmp = image.Image.GetPixel(image.DefBlok[blok1].M + j, image.DefBlok[blok1].N + i);
                    image.Image.SetPixel(image.DefBlok[blok1].M + j, image.DefBlok[blok1].N + i,image.Image.GetPixel(image.DefBlok[blok2].M + j, image.DefBlok[blok2].N + i));
                    image.Image.SetPixel(image.DefBlok[blok2].M + j, image.DefBlok[blok2].N + i,tmp);
                }
            }
        }

        public int primeNumber(int number)
        {
            for (int i = number; i < number + 100; i++)
            {
                if (this.isPrime(i))
                {
                    return i;
                }
            }
            return 0; //????
        }

        public bool isPrime(int number)
        {
            for (int i = 2; i < (int)Math.Sqrt(number); i++)
            {
                if (number % i == 0)
                {
                    return false;
                }
            }
            return true;
        }

    }
}
