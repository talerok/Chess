using System;
using System.Collections.Generic;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;
using System.Drawing;

namespace Chess.Views
{
    class Board : Interfaces.IModel
    {
        private Dictionary<Models.FiguresId, Interfaces.IModel> WModels = new Dictionary<Models.FiguresId, Interfaces.IModel>();
        private Dictionary<Models.FiguresId, Interfaces.IModel> BModels = new Dictionary<Models.FiguresId, Interfaces.IModel>();

        Interfaces.IBoard BoardLogic;

        public Board(Interfaces.IBoard board)
        {
            BoardLogic = board;
            WModels[Models.FiguresId.Pawn] = new Views.OpenGLfigures.Pawn(true);
            WModels[Models.FiguresId.Rock] = new Views.OpenGLfigures.Rook(true);
            WModels[Models.FiguresId.Bishop] = new Views.OpenGLfigures.Bishop(true);
            WModels[Models.FiguresId.Knight] = new Views.OpenGLfigures.Knight(true);
            WModels[Models.FiguresId.Queen] = new Views.OpenGLfigures.Queen(true);
            WModels[Models.FiguresId.King] = new Views.OpenGLfigures.King(true);

            BModels[Models.FiguresId.Pawn] = new Views.OpenGLfigures.Pawn(false);
            BModels[Models.FiguresId.Rock] = new Views.OpenGLfigures.Rook(false);
            BModels[Models.FiguresId.Bishop] = new Views.OpenGLfigures.Bishop(false);
            BModels[Models.FiguresId.Knight] = new Views.OpenGLfigures.Knight(false);
            BModels[Models.FiguresId.Queen] = new Views.OpenGLfigures.Queen(false);
            BModels[Models.FiguresId.King] = new Views.OpenGLfigures.King(false);
        }

        [STAThread]
        public void Render(float x, float y, float z, float scale)
        {
            float ScaleX = 1.0f / BoardLogic.SizeX;
            float ScaleY = 1.0f / BoardLogic.SizeY;

            foreach (var f in BoardLogic.Figures)
            {
                var Model = f.Color ? WModels[f.ID] : BModels[f.ID];
                Model.Render(f.X * ScaleX, f.Y * ScaleY, 0, ScaleX);
            }
            
            //------Render This
            for(int i = 0; i < BoardLogic.SizeX; i++)
            {
                for(int j = 0; j < BoardLogic.SizeY; j++)
                {
                    GL.Begin(PrimitiveType.Quads);
                    if ((i + j) % 2 == 0) GL.Material(MaterialFace.Front, MaterialParameter.Diffuse, Color.Black);
                    else GL.Material(MaterialFace.Front, MaterialParameter.Diffuse, Color.White);

                    GL.Vertex3((i+1) * ScaleX, (j + 1) * ScaleY, 0.0f);
                    GL.Vertex3(i * ScaleX, (j + 1) * ScaleY, 0.0f);
                    GL.Vertex3(i  * ScaleX, j  * ScaleY, 0.0f);
                    GL.Vertex3((i + 1) * ScaleX, j * ScaleY, 0.0f);
                    GL.End();
                }
            }

        }
    }
}
