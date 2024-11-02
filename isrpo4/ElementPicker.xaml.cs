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
    /// Логика взаимодействия для ElementPicker.xaml
    /// </summary>
    public partial class ElementPicker : Window
    {
        public ElementPicker()
        {
            InitializeComponent();
        }

        private void btn_Clicked(object sender, RoutedEventArgs e)
        {
            GlobalData.ElementId = Convert.ToInt32(((Button)sender).Name.TrimStart('b'));

            GlobalData.isSuccessful = true;

            Close();
        }
    }
}
