using DrawingProblem.DrawingActions;
using DrawingProblem.Utilities;
using System;

namespace DrawingProblem.DrawingFactory
{
    /// <summary>
    /// Factory class that will return object of intened drawing class as per command send accross
    /// </summary>
    class DrawingFactory : IDrawingFactory
    {
        public IDrawing CreateObject(string c)
        {
            IDrawing drawing = null;

            if (!Enum.TryParse(c, out CommandEnum command))
            {
                return drawing;
            }
            else
            {
                if (command == CommandEnum.C)
                {
                    drawing = new CreateCanvas();
                }
                else if (command == CommandEnum.L)
                {
                    drawing = new CreateNewLine();
                }
                else if (command == CommandEnum.R)
                {
                    drawing = new CreateRectangle();
                }
                else if (command == CommandEnum.B)
                {
                    drawing = new FillArea();
                }
            }

            return drawing;
        }
    }
}
