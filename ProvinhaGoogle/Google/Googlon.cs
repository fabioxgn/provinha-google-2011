using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Google
{
    public static class Googlon
    {
        static char[] foo = {'v', 'g', 'l', 'd', 't'};
        static string alfabeto = "tslbqfvnzrmxgwcdhpjk";
        public static int ContarPreposicoes(string Texto)
        {
            int tamanho = 3;
            int Count = 0;
            
            char naoOcorre = 'v';
            string[] Palavras = Texto.Split(' ');
            
            Count = 0;
            foreach(string palavra in Palavras)
            {
                if (palavra.Length != tamanho)
                    continue;

                if (!foo.Contains(palavra[palavra.Length - 1]))
                    continue;

                if (palavra.Contains(naoOcorre))
                    continue;                   

                Count++;
            }
            return Count;
        }

        public static void ContarVerbos(string Texto, out int Verbos, out int PrimeiraPessoa)
        {
            int tamanhoMinimo = 7;
            string[] Palavras = Texto.Split(' ');

            Verbos = 0;
            PrimeiraPessoa = 0;
            foreach (string palavra in Palavras)
            {
                if (palavra.Length < tamanhoMinimo)
                    continue;

                if (foo.Contains(palavra[palavra.Length - 1]))
                {
                    Verbos++;
                    if (foo.Contains(palavra[0]))
                        PrimeiraPessoa++;
                }
            }
        }

        private static int Comparar(string a, string b)
        {            
            int I = 0;             
            foreach (char letra in b)
            {
                if (alfabeto.IndexOf(a[I]) == alfabeto.IndexOf(letra))
                {
                    if (a.Length - 1 == I)
                        break;                    
                    I++;
                }
                else if (alfabeto.IndexOf(a[I]) > alfabeto.IndexOf(letra))
                    return 1;
                else
                    return -1;
            }
            return 0;
        }

        public static string SortText(string Texto)
        {
            List<string> palavras = Texto.Split(' ').ToList<string>();
            palavras.Sort((a, b) => Comparar(a, b));

            return string.Join(" ", palavras.ToArray());
        }

        public static long ValorNumerico(string Palavra)
        {
            int Index, I;
            long valor = 0;
            for(I = 0; I < Palavra.Length; I++)
            {
                Index = alfabeto.IndexOf(Palavra[I]);
                valor = valor + (long)(Index * Math.Pow(20, I));
            }
            return valor;
        }

        public static int NumerosBonitos(string Texto)
        {
            List<long> Numeros = new List<long>();
            long Numero;
            foreach (string palavra in Texto.Split(' '))
            {
                Numero = ValorNumerico(palavra);
                if ((Numero >= 575968) & (Numero % 5) == 0)
                    Numeros.Add(Numero);
            }
            return Numeros.Distinct().Count();
        }
    }

   
}
