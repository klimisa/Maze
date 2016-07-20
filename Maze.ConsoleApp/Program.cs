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
            var filePath = Path.Combine(Environment.CurrentDirectory, @"..\..\MazeMap.txt");
            var pathFinderService = new PathFinderService();
            var path = pathFinderService.FindPathFromFile(filePath);

            Console.ReadLine();
        }

    }
}

