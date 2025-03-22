namespace ASPDay4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mod3 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.departments",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            AddColumn("dbo.client", "dept_id", c => c.Int());
            CreateIndex("dbo.client", "dept_id");
            AddForeignKey("dbo.client", "dept_id", "dbo.departments", "id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.client", "dept_id", "dbo.departments");
            DropIndex("dbo.client", new[] { "dept_id" });
            DropColumn("dbo.client", "dept_id");
            DropTable("dbo.departments");
        }
    }
}
