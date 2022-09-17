namespace API_Prueba.Results.UsersR;

public class ResultUsers : BaseResult
{
    public List<ResultUserItem> userList = new List<ResultUserItem>();
}

public class ResultUserItem
{
    public Guid Id { get; set; }
    public string Username { get; set; }
}
