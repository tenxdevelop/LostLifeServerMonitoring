/**************************************************************************\
    Copyright (C) 2024-2025 SkyForge Corporation. All Rights Reserved.
    Author: Stepan Myasnikov --> tenxdeveloper.
\**************************************************************************/

namespace LostLifeServerMonitoring.Controllers.ViewModel
{
    [Serializable]
    public class ServerInfoListViewModel
    {
        public List<ServerInfoViewModel> ServerInfos { get; set; }
    }
}