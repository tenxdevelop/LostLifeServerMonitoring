/**************************************************************************\
    Copyright (C) 2024-2025 SkyForge Corporation. All Rights Reserved.
    Author: Stepan Myasnikov --> tenxdeveloper.
\**************************************************************************/

using LostLifeServerMonitoring.Application.Interfaces;

namespace LostLifeServerMonitoring.Application.Features.ServerInfo.Commands
{
    public class DeleteServerInfoCommandHandler : ICommandHandler<CmdDeleteServerInfo, bool>
    {
        private IServerInfoRepository m_serverInfoRepository;

        public DeleteServerInfoCommandHandler(IServerInfoRepository serverInfoRepository)
        {
            m_serverInfoRepository = serverInfoRepository;
        }
        
        public async Task<bool> Handle(CmdDeleteServerInfo command)
        {
            var deleteServerInfo = await m_serverInfoRepository.GetServerInfoBySocket(command.IpAddress, command.Port);
            
            var result = await m_serverInfoRepository.DeleteServerInfo(deleteServerInfo);
            return result;
        }
    }    
}

