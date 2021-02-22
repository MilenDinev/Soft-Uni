﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace EFCoreIntroductionDemo.Models
{
    [Keyless]
    public partial class VEmployeeNameJobTitle
    {
        [StringLength(152)]
        public string FullName { get; set; }
        [Required]
        [StringLength(50)]
        public string JobTitle { get; set; }
    }
}
