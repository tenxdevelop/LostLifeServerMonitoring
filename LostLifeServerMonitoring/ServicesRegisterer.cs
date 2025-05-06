/**************************************************************************\
    Copyright (C) 2024-2025 SkyForge Corporation. All Rights Reserved.
    Author: Stepan Myasnikov --> tenxdeveloper.
\**************************************************************************/

using LostLifeServerMonitoring.Persistence.JsonPrefs.Repositories;
using LostLifeServerMonitoring.Application.Interfaces;

namespace LostLifeServerMonitoring
{
    public static class ServicesRegisterer
    {
        public static void RegisterServices(IServiceCollection container)
        {
            container.AddSingleton<IServerInfoRepository, ServerInfoJsonPrefs>();
        }
    }
}