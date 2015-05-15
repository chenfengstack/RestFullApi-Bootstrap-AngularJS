namespace Spartan.Model.Migrations.config
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class one : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.news",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NewName = c.String(maxLength: 200, storeType: "nvarchar"),
                        NewTime = c.DateTime(nullable: false, precision: 0),
                        NewContent = c.String(unicode: false),
                        IsDel = c.Boolean(nullable: false),
                        AppTime = c.DateTime(nullable: false, precision: 0),
                        NewType_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.newtype", t => t.NewType_Id)
                .Index(t => t.NewType_Id);
            
            CreateTable(
                "dbo.newtype",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50, storeType: "nvarchar"),
                        IsDel = c.Boolean(nullable: false),
                        AppTime = c.DateTime(nullable: false, precision: 0),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.news", "NewType_Id", "dbo.newtype");
            DropIndex("dbo.news", new[] { "NewType_Id" });
            DropTable("dbo.newtype");
            DropTable("dbo.news");
        }
    }
}
