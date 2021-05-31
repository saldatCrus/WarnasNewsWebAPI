using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WarnasNewsWebAPI.Repositoryes.LogsRepository;
using WarnasNewsWebAPI.Repositoryes.NewsRepository;
using WarnasNewsWebAPI.Models;
using WarnasNewsWebAPI.Services;

namespace WarnasNewsWebAPI.Controllers
{
    [ApiController]
    [Route(template: "/api/news")]
    public class NewsController : ControllerBase
    {
        private readonly INewsRepository inewsRepository;

        private readonly ILogRepository iLogRepository;

        private readonly ILogger<LogsController> iLogger;

        public NewsController(INewsRepository InputINewsRepository, ILogRepository InputIlogRepository, ILogger<LogsController> Inputlogger)
        {
            inewsRepository = InputINewsRepository;

            iLogRepository = InputIlogRepository;

            iLogger = Inputlogger;
        }

        /// <summary>
        /// Отправить все заказы которые были сделаны
        /// </summary>
        [HttpGet("getallnews")]
        public async Task<List<News>> GetAllNews()
        {
            try
            {
                return (await inewsRepository.GetAll()).ToList();
            }
            catch (Exception ERROR)
            {
                var loger = new Loger(iLogRepository);

                await loger.DbExeptionHandler(iLogger, ERROR);

                await loger.FileExeptionHandler(ERROR);
            }

            return null;
        }

        [HttpGet("getlastnews")]
        public async Task<News> GetLastNews()
        {
            try
            {
                return await inewsRepository.GetLastNews();
            }
            catch (Exception ERROR)
            {
                var loger = new Loger(iLogRepository);

                await loger.DbExeptionHandler(iLogger, ERROR);

                await loger.FileExeptionHandler(ERROR);
            }

            return null;
        }

        [HttpGet("checkfreshnews")]
        public async Task<bool> CheckFreshNews(int id)
        {
            try
            {
               if(id == inewsRepository.GetLastNews().Id) 
               {
                    return true;
               }
            }
            catch (Exception ERROR)
            {
                var loger = new Loger(iLogRepository);

                await loger.DbExeptionHandler(iLogger, ERROR);

                await loger.FileExeptionHandler(ERROR);
            }

            return false;
        }

        [HttpPost("addnews")]
        public async Task AddNews(object Json)
        {
            try
            {
                await inewsRepository.Create(Newtonsoft.Json.JsonConvert.DeserializeObject<News>(Json.ToString()));
            }
            catch (Exception ERROR)
            {
                var loger = new Loger(iLogRepository);

                await loger.DbExeptionHandler(iLogger, ERROR);

                await loger.FileExeptionHandler(ERROR);
            }
        }
    }
}
