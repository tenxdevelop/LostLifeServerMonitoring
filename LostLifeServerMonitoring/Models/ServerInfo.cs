/**************************************************************************\
    Copyright (C) 2024-2025 SkyForge Corporation. All Rights Reserved.
    Author: Stepan Myasnikov --> tenxdeveloper.
\**************************************************************************/

namespace LostLifeServerMonitoring.Models
{
    [Serializable]
    public class ServerInfo
    {
        public int Id { get; set; }

        public string? Description { get; set; }
        public string? Name { get; set; }
        public string? IpAddress { get; set; }
        public string? Port { get; set; }
        
        public int CountPeopleInActive { get; set; }
        public int MaxCountPeopleInActive { get; set; }

    }
}