using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using DataCleaner.Entities;
using DataCleaner.Models;

namespace DataCleaner
{
    class Program
    {
        static void Main(string[] args)
        {
            var data = new List<CleanData>();
            var ratingThreshold = 7.2;
            var context = new ImdbContext();
            //var actors = context.title_principals.Select(_ => new { _.tconst, _.nconst, _.category, _.ordering }).ToList();
            var ratings = context.title_ratings_clean
                .ToList();
            var progress = 0;
            foreach (var rating in ratings)
            {
                progress++;
                var movie = context.title_basics_clean.First(x => x.tconst.Equals(rating.tconst));
                var actors = context.title_principals_clean.Where(x => x.tconst.Equals(rating.tconst)).ToList();
                var actorInfo = actors
                    .OrderBy(o => o.ordering)
                    .FirstOrDefault(x => x.category.Equals("actor") || x.category.Equals("actress"));
                if (actorInfo == null) continue;
                var actor = context.name_basics_clean.First(x => x.nconst.Equals(actorInfo.nconst));

                var ageGapData = GetAgeGap(movie.startYear, actor.birthYear);
                if (ageGapData == null) continue;

                data.Add(new CleanData
                {
                    ActorAgeGapId = ageGapData.Id,
                    AgeGapDefinition = ageGapData.Definition,
                    Genres = movie.genres,
                    NumberOfVotes = int.Parse(rating.numVotes),
                    Rating = rating.averageRating,
                    StaringActorId = actor.Id,
                    Title = movie.originalTitle,
                    Success = float.Parse(rating.averageRating) > ratingThreshold
                });

                Console.WriteLine($"{progress} out of {ratings.Count} - Added movie: {movie.originalTitle}");
            }
            
             context.CleanData.AddRange(data);
            context.SaveChanges();
            Console.ReadLine();
        }

        private static AgeGapModel GetAgeGap(string movieYear, string birthYear)
        {
            var result = new AgeGapModel();

            if (!int.TryParse(movieYear, out var y1))
                return null;
            if (!int.TryParse(birthYear, out var y2))
                return null;

            var age = y1 - y2;
            if (age > 60)
            {
                result.Id = 1;
                result.Definition = "+60s";
            }
            else if (age > 50)
            {
                result.Id = 2;
                result.Definition = "50s";
            }
            else if (age > 40)
            {
                result.Id = 3;
                result.Definition = "40s";
            }
            else if (age > 30)
            {
                result.Id = 4;
                result.Definition = "30s";
            }
            else if (age > 20)
            {
                result.Id = 5;
                result.Definition = "20s";
            }
            else if (age > 10)
            {
                result.Id = 6;
                result.Definition = "teenager";
            }
            else if (age > 0)
            {
                result.Id = 7;
                result.Definition = "childhood";
            }

            return result;
        }
    }
}
