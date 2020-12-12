using System;
using System.Collections.Generic;

namespace JSC_Ingenium
{
    public static class Solucion
    {

        public static int Caniones(int[] arrDatos)
        {
            if (arrDatos == null)
                throw new ArgumentNullException(nameof(arrDatos));

            if (arrDatos.Length<3)
            {
                return 0;
            }
           
            // Vemos los picos
            IList<int> ilPosiciones = Posiciones(arrDatos);
            // Cañones
            int iCaniones = Caniones(arrDatos, ilPosiciones);

            return iCaniones;
        }

        private static IList<int> Posiciones(IList<int> arrayDatos)
        {
            List<int> iPosiciones = new List<int>();

            int iLongitudDatos = arrayDatos.Count - 1;
            int a = 0;
            while (a <= iLongitudDatos)
            {
                // Extremo izquierdo
                if (a == 0)
                {
                    if (arrayDatos[0] > arrayDatos[1])
                    {
                        iPosiciones.Add(0);
                    }
                }
                else if (a == iLongitudDatos)
                {
                    // Final del array
                    if (arrayDatos[iLongitudDatos] > arrayDatos[iLongitudDatos - 1])
                    {
                        iPosiciones.Add(iLongitudDatos);
                    }

                }
                else
                {
                    if ((arrayDatos[a] > arrayDatos[a - 1]) && (arrayDatos[a] > arrayDatos[a + 1]))
                    {
                        iPosiciones.Add(a);
                    }
                }
                a++;

            }

            //for (int i = 1; i < arrayDatos.Count-1; i++)
            //{
            //    if ((arrayDatos[i] > arrayDatos[i-1]) && (arrayDatos[i] > arrayDatos[i+1]))
            //    {
            //        iPosiciones.Add(i);
            //    }
            //}
            return iPosiciones;
        }

        private static int Caniones(IList<int> arrayCumbres, IList<int> arrayDatos)
        {
            int iNumDatos = arrayDatos.Count;
            if (iNumDatos <= 2)
                return iNumDatos;
            int iCanionesMax = Math.Min(iNumDatos, (int)Math.Sqrt(arrayCumbres.Count));
            int iPosicionDerecha = arrayDatos[iNumDatos - 1];
            int iDistancia = iCanionesMax;

            for (int a=iCanionesMax-2; a>0; a--)
            {
                int iCaniones = a;
                int iPrimero = arrayDatos[0];

                for (int i=1; i<=iNumDatos-2; i++)
                {
                    if ((arrayDatos[i]-iPrimero >= iDistancia) && (iPosicionDerecha-arrayDatos[i] >= iDistancia))
                    {
                        if (iCaniones == 1)
                        { 
                         return (a+2);
                        }
                        iCaniones--;
                        iPrimero = arrayDatos[i];
                    }

                    if (iPosicionDerecha - arrayDatos[i]<=iCaniones*(iDistancia + 1))
                        break;
                }
                if (iCaniones == 0)
                    return (a+2);
                iDistancia--;
            }
            return 2;
        }
    }
}
