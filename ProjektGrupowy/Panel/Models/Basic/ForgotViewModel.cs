﻿using System.ComponentModel.DataAnnotations;

namespace Panel.Models
{
    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}
