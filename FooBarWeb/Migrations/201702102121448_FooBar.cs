namespace FooBarWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FooBar : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bars",
                c => new
                    {
                        BarID = c.Int(nullable: false, identity: true),
                        BarName = c.String(),
                    })
                .PrimaryKey(t => t.BarID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Bars");
        }
    }
}
