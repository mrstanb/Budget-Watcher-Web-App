namespace BusinessLogic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Budgets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        InitialBudget = c.Decimal(nullable: false, precision: 18, scale: 2),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        TotalLeft = c.Decimal(nullable: false, precision: 18, scale: 2),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Spendings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SpendingDate = c.DateTime(nullable: false),
                        Budget_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Budgets", t => t.Budget_Id)
                .Index(t => t.Budget_Id);
            
            CreateTable(
                "dbo.SpendingCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(),
                        Description = c.String(),
                        MoneySpent = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IsChosen = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        Spending_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Spendings", t => t.Spending_Id)
                .Index(t => t.Spending_Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(),
                        Password = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Budgets", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Spendings", "Budget_Id", "dbo.Budgets");
            DropForeignKey("dbo.SpendingCategories", "Spending_Id", "dbo.Spendings");
            DropIndex("dbo.SpendingCategories", new[] { "Spending_Id" });
            DropIndex("dbo.Spendings", new[] { "Budget_Id" });
            DropIndex("dbo.Budgets", new[] { "User_Id" });
            DropTable("dbo.Users");
            DropTable("dbo.SpendingCategories");
            DropTable("dbo.Spendings");
            DropTable("dbo.Budgets");
        }
    }
}
