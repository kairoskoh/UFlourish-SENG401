using System.ComponentModel.DataAnnotations.Schema;

namespace JokesWebApp.Models
{
    public class UserInsurance
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string GroupNumber { get; set; }
        public string PolicyNumber { get; set; }
        public int CoPayAmount { get; set; }

        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual UserBasicInfo User { get; set; }
    }
}
