namespace CieTrade.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateCardTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cards",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateTime = c.DateTime(nullable: false),
                        Profession_Id = c.Byte(),
                        Professionals_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Professions", t => t.Profession_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Professionals_Id)
                .Index(t => t.Profession_Id)
                .Index(t => t.Professionals_Id);
            
            CreateTable(
                "dbo.Professions",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cards", "Professionals_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Cards", "Profession_Id", "dbo.Professions");
            DropIndex("dbo.Cards", new[] { "Professionals_Id" });
            DropIndex("dbo.Cards", new[] { "Profession_Id" });
            DropTable("dbo.Professions");
            DropTable("dbo.Cards");
        }
    }
}
