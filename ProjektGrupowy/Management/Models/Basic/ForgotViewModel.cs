﻿using System.ComponentModel.DataAnnotations;

namespace Management.Models
{
    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}
