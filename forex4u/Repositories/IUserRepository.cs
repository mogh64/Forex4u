using forex4u.Models;
using FX.Core.Bsse;
using FX.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace forex4u.Repositories
{
    public interface IUserRepository:IRepository<StockUser>
    {
        StockUser CheckAccount(string username, string password);
    }
}
