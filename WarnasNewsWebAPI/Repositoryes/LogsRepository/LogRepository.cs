using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WarnasNewsWebAPI.Data;
using WarnasNewsWebAPI.Models;

namespace WarnasNewsWebAPI.Repositoryes.LogsRepository
{
    public class LogRepository : ILogRepository
    {
        private readonly AppDbContext Context;

        public LogRepository(AppDbContext IncomingContext)
        {
            this.Context = IncomingContext;
        }

        /// <summary>
        /// This method Add element of Log on DataBase
        /// </summary>
        public async Task Create(Log InputLog)
        {
            Context.Logs.Add(InputLog);

            await Context.SaveChangesAsync();
        }

        /// <summary>
        /// This method Delete element of Log from DataBase
        /// </summary>
        public async Task Delete(int id)
        {
            var OrderToDelate = Context.Logs.Find(id);

            Context.Logs.Remove(OrderToDelate);

            await Context.SaveChangesAsync();
        }

        /// <summary>
        /// This method show all elements of Log on DataBase
        /// </summary>
        public async Task<IEnumerable<Log>> GetAll()
        {
            return await Context.Logs.ToListAsync();
        }

        /// <summary>
        /// This method show element of Log on DataBase by his Id 
        /// </summary>
        public async Task<Log> Get(int id)
        {
            return await Context.Logs.FindAsync(id);
        }

        /// <summary>
        /// This method change element of Log on DataBase
        /// </summary>
        public void Update(Log InputLog)
        {
            Context.Entry(InputLog).State = EntityState.Modified;
            Context.SaveChanges();
        }
    }
}
