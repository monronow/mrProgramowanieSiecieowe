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
            Console.Write("Podaj dane (hex): ");
            string input = Console.ReadLine(); //odczyt danych od użytkownika
            var bytes = HexToBytes(input); //zamiana danych w postaci hex na bajty
            int j=0;
            foreach (int i in bytes) //wydruk poszcególnych bajtów
            {
                Console.Write("bajt {0} (dec): ", j);
                Console.WriteLine(i);
                j++;
            }

            string hex = Crc16.ComputeChecksum(bytes).ToString("x2"); //zapis wyniku do postaci binarnej
            Console.WriteLine(hex); 
            Console.ReadKey();
        }
        static byte[] HexToBytes(string input)
        {
            byte[] result = new byte[input.Length / 2]; //inicjalizacja tablicy z danymi o połowie długości danych wejściowych
            for (int i = 0; i < result.Length; i++) //iteracja po każdym z bitów
            {
                result[i] = Convert.ToByte(input.Substring(2 * i, 2), 16); //konwersja do bajtów w postaci 16-stkowej 
                                                                        //substring grupuje dane po 2 bajty
            }
            return result;
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