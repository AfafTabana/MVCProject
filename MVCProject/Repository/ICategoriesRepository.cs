using MVCProject.Models;

namespace MVCProject.Repository
{
    public interface ICategoriesRepository
    {
        public List<Categeories> GetAllCategories();
    }
}
