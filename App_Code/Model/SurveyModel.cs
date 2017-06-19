namespace _model
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    

    public partial class SurveyModel : DbContext
    {
        public SurveyModel()
            : base("name=SurveyModelConn")
        {
        }

        public virtual DbSet<Content> Content { get; set; }
        public virtual DbSet<Topic> Topic { get; set; }
        public virtual DbSet<D1_Choose> D1_Choose { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
