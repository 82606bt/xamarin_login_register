using SQLite;


namespace xamarinApp.Data
{
    public interface ISQLiteConnection
    {
        SQLiteConnection GetSQLiteConnection();
    }
}
