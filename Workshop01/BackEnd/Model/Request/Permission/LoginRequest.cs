namespace Workshop01.BackEnd.Model.Request.Permission
{
    public class LoginRequest
    {
    }


    public class LoginUserRequest
    {
        public int StudentId { get; set; }
        public string PassWord { get; set; } = string.Empty;
    }
}
