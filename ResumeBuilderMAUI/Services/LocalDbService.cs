using ResumeBuilderMAUI.Helpers;
using ResumeBuilderMAUI.Models;
using SQLite;

namespace ResumeBuilderMAUI.Services
{
    public static class LocalDbService
    {
        static SQLiteAsyncConnection db;

        static async Task<SQLiteAsyncConnection> Inıt()
        {
            string dbPath = Path.Combine(FileSystem.AppDataDirectory, "local_resume_db.db");
            try
            {
                if (db != null)
                    return db;
                db = new SQLiteAsyncConnection(dbPath);
                await db.CreateTableAsync<Person>();
                await db.CreateTableAsync<Certification>();
                await db.CreateTableAsync<Education>();
                await db.CreateTableAsync<Experience>();
                await db.CreateTableAsync<Project>();
                await db.CreateTableAsync<Skill>();

                return db;
            }
            catch (Exception ex)
            {
                DisplayAlertHelpers.ShowAlert("Error", ex.Message);
                return null;
            }
        }

        public static async Task AddPerson(Person resume)
        {
            await Inıt();
            await db.InsertAsync(resume);
        }

        public static async Task AddCertification(Certification certification)
        {
            await Inıt();
            await db.InsertAsync(certification);
        }

        public static async Task AddEducation(Education education)
        {
            await Inıt();
            await db.InsertAsync(education);
        }

        public static async Task AddExperience(Experience experience)
        {
            try
            {
                await Inıt();
                await db.InsertAsync(experience);
            }
            catch (Exception ex)
            {
                DisplayAlertHelpers.ShowAlert("Error", ex.Message);
            }
        }

        public static async Task AddProject(Project project)
        {
            await Inıt();
            await db.InsertAsync(project);
        }

        public static async Task AddSkill(Skill skill)
        {
            await Inıt();
            await db.InsertAsync(skill);
        }

        public static async Task<List<Person>> GetAllPersons()
        {
            await Inıt();
            var persons = await db.Table<Person>().ToListAsync();
            return persons;
        }

        public static async Task<List<Person>> GetPersonsByName(string firstName, string lastName)
        {
            await Inıt();
            var persons = await db.Table<Person>().Where(x => x.FirstName == firstName && x.LastName == lastName).ToListAsync();
            return persons;
        }
    }
}
