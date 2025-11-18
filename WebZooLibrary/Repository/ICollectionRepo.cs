using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebZooLibrary.Repository
{
    public interface ICollectionRepo<T, Tkey>
    {
        public T Get(Tkey id);
        public List<T> GetAll();
        public void Add(T item);
        public void Remove(Tkey id);
        public void Edit(T item);




    }
}
