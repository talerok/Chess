using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Models.figures
{
    class King : Figure
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

            for(int i = -1; i <= 1; i++)
            {
                for(int j = -1; j <= 1; j++)
                {
                    if (i == 0 && j == 0) continue;
                    if(X + i >= 0 && X + i < Board.SizeX && Y + j >= 0 && Y + j < Board.SizeY)
                    {
                        if (Board[X + i, Y + j] == null || Board[X + i, Y + j].Color != Color) res[X + i, Y + j] = true;
                    }
                }
            }
            if(this.Color == Board.Turn) CheckEnemysPaths(res);
            return res;
        }

        private void CheckEnemysPaths(bool[,] kingp)
        {
            foreach (var a in Board.Figures.Where(x => x.Color != this.Color))
            {
                var enp = a.GetCorrectPaths();
                for(int i = 0; i < kingp.GetLength(0); i++)
                {
                    for(int j = 0; j < kingp.GetLength(1); j++)
                    {
                        if (!kingp[i, j]) continue;
                        if (enp[i, j]) kingp[i, j] = false;
                    }
                }
            }
        }

        public King(int x, int y, bool color, Interfaces.IBoard board) : base(x, y, color, board)
        {
            ID = FiguresId.King;
        }

       

    }
}
