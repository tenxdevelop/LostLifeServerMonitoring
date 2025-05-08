/**************************************************************************\
    Copyright (C) 2024-2025 SkyForge Corporation. All Rights Reserved.
    Author: Stepan Myasnikov --> tenxdeveloper.
\**************************************************************************/

using LostLifeServerMonitoring.Application.Interfaces;

namespace LostLifeServerMonitoring.Application.Features.Player.Commands
{
    public class DisconnectionPlayerCommandHandler : ICommandHandler<CmdDisconnectionPlayer, bool>
    {
        private IServerInfoRepository m_serverInfoRepository;
        private IPlayerRepository m_playerRepository;

        public DisconnectionPlayerCommandHandler(IServerInfoRepository serverInfoRepository, IPlayerRepository playerRepository)
        {
            m_serverInfoRepository = serverInfoRepository;
            m_playerRepository = playerRepository;
        }
        
        public async Task<bool> Handle(CmdDisconnectionPlayer command)
        {
            var player = await m_playerRepository.GetPlayerById(command.Id);
            
            if (player is null)
                return false;
            
            if(string.IsNullOrEmpty(player.ServerInfoId))
                return false;
            
            var serverInfo = await m_serverInfoRepository.GetServerInfoById(int.Parse(player.ServerInfoId));
            
            serverInfo.PlayersInActive.Remove(player);
            serverInfo.CountPeopleInActive = serverInfo.PlayersInActive.Count;
            
            var result = await m_serverInfoRepository.UpdateServerInfo(serverInfo);

            if (result)
            {
                player.ServerInfoId = string.Empty;
                await m_playerRepository.UpdatePlayer(player);
            }
            
            return result;
        }
    }
}