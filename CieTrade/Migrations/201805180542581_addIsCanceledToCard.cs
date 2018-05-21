namespace CieTrade.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addIsCanceledToCard : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cards", "IsCanceled", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Cards", "IsCanceled");
        }
    }
}
