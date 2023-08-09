namespace Workshop01.BackEnd.Model.Request.Permission
{
    public class LoginRequest
    {
    }


    public class LoginUserRequest
    {
        public string UserName { get; set; } = string.Empty;
        public string PassWord { get; set; } = string.Empty;
    }
}
