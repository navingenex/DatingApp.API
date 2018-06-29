using System.Collections.Generic;
using System.Threading.Tasks;
using DatingApp.API.models;

namespace DatingApp.API.Data
{
    public interface IdatingRepository
    {
        void Add<T>(T entity) where T : class;
        void Delete<T>(T entity) where T:class;
        Task <bool> SavedAll();
        Task<IEnumerable<User>> GetUsers();
        Task<User> GetUser(int id);

    }
}