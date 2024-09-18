using PDFReader.API.DBModels;

namespace PDFReader.API.Repositories.Interfaces
{
    public interface IUserRepository
    {
        //TODO : 
        //     Implement other methods
        //     Make Asynchronous

        // Task<IEnumerable<User>> GetAllUsersAsync();
        void AddUser(User user);
        // Task DeleteUserAsync(int ID);
        User GetUserByID(int ID);

        User GetUserByName(string name);

        bool Exists(string name); 
    }
}
