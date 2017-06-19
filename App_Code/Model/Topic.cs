namespace _model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Topic")]
    public partial class Topic
    {
        public int TopicID { get; set; }

        [Required]
        [StringLength(100)]
        public string TopicName { get; set; }

        public DateTime TopicTime { get; set; }
    }
}
