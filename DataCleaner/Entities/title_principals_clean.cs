namespace DataCleaner.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("[title.principals.clean]")]
    public partial class title_principals_clean
    {
        public string tconst { get; set; }

        public string ordering { get; set; }

        public string nconst { get; set; }

        public string category { get; set; }

        public string job { get; set; }

        public string characters { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
    }
}
