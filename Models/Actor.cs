using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Kinoteathree.Models
{
    public class Actor
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public byte[] Image { get; set; } = null!;

        [JsonIgnore]
        public virtual List<ActorFilmTable>? ActorFilmTables { get; set; }
    }
}
