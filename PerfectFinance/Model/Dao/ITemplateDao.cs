using Logic.Model;

namespace Logic.Dao
{
    public interface ITemplateDao
    {
        void Create(Template template);
        void Update(Template template);
        void Delete(Template template);
        List<Template> List();
    }
}
