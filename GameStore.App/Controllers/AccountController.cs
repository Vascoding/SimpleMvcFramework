namespace GameStore.App.Controllers
{
    using GameStore.App.Models;
    using GameStore.App.Services;
    using GameStore.App.Services.Contracts;
    using SimpleMvc.Framework.Attributes.Methods;
    using SimpleMvc.Framework.Contracts;

    public class AccountController : BaseController
    {
        private readonly IUserService users;

        public AccountController()
        {
            this.users = new UserService();
        }
       
        public IActionResult Register()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Register(RegisterModel model)
        {
            if (model.Password != model.ConfirmPassword)
            {
                this.ShowError("Sorry password not match!");
                return this.Register();
            }
            var created = this.users.Create(model.Email, model.FullName, model.Password);
            if (created)
            {
                return this.Redirect(@"/account/login");
            }
            this.ShowError("Sorry there is allready user with the same email address!");
            return this.Register();
        }

        public IActionResult Login()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Login(LoginModel model)
        {
            var exists = this.users.Exists(model.Email, model.Password);
            if (exists)
            {
                 this.SignIn(model.Email);
                return this.Redirect(@"/");
            }
            this.ShowError("Username or password not valid!");
            return this.View();
        }

        public IActionResult Logout()
        {
            this.SignOut();
            return this.Redirect("/");
        }
    }
}