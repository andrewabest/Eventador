using System;

namespace Eventador.Queries
{
    public class AttendeeDto
    {
        public string DietaryRequirements { get; set; }
        public Guid Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
    }
}