using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMDB.Model
{
    public class CleanDataModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public int? StaringActorId { get; set; }

        public string StaringActor { get; set; }

        public int? ActorAgeGapId { get; set; }

        public string AgeGapDefinition { get; set; }

        public int? WriterId { get; set; }

        public string Writer { get; set; }

        public string Genres { get; set; }

        public int? GenreId { get; set; }

        public int? NumberOfVotes { get; set; }

        public string Rating { get; set; }

        public int? Success { get; set; }
    }
}
