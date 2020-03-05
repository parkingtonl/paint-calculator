using System;
using System.ComponentModel.DataAnnotations;

namespace PaintCalculator.Models
{
    public class PaintModel
    {
        [Required]
        public string Length { get; set; }

        [Required]
        public string Width { get; set; }

        [Required]
        public string Height { get; set;}

        public string Area { get; set; }

        public string Paint { get; set; }

        public string Volume { get; set; }
    }
}
