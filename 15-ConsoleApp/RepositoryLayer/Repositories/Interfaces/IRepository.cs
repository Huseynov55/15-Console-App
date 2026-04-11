using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Repositories.Interfaces
{
    public interface IRepository<T>
    {
        void Create(T data);
        void Update(T data);
        void Delete(T data);
        T GetById(int id);
        
    }
}
