namespace codeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeNameCourseTable : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Courses", newName: "ourCourses");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.ourCourses", newName: "Courses");
        }
    }
}
