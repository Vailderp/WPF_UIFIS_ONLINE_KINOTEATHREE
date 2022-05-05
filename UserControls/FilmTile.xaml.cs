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
    /// Логика взаимодействия для FilmTile.xaml
    /// </summary>
    public partial class FilmTile : UserControl
    {
        public string FilmName { get; set; } = "";
        public FilmTile()
        {
            InitializeComponent();
        }
        public FilmTile HasFilm(Models.Film film)
        {
            FilmName = film.Name;
            DataContext = new ViewModels.FilmTileViewModel().HasFilm(film);
            return this;
        }
    }
}
