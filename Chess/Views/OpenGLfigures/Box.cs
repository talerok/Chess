using System;
using System.Collections.Generic;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;
using System.Drawing;

namespace Chess.Views.OpenGLfigures
{
    class Box : Interfaces.IModel
    {
        private float X1, Y1, Z1, X2, Y2, Z2;
        private Color col;
        public void Render(float x, float y, float z, float scale)
        {
            GL.Material(MaterialFace.Front, MaterialParameter.Diffuse, col);
            float[] amb = { 0.4f, 0.4f, 0.4f, 0.4f };
            GL.Material(MaterialFace.Front, MaterialParameter.Ambient, amb);
            float xcor1 = x + X1 * scale;
            float xcor2 = x + X2 * scale;
            float ycor1 = y + Y1 * scale;
            float ycor2 = y + Y2 * scale;
            float zcor1 = z + Z1 * scale;
            float zcor2 = z + Z2 * scale;


            GL.Begin(PrimitiveType.Polygon);

            GL.Vertex3(xcor2, ycor1, zcor1);      
            GL.Vertex3(xcor2, ycor2, zcor1);      
            GL.Vertex3(xcor1, ycor2, zcor1);      
            GL.Vertex3(xcor1, ycor1, zcor1);      

            GL.End();


            GL.Begin(PrimitiveType.Polygon);
            GL.Vertex3(xcor2, ycor1, zcor2);
            GL.Vertex3(xcor2, ycor2, zcor2);
            GL.Vertex3(xcor1, ycor2, zcor2);
            GL.Vertex3(xcor1, ycor1, zcor2);
            GL.End();


            GL.Begin(PrimitiveType.Polygon);
            GL.Vertex3(xcor2, ycor1, zcor1);
            GL.Vertex3(xcor2, ycor2, zcor1);
            GL.Vertex3(xcor2, ycor2, zcor2);
            GL.Vertex3(xcor2, ycor1, zcor2);
            GL.End();


            GL.Begin(PrimitiveType.Polygon);
            GL.Vertex3(xcor1, ycor1, zcor2);
            GL.Vertex3(xcor1, ycor2, zcor2);
            GL.Vertex3(xcor1, ycor2, zcor1);
            GL.Vertex3(xcor1, ycor1, zcor1);
            GL.End();


            GL.Begin(PrimitiveType.Polygon);
            GL.Vertex3(xcor2, ycor2, zcor2);
            GL.Vertex3(xcor2, ycor2, zcor1);
            GL.Vertex3(xcor1, ycor2, zcor1);
            GL.Vertex3(xcor1, ycor2, zcor2);
            GL.End();


            GL.Begin(PrimitiveType.Polygon);
            GL.Vertex3(xcor2, ycor1, zcor1);
            GL.Vertex3(xcor2, ycor1, zcor2);
            GL.Vertex3(xcor1, ycor1, zcor2);
            GL.Vertex3(xcor1, ycor1, zcor1);
            GL.End();

        }


        public Box(float x1, float y1, float z1, float x2, float y2, float z2, Color color)
        {
            col = color;
            X1 = x1;
            Y1 = y1;
            Z1 = z1;
            X2 = x2;
            Y2 = y2;
            Z2 = z2;
        }

    }
}
