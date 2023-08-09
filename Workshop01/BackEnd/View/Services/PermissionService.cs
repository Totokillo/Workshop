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

            var dataLogin = await connection.QueryAsync<LoginModel>(queryLogin , new { USERNAME = request.UserName , PASSWORD = request.PassWord });

            if(dataLogin.Count() > 0 )
            {
                result.dataUser = dataLogin.ToList();
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

