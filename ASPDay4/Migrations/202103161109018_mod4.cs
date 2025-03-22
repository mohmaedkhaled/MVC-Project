namespace ASPDay4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mod4 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.client", "name", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.client", "age", c => c.Int(nullable: false));
            AlterColumn("dbo.client", "email", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.client", "email", c => c.String());
            AlterColumn("dbo.client", "age", c => c.Int());
            AlterColumn("dbo.client", "name", c => c.String(nullable: false));
        }
    }
}
