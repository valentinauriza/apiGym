namespace API_Prueba.Results.RolesR;

public class ResultGetRoles : BaseResult
{
    public List<ResultRolItem> rolesList { get; set; } = new List<ResultRolItem>();
}

public class ResultRolItem
{
    public Guid Id { get; set; }
    public string Rol { get; set; }
}
