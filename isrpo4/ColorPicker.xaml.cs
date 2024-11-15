using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace isrpo4
{
    /// <summary>
    /// Логика взаимодействия для ColorPicker.xaml
    /// </summary>
    public partial class ColorPicker : Window
    {
        public ColorPicker()
        {
            InitializeComponent();
        }

        private void btnColor_Click(object sender, RoutedEventArgs e)
        {
            GlobalData.isGradient = false;

            GlobalData.ElementColor = ((Button)sender).Background;

            GlobalData.isSuccessful = true;

            Close();
        }

        private void btnGradient_Click(object sender, RoutedEventArgs e)
        {
            GlobalData.isGradient = true;

            GlobalData.isSuccessful = true;

            Close();
        }
    }
}
