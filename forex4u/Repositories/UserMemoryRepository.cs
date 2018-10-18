using System;
using System.Collections.Generic;
using System.Text;
using forex4u.Models;
using FX.Core.Entities;

namespace forex4u.Repositories
{
    public class UserMemoryRepository : IUserRepository
    {
        private static List<StockUser> userList = new List<StockUser>();
        private int maxId = 0;
        public UserMemoryRepository()
        {
            if (userList.Count == 0)
            {
                var initial = new[] {
                    new StockUser (){ FirstName = "ali",LastName="akbari",MobileNumber="09125462145",Email="al@mm.com",State=1},
                    new StockUser (){ FirstName = "akbar",LastName="sadeghi",MobileNumber="09125468875",Email="ss@mm.com",State=1},
                    new StockUser (){ FirstName = "jalil",LastName="montazeri",MobileNumber="09125464628",Email="ac@mm.com",State=1}
                };
                foreach (var item in initial)
                {
                    Add(item);
                }
            }
            
        }
        public StockUser Add(StockUser item)
        {
            item.StockUserId = ++maxId;
            userList.Add(item);
            return item;
        }

        public StockUser CheckAccount(string username, string password)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
           var item =  userList.Find(it => it.StockUserId == id);
            userList.Remove(item);
        }

        public StockUser Get(int id)
        {
            var item = userList.Find(it => it.StockUserId == id);
            return item;
        }

        public IEnumerable<StockUser> Get()
        {
            return userList;
        }

        public StockUser Update(StockUser item)
        {
            var memItem = userList.Find(it => it.StockUserId == item.StockUserId);
            memItem.FirstName = item.FirstName;
            memItem.LastName = item.LastName;
            memItem.MobileNumber = item.MobileNumber;
            memItem.State = item.State;

            return item;
        }
    }
}
