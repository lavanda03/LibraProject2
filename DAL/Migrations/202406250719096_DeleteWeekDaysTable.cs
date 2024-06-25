namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteWeekDaysTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.WeekDaysPOS", "WeekDaysId", "dbo.WeekDays");
            DropIndex("dbo.WeekDaysPOS", new[] { "WeekDaysId" });
            DropPrimaryKey("dbo.WeekDaysPOS");
            AlterColumn("dbo.WeekDaysPOS", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.WeekDaysPOS", "Id");
            DropColumn("dbo.WeekDaysPOS", "WeekDaysId");
            DropTable("dbo.WeekDays");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.WeekDays",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        WeekName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.WeekDaysPOS", "WeekDaysId", c => c.Int(nullable: false));
            DropPrimaryKey("dbo.WeekDaysPOS");
            AlterColumn("dbo.WeekDaysPOS", "Id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.WeekDaysPOS", new[] { "PosId", "WeekDaysId" });
            CreateIndex("dbo.WeekDaysPOS", "WeekDaysId");
            AddForeignKey("dbo.WeekDaysPOS", "WeekDaysId", "dbo.WeekDays", "Id");
        }
    }
}
