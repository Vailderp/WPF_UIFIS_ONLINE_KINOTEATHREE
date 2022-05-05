using Kinoteathree.Models;
using Kinoteathree.UserControls;
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
    /// Логика взаимодействия для FilmsListPage.xaml
    /// </summary>
    public partial class FilmsListPage : Page
    {
        private List<Film> _films = new List<Film>();
        private string _searchingFilmName = "";
        public string SearchingFilmName
        {
            private get => _searchingFilmName;
            set
            {
                _searchingFilmName = value;
                SearchFilms();
            }
        }
        private void SearchFilms()
        {
            WpFilmTiles.Children.Clear();
            foreach (var film in _films)
            {
                WpFilmTiles.Children.Add(new FilmTile().HasFilm(film));
            }
            if (_searchingFilmName == "")
            {
                return;
            }
            var children = WpFilmTiles.Children.OfType<UIElement>().ToList();
            foreach (object filmTileObj in children)
            {
                if (filmTileObj is FilmTile && filmTileObj != null)
                {
                    FilmTile? filmTile = filmTileObj as FilmTile;
                    if (filmTile != null)
                    {
                        if (!filmTile.FilmName.ToUpper().Contains(_searchingFilmName.ToUpper()))
                        {
                            WpFilmTiles.Children.Remove(filmTile);
                        }
                    }
                }
            }
        }

        public FilmsListPage()
        {
            InitializeComponent();
        }

        public FilmsListPage WithSorting(Sorting sorting, Country country, Genre genre, (double min, double max) raiting)
        {
            _films = new List<Film>();
            if (country.Id == 0 && genre.Id == 0)
            {
                var ctx = new KinoContext();
                foreach (var film in ctx.Films.Where(f => f.Raiting >= raiting.min && f.Raiting <= raiting.max))
                {
                    _films.Add(film);
                }
            }
            else if (country.Id != 0 && genre.Id != 0)
            {
                var ctx = new KinoContext();
                var filteredFilms = ctx.Films
                    .Where(f => f.Raiting >= raiting.min && f.Raiting <= raiting.max && f.CountryId == country.Id && f.GenreId == genre.Id);
                foreach (var film in filteredFilms)
                {
                    _films.Add(film);
                }
            }
            else
            {
                if (country.Id != 0 && country.Films != null)
                {
                    foreach (var film in country.Films.Where(f => f.Raiting >= raiting.min && f.Raiting <= raiting.max))
                    {
                        _films.Add(film);
                    }
                }
                if (genre.Id != 0 && genre.Films != null)
                {
                    foreach (var film in genre.Films.Where(f => f.Raiting >= raiting.min && f.Raiting <= raiting.max))
                    {
                        _films.Add(film);
                    }
                }
            }
            switch (sorting.Id)
            {
                case 0:
                    _films = _films.OrderBy(f => f.Raiting).ToList();
                    break;
                case 1:
                    _films = _films.OrderBy(f => f.Name).ToList();
                    break;
                case 2:
                    _films = _films.OrderBy(f => f.Cost).ToList();
                    break;
                default:
                    break;
            }
            foreach (var film in _films)
            {
                WpFilmTiles.Children.Add(new FilmTile().HasFilm(film));
            }
            SearchFilms();
            return this;
        }
        public FilmsListPage WithoutSorting()
        {
            InitializeFilmTiles();
            return this;
        }

        public FilmsListPage WithDataContext(object dataContext)
        {
            FfpUserControl.DataContext = dataContext;
            return this;
        }

        private void InitializeFilmTiles()
        {
            var ctx = new KinoContext();
            foreach (var film in ctx.Films)
            {
                _films.Add(film);
                WpFilmTiles.Children.Add(new FilmTile().HasFilm(film));
            }
        }
    }
}
