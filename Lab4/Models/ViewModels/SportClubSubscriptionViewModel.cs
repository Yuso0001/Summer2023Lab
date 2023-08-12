

namespace Lab4.Models.ViewModels
{
    public class SportClubSubscriptionViewModel : SportClubViewModel
    {
        public IEnumerable<SportClub> SportClubId { get; set; }
        public string Title { get; set; }
        public bool IsMember { get; set; }
        public int FanId { get; set; }
        public Fan Fan { get; set; }
        public SportClub SportClub { get; set; }
    }
}