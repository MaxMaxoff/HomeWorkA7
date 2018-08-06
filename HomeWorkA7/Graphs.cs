using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace HomeWorkA7
{
    class Graphs
    {
        /// <summary>
        /// adjacency matrix
        /// </summary>
        int[,] graph;

        /// <summary>
        /// array of vertexes
        /// </summary>
        string[] vertex;

        /// <summary>
        /// Initialize graph with default size 10x10
        /// </summary>
        public Graphs()
        {
            graph = new int[10, 10];
            vertex = new string[10];
        }

        /// <summary>
        /// Initialize graph with requested size
        /// </summary>
        /// <param name="n">size of graph</param>
        public Graphs(int n)
        {
            graph = new int[n, n];
            vertex = new string[n];
        }

        /// <summary>
        /// Initialize graph with requested size and read data from file
        /// </summary>
        /// <param name="n">size of graph</param>
        /// <param name="filename">filename</param>
        public Graphs(int n, string filename):this(n)
        {
            readMatrixFromFile(filename);
        }
        

        /// <summary>
        /// Method read matrix from file
        /// </summary>
        /// <param name="filename">name of the file</param>
        /// <returns>true/false</returns>
        public bool readMatrixFromFile(string filename)
        {
            int i = 0;
            string line;

            StreamReader streamReader = null;

            try
            {
                streamReader = new StreamReader(filename);

                while (!streamReader.EndOfStream)
                {
                    try
                    {
                        line = streamReader.ReadLine();
                        string[] fields = line.Split(',');
                        vertex[i] = fields[0];
                        for (int j = 1; j < fields.Length; j++)
                            int.TryParse(fields[j], out graph[j, i]);
                    }
                    catch
                    {

                    }
                    i++;
                }
            }
            catch
            {
                Console.WriteLine($"Something goes wrong! Please check the file {filename}");
                return false;
            }
            finally
            {
                streamReader?.Close();
            }

            return true;
        }

        /// <summary>
        /// Method write matrix to file
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public bool writeMatrixTofile(string filename)
        {

            StreamWriter streamWriter = null;
            string str = "0";

            try
            {
                streamWriter = new StreamWriter(filename);

                for (int j = 1; j < vertex.Length; j++)
                    str += $",{vertex[j]}";

                for (int j = 1; j < vertex.Length; j++)
                {
                    str += $"\r\n{vertex[j]}";
                    for (int i = 1; i < vertex.Length; i++)
                    {
                        str += $",{graph[i, j]}";
                    }
                }

                streamWriter.WriteLine(str);

            }
            catch (DirectoryNotFoundException exc)
            {
                Console.WriteLine(exc.Message);
            }
            catch (Exception)
            {
                Console.WriteLine("Something goes wrong!");
                return false;
            }
            finally
            {
                //if (streamWriter!=null)
                //streamWriter.Close();
                streamWriter?.Close();

            }

            return true;
        }

        /// <summary>
        /// Method print out adjacency matrix
        /// </summary>
        /// <returns>adjacency matrix</returns>
        public override string ToString()
        {
            string str = "    ";

            for (int j = 1; j < vertex.Length; j++)
                str += $"{vertex[j],3}";

            for (int j = 1; j < vertex.Length; j++)
            {
                str += $"\n {vertex[j],3}";
                for (int i = 1; i < vertex.Length; i++)
                {
                    str += $"{graph[i, j],3}";
                }
            }
            return str;
        }
    }
}
