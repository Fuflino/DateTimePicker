using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FriendsList.Repository
{
    interface IRepository<T, K>
    {
        void Create(T item);
        List<T> ReadAll();
        T Read(K id);
        void Update(T item);
        bool Delete(T item);
    }
}
