using DrawingProblem.Models;
using System.Collections.Generic;

namespace DrawingProblem.DrawingActions
{
    /// <summary>
    /// Will implement Draw() method of IDrawing interface to create a new rectangle
    /// </summary>
    class CreateRectangle : IDrawing
    {
        public void Draw(char[][] matrix, IList<Point> list, char c = ' ')
        {
            int x1 = list[0].X;
            int y1 = list[0].Y;
            int x2 = list[1].X;
            int y2 = list[1].Y;

            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    if ((i == y1 || i == y2) && j >= x1 && j <= x2)
                    {
                        matrix[i][j] = 'x';
                    }

                    if ((j == x1 || j == x2) && i >= y1 && i <= y2)
                    {
                        matrix[i][j] = 'x';
                    }
                }
            }
        }
    }
}
