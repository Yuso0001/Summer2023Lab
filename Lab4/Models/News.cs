using System.ComponentModel.DataAnnotations;

namespace Lab4.Models {
    public class News {
        [Key]
        [Microsoft.Build.Framework.Required]
        public int Id { get; set; }

        [Microsoft.Build.Framework.Required]
        [StringLength(1000)]
        [Display(Name = "File Name")]
        public string FileName { get; set; }

        [Display(Name = "News Images")]
        public string Url { get; set; }
    }
}
