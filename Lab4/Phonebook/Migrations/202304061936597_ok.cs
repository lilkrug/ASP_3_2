namespace Phonebook.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ok : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.HandbookRecords",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LastName = c.String(nullable: false, maxLength: 20),
                        Phone = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Phone, unique: true);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.HandbookRecords", new[] { "Phone" });
            DropTable("dbo.HandbookRecords");
        }
    }
}
