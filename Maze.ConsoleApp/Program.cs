﻿using System;
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

            var filePath = Path.Combine(Environment.CurrentDirectory, @"..\..\MazeMapS1.txt");
            var pathFinderService = new PathFinderService();
            var actorRoute = pathFinderService.FindPathFromFile(filePath);

            Console.WriteLine(actorRoute);
            Console.ReadLine();
        }

    }
}

