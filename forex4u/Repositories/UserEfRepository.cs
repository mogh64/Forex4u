using System;
using System.Collections.Generic;
using System.Text;
using forex4u.Infrastructure;
using forex4u.Models;
using System.Linq;
namespace forex4u.Repositories
{
    public class UserEfRepository : IUserRepository
    {
        ApplicationDbContext dbContext;
        public UserEfRepository(ApplicationDbContext ctx)
        {
            dbContext = ctx;
        }
        public StockUser CheckAccount(string username, string password)
        {
            
            if (password == StaticValues.TokenRequestKey)
            {
                var user  = dbContext.StockUsers.Where(e => e.MobileNumber == username).FirstOrDefault();
                if (user != null)
                    return user;                
            }
         
            return null;
        }
        public StockUser Add(StockUser item)
        {
            var dbUser =  dbContext.StockUsers.FirstOrDefault(it => it.MobileNumber == item.MobileNumber);
            if (dbUser != null)
            {
                throw new Exception("User Mobile Number is duplicated!!");
            }
            dbContext.StockUsers.Add(item);
            dbContext.SaveChanges();
            return item;
        }

        public void Delete(int id)
        {
            var item =   dbContext.StockUsers.Find(id);
            dbContext.Remove(item);
        }

        public StockUser Get(int id)
        {
            var item = dbContext.StockUsers.Find(id);
            return item;
        }

        public IEnumerable<StockUser> Get()
        {
            return dbContext.StockUsers;
        }

        public StockUser Update(StockUser item)
        {
            var dbItem = dbContext.StockUsers.Find(item.StockUserId);
            dbItem.FirstName = item.FirstName;
            dbItem.LastName = item.LastName;
            dbItem.MobileNumber = item.MobileNumber;
            dbItem.State = item.State;

            return item;
        }
       
    }
}
