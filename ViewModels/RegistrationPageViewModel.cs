using Kinoteathree.Models;
using Kinoteathree.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Kinoteathree.ViewModels
{
    internal class RegistrationPageViewModel : BaseViewModel
    {
        private string? _registerErrorString;
        public string RegisterErrorString
        {
            get => _registerErrorString ?? (_registerErrorString = "");
            set
            {
                _registerErrorString = value;
                OnPropertyChanged();
            }
        }
        private RelayCommand? _registerCommand;
        private User? user_;
        public User User
        {
            get => user_ ?? (user_ = new User());
            set
            {
                user_ = value;
                OnPropertyChanged();
            }
        }
        public RelayCommand RegisterCommand
        {
            get
            {
                return _registerCommand ?? (_registerCommand = new RelayCommand(
                e =>
                {
                    KinoContext ctx = new KinoContext();
                    ctx.Users.Add(User);
                    ctx.SaveChanges();
                    MessageBox.Show("Вы успешно зарегистрировались!");
                    KinoAppHelper.GetWindowAtType<Windows.UserWindow>()?.Frame.Navigate(new Pages.LoginPage());
                },
                e =>
                {
                    Regex regexNumber = new Regex("[0-9]", RegexOptions.Singleline);
                    Regex regexLogin = new Regex("[a-z0-9]", RegexOptions.Singleline);
                    Regex regexPassword = new Regex("[a-z0-9]", RegexOptions.Singleline);

                    if (User.Login.Length > 64 || !regexLogin.IsMatch(User.Login))
                    {
                        RegisterErrorString = "Неверно введён логин";
                        return false;
                    }
                    if (User.CvvCode.Length != 3)
                    {
                        RegisterErrorString = "Неверно введён Cvv код";
                        return false;
                    }
                    if (User.Password.Length > 64 || !regexPassword.IsMatch(User.Password))
                    {
                        RegisterErrorString = "Неверно введён пароль";
                        return false;
                    }
                    if (User.Phone.Length != 12)
                    {
                        RegisterErrorString = "Неверно введён номер телефона";
                        return false;
                    }
                    if (!User.MailAddress.Contains('@') || !User.MailAddress.Contains('.'))
                    {
                        RegisterErrorString = "Неверно введён Mail адрес";
                        return false;
                    }
                    return true;
                }
                ));
            }
        }
    }
}
