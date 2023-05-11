using person_crud.DataAccess.DataModel;

namespace person_crud.DataAccess.Interfaces
{
    public interface IPersonDA
    {
        Person Get(int id);
        List<Person> GetAll();
        bool Save(string person);
        bool Update(string person, int id);
        bool Delete(int id);
    }
}