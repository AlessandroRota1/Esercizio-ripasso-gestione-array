using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esercizio_ripasso_gestione_array
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //dichiarazioni
            int[] array = new int[100];
            int n = 0, el = 0, dim = 0, scelta = 0;

            //struttura menù
            do
            {
                //stampa delle opzioni
                Console.Clear();
                Console.WriteLine("1 - Caricamento di un array di n numeri random compresi tra X e Y");
                Console.WriteLine("2 - Troncamento di un array data una dimenzione Z");
                Console.WriteLine("3 - Aggiunta ordinata di numeri in un array");
                Console.WriteLine("4 - Uscita del programma");
                //scelta dell'opzione
                Console.WriteLine("\n Inserisci la scelta: ");
                scelta = int.Parse(Console.ReadLine());
                //esecuzione dell'opzione
                switch (scelta)
                {
                    case 1:
                        Console.WriteLine("Inserire n: ");
                        int num = int.Parse(Console.ReadLine());
                        Console.WriteLine("Inserire X: ");
                        int X = int.Parse(Console.ReadLine());
                        Console.WriteLine("Inserire Y: ");
                        int Y = int.Parse(Console.ReadLine());
                        array = ArrayRandom(array, num, X, Y, ref dim);
                        Console.WriteLine("Array generato correttamente");
                        break;
                    case 2:
                        Console.WriteLine("Inserire Z: ");
                        int Z = int.Parse(Console.ReadLine());
                        TroncaArray(ref dim, Z);
                        Console.WriteLine("Array troncato correttamente");
                        break;
                    case 3:
                        Console.WriteLine("Inserire il numero: ");
                        el = int.Parse(Console.ReadLine());
                        PosizionamentoCorretto(array, ref dim, el);
                        Console.WriteLine("Elemento inserito correttamente");
                        break;
                }
                Console.WriteLine("Premere un tasto per continuare...");
                Console.ReadLine();
            } while (scelta != 4);
        }
            static int[] ArrayRandom(int[] array, int numero, int x, int y, ref int dim)
            {
                //assegno a dim il valore numero
                dim = numero;
                //dichiarazioni
                Random random = new Random();
                //ciclo di caricamento dell'array con numeri casuali compresi tra X e Y
                for (int i = 0; i < dim; i++)
                {
                    array[i] = random.Next(x, y + 1);
                }
                return array;
            }
            static void TroncaArray(ref int dim, int Z)
            {
                //riduco l'array alla dimensione Z
                dim = dim - (dim - Z);
            }
            static bool AggiungiElemento(int[] array, int elem, ref int i)
            {
                bool ins = true;
                //controllo la dimensione dell'array
                if (i < array.Length)
                {
                    //inserimento
                    array[i] = elem;
                    i++;
                }
                else //se l'array è pieno
                {
                    ins = false;
                }
                return ins;
            }
            static void PosizionamentoCorretto(int[] array, ref int dimensione, int el)
            {
                //dichiarazioni
                int x, y, temp;
                //aggiunge l'elemento
                if (AggiungiElemento(array, el, ref dimensione))
                {
                    Console.WriteLine("Elemento inserito correttamente");
                }
                else
                {
                    Console.WriteLine("Array pieno");
                }
                //ciclo per tutti i numeri
                for (x = 0; x < dimensione - 1; x++)
                {
                    //per confrontare tutte le coppie
                    for (y = 0; y < dimensione - 1; y++)
                    {
                        //se la coppia è da scambiare
                        if (array[y] > array[y + 1])
                        {
                            temp = array[y];
                            //faccio avvenire lo scambio
                            array[y] = array[y + 1];
                            array[y + 1] = temp;
                        }
                    }
                }
            }
        }
    }