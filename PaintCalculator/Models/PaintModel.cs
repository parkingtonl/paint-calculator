using System;
using System.ComponentModel.DataAnnotations;

namespace PaintCalculator.Models
{
    public class PaintModel
    {
        [Required]
        public string Length { get; set; }

        public string Width { get; set; }

        public string Height { get; set;}
    }
}
