namespace API_Prueba.Results.PeopleR;

public class ResultGetOnePerson : BaseResult
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public int IdNo { get; set; }
    public string Gender { get; set; }
    public string Adress { get; set; }
    public int No { get; set; }
}
