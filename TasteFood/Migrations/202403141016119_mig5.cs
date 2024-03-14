namespace TasteFood.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig5 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PartialSliders",
                c => new
                    {
                        SliderId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        SubTitle = c.String(),
                        Description = c.String(),
                        ImageUrl = c.String(),
                    })
                .PrimaryKey(t => t.SliderId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.PartialSliders");
        }
    }
}
