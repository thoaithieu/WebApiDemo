namespace WebApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Condition",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        VehicleId = c.Int(nullable: false),
                        Type = c.String(),
                        ImagePath = c.String(),
                        Note = c.String(),
                        CreateAt = c.DateTime(nullable: false),
                        UpdateAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Vehicle", t => t.VehicleId, cascadeDelete: true)
                .Index(t => t.VehicleId);
            
            CreateTable(
                "dbo.Vehicle",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CustomerId = c.Int(nullable: false),
                        ModelId = c.Int(nullable: false),
                        MakeId = c.Int(nullable: false),
                        VIN = c.String(),
                        Odometer = c.Int(nullable: false),
                        Engine = c.String(),
                        CreateAt = c.DateTime(nullable: false),
                        UpdateAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customer", t => t.CustomerId, cascadeDelete: true)
                .ForeignKey("dbo.Make", t => t.MakeId, cascadeDelete: true)
                .ForeignKey("dbo.Model", t => t.ModelId, cascadeDelete: true)
                .Index(t => t.CustomerId)
                .Index(t => t.MakeId)
                .Index(t => t.ModelId);
            
            CreateTable(
                "dbo.Customer",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Phone = c.String(),
                        Email = c.String(),
                        Address1 = c.String(),
                        Address2 = c.String(),
                        City = c.String(),
                        Country = c.String(),
                        CreateAt = c.DateTime(nullable: false),
                        UpdateAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Make",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CreateAt = c.DateTime(nullable: false),
                        UpdateAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Model",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Year = c.Int(nullable: false),
                        CreateAt = c.DateTime(nullable: false),
                        UpdateAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.VehicleAppraisal",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        VehicleId = c.Int(nullable: false),
                        AppraiseValue = c.Double(nullable: false),
                        CreateAt = c.DateTime(nullable: false),
                        UpdateAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Vehicle", t => t.VehicleId, cascadeDelete: true)
                .Index(t => t.VehicleId);
            
            CreateTable(
                "dbo.AppUserRole",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CreateAt = c.DateTime(nullable: false),
                        UpdateAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AppUser",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        Email = c.String(),
                        EmailConfirm = c.Boolean(nullable: false),
                        FullName = c.String(),
                        PasswordHash = c.String(),
                        Salt = c.String(),
                        UserRoleId = c.Int(nullable: false),
                        CreateAt = c.DateTime(nullable: false),
                        UpdateAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AppUserRole", t => t.UserRoleId, cascadeDelete: true)
                .Index(t => t.UserRoleId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AppUser", "UserRoleId", "dbo.AppUserRole");
            DropForeignKey("dbo.VehicleAppraisal", "VehicleId", "dbo.Vehicle");
            DropForeignKey("dbo.Vehicle", "ModelId", "dbo.Model");
            DropForeignKey("dbo.Vehicle", "MakeId", "dbo.Make");
            DropForeignKey("dbo.Vehicle", "CustomerId", "dbo.Customer");
            DropForeignKey("dbo.Condition", "VehicleId", "dbo.Vehicle");
            DropIndex("dbo.AppUser", new[] { "UserRoleId" });
            DropIndex("dbo.VehicleAppraisal", new[] { "VehicleId" });
            DropIndex("dbo.Vehicle", new[] { "ModelId" });
            DropIndex("dbo.Vehicle", new[] { "MakeId" });
            DropIndex("dbo.Vehicle", new[] { "CustomerId" });
            DropIndex("dbo.Condition", new[] { "VehicleId" });
            DropTable("dbo.AppUser");
            DropTable("dbo.AppUserRole");
            DropTable("dbo.VehicleAppraisal");
            DropTable("dbo.Model");
            DropTable("dbo.Make");
            DropTable("dbo.Customer");
            DropTable("dbo.Vehicle");
            DropTable("dbo.Condition");
        }
    }
}
