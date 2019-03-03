using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace RazorPagesMovie.Models
{
    public class Movie
    {
        public int ID { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string Book { get; set; }

        [Display(Name = "Log Date")]
        [DataType(DataType.Date)]
        public DateTime LogDate { get; set; }

        [Range(1, 100)]
        [DataType(DataType.Text)]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Scripture{ get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$")]
        [Required]
        [StringLength(30)]
        public string Chapter { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z0-9""'\s-]*$")]
        [StringLength(100, MinimumLength= 3)]
        [Required]
        public string Notes { get; set; }
    }
}
