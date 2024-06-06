namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstMigration : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UsersEntities", "UserType_Id", "dbo.UserTypeEntities");
            DropForeignKey("dbo.IssuesEntities", "UserType_Id", "dbo.UserTypeEntities");
            DropIndex("dbo.UsersEntities", new[] { "UserType_Id" });
            DropColumn("dbo.PosEntities", "IdCity");
            DropColumn("dbo.PosEntities", "IdConnType");
            DropColumn("dbo.IssuesEntities", "IdPos");
            DropColumn("dbo.IssuesEntities", "IdUserCreated");
            DropColumn("dbo.LogsEntities", "IdIssue");
            DropColumn("dbo.LogsEntities", "IdUser");
            DropColumn("dbo.UserTypeEntities", "Id");
            RenameColumn(table: "dbo.PosEntities", name: "Cities_Id", newName: "IdCity");
            RenameColumn(table: "dbo.PosEntities", name: "ConnectionType_Id", newName: "IdConnType");
            RenameColumn(table: "dbo.IssuesEntities", name: "Pos_Id", newName: "IdPos");
            RenameColumn(table: "dbo.LogsEntities", name: "Issues_Id", newName: "IdIssue");
            RenameColumn(table: "dbo.IssuesEntities", name: "User_Id", newName: "IdUserCreated");
            RenameColumn(table: "dbo.IssuesEntities", name: "UserType_Id", newName: "IdUserType");
            RenameColumn(table: "dbo.LogsEntities", name: "User_Id", newName: "IdUser");
            RenameColumn(table: "dbo.UserTypeEntities", name: "UserType_Id", newName: "Id");
            RenameIndex(table: "dbo.PosEntities", name: "IX_Cities_Id", newName: "IX_IdCity");
            RenameIndex(table: "dbo.PosEntities", name: "IX_ConnectionType_Id", newName: "IX_IdConnType");
            RenameIndex(table: "dbo.IssuesEntities", name: "IX_Pos_Id", newName: "IX_IdPos");
            RenameIndex(table: "dbo.IssuesEntities", name: "IX_User_Id", newName: "IX_IdUserCreated");
            RenameIndex(table: "dbo.IssuesEntities", name: "IX_UserType_Id", newName: "IX_IdUserType");
            RenameIndex(table: "dbo.LogsEntities", name: "IX_Issues_Id", newName: "IX_IdIssue");
            RenameIndex(table: "dbo.LogsEntities", name: "IX_User_Id", newName: "IX_IdUser");
            DropPrimaryKey("dbo.UserTypeEntities");
            AlterColumn("dbo.UserTypeEntities", "Id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.UserTypeEntities", "Id");
            CreateIndex("dbo.UsersEntities", "Id", unique: true, name: "Email");
            CreateIndex("dbo.UsersEntities", "Id", unique: true, name: "Login");
            CreateIndex("dbo.UsersEntities", "Id", unique: true, name: "Telephone");
            CreateIndex("dbo.UserTypeEntities", "Id");
            AddForeignKey("dbo.UserTypeEntities", "Id", "dbo.UsersEntities", "Id");
            AddForeignKey("dbo.IssuesEntities", "IdUserType", "dbo.UserTypeEntities", "Id", cascadeDelete: true);
            DropColumn("dbo.IssuesEntities", "IdAssigned");
            DropColumn("dbo.UsersEntities", "UserType_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UsersEntities", "UserType_Id", c => c.Int(nullable: false));
            AddColumn("dbo.IssuesEntities", "IdAssigned", c => c.Int(nullable: false));
            DropForeignKey("dbo.IssuesEntities", "IdUserType", "dbo.UserTypeEntities");
            DropForeignKey("dbo.UserTypeEntities", "Id", "dbo.UsersEntities");
            DropIndex("dbo.UserTypeEntities", new[] { "Id" });
            DropIndex("dbo.UsersEntities", "Telephone");
            DropIndex("dbo.UsersEntities", "Login");
            DropIndex("dbo.UsersEntities", "Email");
            DropPrimaryKey("dbo.UserTypeEntities");
            AlterColumn("dbo.UserTypeEntities", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.UserTypeEntities", "Id");
            RenameIndex(table: "dbo.LogsEntities", name: "IX_IdUser", newName: "IX_User_Id");
            RenameIndex(table: "dbo.LogsEntities", name: "IX_IdIssue", newName: "IX_Issues_Id");
            RenameIndex(table: "dbo.IssuesEntities", name: "IX_IdUserType", newName: "IX_UserType_Id");
            RenameIndex(table: "dbo.IssuesEntities", name: "IX_IdUserCreated", newName: "IX_User_Id");
            RenameIndex(table: "dbo.IssuesEntities", name: "IX_IdPos", newName: "IX_Pos_Id");
            RenameIndex(table: "dbo.PosEntities", name: "IX_IdConnType", newName: "IX_ConnectionType_Id");
            RenameIndex(table: "dbo.PosEntities", name: "IX_IdCity", newName: "IX_Cities_Id");
            RenameColumn(table: "dbo.UserTypeEntities", name: "Id", newName: "UserType_Id");
            RenameColumn(table: "dbo.LogsEntities", name: "IdUser", newName: "User_Id");
            RenameColumn(table: "dbo.IssuesEntities", name: "IdUserType", newName: "UserType_Id");
            RenameColumn(table: "dbo.IssuesEntities", name: "IdUserCreated", newName: "User_Id");
            RenameColumn(table: "dbo.LogsEntities", name: "IdIssue", newName: "Issues_Id");
            RenameColumn(table: "dbo.IssuesEntities", name: "IdPos", newName: "Pos_Id");
            RenameColumn(table: "dbo.PosEntities", name: "IdConnType", newName: "ConnectionType_Id");
            RenameColumn(table: "dbo.PosEntities", name: "IdCity", newName: "Cities_Id");
            AddColumn("dbo.UserTypeEntities", "Id", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.LogsEntities", "IdUser", c => c.Int(nullable: false));
            AddColumn("dbo.LogsEntities", "IdIssue", c => c.Int(nullable: false));
            AddColumn("dbo.IssuesEntities", "IdUserCreated", c => c.Int(nullable: false));
            AddColumn("dbo.IssuesEntities", "IdPos", c => c.Int(nullable: false));
            AddColumn("dbo.PosEntities", "IdConnType", c => c.Int(nullable: false));
            AddColumn("dbo.PosEntities", "IdCity", c => c.Int(nullable: false));
            CreateIndex("dbo.UsersEntities", "UserType_Id");
            AddForeignKey("dbo.IssuesEntities", "UserType_Id", "dbo.UserTypeEntities", "Id", cascadeDelete: true);
            AddForeignKey("dbo.UsersEntities", "UserType_Id", "dbo.UserTypeEntities", "Id", cascadeDelete: true);
        }
    }
}
