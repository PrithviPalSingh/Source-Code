using DrawingProblem.Models;
using System;
using System.Collections.Generic;

namespace DrawingProblem.Utilities
{    
    /// <summary>
    /// This is a helper class that comprises of all the comman functionalities
    /// </summary>
    static class Utilities
    {
        /// <summary>
        /// Draw the canvas using matrix send to this method
        /// </summary>
        public static void Paint(char[][] matrix)
        {          
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    Console.Write(matrix[i][j]);
                }

                Console.WriteLine();
            }           
        }

        /// <summary>
        /// Return true
        ///     - If all the points are inside canvas
        /// false
        ///     - If any one point is crossing canvas boundries
        /// </summary>
        public static bool ValidCoordinates(List<Point> pointList, int w, int h)
        {
            foreach (var item in pointList)
            {
                if (item.X <= 0 || item.X >= (w + 1) || item.Y <= 0 || item.Y >= (h + 1))
                    return false;
            }

            return true;
        }
    }
}
