using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Netflix.DAL.Repository.Abstract
{
    internal interface IGenaricRepo<T>
    {
        public void Add(T entitiy);
        public void Delete(T entitiy); // Shadow Delete
        public void Remove(T entitiy); //Soft Delate
        public void Update(T entitiy);  
        public T Get(T entitiy);    
        public ICollection<T> GetAll();
    }
}
