using System;

namespace RistorApp.ConsoleApp.Utilities
{
    public class ReadUtility
    {
        public static int Intero(string messaggio, bool positive = false)
        {
            int output = 0;
            string input;
            bool continua = true;

            do
            {
                Console.Write(messaggio);
                input = Console.ReadLine() ?? "";
                try
                {
                    output = int.Parse(input);

                    if (positive && output < 0)
                    {
                        throw new IndexOutOfRangeException();
                    }

                    continua = false;
                }
                catch (IndexOutOfRangeException)
                {
                    Console.WriteLine("Inserire un numero maggiore di zero..");
                }
                catch
                {
                    Console.WriteLine("Inserire un numero intero valido..");
                }
            } while (continua);

            return output;
        }

        public static int Range(string messaggio, int max, int min = 0)
        {
            int output;
            bool continua = true;

            do
            {
                output = Intero(messaggio);

                if (output < min || output > max)
                {
                    Console.WriteLine($"Inserire numero compreso tra {min} e {max}..");
                }
                else
                {
                    continua = false;
                }
            } while (continua);

            return output;
        }

        public static DateTime Data(string messaggio)
        {
            string input;
            bool continua = true;

            do
            {
                Console.Write(messaggio);
                input = Console.ReadLine() ?? "";

                try
                {
                    DateTime output = DateTime.Parse(input);
                    return output;
                }
                catch
                {
                    Console.WriteLine("Inserire una data valida in formato YYYY/MM/DD..");
                }
            } while (continua);

            return DateTime.Now;
        }
    }
}
