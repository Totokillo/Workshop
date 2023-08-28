namespace Workshop01.BackEnd.Model.Response.Permission
{
    public class LoginResponse
    {
    }

    //public class LoginList
    //{
    //    public List<LoginList> dataUser { get; set; } = new();
    //}

    public class LoginList
    {
        public int Id { get; set; }  
        public string StudentName { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
    }
}
