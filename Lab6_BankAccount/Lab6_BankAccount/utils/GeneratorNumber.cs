using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab6_BankAccount.utils
{
    public class GeneratorNumber : IGeneratorNumber
    {
        public long Generate()
        {
            return Int64.Parse(DateTime.Now.ToString("yyMMddhhmmss"));
        }
    }
}