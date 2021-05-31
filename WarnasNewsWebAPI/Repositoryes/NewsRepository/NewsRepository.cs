using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WarnasNewsWebAPI.Data;
using WarnasNewsWebAPI.Models;

namespace WarnasNewsWebAPI.Repositoryes.NewsRepository
{
    public class NewsRepository : INewsRepository
    {
        private readonly AppDbContext Context;

        public NewsRepository(AppDbContext IncomingContext)
        {
            this.Context = IncomingContext;
        }

        /// <summary>
        /// This method Add element of News on DataBase
        /// </summary>
        public async Task Create(News InputNews)
        {
            Context.News.Add(InputNews);

            await Context.SaveChangesAsync();
        }

        /// <summary>
        /// This method Delete element of News from DataBase
        /// </summary>
        public async Task Delete(int id)
        {
            var OrderToDelate = Context.News.Find(id);

            Context.News.Remove(OrderToDelate);

            await Context.SaveChangesAsync();
        }

        /// <summary>
        /// This method show all elements of News on DataBase
        /// </summary>
        public async Task<IEnumerable<News>> GetAll()
        {
            return await Context.News.ToListAsync();
        }

        /// <summary>
        /// This method show element of News on DataBase by his Id 
        /// </summary>
        public async Task<News> Get(int id)
        {
            return await Context.News.FindAsync(id);
        }

        /// <summary>
        /// This method change element of News on DataBase
        /// </summary>
        public void Update(News InputNews)
        {
            Context.Entry(InputNews).State = EntityState.Modified;
            Context.SaveChanges();
        }

        public async Task<News> GetLastNews()
        {
            return await Context.News.LastAsync();
        }
    }
}
