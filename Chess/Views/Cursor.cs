using Chess.Views.OpenGLfigures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace Chess.Views
{
    class Cursor 
    {
        private Interfaces.IBoard LogicBoard;
        public int Posx { get; private set; }
        public int Posy { get; private set; }

        private Box point = new Box(0, 0, 0, 1, 1, 0.15f, Color.Red); 

        public Cursor(Interfaces.IBoard board)
        {
            LogicBoard = board;

        }

        public void Left()
        {
            if (Posx > 0) Posx--;
        }

        public void Right()
        {
            if (Posx < LogicBoard.SizeX - 1) Posx++;
        }

        public void Up()
        {
            if (Posy < LogicBoard.SizeY - 1) Posy++;
        }

        public void Down()
        {
            if (Posy > 0) Posy--;
        }

        public void Render()
        {
            float ScaleX = 1.0f / LogicBoard.SizeX;
            float ScaleY = 1.0f / LogicBoard.SizeY;

            point.Render(ScaleX * Posx, ScaleY * Posy,0,ScaleX);
        }
        

    }
}
