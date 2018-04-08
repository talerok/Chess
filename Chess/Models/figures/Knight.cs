using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Models.figures
{
    class Knight : Figure
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

            if (X + 2 < Board.SizeX && Y + 1 < Board.SizeY && (Board[X + 2, Y + 1] == null || Board[X + 2, Y + 1].Color != this.Color)) res[X + 2, Y + 1] = true;
            if (X + 1 < Board.SizeX && Y + 2 < Board.SizeY && (Board[X + 1, Y + 2] == null || Board[X + 1, Y + 2].Color != this.Color)) res[X + 1, Y + 2] = true;
            if (X - 2 >= 0 && Y + 1 < Board.SizeY && (Board[X - 2, Y + 1] == null || Board[X - 2, Y + 1].Color != this.Color)) res[X - 2, Y + 1] = true;
            if (X - 1 >= 0 && Y + 2 < Board.SizeY && (Board[X - 1, Y + 2] == null || Board[X - 1, Y + 2].Color != this.Color)) res[X - 1, Y + 2] = true;
            if (X + 2 < Board.SizeX && Y - 1 >= 0 && (Board[X + 2, Y - 1] == null || Board[X + 2, Y - 1].Color != this.Color)) res[X + 2, Y - 1] = true;
            if (X + 1 < Board.SizeX && Y - 2 >= 0 && (Board[X + 1, Y - 2] == null || Board[X + 1, Y - 2].Color != this.Color)) res[X + 1, Y - 2] = true;
            if (X - 2 >= 0 && Y - 1 >= 0 && (Board[X - 2, Y - 1] == null || Board[X - 2, Y - 1].Color != this.Color)) res[X - 2, Y - 1] = true;
            if (X - 1 >= 0 && Y - 2 >= 0 && (Board[X - 1, Y - 2] == null || Board[X - 1, Y - 2].Color != this.Color)) res[X - 1, Y - 2] = true;
            return res;
        }

        public Knight(int x, int y, bool color, Interfaces.IBoard board) : base(x, y, color, board)
        {
            ID = FiguresId.Knight;
        }


    }
}
