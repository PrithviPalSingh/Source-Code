using DrawingProblem.Models;
using System.Collections.Generic;

namespace DrawingProblem.DrawingActions
{
    /// <summary>
    /// Will implement Draw() method of IDrawing interface to fill area with specified character
    /// </summary>
    class FillArea : IDrawing
    {
        public void Draw(char[][] matrix, IList<Point> list, char c = ' ')
        {
            int x = list[0].X;
            int y = list[0].Y;

            if (x < 1 || y < 1 || matrix[y][x] == 'x' || matrix[y][x] == '-' || matrix[y][x] == '|')
                return;

            matrix[y][x] = c;

            if (x > 0 && matrix[y][x - 1] == '\0')
                Draw(matrix, new List<Point>() { new Point { X = x - 1, Y = y } }, c);

            if (x < matrix[y].Length - 1 && matrix[y][x + 1] == '\0')
                Draw(matrix, new List<Point>() { new Point { X = x + 1, Y = y } }, c);

            if (y > 0 && matrix[y - 1][x] == '\0')
                Draw(matrix, new List<Point>() { new Point { X = x, Y = y - 1 } }, c);

            if (y < matrix.Length - 1 && matrix[y + 1][x] == '\0')
                Draw(matrix, new List<Point>() { new Point { X = x, Y = y + 1 } }, c);
        }
    }
}
