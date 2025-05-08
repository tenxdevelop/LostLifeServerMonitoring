/**************************************************************************\
    Copyright (C) 2024-2025 SkyForge Corporation. All Rights Reserved.
    Author: Stepan Myasnikov --> tenxdeveloper.
\**************************************************************************/

using LostLifeServerMonitoring.Application.Interfaces;

namespace LostLifeServerMonitoring.Application.Features.Player.Commands
{
    public class CmdConnectionPlayer : ICommand<bool>
    {
        public int PlayerId { get; private set; }
        public string? IpAddress { get; private set; }
        public string? Port { get; private set; }

        public CmdConnectionPlayer(int playerId, string? ipAddress, string? port)
        {
            PlayerId = playerId;
            IpAddress = ipAddress;
            Port = port;
        }
    }
}