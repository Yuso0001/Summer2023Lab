using System.Collections;
namespace Lab4.Models.ViewModels {
    public class SportClubViewModel {

        public IEnumerable<News> News { get; set; }
        public IEnumerable<Fan> Fans { get; set; }
        public IEnumerable<SportClub> SportClubs { get; set; }
        public IEnumerable<Subscription> Subscriptions { get; set; }
    }
}
