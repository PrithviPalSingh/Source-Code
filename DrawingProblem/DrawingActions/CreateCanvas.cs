using DrawingProblem.Models;
using System.Collections.Generic;

namespace DrawingProblem.DrawingActions
{
    /// <summary>
    /// Will implement Draw() method of IDrawing interface to create canvas
    /// </summary>
    class CreateCanvas : IDrawing
    {
        public void Draw(char[][] matrix, IList<Point> list, char c = ' ')
        {
            int w = list[0].X;
            int h = list[0].Y;

            for (int i = 0; i < h + 2; i++)
            {
                matrix[i] = new char[w + 2];
                for (int j = 0; j < w + 2; j++)
                {
                    if (i == 0 || i == h + 1)
                    {
                        matrix[i][j] = '-';
                    }
                    else
                    {
                        if (j == 0 || j == (w + 1))
                        {
                            matrix[i][j] = '|';
                        }
                    }
                }
            }
        }
    }
}
