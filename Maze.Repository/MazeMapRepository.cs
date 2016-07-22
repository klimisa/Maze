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
using Maze.Domain.Points;
using Maze.Domain.Service;

namespace Maze.Repository
{
    public class MazeMapRepository: IMazeMapRepository
{
        public MazeMap GetMazeMap(string filePath)
        {
            try
            {
                if (!File.Exists(filePath))
                {
                    throw new IOException("File not found: " + filePath);
                }

                var rows = File.ReadLines(filePath).ToList();

                MazePoint start = null;
                MazePoint goal = null;
                var mazeMap = new MazePoint[rows.Count, rows[0].Length];

                //TODO: Maybe this belongs to a Creation Method.
                var i = 0;
                foreach (var row in rows)
                {
                    var cols = row.ToCharArray();
                    var j = 0;
                    foreach (var col in cols)
                    {
                        MazePoint point;
                        switch (col)
                        {
                            case 'S':
                                point = new StartPoint(i, j);
                                start = point;
                                break;
                            case 'G':
                                point = new GoalPoint(i, j);
                                goal = point;
                                break;
                            case '_':
                                point = new EmptyPoint(i, j);
                                break;
                            case 'X':
                                point = new WallPoint(i, j);
                                break;
                            default:
                                throw new InvalidDataException();
                        }
                        mazeMap[i, j] = point;

                        j++;
                    }
                    i++;
                }

                return new MazeMap(start, mazeMap);
            }
            catch (Exception e)
            {
                //TODO: log exception
                throw;
            }
        }
    }
}

