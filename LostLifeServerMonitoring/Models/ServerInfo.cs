/**************************************************************************\
    Copyright (C) 2024-2025 SkyForge Corporation. All Rights Reserved.
    Author: Stepan Myasnikov --> tenxdeveloper.
\**************************************************************************/

namespace LostLifeServerMonitoring.Models
{
    [Serializable]
    public class ServerInfo
    {
        public int Id;
        
        public string? Description;
        public string? Name;
        public string? IpAddress;
        public string? Port;
        
        public int CountPeopleInActive;
        public int MaxCountPeopleInActive;

    }
}