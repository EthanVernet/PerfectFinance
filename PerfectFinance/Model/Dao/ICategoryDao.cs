using Logic.Model;

namespace Logic.Dao
{
    public interface ICategoryDao
    {
        void Create(Category category, User user);
        void Update(Category category, User user);
        void Delete(Category category, User user);
        List<Category> List(User user);
    }
}
