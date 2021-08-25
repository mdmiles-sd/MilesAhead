namespace MilesAhead.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Client",
                c => new
                    {
                        ClientID = c.Int(nullable: false, identity: true),
                        OwnerID = c.Guid(nullable: false),
                        FirstName = c.String(),
                        LastName = c.String(),
                        BirthDate = c.DateTime(nullable: false),
                        Age = c.Int(nullable: false),
                        Height = c.Single(nullable: false),
                        Weight = c.Single(nullable: false),
                        Sex = c.Int(nullable: false),
                        InitalCreateUTC = c.DateTimeOffset(nullable: false, precision: 7),
                        EditUTC = c.DateTimeOffset(precision: 7),
                        ContactInfoID = c.Int(),
                        BasicHealthQuestionID = c.Int(),
                        BeneficiaryID = c.Int(),
                    })
                .PrimaryKey(t => t.ClientID)
                .ForeignKey("dbo.BasicHealthQuestion", t => t.BasicHealthQuestionID)
                .ForeignKey("dbo.Beneficiary", t => t.BeneficiaryID)
                .ForeignKey("dbo.ContactInfo", t => t.ContactInfoID)
                .Index(t => t.ContactInfoID)
                .Index(t => t.BasicHealthQuestionID)
                .Index(t => t.BeneficiaryID);
            
            CreateTable(
                "dbo.BasicHealthQuestion",
                c => new
                    {
                        BasicHealthQuestionID = c.Int(nullable: false, identity: true),
                        IsTakingMedication = c.Boolean(nullable: false),
                        IsDiabetic = c.Boolean(nullable: false),
                        IsSmoker = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.BasicHealthQuestionID);
            
            CreateTable(
                "dbo.Beneficiary",
                c => new
                    {
                        BeneficiaryID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(),
                        Relationship = c.Int(nullable: false),
                        PhoneNumber = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BeneficiaryID);
            
            CreateTable(
                "dbo.ContactInfo",
                c => new
                    {
                        ContactInfoID = c.Int(nullable: false, identity: true),
                        Address = c.String(nullable: false),
                        City = c.String(),
                        State = c.String(),
                        ZipCode = c.Int(nullable: false),
                        Email = c.String(),
                        PhoneNumber = c.Int(nullable: false),
                        BestTimeToCall = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ContactInfoID);
            
            CreateTable(
                "dbo.IdentityRole",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserRole",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(),
                        IdentityRole_Id = c.String(maxLength: 128),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.IdentityRole", t => t.IdentityRole_Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.IdentityRole_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.ApplicationUser",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserClaim",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.IdentityUserLogin",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IdentityUserRole", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserLogin", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserClaim", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserRole", "IdentityRole_Id", "dbo.IdentityRole");
            DropForeignKey("dbo.Client", "ContactInfoID", "dbo.ContactInfo");
            DropForeignKey("dbo.Client", "BeneficiaryID", "dbo.Beneficiary");
            DropForeignKey("dbo.Client", "BasicHealthQuestionID", "dbo.BasicHealthQuestion");
            DropIndex("dbo.IdentityUserLogin", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserClaim", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "IdentityRole_Id" });
            DropIndex("dbo.Client", new[] { "BeneficiaryID" });
            DropIndex("dbo.Client", new[] { "BasicHealthQuestionID" });
            DropIndex("dbo.Client", new[] { "ContactInfoID" });
            DropTable("dbo.IdentityUserLogin");
            DropTable("dbo.IdentityUserClaim");
            DropTable("dbo.ApplicationUser");
            DropTable("dbo.IdentityUserRole");
            DropTable("dbo.IdentityRole");
            DropTable("dbo.ContactInfo");
            DropTable("dbo.Beneficiary");
            DropTable("dbo.BasicHealthQuestion");
            DropTable("dbo.Client");
        }
    }
}
