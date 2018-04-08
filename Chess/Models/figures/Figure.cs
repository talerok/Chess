using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chess.Interfaces;

namespace Chess.Models.figures
{
    class Figure : Interfaces.IFigure
    {
        public bool Color { get; private set; }

        public int X { get; protected set; }

        public int Y { get; protected set; }

        public FiguresId ID { get; protected set; }

        protected Interfaces.IBoard Board;

        public virtual bool[,] GetCorrectPaths()
        {
            return null;
        }

        public Figure(int x, int y, bool color, Interfaces.IBoard board)
        {
            X = x;
            Y = y;
            Color = color;
            Board = board;
        }

        public virtual void MoveTo(int x, int y)
        {
            var a = Board[x, y];
            if (a != null) Board.RemoveFigure(a);
            X = x;
            Y = y;
        }
    }
}
