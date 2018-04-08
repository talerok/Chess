using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Interfaces
{
    interface IBoard 
    {
        List<IFigure> Figures { get; }

        IFigure this[int x, int y]
        {
            get;
        }

        Models.GameStages NextTurn();

        void RemoveFigure(IFigure figure);

        void PawnToQueen(Interfaces.IFigure fig);

        bool Turn { get; }
        int SizeX { get; }
        int SizeY { get; }
    }
}
