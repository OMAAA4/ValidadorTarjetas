using System.Numerics;

namespace Tarjetas
{
    internal class Program
    {
        const int RestaSuperior = 9;
        const int ComodinMultiProduct = 2;
        static void Main(string[] args)
        {
            Console.WriteLine("\t..::VALIDAR::..");
            string numeroTarjeta = "30569309025904"; //AQUI EL NÚMERO
            string tipoTarjeta;
            bool respuesta = ValidarNumero(numeroTarjeta); 
            if (respuesta)
            {
                tipoTarjeta = TipoTarjeta(numeroTarjeta);
                Console.WriteLine($"TARJETA VALIDA - TIPO: {tipoTarjeta}");
            }
            else Console.WriteLine("Número de tarjeta invalido");
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
                    bool par = i % ComodinMultiProduct != 0;
                    if (par)
                        cadenaProcesada[i] = cadenaNumeros[i] * ComodinMultiProduct > RestaSuperior 
                            ? (cadenaNumeros[i] * ComodinMultiProduct) - RestaSuperior 
                            : cadenaNumeros[i] * ComodinMultiProduct;
                    else
                        cadenaProcesada[i] = cadenaNumeros[i];
                }

                foreach(int x in cadenaProcesada)
                {
                    suma += x;
                }

                if(suma % 10 == 0)
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

        static string TipoTarjeta(string num)
        {
            string prefijo = num[..8];
            int largo = num.Length;

            //Discover
            if ((prefijo[..4] == "6011" || prefijo[..2] == "65" 
                || (Convert.ToInt32(prefijo[..3]) >= 644 && Convert.ToInt32(prefijo[..3]) <= 649)
                || (Convert.ToInt32(prefijo[..6]) >= 622126 && Convert.ToInt32(prefijo[..6]) <= 622925))
                && (largo == 16 || largo == 19))
            {
                return "Discover";
            }
            //China UnionPay
            else if (prefijo[..2] == "62" && (largo >= 16 && largo <= 19))
            {
                return "China UnionPay";
            }
            //Maestro Mastercard / antigua
            else if ((prefijo[..2] == "50" 
                || (Convert.ToInt32(prefijo[..2]) >= 56 && Convert.ToInt32(prefijo[..2]) <= 69))
                && (largo >= 12 && largo <= 19))
            {
                return "MasterCard Maestro";
            }
            //Mastercard
            else if (((Convert.ToInt32(prefijo[..2]) >= 51 && Convert.ToInt32(prefijo[..2]) <= 55) 
                || (Convert.ToInt32(prefijo[..4]) >= 2221 && Convert.ToInt32(prefijo[..4]) <= 2720))
                && largo == 16)
            {
                return "Mastercard";
            }
            //JCB
            else if ((Convert.ToInt32(prefijo[..4]) >= 3528 && Convert.ToInt32(prefijo[..4]) <= 3589)
                && largo == 16)
            {
                return "JCB";
            }
            //Diners Club
            else if ((prefijo[..2] == "36" || prefijo[..2] == "38" 
                || (Convert.ToInt32(prefijo[..3]) >= 300 && Convert.ToInt32(prefijo[..3]) <= 305))
                && largo == 14)
            {
                return "Diners Club";
            }
            //American Express
            else if ((prefijo[..2] == "34" || prefijo[..2] == "37") && largo == 15)
            {
                return "American Express";
            }
            //Visa
            else if (prefijo[..1] == "4" && (largo == 13 || largo == 16 || largo ==19))
            {
                return "Visa";
            }
            else
            {
                return "Tipo No Registrada";
            }
        }
    }
}
