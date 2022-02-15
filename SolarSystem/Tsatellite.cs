using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SolarSystem
{
    class Tsatellite: Tbody //спутники
    {
        public Tsatellite(Tbody owner):base(owner)
        {

        }
        public override double cx //Координаты центра, вокруг которого тело вращается         
        {
            get
            {
                return Owner.x;
            }
        }

        public override double cy
        {
            get
            {
                return Owner.y;
            }
        }



    }
}
