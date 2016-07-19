using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Maze.Domain;

namespace Maze.Repository
{
    public class MazeMapRepository
    {
        public MazePoint[][] ProcessRead()
        {
            var filePath = @"../../MazeMap.txt";

            if (File.Exists(filePath))
            {
                throw new IOException("File not found: " + filePath);
            }

            var rows = File.ReadLines(filePath).ToList();
            var mazeMap = new MazePoint[rows.Count][];

            var i = 0;
            foreach (var row in rows)
            {
                var cols = row.ToCharArray();
                mazeMap[i] = new MazePoint[cols.Length];

                var j = 0;
                foreach (var col in cols)
                {
                    MazePoint point;
                    switch (col)
                    {
                        case 'S':
                            point = new MazePoint(i, j, MazePointStatus.Start);
                            break;
                        case 'G':
                            point = new MazePoint(i, j, MazePointStatus.End);
                            break;
                        case '_':
                            point = new MazePoint(i, j, MazePointStatus.Walkable);
                            break;
                        case 'X':
                            point = new MazePoint(i, j, MazePointStatus.Unwalkable);
                            break;
                        default:
                            throw new InvalidDataException();
                    }
                    mazeMap[i][j] = point;

                    j++;
                }
                i++;
            }

            return mazeMap;
        }
    }
}

