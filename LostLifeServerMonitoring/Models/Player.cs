/**************************************************************************\
    Copyright (C) 2024-2025 SkyForge Corporation. All Rights Reserved.
    Author: Stepan Myasnikov --> tenxdeveloper.
\**************************************************************************/

namespace LostLifeServerMonitoring.Models
{
    [Serializable]
    public class Player
    {
        public int Id { get; set; }

        public string? ServerInfoId { get; set; }

        public override bool Equals(object? obj)
        {
            if(obj is not null && obj is Player player)
            {
                return Id.Equals(player.Id);
            }
            
            return false;
        }
    }
}