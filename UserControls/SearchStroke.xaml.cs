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

namespace Kinoteathree.UserControls
{
    /// <summary>
    /// Логика взаимодействия для SearchStroke.xaml
    /// </summary>
    public partial class SearchStroke : UserControl
    {
        public SearchStroke()
        {
            InitializeComponent();
        }

        public delegate void EventButtonSearchClick(string text);
        public event EventButtonSearchClick? ButtonSearchClick;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ButtonSearchClick?.Invoke(TbSearchText.Text);
        }
    }
}
