namespace codeFirst.Migrations
{
    using System;
    using System.Collections.ObjectModel;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<codeFirst.PlutoContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(codeFirst.PlutoContext context)
        {
            context.Authors.AddOrUpdate(a => a.Name,
                new Author
                {
                    Name = "Author 1",
                    Courses = new Collection<Course>()
                    {
                        new Course(){ Title="Course for author 1", Description = "Description 1"}
                    }
                });
;        }
    }
}
