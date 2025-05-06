/**************************************************************************\
    Copyright (C) 2024-2025 SkyForge Corporation. All Rights Reserved.
    Author: Stepan Myasnikov --> tenxdeveloper.
\**************************************************************************/

using LostLifeServerMonitoring.Application.Interfaces;

namespace LostLifeServerMonitoring.Application.Features.ServerInfo.Commands
{
    public class CreateServerInfoCommandHandler : ICommandHandler<CmdCreateServerInfo, bool>
    {
        private IServerInfoRepository m_serverInfoRepository;

        public CreateServerInfoCommandHandler(IServerInfoRepository serverInfoRepository)
        {
            m_serverInfoRepository = serverInfoRepository;
        }
        
        public async Task<bool> Handle(CmdCreateServerInfo command)
        {
            var result = await m_serverInfoRepository.CreateServerInfo(command.IpAddress, command.Port, command.Name, command.Description, command.MaxCountPeopleInActive);
            return result;
        }
    }
}