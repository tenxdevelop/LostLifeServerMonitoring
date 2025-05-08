/**************************************************************************\
    Copyright (C) 2024-2025 SkyForge Corporation. All Rights Reserved.
    Author: Stepan Myasnikov --> tenxdeveloper.
\**************************************************************************/

using LostLifeServerMonitoring.Application.Features.Player.Commands;
using LostLifeServerMonitoring.Controllers.Base;
using Microsoft.AspNetCore.Mvc;

namespace LostLifeServerMonitoring.Controllers
{
    [Route("api/[controller]/[action]")]
    public class PlayerController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> ConnectionPlayer([FromBody] CmdConnectionPlayer command)
        {
            var result = await CommandProcessor?.Process(command)!;
            
            return Ok(result);
        }
    }
}