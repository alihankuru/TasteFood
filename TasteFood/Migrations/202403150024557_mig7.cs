namespace TasteFood.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig7 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Footers",
                c => new
                    {
                        FooterId = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        SocialMedia1 = c.String(),
                        SocialMedia2 = c.String(),
                        SocialMedia3 = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.FooterId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Footers");
        }
    }
}
