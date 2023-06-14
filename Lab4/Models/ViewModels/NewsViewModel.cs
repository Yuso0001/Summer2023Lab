using System.Collections;
namespace Lab4.Models.ViewModels {
    public class NewsViewModel {
        public IEnumerable<SportClub> SportClub { get; set; }
        public IEnumerable<Fan> Fans { get; set; }
        public IEnumerable<Subscription> Subscriptions { get; set; }

    }
}
