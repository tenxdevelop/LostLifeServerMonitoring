/**************************************************************************\
    Copyright (C) 2024-2025 SkyForge Corporation. All Rights Reserved.
    Author: Stepan Myasnikov --> tenxdeveloper.
\**************************************************************************/

using LostLifeServerMonitoring.Models;

namespace LostLifeServerMonitoring.Application.Interfaces
{
    public interface IServerInfoRepository
    {
        Task<List<ServerInfo>> GetAllServerInfo();

        Task<ServerInfo?> GetServerInfoBySocket(string ipAddress, string port);
        
        Task<ServerInfo?> GetServerInfoById(int id);
        
        Task<bool> CreateServerInfo(string ipAddress, string port, string name, string description, int maxCountPeopleInActive);

        Task<bool> DeleteServerInfo(ServerInfo serverInfo);
        
        Task<bool> UpdateServerInfo(ServerInfo serverInfo);
    }
}