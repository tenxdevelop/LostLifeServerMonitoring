/**************************************************************************\
    Copyright (C) 2024-2025 SkyForge Corporation. All Rights Reserved.
    Author: Stepan Myasnikov --> tenxdeveloper.
\**************************************************************************/

using LostLifeServerMonitoring.Application.Interfaces;

namespace LostLifeServerMonitoring.Application.Features.ServerInfo.Commands
{
    public class CmdCreateServerInfo : ICommand<bool>
    {
        public string? IpAddress { get; private set; }
        public string? Port { get; private set; }
        
        public string? Name { get; private set; }
        public string? Description { get; private set; }

        public int MaxCountPeopleInActive { get; private set; }
        
        public CmdCreateServerInfo(string? ipAddress, string? port, string? name, string? description, int maxCountPeopleInActive)
        {
            IpAddress = ipAddress;
            Port = port;
            
            Name = name;
            Description = description;
            
            MaxCountPeopleInActive = maxCountPeopleInActive;
        }
    }
}