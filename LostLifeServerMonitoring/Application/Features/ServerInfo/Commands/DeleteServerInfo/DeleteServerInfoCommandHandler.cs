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
        private IPlayerRepository m_playerRepository;
        public DeleteServerInfoCommandHandler(IServerInfoRepository serverInfoRepository, IPlayerRepository playerRepository)
        {
            m_serverInfoRepository = serverInfoRepository;
            m_playerRepository = playerRepository;
        }
        
        public async Task<bool> Handle(CmdDeleteServerInfo command)
        {
            var deleteServerInfo = await m_serverInfoRepository.GetServerInfoBySocket(command.IpAddress, command.Port);
            
            if(deleteServerInfo is null)
                return false;

            var playersInActive = deleteServerInfo.PlayersInActive;
            
            var result = await m_serverInfoRepository.DeleteServerInfo(deleteServerInfo);
            
            if (result)
            {
                foreach (var player in playersInActive)
                {
                    player.ServerInfoId = string.Empty;
                    await m_playerRepository.UpdatePlayer(player);
                }
            }
            
            return result;
        }
    }    
}

