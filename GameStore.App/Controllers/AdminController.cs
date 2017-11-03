namespace GameStore.App.Controllers
{
    using System;
    using System.Linq;
    using GameStore.App.Infrastructure.Common;
    using GameStore.App.Models;
    using GameStore.App.Services;
    using GameStore.App.Services.Contracts;
    using SimpleMvc.Framework.Attributes.Methods;
    using SimpleMvc.Framework.Contracts;

    public class AdminController : BaseController
    {
        private const string AdminListGames = "/admin/all";

        private readonly IGameService games;

        public AdminController()
        {
            this.games = new GameService();
        }

        public IActionResult All()
        {
            if (this.IsAdmin)
            {
                var allGames = this.games.All();

                var gamesAsHtml = allGames
                    .Select(g => HtmlHelper.AdminAllGamesAsString(g.Title, g.Size, g.Price));

                this.ViewModel["games"] = string.Join(Environment.NewLine, gamesAsHtml);
                return this.View();
            }
            return this.Redirect(HomePath);
        }

        public IActionResult Add()
        {
            if (this.IsAdmin)
            {
                return this.View();
            }
            return this.Redirect(HomePath);
        }

        [HttpPost]
        public IActionResult Add(AddGameModel model)
        {
            this.games.Add(model.Title, model.Description, model.Image, model.Price, model.Size, model.Trailer, model.ReleaseDate);

            return this.Redirect(AdminListGames);
        }
    }
}