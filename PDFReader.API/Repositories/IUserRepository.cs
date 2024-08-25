using PDFReader.API.DBModels;

namespace PDFReader.API.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task AddUserAsync(User user);

        Task DeleteUserAsync(int ID);
        Task GetUserAsync(int ID);
    }
}
