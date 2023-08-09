using MediatR;
using Workshop01.BackEnd.Model.Function.Database;
using Workshop01.BackEnd.Model.Request.ManageUser;
using Workshop01.BackEnd.Model.Response.Common;
using Workshop01.BackEnd.Model.Validation.ManageUser;
using Workshop01.BackEnd.View.Infrastructure;

namespace Workshop01.BackEnd.Model.Function.Command.ManageUser
{
    public class InsertManageUser : IRequest<BaseResponses<bool>>
    {
        public InsertManageUserRequest request { get; set; } = new();

        public class DatabaseHandler : IRequestHandler<InsertManageUser, BaseResponses<bool>>
        {
            private readonly IManageUser _Infrastructure;
            public DatabaseHandler(IManageUser Infrastructure)
            {
                _Infrastructure = Infrastructure;
            }

            public async Task<BaseResponses<bool>> Handle(InsertManageUser command, CancellationToken cancellationToken)
            {
                try
                {
                    var response = new BaseResponses<bool>();
                    InsertManageUserValidate validator = new();
                    var validationResult = await validator.ValidateAsync(command.request, cancellationToken);
                    if (!validationResult.IsValid)
                    {
                        response.Success = false;
                        response.Message = "Validation Failed";
                        response.Errors = validationResult.Errors.Select(x => x.ErrorMessage).ToList();
                    }
                    else
                    {
                        response.ResponseObject = await _Infrastructure.InsertManageUser(command.request);
                        response.Success = true;
                        response.Message = "Success";
                    }
                    return response;
                }
                catch (Exception ex)
                {
                    return new BaseResponses<bool>() { Message = ex.Message };
                }
            }
        }
    }
}
