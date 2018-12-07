namespace DataCleaner.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("[title.basics.clean]")]
    public partial class title_basics_clean
    {
        public string tconst { get; set; }

        public string titleType { get; set; }

        public string primaryTitle { get; set; }

        public string originalTitle { get; set; }

        public string isAdult { get; set; }

        public string startYear { get; set; }

        public string endYear { get; set; }

        public string runtimeMinutes { get; set; }

        public string genres { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
    }
}
