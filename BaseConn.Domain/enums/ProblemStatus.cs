using System.ComponentModel;

namespace BaseConn.Domain.enums
{
    public enum ProblemStatus
    {
       
       [Description("Resolved")]
       Resolved = 1,
       [Description("UnResolved")]
       UnResolved = 0
        
    }
}