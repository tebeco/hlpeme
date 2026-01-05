
public class RequestParameters
{
  private const int MaxPageSize = 50;
  public int PageNumber { get; set; } = 1;
  private int _pageSize = 10;
  public int PageSize
  {
    get
    {
      return _pageSize;
    }
    set
    {
      _pageSize = (value > MaxPageSize) ? MaxPageSize : value;
    }
  }
  public string? SearchTerm { get; set; }
  public string? SearchBy { get; set; }
  public string? Category {get;set;}
  public string OrderBy { get; set; } = "name";
  public string FilterBy { get; set; } = "";


  public string? problemCode {get;set;}
  public string? ProbemUsername {get;set;}

  public string? problemFileName {get;set;}

  public DateTime? problemStartDate {get;set;}

  public DateTime? problemEndDate {get;set;}

  public Guid? serviceId {get;set;}
}
