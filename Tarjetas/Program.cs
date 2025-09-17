using System.Numerics;

namespace Tarjetas
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            bool respuesta = ValidarNumero("16516516816849"); //AQUI EL NÚMERO
            if (respuesta)
                Console.WriteLine("Tarjeta valida!!");
            else Console.WriteLine("Tarjeta Invalida");
        }

        static bool ValidarNumero(string num)
        {
            char[] cadena = new char[] { };
            int[] cadenaNumeros;
            int[] cadenaProcesada;
            int iterador = 0;
            int suma = 0;
            long validado;
            if(long.TryParse(num, out validado))
            {
                cadena = num.ToCharArray();
                cadenaNumeros = new int[cadena.Length];
                foreach (char x in cadena.Reverse())
                {
                    cadenaNumeros[iterador] = int.Parse(x.ToString());
                    iterador++;
                }
                cadenaProcesada = new int[cadenaNumeros.Length];
                for (int i = 0; i < cadenaNumeros.Length; i++)
                {
                    bool par = i % 2!=0 ? true : false;
                    if (par)
                        cadenaProcesada[i] = cadenaNumeros[i] * 2 > 9 ? (cadenaNumeros[i] * 2)-9 : cadenaNumeros[i] * 2;
                    else
                        cadenaProcesada[i] = cadenaNumeros[i];
                }

                foreach(int x in cadenaProcesada)
                {
                    suma = suma + x;
                }

                if(suma%10 == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
            
        }
    }
}
