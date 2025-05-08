/**************************************************************************\
    Copyright (C) 2024-2025 SkyForge Corporation. All Rights Reserved.
    Author: Stepan Myasnikov --> tenxdeveloper.
\**************************************************************************/

using LostLifeServerMonitoring.Application.Interfaces;

namespace LostLifeServerMonitoring.Application.Features.ServerInfo.Commands
{
    public class CmdDeleteServerInfo : ICommand<bool>
    {
        public string? IpAddress { get; private set; }
        public string? Port { get; private set; }
        

        public CmdDeleteServerInfo(string? ipAddress, string? port)
        {
            IpAddress = ipAddress;
            Port = port;
        }
    }
    
}

