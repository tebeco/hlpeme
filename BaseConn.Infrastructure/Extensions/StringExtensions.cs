using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaseConn.Infrastructure.Extensions
{
    public static class StringExtensions
    {

        public static String NullCheck(string input) {  
    if (input == null)  
        return "";  
    else  
        return "Input is not null";
}

        
    }
}