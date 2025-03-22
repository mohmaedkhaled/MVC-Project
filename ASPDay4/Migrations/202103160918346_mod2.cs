namespace ASPDay4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mod2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.client", "photo", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.client", "photo");
        }
    }
}
