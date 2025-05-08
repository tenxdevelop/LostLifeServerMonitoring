/**************************************************************************\
    Copyright (C) 2024-2025 SkyForge Corporation. All Rights Reserved.
    Author: Stepan Myasnikov --> tenxdeveloper.
\**************************************************************************/

using LostLifeServerMonitoring.Models;

namespace LostLifeServerMonitoring.Application.Interfaces
{
    public interface IPlayerRepository
    {
        Task<bool> CreatePlayer(int id);

        Task<Player> GetPlayerById(int id);
    }
}