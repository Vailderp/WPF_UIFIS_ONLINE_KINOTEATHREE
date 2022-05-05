using Kinoteathree.Models;
using Kinoteathree.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Kinoteathree.ViewModels
{
    internal class LoginPageViewModel : BaseViewModel
    {
        public LoginPageViewModel() { }

        private RelayCommand? _loginComand;

        private User? _user;

        public User User
        {
            get => _user ?? (_user = new User());
            set
            {
                _user = value;
                OnPropertyChanged();
            }
        }

        public RelayCommand LoginComand
        {
            get
            {
                return _loginComand ?? (_loginComand = new RelayCommand(
                e =>
                {
                 
                    KinoContext ctx = new KinoContext();
                    User? user = ctx.Users.FirstOrDefault(u => u.Login == User.Login && u.Password == User.Password);
                    if (user != null)
                    {
                        User.LoggedUser = user;
                        MessageBox.Show("Вы успешно вошли в свой аккаунт!");
                        if (user.IsAdmin)
                        {
                            KinoAppHelper.GetWindowAtType<Windows.UserWindow>()?.Frame.Navigate(new Pages.FilmsListPageAdmin());
                        }
                        else
                        {
                            KinoAppHelper.GetWindowAtType<Windows.UserWindow>()?.Frame.Navigate(new Pages.FilmsListPage());
                        }
                    }
                    else
                    {
                        MessageBox.Show("Вы ввели неверно логин или пароль!");
                    }
                },
                e =>
                {
                    Regex regex = new Regex("[a-z0-9]", RegexOptions.Singleline);
                    if (regex.IsMatch(User.Login ?? "") && regex.IsMatch(User.Password ?? "")) 
                        return true;
                    return false;
                }
                ));
            }
        }
    }
}
