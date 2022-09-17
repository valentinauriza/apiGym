namespace API_Prueba.Commands.People;

public class UpdatePersonCommand
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public Guid IdGender { get; set; }
    public string Adress { get; set; }
    public int No { get; set; }
}
