namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CitiesEntities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CityName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PosEntities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Telephone = c.String(),
                        CellPhone = c.String(),
                        Address = c.String(),
                        IdCity = c.Int(nullable: false),
                        Model = c.String(),
                        Brand = c.String(),
                        IdConnType = c.Int(nullable: false),
                        MorningOperning = c.String(),
                        MorningClosing = c.String(),
                        AfternoonOpening = c.String(),
                        AfternonClosing = c.String(),
                        DaysClosed = c.String(),
                        InsertDate = c.Long(nullable: false),
                        Cities_Id = c.Int(nullable: false),
                        ConnectionType_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CitiesEntities", t => t.Cities_Id, cascadeDelete: true)
                .ForeignKey("dbo.ConnectionTypesEntities", t => t.ConnectionType_Id, cascadeDelete: true)
                .Index(t => t.Cities_Id)
                .Index(t => t.ConnectionType_Id);
            
            CreateTable(
                "dbo.ConnectionTypesEntities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ConnectionType = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IssuesEntities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdPos = c.Int(nullable: false),
                        IdType = c.Int(nullable: false),
                        IdSubType = c.Int(nullable: false),
                        IdProblem = c.Int(nullable: false),
                        Priority = c.String(),
                        IdStatus = c.Int(nullable: false),
                        Memo = c.String(),
                        IdUserCreated = c.Int(nullable: false),
                        IdAssigned = c.Int(nullable: false),
                        Description = c.String(),
                        AssignedDate = c.Long(nullable: false),
                        CreationDate = c.Long(nullable: false),
                        ModifDate = c.Long(nullable: false),
                        Solotion = c.String(),
                        IssuesType_Id = c.Int(),
                        Pos_Id = c.Int(nullable: false),
                        Statuses_Id = c.Int(),
                        User_Id = c.Int(nullable: false),
                        UserType_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.IssuesTypesEntities", t => t.IssuesType_Id)
                .ForeignKey("dbo.PosEntities", t => t.Pos_Id, cascadeDelete: true)
                .ForeignKey("dbo.StatusesEntities", t => t.Statuses_Id)
                .ForeignKey("dbo.UsersEntities", t => t.User_Id, cascadeDelete: true)
                .ForeignKey("dbo.UserTypeEntities", t => t.UserType_Id, cascadeDelete: true)
                .Index(t => t.IssuesType_Id)
                .Index(t => t.Pos_Id)
                .Index(t => t.Statuses_Id)
                .Index(t => t.User_Id)
                .Index(t => t.UserType_Id);
            
            CreateTable(
                "dbo.IssuesTypesEntities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IssueLevel = c.Int(nullable: false),
                        ParentIssues = c.String(),
                        Name = c.String(),
                        InsertDate = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.LogsEntities",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    IdIssue = c.Int(nullable: false),
                    IdUser = c.Int(nullable: false),
                    Action = c.String(),
                    Notes = c.String(),
                    InsertDate = c.Long(nullable: false),
                    Issues_Id = c.Int(nullable: false),
                    User_Id = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.IssuesEntities", t => t.Issues_Id, cascadeDelete: true)
                .ForeignKey("dbo.UsersEntities", t => t.User_Id, cascadeDelete: false)
                .Index(t => t.Issues_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.UsersEntities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                        Email = c.String(maxLength: 100),
                        Password = c.String(),
                        Login = c.String(),
                        Telephone = c.String(),
                        IdUserType = c.Int(nullable: false),
                        UserType_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UserTypeEntities", t => t.UserType_Id, cascadeDelete: false)
                .Index(t => t.UserType_Id);
            
            CreateTable(
                "dbo.UserTypeEntities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserType = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.StatusesEntities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Status = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IssuesEntities", "UserType_Id", "dbo.UserTypeEntities");
            DropForeignKey("dbo.IssuesEntities", "User_Id", "dbo.UsersEntities");
            DropForeignKey("dbo.IssuesEntities", "Statuses_Id", "dbo.StatusesEntities");
            DropForeignKey("dbo.IssuesEntities", "Pos_Id", "dbo.PosEntities");
            DropForeignKey("dbo.LogsEntities", "User_Id", "dbo.UsersEntities");
            DropForeignKey("dbo.UsersEntities", "UserType_Id", "dbo.UserTypeEntities");
            DropForeignKey("dbo.LogsEntities", "Issues_Id", "dbo.IssuesEntities");
            DropForeignKey("dbo.IssuesEntities", "IssuesType_Id", "dbo.IssuesTypesEntities");
            DropForeignKey("dbo.PosEntities", "ConnectionType_Id", "dbo.ConnectionTypesEntities");
            DropForeignKey("dbo.PosEntities", "Cities_Id", "dbo.CitiesEntities");
            DropIndex("dbo.UsersEntities", new[] { "UserType_Id" });
            DropIndex("dbo.LogsEntities", new[] { "User_Id" });
            DropIndex("dbo.LogsEntities", new[] { "Issues_Id" });
            DropIndex("dbo.IssuesEntities", new[] { "UserType_Id" });
            DropIndex("dbo.IssuesEntities", new[] { "User_Id" });
            DropIndex("dbo.IssuesEntities", new[] { "Statuses_Id" });
            DropIndex("dbo.IssuesEntities", new[] { "Pos_Id" });
            DropIndex("dbo.IssuesEntities", new[] { "IssuesType_Id" });
            DropIndex("dbo.PosEntities", new[] { "ConnectionType_Id" });
            DropIndex("dbo.PosEntities", new[] { "Cities_Id" });
            DropTable("dbo.StatusesEntities");
            DropTable("dbo.UserTypeEntities");
            DropTable("dbo.UsersEntities");
            DropTable("dbo.LogsEntities");
            DropTable("dbo.IssuesTypesEntities");
            DropTable("dbo.IssuesEntities");
            DropTable("dbo.ConnectionTypesEntities");
            DropTable("dbo.PosEntities");
            DropTable("dbo.CitiesEntities");
        }
    }
}
