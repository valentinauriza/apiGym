namespace API_Prueba.Results.GendersR;

public class ResultGetGender : BaseResult
{
    public List<ResultGenderItem> genderList { get; set; } = new List<ResultGenderItem>();
}

public class ResultGenderItem
{
    public Guid Id { get; set; }
    public string Gender { get; set; }
}