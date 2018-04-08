﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chess.Interfaces;
using System.Drawing;

namespace Chess.Views.OpenGLfigures
{
    class King : Interfaces.IModel
    {

        Color mainColor;
        Color secondColor;

        Box baseF;
        Box Fig1;
        Box Fig2;
        public void Render(float x, float y, float z, float scale)
        {

            baseF.Render(x, y, z, scale);
            Fig1.Render(x, y, z, scale);
            Fig2.Render(x, y, z, scale);
        }

        public King(bool color)
        {
            secondColor = Color.Brown;
            mainColor = color ? Color.Wheat : Color.DarkGray;

            baseF = new Box(0.1f, 0.1f, 0, 0.9f, 0.9f, 0.3f, secondColor);
            Fig1 = new Box(0.2f, 0.2f, 0.3f, 0.8f, 0.8f, 0.8f, mainColor);
            Fig2 = new Box(0.4f, 0.4f, 0.8f, 0.6f, 0.6f, 1.0f, secondColor);
        }

    }
}
