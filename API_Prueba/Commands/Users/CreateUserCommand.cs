using API_Prueba.Commands.People;
namespace API_Prueba.Commands.Users;

public class CreateUserCommand : CreatePersonCommand
{
    public Guid Id { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public DateTime CreationDate { get; set; }
    public bool Active { get; set; }
    public Guid Rol { get; set; }
    public Guid Sport { get; set; }
}
