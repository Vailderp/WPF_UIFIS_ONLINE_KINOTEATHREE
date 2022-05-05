using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Kinoteathree.Models
{
    public class User
    {
        public User()
        {
            IsAdmin = false;
            (FirstName, SecondName, MiddleName, Login, Password, Phone, MailAddress, CvvCode, CardCode) = ("", "", "", "", "", "", "", "", "");
        }

        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string MiddleName { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public string MailAddress { get; set; } 
        public string CvvCode { get; set; } 
        public string CardCode { get; set; }
        public bool IsAdmin { get; set; }

        [JsonIgnore]
        public virtual List<Review>? Reviews { get; set; }

        [JsonIgnore]
        public static User? LoggedUser { get; set; }
    }
}
