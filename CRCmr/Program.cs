using System;

namespace CRCmr
{
    class labjeden
    {
        static void Main()
        {
            
            string slowo = "slowo";
            int a, b, c = 0;
            int suma;
            suma=0;

            for (int i = 0; i < slowo.Length; i++)
            {
                for (int j = 0; j < 8 ; j++)
                {
                    a = (1 << j);
                    b = slowo[i]; 
                    c = (c & a) >> j;

                    suma ^= b;
                }
            }
        }
    }

}