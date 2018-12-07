namespace DataCleaner.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("[title.ratings.clean]")]
    public partial class title_ratings_clean
    {
        public string tconst { get; set; }

        public string averageRating { get; set; }

        public string numVotes { get; set; }

        public int Id { get; set; }
    }
}
