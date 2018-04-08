using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Models.figures
{
    class Bishop : Figure
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
            //------------------------------------------
            for (int i = 1; X + i < Board.SizeX && Y + i < Board.SizeY; i++)
            {
                if (Board[X + i, Y + i] == null) res[X + i, Y + i] = true;
                else
                {
                    if (Board[X + i, Y + i].Color != this.Color) res[X + i, Y + i] = true;
                    break;
                }
            }

            for (int i = 1; X - i >= 0 && Y - i >= 0; i++)
            {
                if (Board[X - i, Y - i] == null) res[X - i, Y - i] = true;
                else
                {
                    if (Board[X - i, Y - i].Color != this.Color) res[X - i, Y - i] = true;
                    break;
                }
            }

            for (int i = 1; X + i < Board.SizeX && Y - i >= 0; i++)
            {
                if (Board[X + i, Y - i] == null) res[X + i, Y - i] = true;
                else
                {
                    if (Board[X + i, Y - i].Color != this.Color) res[X + i, Y - i] = true;
                    break;
                }
            }

            for (int i = 1; X - i >= 0 && Y + i < Board.SizeY; i++)
            {
                if (Board[X - i, Y + i] == null) res[X - i, Y + i] = true;
                else
                {
                    if (Board[X - i, Y + i].Color != this.Color) res[X - i, Y + i] = true;
                    break;
                }
            }

            return res;
        }

        public Bishop(int x, int y, bool color, Interfaces.IBoard board) : base(x, y, color, board)
        {
            ID = FiguresId.Bishop;
        }

        
    }
}
