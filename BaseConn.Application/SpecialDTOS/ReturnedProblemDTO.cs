using BaseConn.Domain.models;
using Microsoft.AspNetCore.Mvc;

namespace BaseConn.Application.SpecialDTOS
{
    public class ReturnedProblemDTO
    {

    
    public Problem problem {get;set;}
    public FileContentResult returnedFile {get;set;}
        
    }
}