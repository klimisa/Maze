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
    public class MazeMapRepository: IMazeMapRepository
{
        public MazeMap GetMazeMap(string filePath)
        {
            if (!File.Exists(filePath))
            {
                throw new IOException("File not found: " + filePath);
            }

            var rows = File.ReadLines(filePath).ToList();

            MazePoint start = null;
            MazePoint goal = null;
            var mazeMap = new MazePoint[rows.Count][];

            //TODO: Maybe this belongs to a Creation Method.
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
                            point = MazePoint.CreateStartPoint(i, j);
                            start = point;
                            break;
                        case 'G':
                            point = MazePoint.CreateGoalPoint(i, j);
                            goal = point;
                            break;
                        case '_':
                            point = MazePoint.CreateWalkablePoint(i, j);
                            break;
                        case 'X':
                            point = MazePoint.CreateObstaclePoint(i, j);
                            break;
                        default:
                            throw new InvalidDataException();
                    }
                    mazeMap[i][j] = point;

                    j++;
                }
                i++;
            }

            return new MazeMap(start, goal, mazeMap);
        }
    }
}

