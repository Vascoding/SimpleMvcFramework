﻿namespace GameStore.App.Models
{
    using GameStore.App.Infrastructure.Validation;

    public class LoginModel
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}