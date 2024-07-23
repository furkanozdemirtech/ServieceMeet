using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CreatedMeetRepository.Model
{
    public class PARTICIPANTS
    {
        [Key, Column(Order = 0)]
        public int USER_ID { get; set; }
        [Key, Column(Order = 1)]
        public int MEET_ID { get; set; }

    }
}
