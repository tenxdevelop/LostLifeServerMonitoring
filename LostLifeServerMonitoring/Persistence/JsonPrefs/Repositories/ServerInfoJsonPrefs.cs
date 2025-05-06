/**************************************************************************\
    Copyright (C) 2024-2025 SkyForge Corporation. All Rights Reserved.
    Author: Stepan Myasnikov --> tenxdeveloper.
\**************************************************************************/

using System.Diagnostics;
using LostLifeServerMonitoring.Application.Interfaces;
using LostLifeServerMonitoring.Models;

namespace LostLifeServerMonitoring.Persistence.JsonPrefs.Repositories
{
    public class ServerInfoJsonPrefs: JsonPrefs<List<ServerInfo>>, IServerInfoRepository
    {
        private const string FILE_PATH = "./JsonPrefs/ServerInfos.json";
        
        private List<ServerInfo> m_serverInfos;
        
        public ServerInfoJsonPrefs() : base(FILE_PATH)
        {
            m_serverInfos = LoadFromJson();
        }

        public Task<List<ServerInfo>> GetAllServerInfo()
        {
            return Task.FromResult(m_serverInfos);
        }

        public Task<ServerInfo?> GetServerInfoBySocket(string ipAddress, string port)
        {
            var serverInfo = m_serverInfos.FirstOrDefault(serverInfo => serverInfo.IpAddress == ipAddress && serverInfo.Port == port);
            return Task.FromResult(serverInfo);
        }

        public Task<bool> CreateServerInfo(string ipAddress, string port, string name, string description, int maxCountPeopleInActive)
        {
            var newServerInfoId = GetNewId();

            var serverInfo = new ServerInfo()
            {
                Id = newServerInfoId,
                IpAddress = ipAddress,
                Port = port,
                Name = name,
                Description = description,
                CountPeopleInActive = 0,
                MaxCountPeopleInActive = maxCountPeopleInActive
            };
            m_serverInfos.Add(serverInfo);
            var result = SaveToJson(m_serverInfos);
            
            return Task.FromResult(result);
        }

        public Task<bool> DeleteServerInfo(ServerInfo serverInfo)
        {
            if (m_serverInfos.Contains(serverInfo))
            {
                m_serverInfos.Remove(serverInfo);
                var result = SaveToJson(m_serverInfos);
                return Task.FromResult(result);
            }
            
            return Task.FromResult(false);
        }

        private int GetNewId()
        {
            
            var lastId = m_serverInfos.Count();
            return lastId + 1;
        }
    }
}