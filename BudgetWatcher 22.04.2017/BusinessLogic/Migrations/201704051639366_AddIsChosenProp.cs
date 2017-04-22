namespace BusinessLogic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIsChosenProp : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Categories", "IsChosen", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Categories", "IsChosen");
        }
    }
}
