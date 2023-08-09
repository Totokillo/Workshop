using Workshop01.BackEnd.Model.Request.ManageUser;
using Workshop01.BackEnd.Model.Response.ManageUser;

namespace Workshop01.BackEnd.View.Infrastructure;

public interface IManageUser
{
    Task<bool> DeleteManageUser(DeleteManageUserRequest request);
    Task<bool> InsertCheckIn(InsertCheckInRequest request);
    Task<bool> InsertManageUser(InsertManageUserRequest request);
    Task<SelectCheckInList?> SelectCheckInTimeStamp(SelectCheckInRequest request);
    Task<ManageUserList?> SelectManageUser(SelectManageUserRequest request);
    Task<bool> UpdateManageUser(UpdateManageUserRequest request);
}

