using System;
using System.Collections.Generic;
using System.Text;

namespace FX.Core.Bsse
{
    public interface IRepository<Item>
    {
        Item Get(int id);
        IEnumerable<Item> Get();
        Item Add(Item item);
        Item Update(Item item);
        void Delete(int id);
    }
}
