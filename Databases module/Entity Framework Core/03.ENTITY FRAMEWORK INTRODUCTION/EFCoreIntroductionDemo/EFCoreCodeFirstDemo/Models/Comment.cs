using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EFCoreCodeFirstDemo.Models
{
    [Index(nameof(QuestionId), Name = "IX_QuestionIdMil")]
    public class Comment
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Content { get; set; }

        public int QuestionId { get; set; }
        public Question Question { get; set; }
    }
}
