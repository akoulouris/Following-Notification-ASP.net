namespace CieTrade.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RequiredAttribute : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Cards", "Profession_Id", "dbo.Professions");
            DropForeignKey("dbo.Cards", "UserProfessionals_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Cards", new[] { "Profession_Id" });
            DropIndex("dbo.Cards", new[] { "UserProfessionals_Id" });
            AlterColumn("dbo.Cards", "Profession_Id", c => c.Byte(nullable: false));
            AlterColumn("dbo.Cards", "UserProfessionals_Id", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Professions", "Name", c => c.String(nullable: false, maxLength: 255));
            CreateIndex("dbo.Cards", "Profession_Id");
            CreateIndex("dbo.Cards", "UserProfessionals_Id");
            AddForeignKey("dbo.Cards", "Profession_Id", "dbo.Professions", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Cards", "UserProfessionals_Id", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cards", "UserProfessionals_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Cards", "Profession_Id", "dbo.Professions");
            DropIndex("dbo.Cards", new[] { "UserProfessionals_Id" });
            DropIndex("dbo.Cards", new[] { "Profession_Id" });
            AlterColumn("dbo.Professions", "Name", c => c.String());
            AlterColumn("dbo.Cards", "UserProfessionals_Id", c => c.String(maxLength: 128));
            AlterColumn("dbo.Cards", "Profession_Id", c => c.Byte());
            CreateIndex("dbo.Cards", "UserProfessionals_Id");
            CreateIndex("dbo.Cards", "Profession_Id");
            AddForeignKey("dbo.Cards", "UserProfessionals_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Cards", "Profession_Id", "dbo.Professions", "Id");
        }
    }
}
