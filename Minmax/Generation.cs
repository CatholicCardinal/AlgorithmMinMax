using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;


namespace Minmax
{
    public class Generation
    {
        private const int MaxValueVector = 1000;

        public Generation()
        {
            var rnd = new Random();

            ParametrsData.ObjectNumber = rnd.Next(1000, 20000);
        }

        public Generation(int ObjectNumber1)
        {
            ParametrsData.ObjectNumber = ObjectNumber1;
        }

        public void RandomGeneration()
        {
            var rnd = new Random();
            ParametrsData.Vectors = new Point[ParametrsData.ObjectNumber];

            for (var i = 0; i < ParametrsData.Vectors.Length; i++)
            {
                ParametrsData.Vectors[i].X = rnd.Next(0, MaxValueVector);
                ParametrsData.Vectors[i].Y = rnd.Next(0, MaxValueVector);
            }

            RdmSelectCentreWeight();
        }

        private void RdmSelectCentreWeight()
        {
            var rnd = new Random();
            ParametrsData.CenterWeight = new PointF[1];
            ParametrsData.CenterWeight[0] = ParametrsData.Vectors[rnd.Next(0, MaxValueVector)];
        }


    }
}
