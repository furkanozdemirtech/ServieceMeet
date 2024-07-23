using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CreatedMeetRepository.Model
{
    public class USER_ROLES
    {
        [Key, Column(Order = 0)]
        public int USER_ID { get; set; }
        [Key, Column(Order = 1)]
        public int ROLE_ID { get; set; }
    }
}
