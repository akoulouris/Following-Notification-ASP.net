namespace CieTrade.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateProfeccions : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Professions (Id,Name) VALUES (1,'Software Developer')");
            Sql("INSERT INTO Professions (Id,Name) VALUES (2,'Accountant')");
            Sql("INSERT INTO Professions (Id,Name) VALUES (3,'Marketing')");
            Sql("INSERT INTO Professions (Id,Name) VALUES (4,'Sales')");
        }
        
        public override void Down()
        {
            Sql("DELETE FROM Professions WHERE Id IN (1, 2, 3, 4)");
        }
    }
}
