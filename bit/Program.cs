using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{


    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Wpisz 7-bitowa liczbe:");
            int a = Convert.ToInt32(Console.ReadLine());
            string binValue = Convert.ToString(a, 2);

            Console.WriteLine("\nbity: {0}", binValue);
            Console.WriteLine("\nilosc bitow: {0}", binValue.Length);
            int ilosc_bitow = binValue.Length;
            Console.WriteLine("\nbit 0: {0}", binValue[0]);
             
            int akumulator = 0;
            Console.WriteLine("\naku: {0}", akumulator);
            for (int i = 0; i < ilosc_bitow; i++) {
                akumulator ^=  binValue[i]-'0';
               
            }
        Console.WriteLine("\nbit parzystosci: {0}", akumulator);
              
   
 
           

            Console.ReadKey();
            }

        }
    }