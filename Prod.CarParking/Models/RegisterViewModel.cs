﻿using System.ComponentModel.DataAnnotations;

namespace Prod.CarParking.Models
{
    public class RegisterViewModel
    {
        [Required]
        [DataType(DataType.EmailAddress,ErrorMessage = "Email address is missing or invalid.")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password,ErrorMessage = "Incorrect or missing password.")]
        public string Password { get; set; }
        [Required]
        public string Role { get; set; }
    }
}
