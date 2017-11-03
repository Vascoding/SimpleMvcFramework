namespace GameStore.App.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using GameStore.App.Data;
    using GameStore.App.Data.Models;
    using GameStore.App.Models;
    using GameStore.App.Services.Contracts;

    public class GameService : IGameService
    {
        public void Add(string title, string description, string image, decimal price, double size, string trailer, DateTime releaseDate)
        {
            using (var db = new GameStoreDbContext())
            {
                Game game = new Game
                {
                    Title = title,
                    Description = description,
                    Image = image,
                    Price = price,
                    Size = size,
                    Trailer = trailer,
                    ReleaseDate = releaseDate
                };

                db.Games.Add(game);
                db.SaveChanges();
            }
        }

        public IEnumerable<AddGameModel> All()
        {
            using (var db = new GameStoreDbContext())
            {
                return db.Games
                    .Select(g => new AddGameModel
                    {
                        Title = g.Title,
                        Image = g.Image,
                        ReleaseDate = g.ReleaseDate,
                        Size = g.Size,
                        Description = g.Description,
                        Trailer = g.Trailer,
                        Price = g.Price
                    }).ToList();
            }
        }
    }
}