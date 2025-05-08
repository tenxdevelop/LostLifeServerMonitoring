/**************************************************************************\
    Copyright (C) 2024-2025 SkyForge Corporation. All Rights Reserved.
    Author: Stepan Myasnikov --> tenxdeveloper.
\**************************************************************************/

using LostLifeServerMonitoring.Application.Features.ServerInfo.Commands;
using LostLifeServerMonitoring.Application.Features.ServerInfo.Queries;
using LostLifeServerMonitoring.Controllers.Base;
using LostLifeServerMonitoring.Controllers.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace LostLifeServerMonitoring.Controllers
{
    [Route("api/[controller]/[action]")]
    public class ServerInfoController : BaseController
    {

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetAllServerInfoQuery();
            var serverInfos = await QueryProcessor.Send(query);
            var serverInfoViewModels = new List<ServerInfoViewModel>();
            
            foreach (var serverInfo in serverInfos)
            {
                var serverInfoViewModel = new ServerInfoViewModel()
                {
                    Description = serverInfo.Description,
                    Name = serverInfo.Name,
                    IpAddress = serverInfo.IpAddress,
                    Port = serverInfo.Port,
                    CountPeopleInActive = serverInfo.CountPeopleInActive,
                    MaxCountPeopleInActive = serverInfo.MaxCountPeopleInActive,
                };
                serverInfoViewModels.Add(serverInfoViewModel);
            }

            var serverInfoListViewModel = new ServerInfoListViewModel()
            {
                ServerInfos = serverInfoViewModels
            };
            
            return Ok(serverInfoListViewModel);
        }
        
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CmdCreateServerInfo command)
        {
            var result = await CommandProcessor?.Process(command)!;
            
            return Ok(result);
        }

        [HttpDelete("{socket}")]
        public async Task<IActionResult> Delete([FromRoute] string socket)
        {
            var ipAddress = socket.Split(':')[0];
            var port = socket.Split(':')[1];
            
            var command = new CmdDeleteServerInfo(ipAddress, port);
            
            var result = await CommandProcessor?.Process(command)!;
            
            return Ok(result);
        }
    }
}