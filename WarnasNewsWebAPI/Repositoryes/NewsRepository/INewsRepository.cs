using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WarnasNewsWebAPI.Models;

namespace WarnasNewsWebAPI.Repositoryes.NewsRepository
{
    public interface INewsRepository
    {
        Task<IEnumerable<News>> GetAll();

        Task<News> Get(int id);

        Task<News> GetLastNews();

        Task Create(News order);

        void Update(News order);

        Task Delete(int id);
    }
}
