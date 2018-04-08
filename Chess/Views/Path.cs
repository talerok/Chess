using Chess.Views.OpenGLfigures;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Views
{
    class Path
    {
        bool[,] path;

        private Box point = new Box(0, 0, 0, 1, 1, 0.1f, Color.Green);

        public void SetPath(bool[,] p)
        {
            path = p;
        }

        public void ResetPath()
        {
            path = null;
        }

        public void Render()
        {
            if (path == null) return;
            int sizex = path.GetLength(0);
            int sizey = path.GetLength(1);

            float scalex = 1.0f / sizex;
            float scaley = 1.0f / sizey;

            for (int i = 0; i < sizex; i++)
            {
                for(int j = 0; j < sizey; j++)
                {
                    if (path[i, j] == true) point.Render(i * scalex, j * scaley, 0, scalex);
                }
            }
        }

    }
}
