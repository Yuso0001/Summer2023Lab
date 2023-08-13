namespace Lab4.Models.ViewModels {
    public class FileInputViewModel : SportClubViewModel {
        public SportClub SportClub { get; set; }

        public List<News> News { get; set; }

        public string SportClubId { get; set; }

        public string SportClubTitle { get; set; }
        public IFormFile File { get; set; }
    }

}
