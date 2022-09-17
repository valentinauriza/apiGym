namespace API_Prueba.Results.SportsR;

public class ResultGetAllSports : BaseResult
{
    public List<ResultSportItem> sportsList { get; set; } = new List<ResultSportItem>();
}

public class ResultSportItem
{
    public Guid Id { get; set; }
    public string Sport { get; set; }
}
