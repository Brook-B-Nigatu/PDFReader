using PDFReader.API.DBModels;
using PDFReader.API.Repositories.Interfaces;
using PDFReader.API.ExceptionHandling.Exceptions;

namespace PDFReader.API.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly PDFReaderDBContext _context;
        public UserRepository(PDFReaderDBContext context)
        {
            _context = context;
        }

        public void AddUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public User GetUserByID(int id)
        {
            
            return _context.Users.Find(id) ?? throw new UserMissingException($"No user with id {id}");
        }

        public User GetUserByName(string username)
        {
            return _context.Users.FirstOrDefault(user => user.UserName == username)
                ?? throw new UserMissingException($"No user with username {username}");
        }

        public bool Exists(string username)
        { 
            return _context.Users.Any(user => user.UserName == username);
        }
    }
}
