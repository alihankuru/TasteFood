namespace TasteFood.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig6 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Aboutts",
                c => new
                    {
                        AbouttId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Title2 = c.String(),
                        ImageUrl = c.String(),
                        ImageUrl2 = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.AbouttId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Aboutts");
        }
    }
}
