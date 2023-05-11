using Microsoft.EntityFrameworkCore;

namespace person_crud.DataAccess.DataModel.DataContext
{
    public class InterviewPersonDataContext: InterviewPersonContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfiguration configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("ConnectionDB"));
        }
    }
}
