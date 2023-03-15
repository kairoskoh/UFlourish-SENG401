
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JokesWebApp.Models
{
    public class UserBasicInfo
    {
        public int Id { get; set; }
        public DateTime BirthDate { get; set; }


        public string Address { get; set; }

        public string Phone { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        
        public virtual ICollection<UserInsurance>? Insurance { get; set; }
        public ICollection<UserPayment>? Payments { get; set; }




    }
}
