namespace GameStore.App.Models
{
    using System;
    using GameStore.App.Infrastructure.Validation;
    using GameStore.App.Infrastructure.Validation.Games;
    using SimpleMvc.Framework.Attributes.Validation;

    public class AddGameModel
    {
        [Required]
        [Title]
        public string Title { get; set; }

        public string Trailer { get; set; }

        [ThumbnailUrl]
        public string Image { get; set; }

        [NumberRange(0, double.MaxValue)]
        public double Size { get; set; }

        [NumberRange(0, double.MaxValue)]
        public decimal Price { get; set; }

        [Required]
        [Description]
        public string Description { get; set; }

        public DateTime ReleaseDate { get; set; }
    }
}