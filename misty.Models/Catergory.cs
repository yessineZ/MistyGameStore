using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace misty.Models
{
    public class Catergory
    {

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(20)]

        [DisplayName("Name")]
        public string Name { get; set; }

        [DisplayName("Display Order")]
        [Range(0, 20, ErrorMessage = "Display a number between 1-20")]
        public int DisplayOrder { get; set; }



    }
}
