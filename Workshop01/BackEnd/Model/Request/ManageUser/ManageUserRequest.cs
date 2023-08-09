namespace Workshop01.BackEnd.Model.Request.ManageUser;

    public class ManageUserRequest
    {

    }

    public class InsertManageUserRequest
{
    public string FisrtName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string? Email { get; set; } = string.Empty;
    public string PassWord { get; set; } = string.Empty;
    public DateTime? BirthDay { get; set; }
}

public class UpdateManageUserRequest
{
    public int Id { get; set; }
    public string? FisrtName { get; set; } = string.Empty;
    public string? LastName { get; set; } = string.Empty;
    public string? Email { get; set; } = string.Empty;
    public DateTime? BirthDay { get; set; }
}

public class DeleteManageUserRequest
{
    public int Id { get; set; }
}

public class SelectManageUserRequest
{
    public int? Id { get; set; }
}

