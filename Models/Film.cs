using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Kinoteathree.Models
{
    public class Film
    {
        public Film() 
        {
            (Name, Description) = ("", "");
        }


        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int AccessOld { get; set; }
        public decimal Cost { get; set; }
        public decimal Budget { get; set; }
        public string Description { get; set; }
        public float Raiting { get; set; }
        public byte[] ImageLogo { get; set; }
        public byte[] ImageFull { get; set; }
        public int Year { get; set; }
        public int GenreId { get; set; }
        public int CountryId { get; set; }
        public byte[] VideoData { get; set; }

        public int FilmVideoId { get; set; }

        [JsonIgnore]
        public virtual List<Review>? Reviews { get; set; }

        [JsonIgnore]
        public virtual Genre? Genre { get; set; }

        [JsonIgnore]
        public virtual Country? Country { get; set; }

        [JsonIgnore]
        public virtual List<ActorFilmTable>? ActorFilmTables { get; set; }
    }
}
