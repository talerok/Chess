using System;
using System.Collections.Generic;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;
using System.Drawing;

namespace Chess.Views.OpenGLfigures
{
    class Bishop : Interfaces.IModel
    {
        Color mainColor;
        Color secondColor;

        Box baseF;
        Cone Fig;

        public void Render(float x, float y, float z, float scale)
        {

            baseF.Render(x, y, z, scale);
            Fig.Render(x, y, z, scale);
        }

        public Bishop(bool color)
        {
            secondColor = Color.Brown;
            mainColor = color ? Color.Wheat : Color.DarkGray;

            baseF = new Box(0.1f, 0.1f, 0, 0.9f, 0.9f, 0.3f, secondColor);
            Fig = new Cone(0.1f, 0.1f, 0.3f, 0.9f, 0.9f, 1, mainColor);
        }
    }
}
