using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Eventador.Domain;
using Tailor;

namespace Eventador.Queries
{
    public class AttendeesWithDietaryPreferencesWhoHavePaidQuery : AsyncDapperQuery<AttendeesWithDietaryPreferencesWhoHavePaidResult[]>
    {
        private readonly IConnectionFactory _connectionFactory;

        public AttendeesWithDietaryPreferencesWhoHavePaidQuery(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public override async Task<AttendeesWithDietaryPreferencesWhoHavePaidResult[]> Execute()
        {
            using (var connection = _connectionFactory.Connection)
            {
                return (
                    await connection.QueryAsync<AttendeesWithDietaryPreferencesWhoHavePaidResult>(
                        GetSql())).ToArray();
            }
        }

        public override string GetSql()
        {
            return @"Select Id, FirstName, LastName, DietaryRequirements
                     From Attendees 
                     Where HasDietaryRequirements = 1
                     AND EXISTS
                     (
                        SELECT 1
                        FROM SessionAttendees Left Outer Join Sessions on SessionAttendees.Session_Id = Sessions.Id
                        WHERE Attendees.Id = SessionAttendees.Attendee_Id
                        AND Sessions.IsCatered = 1
                     )
                     AND EXISTS
                     (
                        SELECT 1 
                        FROM Accommodations 
                        WHERE Accommodations.Attendee_ID = Attendees.ID
                        AND Accommodations.Amount_Amount > 0
                    )
                    ";
        }
    }
    public class AttendeesWithDietaryPreferencesWhoHavePaidResult
    {
        public string DietaryRequirements { get; set; }
        public Guid Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
    }
}