namespace ASPDay4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mod1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.client", "address");
        }
        
        public override void Down()
        {
            AddColumn("dbo.client", "address", c => c.String());
        }
    }
}
