namespace Workshop01.BackEnd.Model.Response.ManageUser;

    public class ManageUserResponse
    {

    }

//    public class ManageUserList
//{
//    public List<ManageUserList> dataUser { get; set; } = new();
//}

    public class ManageUserList
{
    public int id { get; set; }
    public string UserName { get; set; } = string.Empty;
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string BirthDay { get; set; } = string.Empty;
}

