using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JokesWebApp.Models
{
    public class UserFinancialActivity
    {
        public int Id { get; set; } // Primary Key
        public string UserId { get; set; }
        public string TransactionName { get; set; }
        public string TransactionType { get; set; }
        public string PostedDate { get; set; }
        public string Term { get; set; }
        public double Charge { get; set; }
        public double Payment { get; set; }
        public double Refund { get; set; }
        public UserFinancialActivity()
        {

        }
    }
}
