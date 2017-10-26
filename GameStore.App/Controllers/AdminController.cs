namespace GameStore.App.Controllers
{
    using System;
    using System.Linq;
    using GameStore.App.Models;
    using GameStore.App.Services;
    using GameStore.App.Services.Contracts;
    using SimpleMvc.Framework.Attributes.Methods;
    using SimpleMvc.Framework.Contracts;

    public class AdminController : BaseController
    {
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
                    .Select(g => $@"<tr class=""table-warning"">
                    <th scope = ""row"">1</ th>
                    <td>{g.Title}</ td>
                    <td>{g.Size} GB </ td>
                    <td>{g.Price} &euro;</ td>
                    <td>
                    <a href = ""#"" class=""btn btn-warning btn-sm"" > Edit</a>
                    <a href = ""#"" class=""btn btn-danger btn-sm"" > Delete</a>
                    </td>
                    </tr>
                    <tr>");

                this.ViewModel["games"] = string.Join(Environment.NewLine, gamesAsHtml);
                return this.View();
            }
            return this.Redirect("/");
        }

        public IActionResult Add()
        {
            if (this.IsAdmin)
            {
                return this.View();
            }
            return this.Redirect("/");
        }

        [HttpPost]
        public IActionResult Add(AddGameModel model)
        {
            this.games.Add(model.Title, model.Description, model.Image, model.Price, model.Size, model.Trailer, model.ReleaseDate);

            return this.Redirect("/admin/all");
        }
    }
}