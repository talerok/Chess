using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chess.Interfaces;

namespace Chess.Models
{
    class StandartBoard : Interfaces.IBoard
    {
        public List<IFigure> Figures { get; private set; }

        private IFigure Wking;
        private IFigure Bking;

        public IFigure this[int x, int y] {
            get
            {
                return Figures.FirstOrDefault(f => f.X == x && f.Y == y);
            }
        }

        public bool Turn { get; private set; }

        public int SizeX
        {
            get; private set;
        }

        public int SizeY
        {
            get; private set;
        }


        public StandartBoard()
        {
            Turn = true;
            Figures = new List<IFigure>();

            SizeX = 8;
            SizeY = 8;

            //---------------------------------
            Figures.Add(new figures.Rock(0, 0, false, this));
            Figures.Add(new figures.Rock(7, 0, false, this));
            Figures.Add(new figures.Knight(1, 0, false, this));
            Figures.Add(new figures.Knight(6, 0, false, this));
            Figures.Add(new figures.Bishop(2, 0, false, this));
            Figures.Add(new figures.Bishop(5, 0, false, this));
            Bking = new figures.King(3, 0, false, this);
            Figures.Add(Bking);
            Figures.Add(new figures.Queen(4, 0, false, this));
            for(int i = 0; i < 8; i++) Figures.Add(new figures.Pawn(i, 1, false, this));
            //---------------------------------
            Figures.Add(new figures.Rock(0, 7, true, this));
            Figures.Add(new figures.Rock(7, 7, true, this));
            Figures.Add(new figures.Knight(1, 7, true, this));
            Figures.Add(new figures.Knight(6, 7, true, this));
            Figures.Add(new figures.Bishop(2, 7, true, this));
            Figures.Add(new figures.Bishop(5, 7, true, this));
            Wking = new figures.King(3, 7, true, this);
            Figures.Add(Wking);
            Figures.Add(new figures.Queen(4, 7, true, this));
            for (int i = 0; i < 8; i++) Figures.Add(new figures.Pawn(i, 6, true, this));
        }

        public void PawnToQueen(Interfaces.IFigure fig)
        {
            int px = fig.X;
            int py = fig.Y;
            bool color = fig.Color;
            Figures.Remove(fig);
            Figures.Add(new figures.Queen(px, py, color, this));
        }

        private bool CheckCheck()
        {
            var king = Turn ? Wking : Bking;
            foreach (var fgs in Figures.Where(x => x.Color != king.Color))
            {
                var buf = fgs.GetCorrectPaths();
                if (buf[king.X, king.Y]) return true;
            }
            return false;
        }

        private bool CheckPat()
        {
            var king = Turn ? Wking : Bking;
            var a = king.GetCorrectPaths();
            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < a.GetLength(1); j++)
                {
                    if (a[i, j]) return true;
                }
            }
            return false;
        }

        public Models.GameStages NextTurn()
        {
            Turn = !Turn;
            bool check = CheckCheck();
            bool pat = CheckPat();
            if (check && pat) return GameStages.CheckMate;
            else if (check && !pat) return GameStages.Check;
            else if (!check && pat) return GameStages.Pat;
            else return GameStages.Continue;
        }

        public void RemoveFigure(IFigure figure)
        {
            Figures.Remove(figure);
        }
    }
}
