using System;
using System.Collections.Generic;

namespace CRCm1r
{
    class Program
    {
        void Main(string[] args)
        {
            string imie;

            Console.WriteLine("Podaj imię");
            imie = Console.ReadLine();

            Console.WriteLine("Masz na imię: {0}", imie);

            Console.ReadLine();
        }
    }
}