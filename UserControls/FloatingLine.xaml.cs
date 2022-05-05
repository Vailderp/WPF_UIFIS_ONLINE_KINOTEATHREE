using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
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
    /// Логика взаимодействия для FloatingLine.xaml
    /// </summary>
    public partial class FloatingLine : UserControl
    {
        public static DependencyProperty PropertyFloatingTextProperty = 
            DependencyProperty.Register("FloatingText", typeof(string), typeof(FloatingLine), new PropertyMetadata("floating textfloating textfloating textfloating textfloating textfloating textfloating textfloating textfloating textfloating textfloating textfloating textfloating textfloating textfloating textfloating textfloating textfloating textfloating textfloating textfloating text"));
        public static DependencyProperty PropertyFloatingWordsCountProperty =
           DependencyProperty.Register("FloatingWordsCount", typeof(int), typeof(FloatingLine), new PropertyMetadata(20));
        public static DependencyProperty PropertyFloatingMoveRateMilliseondsProperty =
            DependencyProperty.Register("FloatingMoveRateMilliseonds", typeof(int), typeof(FloatingLine), new PropertyMetadata(200));
        public static DependencyProperty PropertyFloatingFontSizeProperty =
             DependencyProperty.Register("FloatingFontSize", typeof(int), typeof(FloatingLine), new PropertyMetadata(14));
        public string FloatingText
        {
            get { return (string)base.GetValue(PropertyFloatingTextProperty); }
            set { base.SetValue(PropertyFloatingTextProperty, value); }
        }
        public int FloatingWordsCount
        {
            get { return (int)base.GetValue(PropertyFloatingWordsCountProperty); }
            set { base.SetValue(PropertyFloatingWordsCountProperty, value); }
        }
        public int FloatingMoveRateMilliseonds
        {
            get { return (int)base.GetValue(PropertyFloatingMoveRateMilliseondsProperty); }
            set { base.SetValue(PropertyFloatingMoveRateMilliseondsProperty, value); }
        }
        public int FloatingFontSize
        {
            get { return (int)base.GetValue(PropertyFloatingFontSizeProperty); }
            set { base.SetValue(PropertyFloatingFontSizeProperty, value); }
        }   
        public FloatingLine()
        {
            InitializeComponent();
            DataContext = LayoutRoot; 
            Thr();

        }
        private static int _i;
        public async void Thr()
        {
            while(true)
            {
                string result = "";
                for (int i = _i; i < FloatingWordsCount + _i; i++)
                {
                    result += FloatingText[i % FloatingText.Length];
                }
                TbMain.Text = result;
                _i++;
                await Task.Delay(FloatingMoveRateMilliseonds);
            }
        }
    }
}
