namespace API_Prueba.Commands.People;

public class CreatePersonCommand
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public int IdNo { get; set; }
    public Guid Gender { get; set; }
    public string Adress { get; set; }
    public int No { get; set; }
}
