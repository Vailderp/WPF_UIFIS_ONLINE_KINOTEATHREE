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
    /// Логика взаимодействия для LargeTextBox.xaml
    /// </summary>
    public partial class LargeTextBox : UserControl
    {
        public static DependencyProperty PropertyMultiTextProperty = DependencyProperty.Register("MultiText", typeof(string), typeof(LargeTextBox), new PropertyMetadata("multiline text"));
        public static DependencyProperty PropertyMultiTextFontSizeProperty = DependencyProperty.Register("MultiTextFontSize", typeof(int), typeof(LargeTextBox), new PropertyMetadata(18));
        public string MultiText
        {
            get { return (string)base.GetValue(PropertyMultiTextProperty); }
            set { base.SetValue(PropertyMultiTextProperty, value); }
        }
        public int MultiTextFontSize
        {
            get { return (int)base.GetValue(PropertyMultiTextFontSizeProperty); }
            set { base.SetValue(PropertyMultiTextFontSizeProperty, value); }
        }
        public LargeTextBox()
        {
            InitializeComponent();
            DataContext = LayoutRoot;
        }
    }
}
