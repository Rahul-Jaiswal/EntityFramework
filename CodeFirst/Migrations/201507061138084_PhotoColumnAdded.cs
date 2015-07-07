namespace EntityFramework.CodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class PhotoColumnAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "Photo", c => c.Binary());
           // DropColumn("dbo.Students", "Photo");
        }
        
        public override void Down()
        {
            
        }
    }
}
