
using System.Collections.Generic;

namespace Library.Models
{ 
   
        public interface IRepo<TEntity>
        {
            void Create(TEntity user);
            void Delete(int id);
            TEntity Get(int id);
            List<TEntity> GetAll();
            void Update(TEntity user);

        }
}