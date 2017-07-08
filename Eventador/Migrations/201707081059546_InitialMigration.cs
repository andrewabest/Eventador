namespace Eventador.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accommodations",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Hotel = c.String(),
                        From = c.DateTimeOffset(nullable: false, precision: 7),
                        Nights = c.Int(nullable: false),
                        Amount_Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Attendee_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Attendees", t => t.Attendee_Id)
                .Index(t => t.Attendee_Id);
            
            CreateTable(
                "dbo.Attendees",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        FirstName = c.String(),
                        LastName = c.String(),
                        HasDietaryRequirements = c.Boolean(nullable: false),
                        DietaryRequirements = c.String(),
                        Event_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Events", t => t.Event_Id)
                .Index(t => t.Event_Id);
            
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        Location = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Sessions",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Title = c.String(),
                        Presenter = c.String(),
                        StartsAt = c.DateTimeOffset(nullable: false, precision: 7),
                        Duration = c.Time(nullable: false, precision: 7),
                        IsCatered = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Travels",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Attendee_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Attendees", t => t.Attendee_Id)
                .Index(t => t.Attendee_Id);
            
            CreateTable(
                "dbo.SessionAttendees",
                c => new
                    {
                        Session_Id = c.Guid(nullable: false),
                        Attendee_Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.Session_Id, t.Attendee_Id })
                .ForeignKey("dbo.Sessions", t => t.Session_Id, cascadeDelete: true)
                .ForeignKey("dbo.Attendees", t => t.Attendee_Id, cascadeDelete: true)
                .Index(t => t.Session_Id)
                .Index(t => t.Attendee_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Travels", "Attendee_Id", "dbo.Attendees");
            DropForeignKey("dbo.SessionAttendees", "Attendee_Id", "dbo.Attendees");
            DropForeignKey("dbo.SessionAttendees", "Session_Id", "dbo.Sessions");
            DropForeignKey("dbo.Attendees", "Event_Id", "dbo.Events");
            DropForeignKey("dbo.Accommodations", "Attendee_Id", "dbo.Attendees");
            DropIndex("dbo.SessionAttendees", new[] { "Attendee_Id" });
            DropIndex("dbo.SessionAttendees", new[] { "Session_Id" });
            DropIndex("dbo.Travels", new[] { "Attendee_Id" });
            DropIndex("dbo.Attendees", new[] { "Event_Id" });
            DropIndex("dbo.Accommodations", new[] { "Attendee_Id" });
            DropTable("dbo.SessionAttendees");
            DropTable("dbo.Travels");
            DropTable("dbo.Sessions");
            DropTable("dbo.Events");
            DropTable("dbo.Attendees");
            DropTable("dbo.Accommodations");
        }
    }
}
