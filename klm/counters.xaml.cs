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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace klm
{
    /// <summary>
    /// counters.xaml 的交互逻辑
    /// </summary>
    public partial class counters : UserControl
    {
        public counters()
        {
            InitializeComponent();
        }
        private void plus_Click(object sender, RoutedEventArgs e)
        {
            int temp;
            int.TryParse(num.Text, out temp);
            temp++;
            num.Text = temp.ToString();
        }

        private void minus_Click(object sender, RoutedEventArgs e)
        {
            int temp;
            int.TryParse(num.Text, out temp);
            if (temp > 0)
            {
                temp--;
                num.Text = temp.ToString();
            }
        }
    }

}
