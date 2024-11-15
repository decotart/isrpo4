using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace isrpo4
{
    static class GlobalData
    {
        private static Brush[] _gradient =
        {
            Brushes.Yellow,
            Brushes.LightGoldenrodYellow,
            Brushes.AliceBlue,
            Brushes.BlueViolet,
            Brushes.DarkViolet,
            Brushes.Purple,
            Brushes.MediumSlateBlue,
            Brushes.Blue
        };

        private static Brush _elementColor;

        public static Brush ElementColor
        {
            get
            {
                if (isGradient)
                {
                    if (GradientId > _gradient.Length - 1)
                    {
                        GradientId = 0;
                    }
                    return _gradient[GradientId];
                }
                else
                {
                    return _elementColor;
                }
            }
            set
            {
                _elementColor = value;
            }
        }

        public static int GradientId = 0;

        public static bool isGradient = false;

        /// <summary>
        /// 0 - Обдуваемое ветром фрактальное дерево \
        /// \ 1 - Кривая Коха \
        /// \ 2 - Ковер Серпинского \
        /// \ 3 - Треугольник Серпинского \
        /// \ 4 - Множество Кантора
        /// </summary>
        public static int ElementId = 2;

        public static int ElementSize = 4;

        public static bool isSuccessful;
    }
}
