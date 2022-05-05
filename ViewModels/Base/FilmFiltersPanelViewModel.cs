using Kinoteathree.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kinoteathree.ViewModels.Base
{
    internal class FilmFiltersPanelViewModel : Base.BaseViewModel
    {

        private List<Sorting>? _sortings;
        public List<Sorting> Sortings
        {
            get => _sortings ?? (_sortings = new List<Sorting>() 
            { 
                new Sorting(0, "По рейтингу"), 
                new Sorting(1, "По названию"),
                new Sorting(2, "По цене"),
            });
        }
        private List<Country>? _countries;
        public List<Country> Countries
        {
            get => _countries ?? (_countries = new KinoContext().Countries.ToList());
        }
        private List<Genre>? _genres;
        public List<Genre> Genres
        {
            get => _genres ?? (_genres = new KinoContext().Genres.ToList());
        }

        private List<Actor>? _actors;
        public List<Actor> Actors
        {
            get => _actors ?? (_actors = new KinoContext().Actors.ToList());
        }

        private Country _country = new Country();
        public Country Country
        {
            private get => _country;
            set
            {
                _country = value;
                OnPropertyChanged();
            }
        }
        private Genre _genre = new Genre();
        public Genre Genre
        {
            private get => _genre;
            set
            {
                _genre = value;
                OnPropertyChanged();
            }
        }
        private Actor _actor = new Actor();
        public Actor Actor
        {
            private get => _actor;
            set
            {
                _actor = value;
                OnPropertyChanged();
            }
        }
        private Sorting _sorting = new Sorting(-1, "");
        public Sorting Sorting
        {
            private get => _sorting;
            set
            {
                _sorting = value;
                OnPropertyChanged();
            }
        }

        private (double min, double max) _raiting = (0, 10);
        public (double min, double max) Raiting
        {
            get => _raiting;
            set
            {
                _raiting = value;
                OnPropertyChanged();
            }
        }


        private RelayCommand? _sortCommand;
        public RelayCommand SortCommand
        {
            get
            {
                return _sortCommand ?? (_sortCommand = new RelayCommand(
                e =>
                {
                    var page = new Pages.FilmsListPage().WithSorting(Sorting, Country, Genre, Raiting).WithDataContext(this);
                    KinoAppHelper.GetWindowAtType<Windows.UserWindow>()?.Frame.Navigate(page);
                }
                ));
            }
        }

        public FilmFiltersPanelViewModel()
        {

        }
    }
}
