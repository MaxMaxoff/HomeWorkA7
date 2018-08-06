using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

// Библиотека для упрощения работы с консолью.
// https://github.com/MaxMaxoff/SupportLibrary
using SupportLibrary;

/// <summary>
/// Максим Торопов
/// Ярославль
/// https://github.com/MaxMaxoff
/// 
/// Домашняя работа "Алгоритмы и структуры данных"
/// 7 урок
/// </summary>
namespace HomeWorkA7
{
    class Program
    {
        /// <summary>
        /// 1. Написать функции, которые считывают матрицу смежности из файла и выводят ее на экран
        /// </summary>
        static void Task1()
        {
            string filename = "./matrix.txt";

            int lineCount = TotalLines(filename);

            Graphs graph = new Graphs(lineCount, filename);

            graph.writeMatrixTofile("./matrix2.txt");

            SupportMethods.Pause(graph.ToString());           

        }

        /// <summary>
        /// function Lines in file
        /// </summary>
        /// <param name="filePath">filename</param>
        /// <returns>lines qty</returns>
        static int TotalLines(string filePath)
        {
            using (StreamReader r = new StreamReader(filePath))
            {
                int i = 0;
                while (r.ReadLine() != null) { i++; }
                if (r != null) r.Close();
                return i;
            }
        }

        /// <summary>
        /// 2. Написать рекурсивную функцию обхода графа в глубину.
        /// </summary>
        static void Task2()
        {

        }

        /// <summary>
        /// 3. Написать функцию обхода графа в ширину.
        /// </summary>
        static void Task3()
        {
            // try-catch section
            try
            {
                string filename = "./matrix.txt";

                int lineCount = TotalLines(filename);

                Graphs graph = new Graphs(lineCount, filename);

                TNode<int> stack = new TNode<int>(lineCount);

            }
            catch (InvalidOperationException ex)
            {
                SupportMethods.Pause(ex.Message);
            }

            SupportMethods.Pause();

        }

        /// <summary>
        /// 4. *Создать библиотеку функций для работы с графами.
        /// </summary>
        static void Task4()
        {

        }

        static void Main(string[] args)
        {
            do
            {
                SupportMethods.PrepareConsoleForHomeTask("1 - Task 1\n" +
                  "2 - Task 2\n" +
                  "3 - Task 3\n" +
                  "4 - Task 4\n" +
                  "0 (Esc) - Exit\n");
                ConsoleKeyInfo key = Console.ReadKey();
                Console.WriteLine();
                switch (key.Key)
                {
                    case ConsoleKey.D1:
                        Task1();
                        break;
                    case ConsoleKey.D2:
                        Task2();
                        break;
                    case ConsoleKey.D3:
                        Task3();
                        break;
                    case ConsoleKey.D4:
                        Task4();
                        break;
                    case ConsoleKey.D0:
                    case ConsoleKey.Escape:
                        return;
                    default:
                        break;
                }
            } while (true);
        }
    }
}
