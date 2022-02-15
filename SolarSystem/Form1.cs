using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SolarSystem
{
    public partial class FormMain : Form
    {
        public List<Tbody> PlanetSystem = new List<Tbody>(); //Список объектов солнечной системы

        public FormMain()
        {
            InitializeComponent();
        }
        double Time = 0;//стартовое время

        private void FormMain_Load(object sender, EventArgs e) 
        {
            Tbody Temp = new Tbody(null); 
            PlanetSystem.Add(Temp); //добавить в Солнечную систему Солнце
            Temp = PlanetSystem[PlanetSystem.Count - 1];
            Temp.color = Color.Yellow;
            Temp.Omega = 0; //Угловая скорость
            Temp.R = 0; //Радиус от центра
            Temp.r = 80; //Размер

            PlanetSystem.Add(new Tplanet(PlanetSystem[0])); //Меркурий
            Temp = PlanetSystem[PlanetSystem.Count - 1];
            Temp.color = Color.Olive;
            Temp.Omega = 0.416; //Угловая скорость
            Temp.R = 58; //Радиус от центра
            Temp.r = 12; //Размер
            Temp.Angle0 = 0; //Начальный угол

            PlanetSystem.Add(new Tplanet(PlanetSystem[0])); //Венеру
            Temp = PlanetSystem[PlanetSystem.Count - 1];
            Temp.color = Color.DarkOrange;
            Temp.Omega = 0.416; //Угловая скорость
            Temp.Omega = 0.25; //Угловая скорость реальная
            Temp.R = 108; //Радиус от центра
            Temp.r = 20; //Размер
            Temp.Angle0 = 1; //Начальный угол

            Tplanet E = new Tplanet(PlanetSystem[0]); //Землю
            PlanetSystem.Add(E);
            E.color = Color.DeepSkyBlue;
            E.Omega = 0.1; //Угловая скорость
            E.R = 150; //Радиус от центра
            E.r = 24; //Размер
            E.Angle0 = 2;

            Tsatellite Moon = new Tsatellite(E)
            {
                color = Color.Gray,
                Omega = 1.3, //Угловая скорость
                R = 15, //Радиус от центра
                r = 8, //Размер
                Angle0 = 3
            };
            E.AddSatellite(Moon); //Луну - спутник земли

            Tplanet Mars = new Tplanet(PlanetSystem[0]); //Марс
            PlanetSystem.Add(Mars);
            Mars.color = Color.DarkRed;
            Mars.Omega = 0.053; //Угловая скорость
            Mars.R = 228; //Радиус от центра
            Mars.r = 16; //Размер
            Mars.Angle0 = 4;

            Tsatellite Fobos = new Tsatellite(Mars)
            {
                color = Color.LightGoldenrodYellow,
                Omega = 144.4, //Угловая скорость
                R = 10, //Радиус от центра
                r = 4, //Размер
                Angle0 = 5
            };
            Mars.AddSatellite(Fobos); //Фобос - спутник Марса

            Tsatellite Deimos = new Tsatellite(Mars)
            {
                color = Color.DarkKhaki,
                Omega = 30.4, //Угловая скорость 
                R = 15, //Радиус от центра
                r = 4, //Размер
                Angle0 = 6
            };
            Mars.AddSatellite(Deimos); //Деймос - спутник Марса  

            Tbody.K = 1.5; //Растяжение при рисовании
            Tbody.B = 445; //Сдвиг при рисовании

            Time = 0;
            foreach (var b in PlanetSystem)
                b.Step(Time);
    }


    private void ButtonStep_Click(object sender, EventArgs e)
        {
            foreach (var b in PlanetSystem) b.Step(Time);//для Солнца и всех планет запуск метода Step
            Time += 0.5; //изменение времени
            pictureBoxMain.Refresh();//Обновление picturebox
        }

        private void PictureBoxMain_Paint(object sender, PaintEventArgs e)
        {
            //нарисовать тела
            foreach (var b in PlanetSystem)
               b.Paint(e.Graphics);
        }

        private void CheckBoxGO_CheckedChanged(object sender, EventArgs e)
        {
            timer1.Enabled = checkBoxGO.Checked;
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            ButtonStep_Click(sender, e);
        }
    }
}
