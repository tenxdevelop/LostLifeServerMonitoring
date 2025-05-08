/**************************************************************************\
    Copyright (C) 2024-2025 SkyForge Corporation. All Rights Reserved.
    Author: Stepan Myasnikov --> tenxdeveloper.
\**************************************************************************/

using LostLifeServerMonitoring.Application.Interfaces;
using LostLifeServerMonitoring.Models;

namespace LostLifeServerMonitoring.Persistence.JsonPrefs.Repositories
{
    public class PlayerJsonPrefs : JsonPrefs<List<Player>>, IPlayerRepository
    {
        private const string FILE_PATH = "./JsonPrefs/Players.json";
        
        public PlayerJsonPrefs() : base(FILE_PATH)
        {
            
        }

        public Task<bool> CreatePlayer(int id)
        {
            var player = new Player()
            {
                Id = id,
            };

            var oldStateModel = LoadFromJson();
            
            model.Add(player);

            var result = SaveToJson(model);

            if (!result)
            {
                model = oldStateModel;
            }
            
            return Task.FromResult(result);
        }

        public Task<Player> GetPlayerById(int id)
        {
            var player = model.FirstOrDefault(playerParam => playerParam.Id == id);
            return Task.FromResult(player);
        }

        public Task<bool> UpdatePlayer(Player player)
        {
            var oldStateModel = LoadFromJson();
            var oldPlayer = oldStateModel.FirstOrDefault(oldPlayerParam => oldPlayerParam.Id == player.Id);
            
            if (oldPlayer is null)
                Task.FromResult(false);

            var result = SaveToJson(model);
           
            if(!result)
                model = oldStateModel;
            
            return Task.FromResult(result);
        }
    }
}