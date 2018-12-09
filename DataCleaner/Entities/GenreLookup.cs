namespace DataCleaner.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("GenreLookup")]
    public partial class GenreLookup
    {
        public int Id { get; set; }

        [StringLength(250)]
        public string Genre { get; set; }
    }
}
