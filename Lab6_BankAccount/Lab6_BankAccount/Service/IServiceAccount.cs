using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab6_BankAccount.Models;

namespace Lab6_BankAccount.Service
{
    public interface IServiceAccount
    {
        decimal CountBonus(Account account, decimal balance);

        long NumberAccount();
    }
}
