using System;
using System.Collections.Generic;
using System.Text;

namespace TicketManager
{
    public abstract class Bank
    {
        public static bool payOnline() {
            Console.Clear();
            Console.WriteLine("Bankkártya adatok lekérése");
            Console.WriteLine("Tulajdonos neve:");
            Console.ReadLine();
            Console.WriteLine("Bankkártya száma");
            Console.ReadLine();
            Console.WriteLine("...");
            Console.WriteLine("Az adatok tegyük fel jók, gratulálunk vett egy jegyet");
            Console.WriteLine("Kívánja menteni a vásárlást?(igen / nem)");
            if (Console.ReadLine().Trim() == "igen")
            {
                //kiir fajlba
                Console.WriteLine("Vásárlás mentve");
            }
            else {
                Console.WriteLine("A vásárlás nem került mentésre");
            }
            Console.ReadLine();

            //Itt le lenne ellenőrizve hogy valóban végigmegy e a vásárlás, de nyilván ezt nem igazán tudjuk kivitelezni.
            return true;

        }
    }
}
