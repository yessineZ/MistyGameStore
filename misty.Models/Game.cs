using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace misty.Models {
    public class Game {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }
        public string Description { get; set; }

        [Required]
        public string ISBN { get; set; }

        [Required]
        public string Author { get; set; }
        [Required]
        [Display(Name = "List Price")]

        [Range(1,1000)]
        public double Price { get; set; }


        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]

        [ValidateNever]
        public Catergory Category { get; set; }


		[ValidateNever]
		public string? ImageUrl { get; set; }


	}
}
