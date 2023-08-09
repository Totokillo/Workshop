namespace Workshop01.BackEnd.Model.Response.Permission
{
    public class LoginResponse
    {
    }

    public class LoginList
    {
        public List<LoginModel> dataUser { get; set; } = new();
    }

    public class LoginModel
    {
        public int Id { get; set; }  
        public string StudentName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
    }
}
