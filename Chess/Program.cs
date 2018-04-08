using System;
using System.Drawing;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;
using System.Windows.Forms;

namespace Chess
{
    class Game
    {
        private static Interfaces.IBoard LogigBoard;
        private static Views.Cursor cursor;
        private static Views.Board RenderBoard;
        private static Views.Path path;
        private static Models.GameStages curStage;

        private static void NewGame()
        {
            LogigBoard = new Models.StandartBoard();
            cursor = new Views.Cursor(LogigBoard);
            RenderBoard = new Views.Board(LogigBoard);
            path = new Views.Path();
            curStage = Models.GameStages.Continue;
        }

        private static void CheckEnd(Models.GameStages stage)
        {
            curStage = stage;
            if (stage == Models.GameStages.CheckMate)
            {
                MessageBox.Show("Шах и мат.");
                NewGame();
            }
            else if (stage == Models.GameStages.Pat)
            {
                MessageBox.Show("Пат.");
                NewGame();
            }
            else if (stage == Models.GameStages.Check)
            {
                MessageBox.Show("Шах.");
            }
        }

        [STAThread]
        public static void Main()
        {
            NewGame();
            //------------------------------------
            Interfaces.IFigure selFigure = null;
            bool[,] selPath = null;

            float wAngle = 150;
            float bAngle = 30;
            float curAngle = 0;
            //------------------------------------
            using (var game = new GameWindow())
            {
                game.Load += (sender, e) =>
                {

                    game.VSync = VSyncMode.On;
                };

                game.Resize += (sender, e) =>
                {
                    GL.Viewport(0, 0, game.Width, game.Height);

                };

                game.KeyDown += (sender, e) =>
                {
                    if (e.Key == Key.Escape)
                    {
                        selFigure = null;
                        selPath = null;
                        path.ResetPath();
                    }
                    if (e.Key == Key.Enter)
                    {
                        if (selFigure != null)
                        {
                            if (selPath[cursor.Posx, cursor.Posy])
                            {
                                selFigure.MoveTo(cursor.Posx, cursor.Posy);
                                selFigure = null;
                                selPath = null;
                                path.ResetPath();
                                CheckEnd(LogigBoard.NextTurn());
                                return;
                            }

                        }

                        selFigure = LogigBoard[cursor.Posx, cursor.Posy];
                        if (selFigure != null)
                        {
                            if (selFigure.Color != LogigBoard.Turn )
                            {
                                selFigure = null;
                                return;
                            }
                            selPath = selFigure.GetCorrectPaths();
                            path.SetPath(selPath);
                        }
                        else
                        {
                            path.ResetPath();
                        }

                    }
                    if (e.Key == Key.Left)
                    {
                        if (!LogigBoard.Turn) cursor.Left();
                        else cursor.Right();
                    }
                    if (e.Key == Key.Right)
                    {
                        if (!LogigBoard.Turn) cursor.Right();
                        else cursor.Left();
                    }
                    if (e.Key == Key.Down)
                    {
                        if (!LogigBoard.Turn) cursor.Down();
                        else cursor.Up();
                    }
                    if (e.Key == Key.Up)
                    {
                        if (!LogigBoard.Turn) cursor.Up();
                        else cursor.Down();
                    }
                };

                game.RenderFrame += (sender, e) =>
                {
                    if (LogigBoard.Turn && curAngle != wAngle)
                    {
                        curAngle += (wAngle - curAngle) / 60 / 4;
                    }
                    else if (curAngle != bAngle)
                    {
                        curAngle += (bAngle - curAngle) / 60 / 4;
                    }

                    GL.Enable(EnableCap.DepthTest);
                    GL.ShadeModel(ShadingModel.Smooth);
                    

                    float[] ambient = { 0.0f, 0.0f, 0.0f, 1.0f };
                    float[] diffuse = { 1.0f, 1.0f, 1.0f, 1.0f };
                    float[] specular = { 1.0f, 1.0f, 1.0f, 1.0f };
                    float[] position = { 1.0f, 3.0f, 2.0f, 0.0f };
                    float[] lmodel_ambient = { 0.4f, 0.4f, 0.4f, 1.0f };
                    float[] local_view = { 0.0f };
                    GL.ClearColor(0.0f, 0.1f, 0.1f, 0.0f);
                    GL.Light(LightName.Light0, LightParameter.Ambient, ambient);
                    GL.Light(LightName.Light0, LightParameter.Diffuse, diffuse);
                    GL.Light(LightName.Light0, LightParameter.Position, position);
                    GL.LightModel(LightModelParameter.LightModelAmbient, lmodel_ambient);
                    GL.LightModel(LightModelParameter.LightModelLocalViewer, local_view);


                    GL.Enable(EnableCap.Lighting);
                    GL.Enable(EnableCap.Light0);
                    GL.DepthFunc(DepthFunction.Lequal);
                    GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

                    GL.MatrixMode(MatrixMode.Projection);
                    GL.LoadIdentity();
                    GL.Ortho(-1.0, 1.0, -1.0, 1.0, -1.0, 1.0);

                    GL.Rotate(320, 1.0f, 0.0f, 0.0f);
                    GL.Rotate(curAngle, 0.0f, 0.0f, 1.0f);
                    GL.Translate(-0.5f, -0.5f, 0);

                    RenderBoard.Render(0, 0, 0, 1);
                    cursor.Render();
                    path.Render();
                    game.SwapBuffers();
                };

                game.Run(60.0);
            }
        }
    }
}