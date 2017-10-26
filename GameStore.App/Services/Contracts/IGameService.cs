namespace GameStore.App.Services.Contracts
{
    using System;
    using System.Collections.Generic;
    using GameStore.App.Models;

    public interface IGameService
    {
        void Add(string title, string description, string image, decimal price, double size, string trailer, DateTime releaseDate);

        IEnumerable<AddGameModel> All();
    }
}