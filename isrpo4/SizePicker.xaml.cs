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
    /// Логика взаимодействия для SizePicker.xaml
    /// </summary>
    public partial class SizePicker : Window
    {
        public SizePicker()
        {
            InitializeComponent();
        }

        private void btnDone_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int num = Convert.ToInt32(tbMain.Text);

                if (num > 0 && num < 7)
                {
                    GlobalData.ElementSize = num;

                    GlobalData.isSuccessful = true;

                    Close();
                }
                else if (num >= 7)
                {
                    MessageBox.Show("Число слишком большое! Попробуй меньше семи...");
                }
                else
                {
                    MessageBox.Show("Размер не может быть отрицательным...");
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Только целые числа!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Что-то пошло не так!\nЕсли интересно:\n{ex.Message}");
            }
        }
    }
}
