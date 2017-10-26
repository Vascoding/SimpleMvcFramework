namespace GameStore.App.Models
{
    using GameStore.App.Infrastructure.Validation.Users;
    using GameStore.App.Infrastructure.Validation;

    public class RegisterModel
    {
        [Email]
        [Required]
        public string Email { get; set; }

        public string FullName { get; set; }

        [Required]
        [Password]
        public string Password { get; set; }

        [Required]
        public string ConfirmPassword { get; set; }
    }
}