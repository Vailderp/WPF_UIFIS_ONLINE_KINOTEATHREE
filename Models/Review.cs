using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Kinoteathree.Models
{
    public class Review
    {
        public Review()
        {
            Text = "";
        }

        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public int FilmId { get; set; }
        public string Text { get; set; }

        [JsonIgnore]
        public virtual User? User { get; set; }

        [JsonIgnore]
        public virtual Film? Film { get; set; }

    }
}
