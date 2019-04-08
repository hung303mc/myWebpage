namespace codeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDatePublishedColumnToCourseTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Courses", "DatePublished", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Courses", "DatePublished");
        }
    }
}
