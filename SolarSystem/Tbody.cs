using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;


namespace SolarSystem
{
    public class Tbody
    {
        static public double K; //Растяжение при рисовании
        static public double B; //Сдвиг при рисовании

        public double Omega; //Угловая скорость вращения
        public double R; //Радиус орбиты
        public int r; //Размер
        public Color color; //Цвет
        public double Angle0; //Начальное положение

        public double x; //текущие координаты тела
        public double y;
        double Angle; //Текущий угол

        //Список спутников
        protected Tbody Owner; //Ссылка на "хозяина", вокруг которого происходит вращение

        public virtual double cx //Координаты центра, вокруг которого тело вращается         
        {
            get {
                    return 0;//если это Солнце или планета
                }
        }

        public virtual double cy
        {
            get {
                    return 0;//если это Солнце
                }
        }
        //метод добавления в список спутников небесного тела
        public Tbody(Tbody owner)
        {
            Owner = owner;
        }

        public virtual void Step(double T) // метод "шаг"
        {
            Angle = Omega * T + Angle0; //вычисление угла
            //Текущие координаты
            x = cx + R * Math.Cos(Angle);
            y = cy + R * Math.Sin(Angle);
        }

        public virtual void Paint(Graphics G)
        {
            //Пересчитать координаты в экранные
            int ix = (int)(K * x + B);
            int iy = (int)(K * y + B);
            //Нарисовать тело                                   
            G.FillEllipse(new SolidBrush(color), ix - r / 2, iy - r / 2, r, r);
            G.DrawEllipse(new Pen(color), ix - r / 2, iy - r / 2, r, r);
        }

    }
}
