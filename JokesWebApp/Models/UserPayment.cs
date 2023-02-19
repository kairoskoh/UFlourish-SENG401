using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JokesWebApp.Models
{
    public class UserPayment
    {
        public int Id { get; set; }

        
        public string CardNumber { get; set; }

        public DateTime ExpiryDate { get; set; }

        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public UserBasicInfo User { get; set; }


    }
}
