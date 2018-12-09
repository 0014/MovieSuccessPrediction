namespace DataCleaner.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CleanData")]
    public partial class CleanData
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public int? StaringActorId { get; set; }

        [StringLength(250)]
        public string StaringActor { get; set; }

        public int? ActorAgeGapId { get; set; }

        [StringLength(50)]
        public string AgeGapDefinition { get; set; }

        public int? WriterId { get; set; }

        [StringLength(250)]
        public string Writer { get; set; }

        public string Genres { get; set; }

        public int? GenreId { get; set; }

        public int? NumberOfVotes { get; set; }

        [StringLength(50)]
        public string Rating { get; set; }

        public bool? Success { get; set; }
    }
}
