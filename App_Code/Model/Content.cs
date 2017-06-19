namespace _model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Content")]
    public partial class Content
    {
        public int ID { get; set; }

        public int TopicID { get; set; }

        public int A_1 { get; set; }

        public int A_2 { get; set; }

        public int A_3 { get; set; }

        public int A_4 { get; set; }

        [StringLength(100)]
        public string A_5 { get; set; }

        public int B_1 { get; set; }

        public int B_2 { get; set; }

        public int B_3 { get; set; }

        public int B_4 { get; set; }

        public int B_5 { get; set; }

        [StringLength(100)]
        public string B_6 { get; set; }

        public int C_1 { get; set; }

        public int C_2 { get; set; }

        public int C_3 { get; set; }

        [StringLength(20)]
        public string D_1_TypeID { get; set; }

        [StringLength(100)]
        public string D_2 { get; set; }

        [StringLength(25)]
        public string PosterLocation { get; set; }

        [StringLength(25)]
        public string D1_Else { get; set; }
    }
}
