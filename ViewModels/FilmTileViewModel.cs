using Kinoteathree.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Kinoteathree.ViewModels
{
    internal class FilmTileViewModel : Base.BaseViewModel
    {
        private Brush _backgroundFilmLogo = null!;
        public Brush BackgroundFilmLogo
        {
            get => _backgroundFilmLogo;
            set
            {
                _backgroundFilmLogo = value;
                OnPropertyChanged();
            }
        }
        private Film _film = null!;
        public Film Film
        {
            get => _film;
            set
            {
                _film = value;
                OnPropertyChanged();
            }
        }
        private RelayCommand? _commandGoAboutFilmPage;
        public RelayCommand CommandGoAboutFilmPage
        {
            get => _commandGoAboutFilmPage ??= new RelayCommand(
                e =>
                {
                    KinoAppHelper.GetWindowAtType<Windows.UserWindow>()?.Frame.Navigate(new Pages.AboutFilmPage().WithFilm(_film));
                });
        }

        public FilmTileViewModel()
        {

        }
        public FilmTileViewModel HasFilm(Film film)
        {
            Film = film;
            BackgroundFilmLogo = new ImageBrush(KinoAppHelper.LoadImage(film.ImageLogo));
            return this;
        }
    }
}
