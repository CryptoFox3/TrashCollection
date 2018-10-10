namespace TrashCollection.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedFullNameToCustomerModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "FullName", c => c.String());
            AddColumn("dbo.AspNetUsers", "UserRole", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "UserRole");
            DropColumn("dbo.Customers", "FullName");
        }
    }
}
