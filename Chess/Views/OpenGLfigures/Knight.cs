using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Chess.Views.OpenGLfigures
{
    class Knight : Interfaces.IModel
    {
        Color mainColor;
        Color secondColor;

        Box baseF;
        Box Fig;
        public void Render(float x, float y, float z, float scale)
        {
            baseF.Render(x, y, z, scale);
            Fig.Render(x, y, z, scale);
        }

        public Knight(bool color)
        {
            secondColor = Color.Brown;
            mainColor = color ? Color.Wheat : Color.DarkGray;

            baseF = new Box(0.1f, 0.1f, 0.0f, 0.9f, 0.9f, 0.3f, secondColor);
            Fig = new Box(0.1f, 0.1f, 0.3f, 0.9f, 0.9f, 1f, mainColor);
        }
    }
}
