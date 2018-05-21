namespace CieTrade.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDescriptionInCard : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cards", "Description", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Cards", "Description");
        }
    }
}
