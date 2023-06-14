using System.ComponentModel.DataAnnotations;

namespace Lab4.Models {
    public class Subscription {

        [Required]
        public int FanId { get; set; }

        [Required]
        public string SportClubId { get; set; }

        public Fan Fan { get; set; }
        public SportClub SportClub { get; set; }
    }
}
