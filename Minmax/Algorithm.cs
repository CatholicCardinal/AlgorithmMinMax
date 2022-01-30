using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minmax
{
    public class Algorithm
    {
        private static int[] classesObject;
        private static List<int[]> iterationList;
        private static List<PointF[]> centreList;
        private float PorogDistance;

        public static int[] ClassesObject { get => classesObject; set => classesObject = value; }
        public static List<int[]> IterationList { get => iterationList; set => iterationList = value; }
        public static List<PointF[]> CentreList { get => centreList; set => centreList = value; }

        public void KMeansAlgoritm()
        {
            IterationList = new List<int[]>();
            ClassesObject = new int[ParametrsData.ObjectNumber];
            CentreList = new List<PointF[]>();

            int i = 0;
            do
            {
                RecalculationArea();
                FindNewCentres();
                CalculatPorogDistance();
                i++;
            } while (i<2 || CentreList[i-1].Length != CentreList[i-2].Length);

        }

        private void RecalculationArea()
        {
            int j = 0;
            ClassesObject = new int[ParametrsData.ObjectNumber];
            foreach (var vector in ParametrsData.Vectors)
            {
                float minDistance = 10000F;
                int k = 0, min = 100;
                foreach (var center in ParametrsData.CenterWeight)
                {

                    float dist = Distance(vector, center);
                    if (minDistance > dist)
                    {
                        minDistance = dist;
                        min = k;
                    }
                    k++;
                }
                ClassesObject[j] = min;
                j++;
            }
            IterationList.Add(ClassesObject);
        }

        private float Distance(PointF A, PointF B)
        {
            return (float)Math.Sqrt(Math.Pow((double)A.X - (double)B.X, 2) + Math.Pow((double)A.Y - (double)B.Y, 2));
        }

        private void FindNewCentres()
        {
            CentreList.Add(ParametrsData.CenterWeight);
            int value = ParametrsData.CenterWeight.Length;
            for (int i = 0; i < value; i++)
            {
                int numuberMaxObject = 0;
                float maxDistance = -1;
                for (int j = 0; j < ParametrsData.ObjectNumber; j++)
                {
                    if (ClassesObject[j] == i)
                    {
                        float res = Distance(ParametrsData.Vectors[j], ParametrsData.CenterWeight[i]);
                        if (res > maxDistance)
                        {
                            numuberMaxObject = j;
                            maxDistance = res;
                        }
                    }
                }

                
                if (ParametrsData.CenterWeight.Length == 1)
                {
                    ResizeCenterWeight(numuberMaxObject);
                }
                else
                {
                    if (maxDistance> PorogDistance)
                    {
                        ResizeCenterWeight(numuberMaxObject);
                    }
                }
            }

        }

        private void ResizeCenterWeight(int numuberMaxObject)
        {
            var newCenterWeight = new PointF[ParametrsData.CenterWeight.Length + 1];
            ParametrsData.CenterWeight.CopyTo(newCenterWeight, 0);
            newCenterWeight[ParametrsData.CenterWeight.Length] = ParametrsData.Vectors[numuberMaxObject];

            ParametrsData.CenterWeight = new PointF[newCenterWeight.Length];
            ParametrsData.CenterWeight = newCenterWeight;
        }

        private void CalculatPorogDistance()
        {
            float sum = 0;
            for (int i = 0; i < ParametrsData.CenterWeight.Length - 1; i++)
            {
                for (int j = i + 1; j < ParametrsData.CenterWeight.Length; j++)
                {
                    sum += Distance(ParametrsData.Vectors[i], ParametrsData.Vectors[j]);
                }
            }

            PorogDistance = sum / (ParametrsData.CenterWeight.Length * ParametrsData.CenterWeight.Length - ParametrsData.CenterWeight.Length);
        }
    }
}
