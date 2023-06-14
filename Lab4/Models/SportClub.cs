using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab4.Models {
    public class SportClub {

        [Required]
        [DisplayName("Sports Club Member ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Maximum 50 characters")]
        public string Title { get; set; }

        [DataType(DataType.Currency)]
        [Column(TypeName = "money")]
        public decimal Fee { get; set; }

        public IEnumerable<Subscription> Subscriptions { get; set; }
    }
}
