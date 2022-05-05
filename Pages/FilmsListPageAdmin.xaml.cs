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

namespace Kinoteathree.Pages
{
    /// <summary>
    /// Логика взаимодействия для FilmsListPageAdmin.xaml
    /// </summary>
    public partial class FilmsListPageAdmin : Page
    {
        public FilmsListPageAdmin()
        {
            InitializeComponent();
            InitializeFilmTiles();
        }

        private void InitializeFilmTiles()
        {
            var ctx = new KinoContext();
            foreach (var film in ctx.Films)
            {
                WpFilmTiles.Children.Add(new UserControls.FilmTile().HasFilm(film));
            }
        }

        private void ButtonCreateNewActor_Click(object sender, RoutedEventArgs e)
        {
            KinoAppHelper.GetWindowAtType<Windows.UserWindow>()?.Frame.Navigate(new Pages.CreateActorPageAdmin());
        }

        private void ButtonCreateNewFilm_Click(object sender, RoutedEventArgs e)
        {
            KinoAppHelper.GetWindowAtType<Windows.UserWindow>()?.Frame.Navigate(new Pages.CreateFilmPageAdmin());
        }
    }
}
