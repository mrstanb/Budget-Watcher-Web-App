namespace BusinessLogic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.SpendingCategories", "Spending_Id", "dbo.Spendings");
            DropForeignKey("dbo.Spendings", "Budget_Id", "dbo.Budgets");
            DropIndex("dbo.Spendings", new[] { "Budget_Id" });
            DropIndex("dbo.SpendingCategories", new[] { "Spending_Id" });
            AddColumn("dbo.SpendingCategories", "IsCustom", c => c.Boolean(nullable: false));
            DropColumn("dbo.SpendingCategories", "Spending_Id");
            DropTable("dbo.Spendings");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Spendings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SpendingDate = c.DateTime(nullable: false),
                        Budget_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.SpendingCategories", "Spending_Id", c => c.Int());
            DropColumn("dbo.SpendingCategories", "IsCustom");
            CreateIndex("dbo.SpendingCategories", "Spending_Id");
            CreateIndex("dbo.Spendings", "Budget_Id");
            AddForeignKey("dbo.Spendings", "Budget_Id", "dbo.Budgets", "Id");
            AddForeignKey("dbo.SpendingCategories", "Spending_Id", "dbo.Spendings", "Id");
        }
    }
}
