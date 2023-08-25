using Dapper;
using Microsoft.Data.Sqlite;
using Workshop01.BackEnd.Model.Request.Permission;
using Workshop01.BackEnd.Model.Response.Permission;
using Workshop01.BackEnd.View.Infrastructure;

namespace Workshop01.BackEnd.View.Services;

    public class PermissionService : IPermissionService
{
    private readonly IConfiguration _configuration;
    public PermissionService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async Task<LoginList?> LoginPermission(LoginUserRequest request)
    {
        using var connection = new SqliteConnection(_configuration["DatabaseName"]);

        try
        {
            LoginList result = new();

            string queryLogin = @"  SELECT Id  , FIRSTNAME ||' '|| LASTNAME as studentname , EMAIL  FROM STUDENT WHERE  EMAIL = @USERNAME  AND PASSWORD = @PASSWORD ";

            var dataLogin = await connection.QueryFirstOrDefaultAsync<LoginList>(queryLogin , new { USERNAME = request.Email , PASSWORD = request.PassWord });

            if(dataLogin is not null )
            {
                result.Id = dataLogin.Id;
                result.StudentName = dataLogin.StudentName;
                result.Email = dataLogin.Email;
            }else
            {
                throw new Exception("ไม่มี User นี้ในระบบ");
            }

            return result;
        }
        catch (Exception ex)
        {
            throw;
        }
        finally { connection.Close(); }
    }
}

