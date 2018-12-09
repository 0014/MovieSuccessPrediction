namespace DataCleaner.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("[title.crew.clean]")]
    public partial class title_crew_clean
    {
        public string tconst { get; set; }

        public string directors { get; set; }

        public string writers { get; set; }

        public int Id { get; set; }
    }
}
