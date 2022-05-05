using Kinoteathree.Models;
using Kinoteathree.Windows;
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
    /// Логика взаимодействия для AboutFilmPage.xaml
    /// </summary>
    public partial class AboutFilmPage : Page
    {
        private Film _film = null!;
        public AboutFilmPage()
        {
            InitializeComponent();
        }
        public AboutFilmPage WithFilm(Film film)
        {
            _film = film;
            InitializeElements();
            DataContext = new ViewModels.AboutFilmPageViewModel().Hasfilm(film);
            return this;
        }
        private void InitializeElements()
        {
            LtbDescription.MultiText = _film.Description;
            if (_film.ActorFilmTables != null)
            {
                foreach (var table in _film.ActorFilmTables)
                {
                    if (table.Actor != null)
                    {
                        WpActorTiles.Children.Add(new UserControls.ActorTile().HasActor(table.Actor));
                    }
                }
            }
            if (_film.Reviews != null)
            {
                foreach (var review in _film.Reviews)
                {
                    WpReviewTiles.Children.Add(new UserControls.ReviewTile().HasReview(review));
                }
            }
        }
        private void ButtonSeeFilm_Click(object sender, RoutedEventArgs e)
        {
            new VideoPlayerWindow().WithVideoData(_film.VideoData).Show();
        }

        private void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            GC.Collect(GC.MaxGeneration, GCCollectionMode.Forced);
        }

        private void ButtonSendReview_Click(object sender, RoutedEventArgs e)
        {
            if (User.LoggedUser != null)
            {
                var ctx = new KinoContext();
                ctx.Reviews.Add(new Review()
                {
                    Text = LtbReviewText.MultiText,
                    FilmId = _film.Id,
                    UserId = User.LoggedUser.Id
                });
                ctx.SaveChanges();
                MessageBox.Show("Отзыв отправлен!");
            }
            else
            {
                MessageBox.Show("Сначала зарегистрируйтесь!");
            }
        }
    }
}
