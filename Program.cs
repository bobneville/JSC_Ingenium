using System;

namespace JSC_Ingenium
{
    class Program
    {
        static void Main(string[] args)
        {

            Random randNum = new Random();


            int iMin = 0;
            int iMax = 1000000;
            int iMaxCumbres = 400000;

            int iMaximoCumbres = randNum.Next(1, iMaxCumbres);            
            int iLongitudArray = randNum.Next(iMin, iMaximoCumbres);

            // testeo para comprobar función, comentar 
            //int iMaximoCumbres = 1500;
            //int[] arrCumbres = new[] { 1, 6, 4, 5, 4, 5, 1, 2, 3, 4, 7, 2 };           

            int[] arrCumbres = new int[iLongitudArray];            
            for (int i = 0; i < arrCumbres.Length; i++)
            {
                arrCumbres[i] = randNum.Next(iMin, iMax);
            }

            // Llamo a cálculos
            int iCaniones = Solucion.Caniones(arrCumbres);                   
            // final 
            Console.WriteLine("Puntos a tratar: {0}", arrCumbres.Length);
            Console.WriteLine("Cañones posicionados: {0}", iCaniones);
            Console.ReadKey();
        }
    }
}
