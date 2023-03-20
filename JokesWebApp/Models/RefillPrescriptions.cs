using System;
using System.ComponentModel.DataAnnotations;

namespace JokesWebApp.Models
{
    public class RefillPrescriptions
    {
        public int Id { get; set; }

        public string UserName { get; set; }
        public string MedicineName { get; set; }

        [DataType(DataType.Date)]
        public DateTime RequestRefillDate { get; set; }  

        public string RefillDate { get; set;}
        public DateTime PrescriptionReadyToPickup { get; set; }



        public RefillPrescriptions()
        {
            
        }
    }
}
