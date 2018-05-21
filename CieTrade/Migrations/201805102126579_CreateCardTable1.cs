namespace CieTrade.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateCardTable1 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Cards", name: "Professionals_Id", newName: "UserProfessionals_Id");
            RenameIndex(table: "dbo.Cards", name: "IX_Professionals_Id", newName: "IX_UserProfessionals_Id");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Cards", name: "IX_UserProfessionals_Id", newName: "IX_Professionals_Id");
            RenameColumn(table: "dbo.Cards", name: "UserProfessionals_Id", newName: "Professionals_Id");
        }
    }
}
