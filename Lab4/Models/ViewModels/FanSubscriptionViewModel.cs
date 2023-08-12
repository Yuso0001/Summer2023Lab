namespace Lab4.Models.ViewModels
{
    public class FanSubscriptionViewModel
    {
        public Fan Fan { get; set; }
        public IEnumerable<Fan> Fans { get; set; }
        public IEnumerable<SportClub> SportsClubs { get; set;}
        public IEnumerable<Subscription> Subscriptions { get; set;}
    }
}