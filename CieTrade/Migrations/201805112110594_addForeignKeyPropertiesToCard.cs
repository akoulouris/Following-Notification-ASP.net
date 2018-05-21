namespace CieTrade.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addForeignKeyPropertiesToCard : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Cards", name: "Profession_Id", newName: "ProfessionId");
            RenameColumn(table: "dbo.Cards", name: "UserProfessionals_Id", newName: "UserProfessionalsId");
            RenameIndex(table: "dbo.Cards", name: "IX_UserProfessionals_Id", newName: "IX_UserProfessionalsId");
            RenameIndex(table: "dbo.Cards", name: "IX_Profession_Id", newName: "IX_ProfessionId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Cards", name: "IX_ProfessionId", newName: "IX_Profession_Id");
            RenameIndex(table: "dbo.Cards", name: "IX_UserProfessionalsId", newName: "IX_UserProfessionals_Id");
            RenameColumn(table: "dbo.Cards", name: "UserProfessionalsId", newName: "UserProfessionals_Id");
            RenameColumn(table: "dbo.Cards", name: "ProfessionId", newName: "Profession_Id");
        }
    }
}
