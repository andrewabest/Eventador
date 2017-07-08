using System.Data.Entity;

namespace Eventador
{
    public partial class EventadorContext : DbContext
    {
        public DbSet<Event> Events { get; set; }
        public DbSet<Attendee> Attendees { get; set; }
        public DbSet<Session> Sessions { get; set; }
        public DbSet<Accommodation> Accommodations { get; set; }
        public DbSet<Travel> Travels { get; set; }
    }
}