using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WarnasNewsWebAPI.Repositoryes.LogsRepository;
using WarnasNewsWebAPI.Repositoryes.NewsRepository;

namespace WarnasNewsWebAPI.Controllers
{
    [ApiController]
    [Route(template: "/api/logs")]
    public class LogsController: ControllerBase
    {
        private readonly INewsRepository inewsRepository;

        private readonly ILogRepository iLogRepository;

        private readonly ILogger<LogsController> iLogger;

        public LogsController(INewsRepository InputINewsRepository, ILogRepository InputIlogRepository, ILogger<LogsController> Inputlogger)
        {
            inewsRepository = InputINewsRepository;

            iLogRepository = InputIlogRepository;

            iLogger = Inputlogger;
        }

    }
}
