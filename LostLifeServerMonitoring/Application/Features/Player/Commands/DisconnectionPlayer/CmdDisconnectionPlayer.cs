/**************************************************************************\
    Copyright (C) 2024-2025 SkyForge Corporation. All Rights Reserved.
    Author: Stepan Myasnikov --> tenxdeveloper.
\**************************************************************************/

using LostLifeServerMonitoring.Application.Interfaces;

namespace LostLifeServerMonitoring.Application.Features.Player.Commands
{
    public class CmdDisconnectionPlayer : ICommand<bool>
    {
        public int Id { get; private set; }

        public CmdDisconnectionPlayer(int id)
        {
            Id = id;
        }
    }
}