using Kinoteathree.Models;
using Kinoteathree.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Kinoteathree.ViewModels
{
    internal class CreateFilmPageAdminViewModel : Base.BaseViewModel
    {
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
        private Film _film = new Film();
        public Film Film
        {
            private get => _film;
            set
            {
                _film = value;
                OnPropertyChanged();
            }
        }

        private RelayCommand? _addActorCommand;
        public RelayCommand AddActorCommand
        {
            get
            {
                return _addActorCommand ?? (_addActorCommand = new RelayCommand(
                e =>
                {
                    var page = (KinoAppHelper.GetWindowAtType<Windows.UserWindow>()?.Frame.Content as CreateFilmPageAdmin);
                    KinoContext ctx = new KinoContext();
                    ActorFilmTable actorFilmTable = new ActorFilmTable() { ActorId = Actor.Id, FilmId = Film.Id };
                    ctx.ActorFilmTables.Add(actorFilmTable);
                    ctx.SaveChanges();
                    MessageBox.Show("Актёр добавлен");
                },
                e =>
                {
                    if (Film.Id == 0)
                    {
                        return false;
                    }
                    if (Actor.Id == 0)
                    {
                        return false;
                    }
                    return true;
                }
                ));

            }
        }

        private RelayCommand? _addFilmCommand;
        public RelayCommand AddFilmCommand
        {
            get
            {
                return _addFilmCommand ?? (_addFilmCommand = new RelayCommand(
                ltbDescriptionParam =>
                {
                    var ltbDescription = ltbDescriptionParam as UserControls.LargeTextBox;
                    var page = (KinoAppHelper.GetWindowAtType<Windows.UserWindow>()?.Frame.Content as CreateFilmPageAdmin);
                    KinoContext ctx = new();
                    ctx.Films.Add(Film);
                    Film.ImageFull = page?.ImageFullData ?? Array.Empty<byte>();
                    Film.ImageLogo = page?.ImageLogoData ?? Array.Empty<byte>();
                    Film.VideoData = page?.VideoData ?? Array.Empty<byte>();
                    Film.Description = ltbDescription?.MultiText ?? "Описание отсутствует";

                    ctx.SaveChanges();
                    MessageBox.Show("Фильм создан. Теперь можно добавить туда актёров.");

                },
                e =>
                {
                    if (Film.Id == 0)
                    {
                        return true;
                    }
                    return false;
                }
                ));

            }
        }

    }
}
