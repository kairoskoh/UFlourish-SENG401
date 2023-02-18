using System;
using System.ComponentModel.DataAnnotations;

namespace JokesWebApp.Models
{
    public class UserPayment
    {
        [Key]
        public string CardNumber { get; set; }

        public DateTime ExpiryDate { get; set; }
        public UserBasicInfo User { get; set; }
    }
}
