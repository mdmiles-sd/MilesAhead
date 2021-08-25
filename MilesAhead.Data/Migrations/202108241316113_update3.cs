namespace MilesAhead.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Client", "FirstName", c => c.String(nullable: false));
            AlterColumn("dbo.Client", "LastName", c => c.String(nullable: false));
            AlterColumn("dbo.Beneficiary", "LastName", c => c.String(nullable: false));
            AlterColumn("dbo.ContactInfo", "City", c => c.String(nullable: false));
            AlterColumn("dbo.ContactInfo", "State", c => c.String(nullable: false));
            AlterColumn("dbo.ContactInfo", "Email", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ContactInfo", "Email", c => c.String());
            AlterColumn("dbo.ContactInfo", "State", c => c.String());
            AlterColumn("dbo.ContactInfo", "City", c => c.String());
            AlterColumn("dbo.Beneficiary", "LastName", c => c.String());
            AlterColumn("dbo.Client", "LastName", c => c.String());
            AlterColumn("dbo.Client", "FirstName", c => c.String());
        }
    }
}
