using MediatR;
using Workshop01.BackEnd.Model.Response.Common;
using Workshop01.BackEnd.View.Infrastructure;

namespace Workshop01.BackEnd.Model.Function.Database;

public class SetupDatabase : IRequest<BaseResponses<bool>>
{
    public List<string> request { get; set; } = new();

    public class DatabaseHandler : IRequestHandler<SetupDatabase, BaseResponses<bool>>
    {
        private readonly IDatabaseService _IDatabaseService;
        public DatabaseHandler(IDatabaseService IDatabaseService)
        {
            _IDatabaseService = IDatabaseService;
        }

        public async Task<BaseResponses<bool>> Handle(SetupDatabase command, CancellationToken cancellationToken)
        {
            try
            {
                var response = new BaseResponses<bool>();
                response.ResponseObject = await _IDatabaseService.SetupDatabase(command.request);
                response.Success = true;
                response.Message = "Success";
                return response;
            }
            catch (Exception ex)
            {
                return new BaseResponses<bool>() { Message = ex.Message };
            }
        }
    }
}


