using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Interfaces
{
    interface IFigure 
    {
        Models.FiguresId ID { get; }
        int X { get; }
        int Y { get; }
        void MoveTo(int x, int y);
        bool Color { get; }
        bool[,] GetCorrectPaths(); 
    }
}
