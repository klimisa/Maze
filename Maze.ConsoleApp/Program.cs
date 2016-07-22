using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Maze.Application;

namespace Maze.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //TODO: A Menu
            //1. Sample1
            //2. Sample2
            //3. Your sample file

            try
            {
                var filePath = Path.Combine(Environment.CurrentDirectory, @"..\..\MazeMapS2.txt");
                var pathFinderService = new PathFinderService();
                var actorRoute = pathFinderService.FindPathFromFile(filePath);

                Console.WriteLine(actorRoute);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadLine();
        }

    }
}

