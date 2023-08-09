using MediatR;
using Workshop01.BackEnd.Model.Request.ManageUser;
using Workshop01.BackEnd.Model.Response.Common;
using Workshop01.BackEnd.Model.Validation.ManageUser;
using Workshop01.BackEnd.View.Infrastructure;

namespace Workshop01.BackEnd.Model.Function.Command.ManageUser
{
    public class DeleteManageUser : IRequest<BaseResponses<bool>>
    {
        public DeleteManageUserRequest request { get; set; } = new();

        public class ManageUserHandler : IRequestHandler<DeleteManageUser, BaseResponses<bool>>
        {
            private readonly IManageUser _Infrastructure;
            public ManageUserHandler(IManageUser Infrastructure)
            {
                _Infrastructure = Infrastructure;
            }

            public async Task<BaseResponses<bool>> Handle(DeleteManageUser command, CancellationToken cancellationToken)
            {
                try
                {
                    var response = new BaseResponses<bool>();
                    DeleteManageUserValidate validator = new();
                    var validationResult = await validator.ValidateAsync(command.request, cancellationToken);
                    if (!validationResult.IsValid)
                    {
                        response.Success = false;
                        response.Message = "Validation Failed";
                        response.Errors = validationResult.Errors.Select(x => x.ErrorMessage).ToList();
                    }
                    else
                    {
                        response.ResponseObject = await _Infrastructure.DeleteManageUser(command.request);
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
