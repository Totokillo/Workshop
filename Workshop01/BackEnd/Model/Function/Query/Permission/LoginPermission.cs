using MediatR;
using Workshop01.BackEnd.Model.Function.Query.ManageUser;
using Workshop01.BackEnd.Model.Request.ManageUser;
using Workshop01.BackEnd.Model.Request.Permission;
using Workshop01.BackEnd.Model.Response.Common;
using Workshop01.BackEnd.Model.Response.ManageUser;
using Workshop01.BackEnd.Model.Response.Permission;
using Workshop01.BackEnd.View.Infrastructure;

namespace Workshop01.BackEnd.Model.Function.Query.Permission
{
    public class LoginPermission : IRequest<BaseResponses<LoginList>>
    {
        public LoginUserRequest request { get; set; } = new();

        public class LoginPermissionHandler : IRequestHandler<LoginPermission, BaseResponses<LoginList>>
        {
            private readonly IPermissionService _Infrastructure;
            public LoginPermissionHandler(IPermissionService Infrastructure)
            {
                _Infrastructure = Infrastructure;
            }

            public async Task<BaseResponses<LoginList>> Handle(LoginPermission command, CancellationToken cancellationToken)
            {
                try
                {
                    var response = new BaseResponses<LoginList>();
                    response.ResponseObject = await _Infrastructure.LoginPermission(command.request);
                    response.Success = true;
                    response.Message = "Success";
                    return response;
                }
                catch (Exception ex)
                {
                    return new BaseResponses<LoginList>() { Message = ex.Message };
                }
            }
        }
    }
}
