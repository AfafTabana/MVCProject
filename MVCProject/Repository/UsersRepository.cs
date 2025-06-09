using MVCProject.Models;

namespace MVCProject.Repository
{
    public class UsersRepository:IUserRepository
    {
        public LibraryContext Context { get; }

        public UsersRepository(LibraryContext _context)
        {
            Context = _context;
        }
        public Users GetUserById(int id)
        {
            var user =  Context.Users.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                throw new ArgumentException("User not found", nameof(id));
            }
            else
            {
                return user;
            }
        }
        public IEnumerable<Users> GetAllUsers()
        {
            return Context.Users.ToList();
        }
        public void AddUser(Users user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user), "User");
            }
            else
            {
                Context.Users.Add(user);
                Context.SaveChanges();
            }
        }

        public void UpdateUser(Users user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user), "User");
            }
            else
            {
                Context.Users.Update(user);
                Context.SaveChanges();
            }
        }
        public void DeleteUser(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Invalid user ID", nameof(id));
            }
            else
            {
                var user = Context.Users.FirstOrDefault(u=>u.Id == id);
                if (user != null)
                {
                    Context.Users.Remove(user);
                    Context.SaveChanges();
                }
            }
        }
    
    }
}
