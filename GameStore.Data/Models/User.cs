namespace GameStore.App.Data.Models
{
    using System.Collections.Generic;

    public class User
    {
        public int Id { get; set; }

        public string Email { get; set; }

        public string FullName { get; set; }

        public string Password { get; set; }

        public bool IsAdmin { get; set; }
        
        public List<Order> Games { get; set; }
    }
}