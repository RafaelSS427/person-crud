using Microsoft.EntityFrameworkCore;
using person_crud.DataAccess.DataModel;
using person_crud.DataAccess.DataModel.DataContext;
using person_crud.DataAccess.Interfaces;

namespace person_crud.DataAccess
{
    public class PersonDA : IPersonDA
    {
        public Person Get(int id)
        {
            Person person = null;

            using (var context = new InterviewPersonDataContext()) {
                person = context.People.FromSqlRaw($"EXECUTE usp_GetPerson @Id = {id}").ToList().FirstOrDefault();
            }

            return person;
        }

        public List<Person> GetAll()
        {
            List<Person> people = null;

            using (var context = new InterviewPersonDataContext())
            {
                people = context.People.FromSqlRaw($"EXECUTE usp_GetAllPerson").ToList();
            }

            return people;
        }

        public bool Save(string person)
        { 
            bool result = false;

            using (var context = new InterviewPersonDataContext())
            {
                int res = context.Database.ExecuteSqlInterpolated($"EXECUTE usp_SavePerson @JsonData = { person }");
                result = res == 1;
            }

            return result;
        }

        public bool Update(string person, int id)
        {
            bool result = false;

            using (var context = new InterviewPersonDataContext())
            {
                int res = context.Database.ExecuteSqlInterpolated($"EXECUTE usp_UpdatePerson @JsonData = { person }, @Id = { id }");
                result = res == 1;
            }

            return result;
        }

        public bool Delete(int id)
        {
            bool result = false;

            using (var context = new InterviewPersonDataContext())
            {
                int res = context.Database.ExecuteSqlInterpolated($"EXECUTE usp_DeletePerson @Id = {id}");
                result = res == 1;
            }

            return result;
        }
    }
}