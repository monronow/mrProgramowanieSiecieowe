using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crc
{
    static class Program_crc
    {
        static void Main()
        {
          //  Console.Write("Podaj dane (hex): ");
            //   int dane_we=Convert.ToInt32(Console.ReadLine());
          //  string input = Console.ReadLine(); //odczyt danych od użytkownika
          //  var bytes = 1;// HexToBytes(input); //zamiana danych w postaci hex na bajty

           // int j = 0;
            //            Console.Write("ilosc bajtow: {0}", bytes.Length);

            Console.Write("Podaj dane: ");
            string text = Console.ReadLine();
            //byte[] byteArrayUTF = System.Text.Encoding.UTF8.GetBytes(text);
            byte[] byteArrayASCII = System.Text.Encoding.ASCII.GetBytes(text);

            Console.Write("ilosc bajtow ascii: {0}\n", byteArrayASCII.Length);
          //  Console.Write("bajt0: {0}; bajt1: {1}; bajt2: {2}", byteArrayASCII[0], byteArrayASCII[1], byteArrayASCII[2]);






            foreach (int i in byteArrayASCII) //wydruk poszcególnych bajtów
            {
                Console.Write("\nbajt {0} (dec)", i);
                // byteArrayASCII[j] = byteArrayASCII[j] << 3;
               // j++;
            }
            int crc_wynik=crc16_wer1.crc16_mcrf4xx(byteArrayASCII);
            Console.Write("\ncrc_wynik {0:X} (dec)", crc_wynik);

          //  int crc_wynik2 = Crc16.ComputeChecksum(byteArrayASCII);
          //  Console.Write("\ncrc_wynik2 {0:X} (dec)", crc_wynik2);

          

            Console.ReadKey();
        }


        public static class crc16_wer1
        {
            public static int crc16_mcrf4xx(byte[] bajty)
            {
                //$data = pack('H*', $dane);
                int crc = 0xFFFF;
                for (int i = 0; i < bajty.Length; i++) //tyle ile bajtów
                {
                  //  Console.Write("\ncrc {0} ", crc);
                    crc ^= bajty[i];
                    //xor crc oraz data

                    for (int j = 8; j != 0; j--)
                    {
                        if ((crc & 0x0001) != 0)
                        {
                            crc >>= 1;
                            crc ^= 0xA001;// 0x8408;
                        }
                        else crc >>= 1;
                    }
                }
                return crc;
            }

        }
    
        

          
   
        public static class Crc16 //klasa dot. obliczania crc16
        {
            const ushort crc_dzielnik = 0xA001;  //dzielnik crc -bin-> 1010 0000 0000 0001
            
            static readonly ushort[] table = new ushort[256]; //tablica 256 elementów
            
            public static ushort ComputeChecksum(byte[] bytes) //metoda - obliczanie sumy kontrolnej
            {
                 
                ushort crc = 0;  //deklaracja początkowej sumy crc
                for (int i = 0; i < bytes.Length; ++i) //iteracja po elementach tablicy z bajtami
                {
                    byte index = (byte)(crc ^ bytes[i]); //operacja xor dla aktualnej sumy crc i bajtu danych
                    crc = (ushort)((crc >> 8) ^ table[index]);//przypisanie nowej sumy crc
                    //przesunięcie crc o 8 bitów w prawo, operacja xor z danymi w tabeli  
                }
                return crc;
            }

            static Crc16() //wyznaczanie tablicy table
            {
                ushort value;
                ushort temp;
                for (ushort i = 0; i < table.Length; ++i)
                {
                    value = 0;
                    temp = i;
                    for (byte j = 0; j < 8; ++j)
                    {
                        if (((value ^ temp) & 0x0001) != 0)
                        {
                            value = (ushort)((value >> 1) ^ crc_dzielnik);
                        }
                        else
                        {
                            value >>= 1;
                        }
                        temp >>= 1;
                    }
                    table[i] = value;
                }
            }




      
    }
       

    }
}