namespace MilesAhead.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update9 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.InsurancePolicy",
                c => new
                    {
                        InsurancePolicyID = c.Int(nullable: false, identity: true),
                        CoverageAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TypeOfPolicy = c.Int(nullable: false),
                        ClientID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.InsurancePolicyID)
                .ForeignKey("dbo.Client", t => t.ClientID, cascadeDelete: true)
                .Index(t => t.ClientID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.InsurancePolicy", "ClientID", "dbo.Client");
            DropIndex("dbo.InsurancePolicy", new[] { "ClientID" });
            DropTable("dbo.InsurancePolicy");
        }
    }
}
