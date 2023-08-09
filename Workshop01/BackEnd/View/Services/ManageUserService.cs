using Dapper;
using Microsoft.Data.Sqlite;
using System.Xml.Linq;
using Workshop01.BackEnd.Model.Request.ManageUser;
using Workshop01.BackEnd.Model.Response.ManageUser;
using Workshop01.BackEnd.View.Infrastructure;

namespace Workshop01.BackEnd.View.Services;

    public class ManageUserService : IManageUser
    {
                private readonly IConfiguration _configuration;
                public ManageUserService(IConfiguration configuration)
                {
                    _configuration = configuration;
                }

    // ManageUser

    public async Task<bool> InsertManageUser(InsertManageUserRequest request)
    {
        using var connection = new SqliteConnection(_configuration["DatabaseName"]);
        try
        {
            if(request.StudentId != 0 )
            {
                string QuerySelect = @" SELECTNAME ||' '|| SURNAME as studentname  FROM STUDENT WHERE STUDENTID = @STUDENTID ";
                string DataValidate = await connection.QueryFirstOrDefaultAsync<string>(QuerySelect , new
                {
                    STUDENTID = request.StudentId,
                });
                if (DataValidate != null)
                {
                    throw new Exception("มีรหัสพนักงานนี้แล้ว");
                }
            }

            string QueryInsert = @" INSERT INTO STUDENT 
                                            (StudentId , Name , Surname , Email , Password , BirthDay)
                                    VALUES  ( @STUDENTID , @NAME , @SURNAME ,@EMAIL, @PASSWORD , @BIRTHDATE ) ";

            await connection.ExecuteAsync(QueryInsert , new
            {
                STUDENTID = request.StudentId,
                NAME = request.Name,
                SURNAME = request.SurName,
                EMAIL = request.Email,
                PASSWORD = request.PassWord,
                BIRTHDATE = request.BirthDay
            });

            return true;
        }catch (Exception ex) { throw; }
        finally { connection.Close(); }
    }

    public async Task<ManageUserList?> SelectManageUser(SelectManageUserRequest request)
    {
        using var connection = new SqliteConnection(_configuration["DatabaseName"]);
        try
        {
            ManageUserList result = new();

            string QuerySelect = @" SELECT ID , STUDENTID , NAME ||' '|| SURNAME as studentname , Email , PassWord , BirthDay FROM STUDENT WHERE 1 = 1 ";

           if(request.StudentId != 0)
            {
                QuerySelect += @" AND STUDENTID = @STUDENTID ";
            }

           if(request.Name is not null)
            {
                QuerySelect += @" AND NAME = @NAME ";
            }

            var DataSelect = await connection.QueryAsync<ManageUserModel>(QuerySelect, new
            {
                STUDENTID = request.StudentId,
                NAME = request.Name,
            });


            result.dataUser = DataSelect.ToList();
            return result;
        }
        catch (Exception ex) { throw; }
        finally { connection.Close(); }
    }

    public async Task<bool> UpdateManageUser(UpdateManageUserRequest request)
    {
        using var connection = new SqliteConnection(_configuration["DatabaseName"]);
        try
        {
            string QueryUpdate = @" Update STUDENT
                                    SET Email = @EMAIL ,
                                        PassWord = @PASSWORD ,
                                        BirthDay = @BIRTHDAY
                                    WHERE id = @ID ";

            await connection.ExecuteAsync(QueryUpdate , new
            {
                EMAIL = request.Email,
                PASSWORD = request.PassWord,
                BIRTHDAY = request.BirthDate,
                ID = request.Id
            });

            return true;
        }
        catch (Exception ex) { throw; }
        finally { connection.Close(); }
    }

    public async Task<bool> DeleteManageUser(DeleteManageUserRequest request)
    {
        using var connection = new SqliteConnection(_configuration["DatabaseName"]);
        try
        {
            string QueryDelete = @" DELETE FROM STUDENT WHERE ID = @ID ";

            await connection.ExecuteAsync(QueryDelete, new
            {
                ID = request.Id
            });

            return true;
        }
        catch (Exception ex) { throw; }
        finally { connection.Close(); }
    }

    // CheckIn

    public async Task<bool> InsertCheckIn(InsertCheckInRequest request)
    {
        using var connection = new SqliteConnection(_configuration["DatabaseName"]);
        try
        {

            string QueryInsert = @" INSERT INTO CHECKIN 
                                            (StudentId , Name  )
                                    VALUES  ( @STUDENTID , (SELECT NAME ||' '|| SURNAME as Name FROM STUDENT WHERE STUDENTID = @STUDENTID )  ) ";

            await connection.ExecuteAsync(QueryInsert, new
            {
                STUDENTID = request.StudentId,
            });

            return true;
        }
        catch (Exception ex) { throw; }
        finally { connection.Close(); }
    }

    public async Task<SelectCheckInList?> SelectCheckInTimeStamp(SelectCheckInRequest request)
    {
        using var connection = new SqliteConnection(_configuration["DatabaseName"]);
        try
        {
            SelectCheckInList result = new();
            string QueryCheckin = @" SELECT ID , STUDENTID , Name as UserName , timestamp from CHECKIN ";

            var dataCheckin = await connection.QueryAsync<SelectCheckInModel>(QueryCheckin);

            result.dataCheckIn = dataCheckin.ToList();
            return result;
        }
        catch (Exception ex) { throw; }
        finally { connection.Close(); }
    }

}

