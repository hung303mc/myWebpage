namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addNameToMemberShipTypeTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MembershipTypes", "Name", c => c.String());

            Sql("UPDATE MembershipTypes SET Name = 'Pay as you Go' WHERE DurationInMonths = 0");
            Sql("UPDATE MembershipTypes SET Name = 'Monthly' WHERE DurationInMonths = 1");
            Sql("UPDATE MembershipTypes SET Name = '3 Monthly' WHERE DurationInMonths = 3");
            Sql("UPDATE MembershipTypes SET Name = 'Yearly' WHERE DurationInMonths = 12");
        }
        
        public override void Down()
        {
            DropColumn("dbo.MembershipTypes", "Name");
        }
    }
}
