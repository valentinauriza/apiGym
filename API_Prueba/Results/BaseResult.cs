namespace API_Prueba.Results;

public class BaseResult
{
    public bool Ok { get; set; } = true;
    public string Error { get; set; }
    public int StatusCode { get; set; }

    public void setError(string errorMsg)
    {
        Ok = false;
        Error = errorMsg;
    }
}
