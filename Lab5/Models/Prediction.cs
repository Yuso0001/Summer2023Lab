using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Lab5.Models {
    public enum Question {
        Earth, Computer
    }
    public class Prediction {

        [Required]
        [Column("Id")]
        public int PredictionId { get; set; }

        [Required]
        [StringLength(50)]
        [Column("FileName")]
        public string FileName { get; set; }

        [Required]
        [StringLength(500)]
        [Column("URL")]
        public string URL { get; set; }

        [Required]
        [Column("Question")]
        public Question Question { get; set; }
    }
}
