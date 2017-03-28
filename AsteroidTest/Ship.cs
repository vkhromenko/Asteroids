using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsteroidTest
{
    public enum Direction{
        Left,
        Right,
    }

    class Ship
    {
        private PointF[] shipPoints;

        public Ship(int startX, int startY)
        {
            shipPoints = new PointF[4];
            GenerateStartPositions(startX, startY);
        }

        private void GenerateStartPositions(int startX, int startY)
        {
            shipPoints[0] = new Point(startX * AsteroidsForm.SCALE, startY * AsteroidsForm.SCALE);
            shipPoints[1] = new Point((startX - 1) * AsteroidsForm.SCALE, (startY + 1) * AsteroidsForm.SCALE);
            shipPoints[2] = new Point(startX * AsteroidsForm.SCALE, (startY - 1) * AsteroidsForm.SCALE);
            shipPoints[3] = new Point((startX + 1) * AsteroidsForm.SCALE, (startY + 1) * AsteroidsForm.SCALE);
        }

        public void PaintShip(BufferedGraphics mainBuffer)
        {
            mainBuffer.Graphics.DrawPolygon(Pens.Black, shipPoints);
        }

        public void Move(Point offset)
        {
            for(int i = 0; i < shipPoints.Length; i++)
            {
                shipPoints[i].X += offset.X;
                shipPoints[i].Y += offset.Y;
            }
        }

        public void Ratate(Direction direct)
        {
            PointF[] tempshipPoints = new PointF[shipPoints.Length];

            shipPoints.CopyTo(tempshipPoints, 0);

            if(direct == Direction.Right)
            {
                for (int i = 1; i < shipPoints.Length; i++)
                {
                    tempshipPoints[i].X = (int)(shipPoints[0].X + (shipPoints[i].X - shipPoints[0].X) * Math.Cos(0.087) - (shipPoints[i].Y - shipPoints[0].Y) * Math.Sin(0.087));
                    tempshipPoints[i].Y = (int)(shipPoints[0].Y + (shipPoints[i].Y - shipPoints[0].Y) * Math.Sin(0.087) + (shipPoints[i].X - shipPoints[0].X) * Math.Cos(0.087));

                    //X = x0 + (x - x0) * cos(a) - (y - y0) * sin(a);
                    //Y = y0 + (y - y0) * cos(a) + (x - x0) * sin(a);
                }
                shipPoints = tempshipPoints;
            }

            if (direct == Direction.Left)
            {
                for (int i = 1; i < shipPoints.Length; i++)
                {
                    tempshipPoints[i].X = (int)(shipPoints[0].X + (shipPoints[i].X - shipPoints[0].X) * Math.Cos(0.087) - (shipPoints[i].Y - shipPoints[0].Y) * Math.Sin(0.087));
                    tempshipPoints[i].Y = (int)(shipPoints[0].Y + (shipPoints[i].Y - shipPoints[0].Y) * Math.Sin(0.087) + (shipPoints[i].X - shipPoints[0].X) * Math.Cos(0.087));


                    //X = x0 + (x - x0) * cos(a) - (y - y0) * sin(a);
                    //Y = y0 + (y - y0) * cos(a) + (x - x0) * sin(a);
                }
                shipPoints = tempshipPoints;
            }
        }

        public void Ratate(Direction direct, BufferedGraphics mainBuffer)
        {
            if (direct == Direction.Right)
            {
                mainBuffer.Graphics.Transform.RotateAt(5, shipPoints[0]);
            }

            if (direct == Direction.Left)
            {
                mainBuffer.Graphics.Transform.RotateAt(-5, shipPoints[0]);
            }
        }

    }
}
