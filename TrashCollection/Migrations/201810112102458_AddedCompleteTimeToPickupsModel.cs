namespace TrashCollection.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedCompleteTimeToPickupsModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Pickups", "CompleteTime", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Pickups", "CompleteTime");
        }
    }
}
