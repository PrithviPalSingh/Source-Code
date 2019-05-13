using DrawingProblem.Models;
using DrawingProblem.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace DrawingProblem
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                int width = -1;
                int height = -1;
                char c = ' ';
                char[][] matrix = null;

                while (true)
                {
                    Console.Write(Constants.EnterCommandMessage);
                    string[] command = Console.ReadLine().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);

                    List<Point> list = new List<Point>();
                    if (!ProcessCommand(command, list, ref matrix, ref width, ref height, ref c))
                    {
                        IDrawingFactory df = new DrawingFactory.DrawingFactory();
                        IDrawing drawing = null;
                        drawing = df.CreateObject(command[0].ToUpper());
                        drawing.Draw(matrix, list, c);
                        Utilities.Utilities.Paint(matrix);
                    }

                    Console.WriteLine();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(Constants.ExceptionMessageToUser);
                File.AppendAllText("ErrorMessages.txt", Environment.NewLine + DateTime.Now +
                    Environment.NewLine + ex.Message + Environment.NewLine
                    + ex.StackTrace + Environment.NewLine);
                Console.WriteLine(Constants.ExitMessageWhileException);
            }
            finally
            {
                Console.Read();
            }
        }

        /// <summary>
        /// Process command and perform following tasks
        ///     - Store inputs as per the command e.g. list of points
        ///     - creat matrix to hold canvas information
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="c"></param>
        /// <param name="matrix"></param>
        /// <param name="command"></param>
        /// <param name="action"></param>
        /// <param name="list"></param>
        private static bool ProcessCommand(string[] command, List<Point> list, ref char[][] matrix,
            ref int width, ref int height, ref char c)
        {
            bool hasError = true;
            int x1 = -1, y1 = -1, x2 = -1, y2 = -1;
            if (command.Length == 0)
            {
                Console.WriteLine(Constants.NoCommandMessage);
            }
            else
            {
                if (!Enum.TryParse(command[0].ToUpper(), out CommandEnum parsedCommand))
                {
                    Console.WriteLine(Constants.BadCommandMessage);
                }
                else
                {
                    switch (command[0].ToUpper())
                    {
                        case "C":
                            if (command.Length != 3)
                            {
                                Console.WriteLine(Constants.ImproperCreateCommandMessage);
                                break;
                            }

                            if (!int.TryParse(command[1], out width) || !int.TryParse(command[2], out height))
                            {
                                Console.WriteLine(Constants.InvalidArgumentFormat);
                                break;
                            }

                            if (width <= 0 || height <= 0)
                            {
                                Console.WriteLine(Constants.CannotCreateCanvasMessage);
                                break;
                            }

                            hasError = false;
                            list.Add(new Point { X = width, Y = height });
                            matrix = new char[height + 2][];
                            break;
                        case "L":
                            if (matrix == null)
                            {
                                Console.WriteLine(Constants.CanvasNotPresentMessage);
                                break;
                            }

                            if (command.Length != 5)
                            {
                                Console.WriteLine(Constants.ImproperNewLineCommandMessage);
                                break;
                            }

                            if (!int.TryParse(command[1], out x1) || !int.TryParse(command[2], out y1)
                                || !int.TryParse(command[3], out x2) || !int.TryParse(command[4], out y2))
                            {
                                Console.WriteLine(Constants.InvalidArgumentFormat);
                                break;
                            }

                            if ((x1 != x2) && (y1 != y2))
                            {
                                Console.WriteLine(Constants.NotALineMessage);
                                break;
                            }

                            hasError = false;
                            if (x1 < x2)
                            {
                                list.Add(new Point { X = x1, Y = y1 });
                                list.Add(new Point { X = x2, Y = y2 });
                            }
                            else if (x2 < x1)
                            {
                                list.Add(new Point { X = x2, Y = y2 });
                                list.Add(new Point { X = x1, Y = y1 });
                            }
                            else
                            {
                                if (y1 < y2)
                                {
                                    list.Add(new Point { X = x1, Y = y1 });
                                    list.Add(new Point { X = x2, Y = y2 });
                                }
                                else
                                {
                                    list.Add(new Point { X = x2, Y = y2 });
                                    list.Add(new Point { X = x1, Y = y1 });
                                }
                            }

                            break;
                        case "R":

                            if (matrix == null)
                            {
                                Console.WriteLine(Constants.CanvasNotPresentMessage);
                                break;
                            }

                            if (command.Length != 5)
                            {
                                Console.WriteLine(Constants.ImproperRectangleCommandMessage);
                                break;
                            }

                            if (!int.TryParse(command[1], out x1) || !int.TryParse(command[2], out y1)
                                || !int.TryParse(command[3], out x2) || !int.TryParse(command[4], out y2))
                            {
                                Console.WriteLine(Constants.InvalidArgumentFormat);
                                break;
                            }

                            if ((x1 == x2) || (y1 == y2))
                            {
                                Console.WriteLine(Constants.NotARectangleMessage);
                                break;
                            }

                            hasError = false;

                            if (x1 < x2)
                            {
                                if (y1 < y2)
                                {
                                    list.Add(new Point { X = x1, Y = y1 });
                                    list.Add(new Point { X = x2, Y = y2 });
                                }
                                else
                                {
                                    list.Add(new Point { X = x1, Y = y2 });
                                    list.Add(new Point { X = x2, Y = y1 });
                                }
                            }
                            else
                            {
                                if (y1 < y2)
                                {
                                    list.Add(new Point { X = x2, Y = y1 });
                                    list.Add(new Point { X = x1, Y = y2 });
                                }
                                else
                                {
                                    list.Add(new Point { X = x2, Y = y2 });
                                    list.Add(new Point { X = x1, Y = y1 });
                                }
                            }

                            break;
                        case "B":
                            if (matrix == null)
                            {
                                Console.WriteLine(Constants.CanvasNotPresentMessage);
                                break;
                            }

                            if (command.Length != 4)
                            {
                                Console.WriteLine(Constants.ImproperFillCommandMessage);
                                break;
                            }

                            if (!int.TryParse(command[1], out x1) || !int.TryParse(command[2], out y1)
                                || !char.TryParse(command[3], out c))
                            {
                                Console.WriteLine(Constants.InvalidArgumentFormat);
                                break;
                            }

                            if (x1 >= 0 && y1 >= 0 && x1 < (width + 2) && y1 < (height + 2)
                                && matrix[y1][x1] != '\0')
                            {
                                Console.WriteLine(Constants.CellOccupied);
                                break;
                            }

                            hasError = false;
                            list.Add(new Point { X = x1, Y = y1 });
                            break;
                        case "Q":
                            Console.WriteLine(Constants.ExitQuestion);
                            var input = Console.ReadLine();
                            if (input.Equals("y", StringComparison.OrdinalIgnoreCase))
                            {
                                Console.WriteLine(Constants.ExitMessage);
                                Thread.Sleep(500);
                                Environment.Exit(0);
                            }

                            break;
                        default:
                            Console.WriteLine(Constants.BadCommandMessage);
                            break;
                    }
                }
            }

            if (!hasError && !Utilities.Utilities.ValidCoordinates(list, width, height))
            {
                hasError = true;
                Console.WriteLine(Constants.CoordinatesOutsideCanvasMessage);
            }

            return hasError;
        }
    }
}
