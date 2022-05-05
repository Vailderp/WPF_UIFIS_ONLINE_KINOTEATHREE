using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Kinoteathree.Models
{
    public class ActorFilmTable
    {
        public int Id { get; set; }
        public int FilmId { get; set; }
        public int ActorId { get; set; }

        [JsonIgnore]
        public virtual Actor? Actor { get; set; }

        [JsonIgnore]
        public virtual Film? Film { get; set; }
    }
}
