using DrawingProblem.Models;
using System.Collections.Generic;

namespace DrawingProblem
{
    /// <summary>
    /// All drawing actions will implement this interface
    /// </summary>
    public interface IDrawing
    {
        void Draw(char[][] matrix, IList<Point> list, char c = ' ');
    }
}
