namespace API_Prueba.Commands.Users;

public class ChangePassCommand
{
    public Guid Id { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public string NewPassword { get; set; }
}
