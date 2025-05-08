/**************************************************************************\
    Copyright (C) 2024-2025 SkyForge Corporation. All Rights Reserved.
    Author: Stepan Myasnikov --> tenxdeveloper.
\**************************************************************************/

using LostLifeServerMonitoring.Application.Interfaces;

namespace LostLifeServerMonitoring.Application.Features.Player.Commands
{
    public class ConnectionPlayerCommandHandler : ICommandHandler<CmdConnectionPlayer, bool>
    {
        private IServerInfoRepository m_serverInfoRepository;
        private IPlayerRepository m_playerRepository;
        public ConnectionPlayerCommandHandler(IServerInfoRepository serverInfoRepository, IPlayerRepository playerRepository)
        {
            m_serverInfoRepository = serverInfoRepository;
            m_playerRepository = playerRepository;
        }
        
        public async Task<bool> Handle(CmdConnectionPlayer command)
        {
            
            var player = await m_playerRepository.GetPlayerById(command.PlayerId);

            if (player is null)
            {
                var isCreatedPlayer = await m_playerRepository.CreatePlayer(command.PlayerId);
                
                if (!isCreatedPlayer)
                    return false;
                
                player = await m_playerRepository.GetPlayerById(command.PlayerId);
            }

            if (!string.IsNullOrEmpty(player.ServerInfoId))
                return false;
            
            var serverInfo = await m_serverInfoRepository.GetServerInfoBySocket(command.IpAddress, command.Port);
            
            if (serverInfo is null)
                return false;
            
            if(serverInfo.CountPeopleInActive >= serverInfo.MaxCountPeopleInActive)
                return false;
            
            player.ServerInfoId = serverInfo.Id.ToString();
            
            serverInfo.PlayersInActive.Add(player);
            serverInfo.CountPeopleInActive = serverInfo.PlayersInActive.Count;
            
            var result = await m_serverInfoRepository.UpdateServerInfo(serverInfo);

            if (result)
            {
                result = await m_playerRepository.UpdatePlayer(player);
            }
            
            return result;
        }
    }
}