using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Models.figures
{
    class Pawn : Figure
    {
        public override bool[,] GetCorrectPaths()
        {
            var res = new bool[Board.SizeX, Board.SizeY];

            for (int i = 0; i < Board.SizeX; i++)
            {
                for (int j = 0; j < Board.SizeY; j++)
                {
                    res[i, j] = false;
                }
            }

            if (!Color)
            {
                if (Y + 1 < Board.SizeY &&  Board[X, Y + 1] == null)
                {
                    res[X, Y + 1] = true;
                    if (Y == 1 && Board[X, 3] == null) res[X, 3] = true;
                }

                if (X + 1 < Board.SizeX && Y + 1 < Board.SizeY && Board[X + 1, Y + 1] != null && Board[X + 1, Y + 1].Color != this.Color) res[X + 1, Y + 1] = true;
                if (X - 1 >= 0 && Y + 1 < Board.SizeY && Board[X - 1, Y + 1] != null && Board[X - 1, Y + 1].Color != this.Color) res[X - 1, Y + 1] = true;
            }
            else
            {
                if (Board[X, Y - 1] == null)
                {
                    res[X, Y - 1] = true;
                    if (Y == Board.SizeY - 2 && Board[X, Board.SizeY - 4] == null) res[X, Board.SizeY - 4] = true;
                }

                if (X + 1 < Board.SizeX && Y - 1 >= 0 && Board[X + 1, Y - 1] != null && Board[X + 1, Y - 1].Color != this.Color) res[X + 1, Y - 1] = true;
                if (X - 1 >= 0 && Y - 1 >= 0 && Board[X - 1, Y - 1] != null && Board[X - 1, Y - 1].Color != this.Color) res[X - 1, Y - 1] = true;
            }

            return res;
        }

        public Pawn(int x, int y, bool color, Interfaces.IBoard board) : base(x, y, color, board)
        {
            ID = FiguresId.Pawn;
        }

        public override void MoveTo(int x, int y)
        {
            var a = Board[x, y];
            if (a != null) Board.RemoveFigure(a);
            X = x;
            Y = y;
            if (Color && y == 0) Board.PawnToQueen(this);
            else if (!Color && y == Board.SizeY - 1) Board.PawnToQueen(this);
        }


    }
}
