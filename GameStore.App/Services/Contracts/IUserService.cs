namespace GameStore.App.Services.Contracts
{
    public interface IUserService
    {
        bool Create(string email, string fullName, string password);

        bool Exists(string email, string password);
    }
}