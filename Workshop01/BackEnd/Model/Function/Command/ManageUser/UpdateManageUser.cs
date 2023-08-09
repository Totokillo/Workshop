using MediatR;
using Workshop01.BackEnd.Model.Request.ManageUser;
using Workshop01.BackEnd.Model.Response.Common;
using Workshop01.BackEnd.Model.Validation.ManageUser;
using Workshop01.BackEnd.View.Infrastructure;

namespace Workshop01.BackEnd.Model.Function.Command.ManageUser
{
    public class UpdateManageUser : IRequest<BaseResponses<bool>>
    {
        public UpdateManageUserRequest request { get; set; } = new();

        public class ManageUserHandler : IRequestHandler<UpdateManageUser, BaseResponses<bool>>
        {
            private readonly IManageUser _Infrastructure;
            public ManageUserHandler(IManageUser Infrastructure)
            {
                _Infrastructure = Infrastructure;
            }

            public async Task<BaseResponses<bool>> Handle(UpdateManageUser command, CancellationToken cancellationToken)
            {
                try
                {
                    var response = new BaseResponses<bool>();
                    UpdateManageUserValidate validator = new();
                    var validationResult = await validator.ValidateAsync(command.request, cancellationToken);
                    if (!validationResult.IsValid)
                    {
                        response.Success = false;
                        response.Message = "Validation Failed";
                        response.Errors = validationResult.Errors.Select(x => x.ErrorMessage).ToList();
                    }
                    else
                    {
                        response.ResponseObject = await _Infrastructure.UpdateManageUser(command.request);
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
