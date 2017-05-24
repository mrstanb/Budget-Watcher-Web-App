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
                        InitialBalance = c.Decimal(nullable: false, precision: 18, scale: 2),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        Balance = c.Decimal(nullable: false, precision: 18, scale: 2),
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
                        Description = c.String(),
                        SpendingDate = c.DateTime(nullable: false),
                        MoneySpent = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Budget_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Budgets", t => t.Budget_Id)
                .Index(t => t.Budget_Id);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        IsChosen = c.Boolean(nullable: false),
                        Spending_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Spendings", t => t.Spending_Id)
                .Index(t => t.Spending_Id);
            
            CreateTable(
                "dbo.DefaultCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Category_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.Category_Id)
                .Index(t => t.Category_Id);
            
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
            DropForeignKey("dbo.Categories", "Spending_Id", "dbo.Spendings");
            DropForeignKey("dbo.DefaultCategories", "Category_Id", "dbo.Categories");
            DropIndex("dbo.DefaultCategories", new[] { "Category_Id" });
            DropIndex("dbo.Categories", new[] { "Spending_Id" });
            DropIndex("dbo.Spendings", new[] { "Budget_Id" });
            DropIndex("dbo.Budgets", new[] { "User_Id" });
            DropTable("dbo.Users");
            DropTable("dbo.DefaultCategories");
            DropTable("dbo.Categories");
            DropTable("dbo.Spendings");
            DropTable("dbo.Budgets");
        }
    }
}
