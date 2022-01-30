using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Minmax;

namespace Lab2
{
    class Program
    {
        static void Main(string[] args)
        {
            Generation randomGeneration = new Generation();
            Algorithm algorithm = new Algorithm();

            randomGeneration.RandomGeneration();
            algorithm.KMeansAlgoritm();

            for (int j = 0; j < Algorithm.IterationList.Count; j++)
            {
                Bitmap b = new Bitmap(1000, 1000);
                using (Graphics g = Graphics.FromImage(b))
                {
                    g.Clear(Color.White);
                    Pen pen = new Pen(Color.Black);
                    pen.Width = 1;

                    for (int i = 0; i < ParametrsData.ObjectNumber; i++)
                    {
                        g.DrawRectangle(SelectColor(j, i), ParametrsData.Vectors[i].X, ParametrsData.Vectors[i].Y, 5, 5);
                        g.FillRectangle(SelectColor(j, i).Brush, ParametrsData.Vectors[i].X, ParametrsData.Vectors[i].Y, 5, 5);
                    }

                    for (int i = 0; i < Algorithm.CentreList[j].Length; i++)
                    {
                        //g.DrawRectangle(pen, ParametrsData.Vectors[i].X, ParametrsData.Vectors[i].Y, 10, 10);
                        g.FillRectangle(pen.Brush, Algorithm.CentreList[j][i].X, Algorithm.CentreList[j][i].Y, 10, 10);
                    }
                }
                b.Save("D:\\TestMaxMin\\Iteration" + j.ToString() + ".bmp", System.Drawing.Imaging.ImageFormat.Bmp);

            }
        }

        private static Pen SelectColor(int j, int i)
        {
            Pen pen = new Pen(Color.Black);
            pen.Width = 2;
            switch (Algorithm.IterationList[j][i])
            {
                case 1:
                    pen.Color = Color.Red;
                    break;
                case 2:
                    pen.Color = Color.Coral;
                    break;
                case 3:
                    pen.Color = Color.Blue;
                    break;
                case 4:
                    pen.Color = Color.Green;
                    break;
                case 5:
                    pen.Color = Color.Brown;
                    break;
                case 6:
                    pen.Color = Color.Orange;
                    break;
                case 7:
                    pen.Color = Color.HotPink;
                    break;
                case 8:
                    pen.Color = Color.Purple;
                    break;
                case 9:
                    pen.Color = Color.Gold;
                    break;
                case 10:
                    pen.Color = Color.DarkRed;
                    break;
                case 11:
                    pen.Color = Color.LightGoldenrodYellow;
                    break;
                case 12:
                    pen.Color = Color.Aqua;
                    break;
                case 13:
                    pen.Color = Color.LimeGreen;
                    break;
                case 14:
                    pen.Color = Color.MistyRose;
                    break;
                case 15:
                    pen.Color = Color.Violet;
                    break;
                case 16:
                    pen.Color = Color.MediumAquamarine;
                    break;
                case 17:
                    pen.Color = Color.LightSlateGray;
                    break;
                case 18:
                    pen.Color = Color.Silver;
                    break;
                case 19:
                    pen.Color = Color.Moccasin;
                    break;
                case 20:
                    pen.Color = Color.SaddleBrown;
                    break;
                case 21:
                    pen.Color = Color.LightSalmon;
                    break;
                case 22:
                    pen.Color = Color.LightSeaGreen;
                    break;
                case 23:
                    pen.Color = Color.Beige;
                    break;
                case 24:
                    pen.Color = Color.Plum;
                    break;
                default:
                    pen.Color = Color.Black;
                    break;

            }
            return pen;
        }
    }
}
