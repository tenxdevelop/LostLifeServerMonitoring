/**************************************************************************\
    Copyright (C) 2024-2025 SkyForge Corporation. All Rights Reserved.
    Author: Stepan Myasnikov --> tenxdeveloper.
\**************************************************************************/

using LostLifeServerMonitoring.Application.Features.ServerInfo.Commands;
using LostLifeServerMonitoring.Application.Features.Player.Commands;
using LostLifeServerMonitoring.Persistence.CommandProcessor;
using LostLifeServerMonitoring.Application.Interfaces;

namespace LostLifeServerMonitoring
{
    public static class CommandRegisterer
    {
        public static void RegisterCommandHandlers(IServiceCollection container)
        {
            container.AddSingleton<ICommandProcessor>(factory =>
            {
                var commandProcessor = new CommandProcessor();
                
                commandProcessor.RegisterHandler(new CreateServerInfoCommandHandler(factory.GetService<IServerInfoRepository>()));
                commandProcessor.RegisterHandler(new DeleteServerInfoCommandHandler(factory.GetService<IServerInfoRepository>(), factory.GetService<IPlayerRepository>()));
                commandProcessor.RegisterHandler(new ConnectionPlayerCommandHandler(factory.GetService<IServerInfoRepository>(), factory.GetService<IPlayerRepository>()));
                commandProcessor.RegisterHandler(new DisconnectionPlayerCommandHandler(factory.GetService<IServerInfoRepository>(), factory.GetService<IPlayerRepository>()));
                
                return commandProcessor;
            });
        }
    }
}