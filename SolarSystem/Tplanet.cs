using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace SolarSystem
{
    class Tplanet:Tbody //планеты
    {
        public List<Tbody> Satellites; //Список спутников        

        public Tplanet(Tbody owner):base(owner)
        {
            Satellites = new List<Tbody>();
        }

        public override void Step(double T)
        {
            base.Step(T);
            foreach (var S in Satellites) S.Step(T);
        }

        public void AddSatellite(Tbody satellite)
        {
            Satellites.Add(satellite);
        }

        public override void Paint(Graphics G)
        {
            base.Paint(G);
            foreach (var S in Satellites) S.Paint(G);
        }

    }
}
