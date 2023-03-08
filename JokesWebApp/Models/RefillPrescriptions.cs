using System;

namespace JokesWebApp.Models
{
    public class RefillPrescriptions
    {
        public int Id { get; set; }

        public string MedicineName { get; set; }

        public string RefillDate { get; set;}

        //public DateTime PickupDate { get; set; } = DateTime.Now;

        public RefillPrescriptions()
        {
            
        }
    }
}
