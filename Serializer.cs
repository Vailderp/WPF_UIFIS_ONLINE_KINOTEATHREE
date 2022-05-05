using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;
using System.Text.Json;
using Kinoteathree.Models;
using System.Text.Json.Serialization;

namespace Kinoteathree
{
    public class Serializer
    {
        public Serializer()
        {

        }
        public static void WriteToFile()
        {
            var ctx = new KinoContext();
            File.WriteAllText("Serializer/Countries.txt", JsonSerializer.Serialize(ctx.Countries));
            File.WriteAllText("Serializer/Genres.txt", JsonSerializer.Serialize(ctx.Genres));
            File.WriteAllText("Serializer/Users.txt", JsonSerializer.Serialize(ctx.Users));
            File.WriteAllText("Serializer/Actors.txt", JsonSerializer.Serialize(ctx.Actors));
            File.WriteAllText("Serializer/Films.txt", JsonSerializer.Serialize(ctx.Films));
            File.WriteAllText("Serializer/ActorFilmTables.txt", JsonSerializer.Serialize(ctx.ActorFilmTables));
            File.WriteAllText("Serializer/Reviews.txt", JsonSerializer.Serialize(ctx.Reviews));
        }
        public static void ReadFromFile()
        {
            var ctx = new KinoContext();

            List<Country> countries = JsonSerializer.Deserialize<List<Country>>(File.ReadAllText("Serializer/Countries.txt"));
            foreach (var country in countries)
            {
                country.Id = 0;
                ctx.Countries.Add(country);
            }

            ctx.SaveChanges();

            List<Genre> genres = JsonSerializer.Deserialize<List<Genre>>(File.ReadAllText("Serializer/Genres.txt"));
            foreach (var genre in genres)
            {
                genre.Id = 0;
                ctx.Genres.Add(genre);
            }

            ctx.SaveChanges();

            List<Film> films = JsonSerializer.Deserialize<List<Film>>(File.ReadAllText("Serializer/Films.txt"));
            foreach (var film in films)
            {
                film.Id = 0;
                ctx.Films.Add(film);
            }

            ctx.SaveChanges();

            List<User> users = JsonSerializer.Deserialize<List<User>>(File.ReadAllText("Serializer/Users.txt"));
            foreach (var user in users)
            {
                user.Id = 0;
                ctx.Users.Add(user);
            }

            ctx.SaveChanges();

            List<Actor> actors = JsonSerializer.Deserialize<List<Actor>>(File.ReadAllText("Serializer/Actors.txt"));
            foreach (var actor in actors)
            {
                actor.Id = 0;
                ctx.Actors.Add(actor);
            }

            ctx.SaveChanges();

            List<Review> reviews = JsonSerializer.Deserialize<List<Review>>(File.ReadAllText("Serializer/Reviews.txt"));
            foreach (var review in reviews)
            {
                review.Id = 0;
                ctx.Reviews.Add(review);
            }

            ctx.SaveChanges();

            List<ActorFilmTable> actorFilmTables = JsonSerializer.Deserialize<List<ActorFilmTable>>(File.ReadAllText("Serializer/ActorFilmTables.txt"));
            foreach (var actorFilmTable in actorFilmTables)
            {
                actorFilmTable.Id = 0;
                if (ctx.Films.Any(film => film.Id == actorFilmTable.FilmId))
                {
                    ctx.ActorFilmTables.Add(actorFilmTable);
                }
            }

            ctx.SaveChanges();

        }
    }
}
