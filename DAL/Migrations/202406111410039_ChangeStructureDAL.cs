namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class ChangeStructureDAL : DbMigration
    {
        public override void Up()
        {

            AlterColumn("dbo.UserEntities", "Name", c => c.String());
            AlterColumn("dbo.UserEntities", "Email", c => c.String());
        }

        public override void Down()
        {
            AlterColumn("dbo.UserEntities", "Email", c => c.String(maxLength: 100));
            AlterColumn("dbo.UserEntities", "Name", c => c.String(maxLength: 50));
        }
    }
}
