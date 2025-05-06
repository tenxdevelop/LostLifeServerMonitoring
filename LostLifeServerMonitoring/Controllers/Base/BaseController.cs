/**************************************************************************\
    Copyright (C) 2024-2025 SkyForge Corporation. All Rights Reserved.
    Author: Stepan Myasnikov --> tenxdeveloper.
\**************************************************************************/

using LostLifeServerMonitoring.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LostLifeServerMonitoring.Controllers.Base
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class BaseController : ControllerBase
    {
        protected ICommandProcessor? CommandProcessor => m_commandProcessor ??= HttpContext.RequestServices.GetService<ICommandProcessor>();
        
        private ICommandProcessor? m_commandProcessor;
    }
}