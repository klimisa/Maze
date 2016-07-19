using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Maze.Repository;

namespace Maze.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var mazeMapRepository = new MazeMapRepository();
            mazeMapRepository.ProcessRead();

            Console.ReadLine();
        }

    }
}

