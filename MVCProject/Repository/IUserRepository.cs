using MVCProject.Models;

namespace MVCProject.Repository
{
    public interface IUserRepository
    {
        public Users getUserByApplicationUserId(string applicationUserId);
        public Users GetUserById(int id);
        public IEnumerable<Users> GetAllUsers();
        public void AddUser(Users user);    
        public void UpdateUser(Users user);
        public void DeleteUser(int id);


    }
}
