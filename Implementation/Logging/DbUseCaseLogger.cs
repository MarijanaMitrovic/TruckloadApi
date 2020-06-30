using Application;
using DataAccess;
using Newtonsoft.Json;
using System;

using System.Collections.Generic;
using System.Text;

namespace Implementation.Logging
{
    public class DbUseCaseLogger : IUseCaseLogger
    {
        private readonly TruckloadContext context;

        public DbUseCaseLogger(TruckloadContext context)
        {
            this.context = context;
        }


        public void Log(IUseCase useCase, IApplicationActor actor, object useCaseData)
        {
            context.UseCaseLogs.Add(new Domain.UseCaseLog
            {
                Actor = actor.Identity,
                Data = JsonConvert.SerializeObject(useCaseData),
                
                Date = DateTime.UtcNow,
                UseCaseName = useCase.Name
            });

            context.SaveChanges();
        }
    }
}

