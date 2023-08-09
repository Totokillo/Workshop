namespace Workshop01.BackEnd.Model.Request.ManageUser;

    public class ManageUserRequest
    {

    }

    public class InsertManageUserRequest
{
    public int StudentId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string SurName { get; set; } = string.Empty;
    public string? Email { get; set; } = string.Empty;
    public string PassWord { get; set; } = string.Empty;
    public DateTime? BirthDay { get; set; }
}

public class UpdateManageUserRequest
{
    public int Id { get; set; }
    public string? Email { get; set; } = string.Empty;
    public string? PassWord { get; set; } = string.Empty;
    public DateTime? BirthDate { get; set; }
}

public class DeleteManageUserRequest
{
    public int Id { get; set; }
}

public class SelectManageUserRequest
{
    public int? StudentId { get; set; }
    public string? Name { get; set; } = string.Empty;
}

