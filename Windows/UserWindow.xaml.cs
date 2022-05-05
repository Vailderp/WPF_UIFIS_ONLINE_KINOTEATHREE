using Kinoteathree.Pages;
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

namespace Kinoteathree.Windows
{
    /// <summary>
    /// Логика взаимодействия для UserWindow.xaml
    /// </summary>
    public partial class UserWindow : Window
    {
        public Frame Frame { get => FramePages; }
        public UserWindow()
        {
            InitializeComponent();
            //Serializer.WriteToFile();
            //Serializer.ReadFromFile();
        }

        private void ButtonSearchStroke_ButtonSearchClick(string text)
        {
            if (Frame.Content is FilmsListPage filmsListPage)
            {
                filmsListPage.SearchingFilmName = text;
            }
        }

        private void ButtonGoBackPage_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Frame.GoBack();
            } catch { }
        }
    }
}
