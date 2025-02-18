using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Final_Assignment_Carter_Fitzgerald.Models
{ 
    public class GenAIs
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter a GenAI name.")]
        [Display(Name = "GenAIName")]
        public string GenAIName { get; set; }

        [Required(ErrorMessage = "Please enter a summary.")]
        [Display(Name = "Summary")]
        public string Summary { get; set; }

        [NotMapped]
        [Required]
        [Display(Name = "Upload Image File")]
        public IFormFile ImgFile { get; set; }
        public int? Likes { get; set; }

        public GenAIs()
        {
            Likes = 0;
        }

        public string ImageFileName { get; set; }
        public string AnchorLink { get; set; }
    }
}
