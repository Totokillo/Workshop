using MediatR;
using Workshop01.BackEnd.Model.Function.Database;
using Workshop01.BackEnd.Model.Request.ManageUser;
using Workshop01.BackEnd.Model.Response.Common;
using Workshop01.BackEnd.Model.Response.ManageUser;
using Workshop01.BackEnd.View.Infrastructure;

namespace Workshop01.BackEnd.Model.Function.Query.ManageUser
{
    public class SelectManageUser : IRequest<BaseResponses<ManageUserList>>
    {
        public SelectManageUserRequest request { get; set; } = new();

        public class ManageUserHandler : IRequestHandler<SelectManageUser, BaseResponses<ManageUserList>>
        {
            private readonly IManageUser _Infrastructure;
            public ManageUserHandler(IManageUser Infrastructure)
            {
                _Infrastructure = Infrastructure;
            }

            public async Task<BaseResponses<ManageUserList>> Handle(SelectManageUser command, CancellationToken cancellationToken)
            {
                try
                {
                    var response = new BaseResponses<ManageUserList>();
                    response.ResponseObject = await _Infrastructure.SelectManageUser(command.request);
                    response.Success = true;
                    response.Message = "Success";
                    return response;
                }
                catch (Exception ex)
                {
                    return new BaseResponses<ManageUserList>() { Message = ex.Message };
                }
            }
        }
    }
}
