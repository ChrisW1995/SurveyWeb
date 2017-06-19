namespace _model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class D1_Choose
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int D1_TypeID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(30)]
        public string Description { get; set; }
    }
}
