using Dapper;
using Microsoft.Data.Sqlite;
using System.Xml.Linq;
using Workshop01.BackEnd.Model.Request.ManageUser;
using Workshop01.BackEnd.Model.Response.ManageUser;
using Workshop01.BackEnd.View.Infrastructure;

namespace Workshop01.BackEnd.View.Services
{
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
                if (request.Email is not null)
                {
                    string QuerySelect = @" SELECT FirstName ||' '|| LastName as studentname  FROM STUDENT WHERE EMAIL = @EMAIL ";
                    string DataValidate = await connection.QueryFirstOrDefaultAsync<string>(QuerySelect, new
                    {
                        EMAIL = request.Email,
                    });
                    if (DataValidate != null)
                    {
                        throw new Exception("มี email ซ้ำ");
                    }
                }

                string QueryInsert = @" INSERT INTO STUDENT 
                                            ( FirstName , LastName , Email , Password , BirthDay)
                                    VALUES  (  @FIRSTNAME , @LASTNAME ,@EMAIL, @PASSWORD , @BIRTHDATE ) ";

                await connection.ExecuteAsync(QueryInsert, new
                {
                    FIRSTNAME = request.FirstName,
                    LASTNAME = request.LastName,
                    EMAIL = request.Email,
                    PASSWORD = request.PassWord,
                    BIRTHDATE = request.BirthDay
                });

                return true;
            }
            catch (Exception ex) { throw; }
            finally { connection.Close(); }
        }

        public async Task<ManageUserList?> SelectManageUser(SelectManageUserRequest request)
        {
            using var connection = new SqliteConnection(_configuration["DatabaseName"]);
            try
            {
                ManageUserList result = new();

                string QuerySelect = @" SELECT ID  , FirstName ||' '|| LastName as Username , FirstName, LastName, Email  , BirthDay FROM STUDENT WHERE ID = @ID ";


                var DataSelect = await connection.QueryFirstOrDefaultAsync<ManageUserList>(QuerySelect, new
                {
                    ID = request.Id,
                });

                result.id = DataSelect.id;
                result.UserName = DataSelect.UserName;
                result.FirstName = DataSelect.FirstName;
                result.LastName = DataSelect.LastName;
                result.Email = DataSelect.Email;
                result.BirthDay = DataSelect.BirthDay.Split(" ")[0] ?? "";

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
                                    SET Firstname = @FIRSTNAME,
                                        Lastname = @LASTNAME,
                                        Email = @EMAIL ,
                                        BirthDay = @BIRTHDAY
                                    WHERE id = @ID ";

                await connection.ExecuteAsync(QueryUpdate, new
                {
                    FIRSTNAME = request.FirstName,
                    LASTNAME = request.LastName,
                    EMAIL = request.Email,
                    BIRTHDAY = request.BirthDay,
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
                                            ( StudentId  , Name  )
                                    VALUES  ( @ID , (SELECT FIRSTNAME ||' '|| LASTNAME as Name FROM STUDENT WHERE ID = @ID )  ) ";

                await connection.ExecuteAsync(QueryInsert, new
                {
                    ID = request.Id,
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
                string QueryCheckin = @" SELECT Id , StudentId, Name as UserName , timestamp from CHECKIN where 1=1 And StudentId = @ID ";

                if (request.Name is not null)
                {
                    QueryCheckin += " And Name like @NAME||'%' ";
                }
                if (request.CheckInDate is not null)
                {
                    QueryCheckin += " And date(timestamp) = date(@TIMESTAMP) ";
                }

                var dataCheckin = await connection.QueryAsync<SelectCheckInModel>(QueryCheckin, new
                {
                    ID = request.Id,
                    NAME = request.Name,
                    TIMESTAMP = request.CheckInDate.HasValue ? request.CheckInDate.Value.ToString("yyyy-MM-dd"): (String?)null
                }) ;

                result.dataCheckIn = dataCheckin.ToList();
                return result;
            }
            catch (Exception ex) { throw; }
            finally { connection.Close(); }
        }

    }
}