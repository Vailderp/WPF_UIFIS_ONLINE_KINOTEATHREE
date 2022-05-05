using Kinoteathree.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Kinoteathree.ViewModels
{
    internal class AboutFilmPageViewModel : Base.BaseViewModel
    {
        private Film _film = null!;
        public Film Film
        {
            get => _film;
            set
            {
                _film = value;
                BackgroundFull = new ImageBrush(KinoAppHelper.LoadImage(_film.ImageFull));
                OnPropertyChanged();
            }
        }

        private Brush _backgroundFull = null!;
        public Brush BackgroundFull
        {
            get => _backgroundFull;
            set
            {
                _backgroundFull = value;
                OnPropertyChanged();
            }
        }

        public AboutFilmPageViewModel Hasfilm(Film film)
        {
            Film = film;
            return this;
        }
    }
}
