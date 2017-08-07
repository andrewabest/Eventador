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
                        Attendee_ID = c.Guid(nullable: false),
                        Hotel = c.String(),
                        From = c.DateTimeOffset(nullable: false, precision: 7),
                        Nights = c.Int(nullable: false),
                        Amount_Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Attendees",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Event_Id = c.Guid(nullable: false),
                        FirstName = c.String(),
                        LastName = c.String(),
                        HasDietaryRequirements = c.Boolean(nullable: false),
                        DietaryRequirements = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
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
                "dbo.SessionAttendees",
                c => new
                    {
                        Session_Id = c.Guid(nullable: false),
                        Attendee_Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.Session_Id, t.Attendee_Id });
            
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
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Sessions");
            DropTable("dbo.SessionAttendees");
            DropTable("dbo.Events");
            DropTable("dbo.Attendees");
            DropTable("dbo.Accommodations");
        }
    }
}
