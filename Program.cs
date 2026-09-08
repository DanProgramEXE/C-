
using System.CodeDom;
using System.Media;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;
using otherthings;

namespace MyApplication 
{
    class App
    {
        static void Main(string[] args)
        {
            while(true)
            {
            Console.WriteLine("Program stating.. Insert input:");
            string? entrada = Console.ReadLine();
            int entrada1 = int.Parse(entrada ?? "0");
            Calculador.processor(entrada1);

            string resultado1 = string.Join(" ", Calculador.numeros);
            Console.WriteLine($"Program.houses_output: {resultado1}.");

            int somatório = Calculador.contador(entrada1);
            string binario = string.Join(" ", Calculador.binarios);
            Console.WriteLine($"Program.binary_output: {binario}.");
            Console.WriteLine($"Program.Somatório: {somatório}.");
            
            Console.WriteLine("Quer terminar o programa?");
            string? fim = Console.ReadLine();
            Calculador.binarios.Clear();
            Calculador.numeros.Clear();
            if(fim == "sim" || fim =="Sim"){break;}
            }
        }
    }
}

namespace otherthings
{
    public class Calculador
    {
        public static List<dynamic> numeros = new List<dynamic>(){};
        public static List<dynamic> binarios = new List<dynamic>(){};
        static int numero;
        static int somatório;
        public static void processor(int entrada)
        {
            for (int i=0;i<entrada;i++)
            {
                numero = (int)Math.Pow(2, i);
                numeros.Add(numero);

                if(numero>entrada)
                {
                    if (numeros.Count > 0)
                    {
                      numeros.RemoveAt(i);
                    }
                    break;
                }
            }
        }

        public static int contador(int comparador)
        {
            for (int i = numeros.Count-1; i >= 0; i--)
            {
                somatório += numeros[i];
                if (somatório > comparador)
                {
                  binarios.Add(0);
                  somatório -= numeros[i];
                }
                else{binarios.Add(1);}
            }
            binarios.Reverse();
            somatório = 0;
            return somatório;
        }
    }
}
