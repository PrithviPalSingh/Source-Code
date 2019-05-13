namespace DrawingProblem
{
    /// <summary>
    /// Inteface for object factory class
    /// </summary>
    interface IDrawingFactory
    {
        IDrawing CreateObject(string c);
    }
}
