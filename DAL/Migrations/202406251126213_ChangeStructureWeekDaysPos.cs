namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeStructureWeekDaysPos : DbMigration
    {
        public override void Up()
        {
			AlterColumn("dbo.WeekDaysPos", "Id", c => c.Int(nullable: false, identity: true));
		}
        
        public override void Down()
        {
			AlterColumn("dbo.WeekDaysPos", "Id", c => c.Int(nullable: false));
		}
    }
}
