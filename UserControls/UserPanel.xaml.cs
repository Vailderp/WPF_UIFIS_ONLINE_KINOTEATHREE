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

namespace Kinoteathree.UserControls
{
    /// <summary>
    /// Логика взаимодействия для UserPanel.xaml
    /// </summary>
    public partial class UserPanel : UserControl
    {

        private Pages.FilmsListPage? _filmsListPage;
        public Pages.FilmsListPage FilmsListPage { get => _filmsListPage ?? (_filmsListPage = new Pages.FilmsListPage().WithoutSorting()); }
        private Pages.FilmsListPageAdmin? _filmsListPageAdmin;
        public Pages.FilmsListPageAdmin FilmsListPageAdmin { get => _filmsListPageAdmin ?? (_filmsListPageAdmin = new Pages.FilmsListPageAdmin()); }

        private Pages.UserAccountPage? _userAccountPage;
        public Pages.UserAccountPage UserAccountPage { get => _userAccountPage ?? (_userAccountPage = new Pages.UserAccountPage()); }

        private Pages.AboutCo? _aboutCo;
        public Pages.AboutCo AboutCo { get => _aboutCo ?? (_aboutCo = new Pages.AboutCo()); }

        private Pages.RegisterPage? _registerPage;
        public Pages.RegisterPage RegisterPage { get => _registerPage ?? (_registerPage = new Pages.RegisterPage()); }

        private Pages.LoginPage? _loginPage;
        public Pages.LoginPage LoginPage { get => _loginPage ?? (_loginPage = new Pages.LoginPage()); }
        public UserPanel()
        {
            InitializeComponent();
        }

        private void ButtonGoFilms_Click(object sender, RoutedEventArgs e)
        {
            if (Models.User.LoggedUser?.IsAdmin ?? false)
            {
                KinoAppHelper.GetWindowAtType<UserWindow>()?.Frame.Navigate(FilmsListPageAdmin);
            }
            else
            {
                KinoAppHelper.GetWindowAtType<UserWindow>()?.Frame.Navigate(FilmsListPage);
            }
        }

        private void ButtonGoSerials_Click(object sender, RoutedEventArgs e)
        {
            KinoAppHelper.GetWindowAtType<UserWindow>()?.Frame.Navigate(UserAccountPage);
        }

        private void ButtonGoMyFilms_Click(object sender, RoutedEventArgs e)
        {
            KinoAppHelper.GetWindowAtType<UserWindow>()?.Frame.Navigate(UserAccountPage);
        }

        private void ButtonGoLogin_Click(object sender, RoutedEventArgs e)
        {
            if (Models.User.LoggedUser == null)
            {
                KinoAppHelper.GetWindowAtType<UserWindow>()?.Frame.Navigate(LoginPage);
            }
        }

        private void ButtonGoRegister_Click(object sender, RoutedEventArgs e)
        {
            if (Models.User.LoggedUser == null)
            {
                KinoAppHelper.GetWindowAtType<UserWindow>()?.Frame.Navigate(RegisterPage);
            }
        }

        private void ButtonGoExit_Click(object sender, RoutedEventArgs e)
        {
            if (Models.User.LoggedUser != null)
            {
                MessageBoxResult mbResult = MessageBox.Show("Выйти?", "Вы уверены, что хотите выйти?", MessageBoxButton.YesNo);
                if (mbResult == MessageBoxResult.Yes)
                {
                    Models.User.LoggedUser = null;
                    (_loginPage, _registerPage, _filmsListPage, _userAccountPage) = (null, null, null, null);
                    KinoAppHelper.GetWindowAtType<UserWindow>()?.Frame.Navigate(LoginPage);
                }
            }
        }

        private void ButtonGoCorpInfo_Click(object sender, RoutedEventArgs e)
        {
            KinoAppHelper.GetWindowAtType<UserWindow>()?.Frame.Navigate(AboutCo);
        }

        private void ButtonGoUserAccountInfo_Click(object sender, RoutedEventArgs e)
        {
            if (Models.User.LoggedUser != null)
            {
                KinoAppHelper.GetWindowAtType<UserWindow>()?.Frame.Navigate(UserAccountPage);
            }
            else
            {
                KinoAppHelper.GetWindowAtType<UserWindow>()?.Frame.Navigate(LoginPage);
            }
        }
    }
}
