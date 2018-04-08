using System;
using System.Collections.Generic;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;
using System.Drawing;

namespace Chess.Views.OpenGLfigures
{
    class Rook : Interfaces.IModel
    {
        Color mainColor;
        Color secondColor;

        Box baseF;
        Box Fig;

        

        public void Render(float x, float y, float z, float scale)
        {

            baseF.Render(x, y, z, scale);
            Fig.Render(x,y,z, scale);
        }

        public Rook(bool color)
        {
            secondColor = Color.Brown;
            mainColor = color ? Color.Wheat : Color.DarkGray;

            baseF = new Box(0.1f, 0.1f, 0, 0.9f, 0.9f, 0.3f, secondColor);
            Fig = new Box(0.2f, 0.2f, 0.3f, 0.8f, 0.8f, 1, mainColor);
        }
    }
}
