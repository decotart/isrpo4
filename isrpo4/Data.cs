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
        /// <summary>
        /// 0 - Обдуваемое ветром фрактальное дерево \
        /// \ 1 - Кривая Коха \
        /// \ 2 - Ковер Серпинского \
        /// \ 3 - Треугольник Серпинского \
        /// \ 4 - Множество Кантора
        /// </summary>
        public static int ElementId = 2;

        public static int ElementSize = 4;

        public static Brush ElementColor = Brushes.MediumAquamarine;

        public static bool isSuccessful;
    }
}
