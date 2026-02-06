using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Clinics
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public required string ClinicName { get; set; }
        public string? Location { get; set; }
        public List<Appointment> Appointments { get; set; } 
    }
}
