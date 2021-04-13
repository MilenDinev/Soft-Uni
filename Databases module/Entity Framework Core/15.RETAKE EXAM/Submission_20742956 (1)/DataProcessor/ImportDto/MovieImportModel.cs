using Cinema.Data.Models.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace Cinema.DataProcessor.ImportDto
{
    public class MovieImportModel
    {
        [Required]
        [MinLength(3)]
        [MaxLength(20)]
        public string Title { get; set; }
        [EnumDataType(typeof(Genre))]
        public string Genre { get; set; }
        [Required]
        public string Duration { get; set; }
        [Range(typeof(double), "1", "10")]
        public double Rating { get; set; }
        [Required]
        [MinLength(3)]
        [MaxLength(20)]
        public string Director { get; set; }
    }
}
