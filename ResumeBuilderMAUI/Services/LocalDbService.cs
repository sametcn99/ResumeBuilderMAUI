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
            try
            {
                if (db != null)
                    return db;
                string dbPath = Path.Combine(FileSystem.AppDataDirectory, "app_db_local.db");
                db = new SQLiteAsyncConnection(dbPath);
                await db.CreateTableAsync<Resume>();
                return db;
            }
            catch (Exception ex)
            {
                DisplayAlertHelpers.ShowAlert("Error", ex.Message);
                return null;
            }
        }

        public static async Task AddResume(Resume resume)
        {
            await Inıt();
            await db.InsertAsync(resume);
        }

    }
}
