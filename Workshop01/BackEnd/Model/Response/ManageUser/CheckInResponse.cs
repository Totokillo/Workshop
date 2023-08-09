namespace Workshop01.BackEnd.Model.Response.ManageUser;

    public class CheckInResponse
    {

    }


public class SelectCheckInList
{
    public List<SelectCheckInModel> dataCheckIn { get; set; } = new();
}
public class SelectCheckInModel
{
    public int Id { get; set; }
    public int StudentId { get; set; }
    public string UserName { get; set; } = string.Empty;
    public DateTime TimeStamp { get; set; }
}

