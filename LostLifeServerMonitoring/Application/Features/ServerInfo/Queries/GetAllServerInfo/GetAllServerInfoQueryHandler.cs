/**************************************************************************\
    Copyright (C) 2024-2025 SkyForge Corporation. All Rights Reserved.
    Author: Stepan Myasnikov --> tenxdeveloper.
\**************************************************************************/

using LostLifeServerMonitoring.Application.Interfaces;

namespace LostLifeServerMonitoring.Application.Features.ServerInfo.Queries
{
    public class GetAllServerInfoQueryHandler : IQueryHandler<GetAllServerInfoQuery, List<Models.ServerInfo>>
    {
        private IServerInfoRepository m_serverInfoRepository;

        public GetAllServerInfoQueryHandler(IServerInfoRepository serverInfoRepository)
        {
            m_serverInfoRepository = serverInfoRepository;    
        }
        
        public async Task<List<Models.ServerInfo>> Handle(GetAllServerInfoQuery query)
        {
            var serverInfos = await m_serverInfoRepository.GetAllServerInfo();
            return serverInfos;
        }
    }    
}

