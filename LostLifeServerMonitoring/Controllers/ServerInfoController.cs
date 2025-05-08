/**************************************************************************\
    Copyright (C) 2024-2025 SkyForge Corporation. All Rights Reserved.
    Author: Stepan Myasnikov --> tenxdeveloper.
\**************************************************************************/

using LostLifeServerMonitoring.Application.Features.ServerInfo.Commands;
using LostLifeServerMonitoring.Controllers.Base;
using Microsoft.AspNetCore.Mvc;

namespace LostLifeServerMonitoring.Controllers
{
    [Route("api/[controller]/[action]")]
    public class ServerInfoController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CmdCreateServerInfo command)
        {
            var result = await CommandProcessor?.Process(command)!;
            
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] CmdDeleteServerInfo command)
        {
            var result = await CommandProcessor?.Process(command)!;
            
            return Ok(result);
        }
    }
}