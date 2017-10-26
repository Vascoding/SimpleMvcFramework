namespace GameStore.App.Models
{
    using System;

    public class AddGameModel
    {
        public string Title { get; set; }

        public string Trailer { get; set; }

        public string Image { get; set; }

        public double Size { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        public DateTime ReleaseDate { get; set; }
    }
}