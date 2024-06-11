using MvvmHelpers;
using ResumeBuilderMAUI.Helpers;
using ResumeBuilderMAUI.Models;
using ResumeBuilderMAUI.ViewModels;
using SQLite;
using System.Collections.ObjectModel;

namespace ResumeBuilderMAUI.Services
{
    public static class LocalDbService
    {
        public static event EventHandler DataChanged = delegate { };

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
                Dialogs.ShowAlert("Error", ex.Message);
                return null;
            }
        }

        public static async Task AddPerson(Person resume)
        {
            await Inıt();
            await db.InsertAsync(resume);
            DataChanged.Invoke(null, EventArgs.Empty);
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
                Dialogs.ShowAlert("Error", ex.Message);
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

        public static async Task<MainViewModel> GetResumeByResumeId(string resumeId)
        {
            await Inıt();
            var person = await db.Table<Person>().Where(p => p.ResumeId == resumeId).FirstOrDefaultAsync();
            var certifications = await db.Table<Certification>().Where(c => c.ResumeId == person.ResumeId).ToListAsync();
            var educations = await db.Table<Education>().Where(e => e.ResumeId == person.ResumeId).ToListAsync();
            var experiences = await db.Table<Experience>().Where(e => e.ResumeId == person.ResumeId).ToListAsync();
            var projects = await db.Table<Project>().Where(p => p.ResumeId == person.ResumeId).ToListAsync();
            var skills = await db.Table<Skill>().Where(s => s.ResumeId == person.ResumeId).ToListAsync();
            var Resume = new MainViewModel
            {
                FirstName = person.FirstName,
                LastName = person.LastName,
                Email = person.Email,
                PhoneNumber = person.PhoneNumber,
                Address = person.Address,
                Summary = person.Summary,
                LinkedIn = person.LinkedIn,
                GitHub = person.GitHub,
                Certifications = new ObservableCollection<string>(certifications.Select(c => c.Name)),
                Educations = new ObservableRangeCollection<Education>(educations),
                Experiences = new ObservableRangeCollection<Experience>(experiences),
                Projects = new ObservableRangeCollection<Project>(projects),
                SkillList = new ObservableCollection<string>(skills.Select(s => s.Name))
            };

            return Resume;
        }
    }
}
