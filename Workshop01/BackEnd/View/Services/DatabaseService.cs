using Dapper;
using Microsoft.Data.Sqlite;
using Workshop01.BackEnd.View.Infrastructure;

namespace Workshop01.BackEnd.View.Services;

    public class DatabaseService : IDatabaseService
    {
         private readonly IConfiguration _configuration;
        public DatabaseService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

    public async Task<bool> SetupDatabase(List<string> request)
    {
        using var connection = new SqliteConnection(_configuration["DatabaseName"]);

        try
        {
            string queryTable = @" CREATE TABLE STUDENT ( 
                                                             Id integer PRIMARY KEY AUTOINCREMENT,
                                                             FirstName varchar(255) NOT NULL,
                                                             LastName varchar(255) NOT NULL,
                                                             Email varchar(255)  NULL,
                                                             PassWord varchar(255) NOT NULL,
                                                             BirthDay DATETIME NULL
                                    )
                                ";

            await connection.ExecuteAsync(queryTable);

            string queryCheckIn = @" CREATE TABLE CHECKIN ( 
                                                             Id integer PRIMARY KEY AUTOINCREMENT,
                                                             StudentId integer NOT NULL,
                                                             Name varchar(255) NOT NULL,
                                                             TimeStamp TIMESTAMP DEFAULT CURRENT_TIMESTAMP 
                                    ) ";
            await connection.ExecuteAsync(queryCheckIn);



            return true;
        }
        catch (Exception ex)
        {
            throw;
        }
        finally { connection.Close(); }
        }
}

