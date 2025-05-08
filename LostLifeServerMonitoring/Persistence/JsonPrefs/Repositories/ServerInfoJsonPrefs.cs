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
        
        public ServerInfoJsonPrefs() : base(FILE_PATH)
        {
            
        }

        public Task<List<ServerInfo>> GetAllServerInfo()
        {
            return Task.FromResult(model);
        }

        public Task<ServerInfo?> GetServerInfoBySocket(string ipAddress, string port)
        {
            var serverInfo = model.FirstOrDefault(serverInfo => serverInfo.IpAddress == ipAddress && serverInfo.Port == port);
            
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
            
            var oldStateModel = LoadFromJson();
            
            model.Add(serverInfo);
            
            var result = SaveToJson(model);

            if (!result)
            {
                model = oldStateModel;
            }
            
            return Task.FromResult(result);
        }

        public Task<bool> DeleteServerInfo(ServerInfo serverInfo)
        {
            
            if (model.Contains(serverInfo))
            {
                model.Remove(serverInfo);
                var result = SaveToJson(model);
                return Task.FromResult(result);
            }
            
            return Task.FromResult(false);
        }

        public Task<bool> UpdateServerInfo(ServerInfo serverInfo)
        {
            var oldStateModel = LoadFromJson();
            var oldServerInfo = oldStateModel.FirstOrDefault(oldServerInfoParam => oldServerInfoParam.Id == serverInfo.Id);
            
            if (oldServerInfo is null)
                return Task.FromResult(false);

            var result = SaveToJson(model);
            
            if (!result)
            {
                model = oldStateModel;
            }

            return Task.FromResult(result);
        }

        private int GetNewId()
        {
            
            var lastId = model.Count();
            return lastId + 1;
        }
    }
}