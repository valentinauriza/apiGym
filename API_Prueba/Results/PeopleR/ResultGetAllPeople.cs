namespace API_Prueba.Results.PeopleR;

public class ResultGetAllPeople : BaseResult
{
    public List<ResultPersonItem> peopleList { get; set; } = new List<ResultPersonItem>();
}

public class ResultPersonItem
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public int IdNo { get; set; }
    public string Gender { get; set; }
    public string Adress { get; set; }
    public int No { get; set; }
}
