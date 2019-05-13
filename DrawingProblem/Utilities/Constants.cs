using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingProblem.Utilities
{
    static class Constants
    {
        public const string EnterCommandMessage = "Enter command: ";
        public const string NoCommandMessage = "No command to execute. Please re-enter!!";
        public const string ExitMessageWhileException = "!!!!!Press enter to exit application!!!!!!";
        public const string ImproperCreateCommandMessage = "Create canvas command should have 3 arguments";
        public const string CanvasNotPresentMessage = "Create canvas before issuing this command";
        public const string ImproperNewLineCommandMessage = "New line command should have 5 arguments";
        public const string ImproperRectangleCommandMessage = "Rectangle command argument should have 5 arguments";
        public const string ImproperFillCommandMessage = "Fill command should have 4 arguments";
        public const string BadCommandMessage = "!!Bad command!!";
        public const string CoordinatesOutsideCanvasMessage = "Coordinates provided are not inside canvas";
        public const string CannotCreateCanvasMessage = "Canvas cannot be created using coordinates provided";
        public const string InvalidArgumentFormat = "Some argument(s) passed have invalid format";
        public const string NotALineMessage = "Cannot create a horizontal or vertical line with the coordinates provided";
        public const string NotARectangleMessage = "Cannot create a rectangle with the coordinates provided";
        public const string ExitQuestion = "Do you want to quit application? Press \"y\" to exit";
        public const string ExitMessage = "Exiting!!";
        public const string CellOccupied = "Cell is occupied and Fill operation cannot be performed.";
        public const string ExceptionMessageToUser = "Something went wrong!! Please contact administrator";
    }
}
