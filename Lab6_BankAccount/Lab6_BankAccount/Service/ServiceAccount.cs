using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lab6_BankAccount.Models;

namespace Lab6_BankAccount.Service
{
    public class ServiceAccount : IServiceAccount
    {

        public decimal CountBonus(Account account, decimal balance)
        {
            return (decimal)account.TypeAccount.BonusPercent * balance;
        }

        public long NumberAccount()
        {
            return Int64.Parse(DateTime.Now.ToString("yyMMddhhmmss"));
        }
    }
}