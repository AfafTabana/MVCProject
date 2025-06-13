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

        public Users getUserByApplicationUserId(string applicationUserId)
        {
            var user = Context.Users.FirstOrDefault(u => u.ApplicationUserId == applicationUserId);
                return user;
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
          
                Context.Users.Add(user);
                Context.SaveChanges();
            
        }

        public void UpdateUser(Users user)
        {
           
                Context.Users.Update(user);
                Context.SaveChanges();
            
        }
        public void DeleteUser(int id)
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
