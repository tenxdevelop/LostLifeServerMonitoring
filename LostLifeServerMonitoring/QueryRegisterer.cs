/**************************************************************************\
    Copyright (C) 2024-2025 SkyForge Corporation. All Rights Reserved.
    Author: Stepan Myasnikov --> tenxdeveloper.
\**************************************************************************/

using LostLifeServerMonitoring.Application.Features.ServerInfo.Queries;
using LostLifeServerMonitoring.Application.Interfaces;
using LostLifeServerMonitoring.Persistence;

namespace LostLifeServerMonitoring
{
    public static class QueryRegisterer
    {
        public static void RegisterQueryHandlers(IServiceCollection container)
        {
            container.AddSingleton<IQueryProcessor>(factory =>
            {
                var queryProcessor = new QueryProcessor();
                
                queryProcessor.RegisterQueryHandler(new GetAllServerInfoQueryHandler(factory.GetService<IServerInfoRepository>()));
                
                return queryProcessor;
            });
        }
    }
}