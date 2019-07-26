using System.Data.Entity.Migrations;

namespace WebServices.Migrations
{
    public partial class init : DbMigration
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
                "dbo.Friendships",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        FriendId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.FriendId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.FriendId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Surname = c.String(),
                        Patronymic = c.String(),
                        Phone = c.String(),
                        DateOfBirth = c.DateTime(),
                        GenderId = c.Int(),
                        PlaceOfBirthId = c.Int(),
                        ResidenceId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Genders", t => t.GenderId)
                .ForeignKey("dbo.Areas", t => t.PlaceOfBirthId)
                .ForeignKey("dbo.Areas", t => t.ResidenceId)
                .Index(t => t.GenderId)
                .Index(t => t.PlaceOfBirthId)
                .Index(t => t.ResidenceId);
            
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Friendships", "UserId", "dbo.Users");
            DropForeignKey("dbo.Friendships", "FriendId", "dbo.Users");
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
            DropIndex("dbo.Friendships", new[] { "FriendId" });
            DropIndex("dbo.Friendships", new[] { "UserId" });
            DropTable("dbo.UserHobby");
            DropTable("dbo.Hobbies");
            DropTable("dbo.Genders");
            DropTable("dbo.Users");
            DropTable("dbo.Friendships");
            DropTable("dbo.Areas");
        }
    }
}
