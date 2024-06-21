namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddWeekDaysTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.WeekDaysPOS",
                c => new
                    {
                        PosId = c.Int(nullable: false),
                        WeekDaysId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.PosId, t.WeekDaysId })
                .ForeignKey("dbo.PosEntities", t => t.PosId)
                .ForeignKey("dbo.WeekDays", t => t.WeekDaysId)
                .Index(t => t.PosId)
                .Index(t => t.WeekDaysId);
            
            CreateTable(
                "dbo.WeekDays",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        WeekName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WeekDaysPOS", "WeekDaysId", "dbo.WeekDays");
            DropForeignKey("dbo.WeekDaysPOS", "PosId", "dbo.PosEntities");
            DropIndex("dbo.WeekDaysPOS", new[] { "WeekDaysId" });
            DropIndex("dbo.WeekDaysPOS", new[] { "PosId" });
            DropTable("dbo.WeekDays");
            DropTable("dbo.WeekDaysPOS");
        }
    }
}
