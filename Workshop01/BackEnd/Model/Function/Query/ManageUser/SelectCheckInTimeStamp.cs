using MediatR;
using Workshop01.BackEnd.Model.Function.Command.ManageUser;
using Workshop01.BackEnd.Model.Request.ManageUser;
using Workshop01.BackEnd.Model.Response.Common;
using Workshop01.BackEnd.Model.Response.ManageUser;
using Workshop01.BackEnd.Model.Validation.ManageUser;
using Workshop01.BackEnd.View.Infrastructure;

namespace Workshop01.BackEnd.Model.Function.Query.ManageUser
{
    public class SelectCheckInTimeStamp : IRequest<BaseResponses<SelectCheckInList>>
    {
        public SelectCheckInRequest request { get; set; } = new();

        public class CheckInHandler : IRequestHandler<SelectCheckInTimeStamp, BaseResponses<SelectCheckInList>>
        {
            private readonly IManageUser _Infrastructure;
            public CheckInHandler(IManageUser Infrastructure)
            {
                _Infrastructure = Infrastructure;
            }

            public async Task<BaseResponses<SelectCheckInList>> Handle(SelectCheckInTimeStamp command, CancellationToken cancellationToken)
            {
                try
                {
                    var response = new BaseResponses<SelectCheckInList>();
                    response.ResponseObject = await _Infrastructure.SelectCheckInTimeStamp(command.request);
                    response.Success = true;
                    response.Message = "Success";

                    return response;
                }
                catch (Exception ex)
                {
                    return new BaseResponses<SelectCheckInList>() { Message = ex.Message };
                }
            }
        }
    }
}
