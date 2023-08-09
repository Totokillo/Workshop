using Workshop01.BackEnd.Model.Request.Permission;
using Workshop01.BackEnd.Model.Response.Permission;

namespace Workshop01.BackEnd.View.Infrastructure
{
    public interface IPermissionService
    {
        Task<LoginList?> LoginPermission(LoginUserRequest request);
    }
}
