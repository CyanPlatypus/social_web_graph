namespace WebSocialWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tblsHobbAreaGen : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Areas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Genders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Hobbies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserHobby",
                c => new
                    {
                        UserId = c.Int(nullable: false),
                        HobbyId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserId, t.HobbyId })
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.Hobbies", t => t.HobbyId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.HobbyId);
            
            AddColumn("dbo.Users", "GenderId", c => c.Int());
            AddColumn("dbo.Users", "PlaceOfBirthId", c => c.Int());
            AddColumn("dbo.Users", "ResidenceId", c => c.Int());
            CreateIndex("dbo.Users", "GenderId");
            CreateIndex("dbo.Users", "PlaceOfBirthId");
            CreateIndex("dbo.Users", "ResidenceId");
            AddForeignKey("dbo.Users", "GenderId", "dbo.Genders", "Id");
            AddForeignKey("dbo.Users", "PlaceOfBirthId", "dbo.Areas", "Id");
            AddForeignKey("dbo.Users", "ResidenceId", "dbo.Areas", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "ResidenceId", "dbo.Areas");
            DropForeignKey("dbo.Users", "PlaceOfBirthId", "dbo.Areas");
            DropForeignKey("dbo.UserHobby", "HobbyId", "dbo.Hobbies");
            DropForeignKey("dbo.UserHobby", "UserId", "dbo.Users");
            DropForeignKey("dbo.Users", "GenderId", "dbo.Genders");
            DropIndex("dbo.UserHobby", new[] { "HobbyId" });
            DropIndex("dbo.UserHobby", new[] { "UserId" });
            DropIndex("dbo.Users", new[] { "ResidenceId" });
            DropIndex("dbo.Users", new[] { "PlaceOfBirthId" });
            DropIndex("dbo.Users", new[] { "GenderId" });
            DropColumn("dbo.Users", "ResidenceId");
            DropColumn("dbo.Users", "PlaceOfBirthId");
            DropColumn("dbo.Users", "GenderId");
            DropTable("dbo.UserHobby");
            DropTable("dbo.Hobbies");
            DropTable("dbo.Genders");
            DropTable("dbo.Areas");
        }
    }
}
