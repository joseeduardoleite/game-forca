using System;
using System.Collections.Generic;

namespace GameForca
{
    class Program
    {
        static int tentativas;
        static string palavra;
        static int tamanhoPalavra;
        public static List<char> listaLetrasUsuario = new List<char>();
        static void Main(string[] args)
        {
            bool letraExiste = false;
            char tentativaLetraUsuario = ' ';

            Console.Clear();
            Console.WriteLine("Digite a palavra:");
            palavra = Console.ReadLine().ToLower();
            Console.WriteLine("Digite quantas tentativas o jogador vai ter:");
            tentativas = int.Parse(Console.ReadLine());

            tamanhoPalavra = palavra.Length;
            string[] vetor = new string[tamanhoPalavra];
            string[] vetorUsuario = new string[tamanhoPalavra];        

            for (int i = 0; i < tamanhoPalavra; i++) {
                vetor[i] = palavra[i].ToString();
            }

            for (int i = 0; i < tamanhoPalavra; i++) {
                vetorUsuario[i] = "_";
            }

            int iterator = 1;
            while (tentativas > 0) {
                if (iterator == 1) {
                    Console.Clear();
                    EscreverQuantidadeLetras();
                    EscreverLetrasVetorUsuario(vetorUsuario);
                }

                while (letraExiste == false) {
                    Console.WriteLine("Digite a " + iterator + "º letra:" + " (Tentativas: " + tentativas + ")");
                    tentativaLetraUsuario = char.Parse(Console.ReadLine().ToLower());
                    iterator++;

                    if (listaLetrasUsuario.Contains(tentativaLetraUsuario)) 
                        Console.WriteLine("Você já tentou a letra '" + tentativaLetraUsuario + "', tente outra:");
                    else {
                        letraExiste = true;
                        listaLetrasUsuario.Add(tentativaLetraUsuario);
                    }
                }
                letraExiste = false;

                if (LetraEncontrada(tentativaLetraUsuario, palavra)) {
                    for (int i = 0; i < tamanhoPalavra; i++) {
                        if (palavra.Contains(tentativaLetraUsuario)) {
                            if (vetor[i].Contains(tentativaLetraUsuario)) {
                                vetorUsuario[i] = tentativaLetraUsuario.ToString();
                            }
                            else if (vetorUsuario[i] == "_"){
                                vetorUsuario[i] = "_";
                            }
                        }
                    }
                }

                Console.Clear();
                EscreverQuantidadeLetras();
                EscreverLetrasDigitadas();
                EscreverLetrasVetorUsuario(vetorUsuario);
                PalavraEncontrada(vetorUsuario);        
            }
            Console.WriteLine("Você perdeu...\nA palavra era: " + palavra);
            Environment.Exit(0);
        }

        private static void PalavraEncontrada(string[] vetorUsuario) {
            string palavraUsuario = String.Join("", vetorUsuario);
            if (palavraUsuario == palavra) {
                Console.WriteLine("Parabéns, você adivinhou!");
                Environment.Exit(0);
            }
        }

        private static bool LetraEncontrada(char tentativaLetraUsuario, string palavra) {
            if (!palavra.Contains(tentativaLetraUsuario)) {
                tentativas--;
                Console.Write("A letra '" + tentativaLetraUsuario + "' não contém na palavra, aperte qualquer tecla para continuar...");
                Console.ReadKey();
                return false;
            }
            return true;
        }

        private static void EscreverLetrasVetorUsuario(string[] vetorUsuario) {
            Console.WriteLine(" ____");
            Console.WriteLine("|    |");
            Console.WriteLine("| ");
            Console.Write("| ");
            foreach (var item in vetorUsuario) {
                Console.Write(item);
            }
            Console.WriteLine("\n");
        }

        private static void EscreverLetrasDigitadas() {
            Console.Write("Letras já digitadas: ");
            foreach (var item in listaLetrasUsuario) {
                Console.Write("'" + item + "' ");
            }
            Console.WriteLine();
        }

        private static void EscreverQuantidadeLetras() {
            Console.WriteLine("Quantidade de letras na palavra: " + tamanhoPalavra);
        }
    }
}