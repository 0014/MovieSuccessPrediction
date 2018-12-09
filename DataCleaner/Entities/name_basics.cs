namespace DataCleaner.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("[name.basics]")]
    public partial class name_basics
    {
        public string nconst { get; set; }

        public string primaryName { get; set; }

        public string birthYear { get; set; }

        public string deathYear { get; set; }

        public string primaryProfession { get; set; }

        public string knownForTitles { get; set; }

        public int Id { get; set; }
    }
}
