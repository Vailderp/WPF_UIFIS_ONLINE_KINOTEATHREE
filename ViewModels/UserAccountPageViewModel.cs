using Kinoteathree.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kinoteathree.ViewModels
{
    internal class UserAccountPageViewModel : Base.BaseViewModel
    {
        public UserAccountPageViewModel()
        {

        }
        public User User { get => User.LoggedUser ?? new User(); }
    }
}
