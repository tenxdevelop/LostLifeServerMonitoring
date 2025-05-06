/**************************************************************************\
    Copyright (C) 2024-2025 SkyForge Corporation. All Rights Reserved.
    Author: Stepan Myasnikov --> tenxdeveloper.
\**************************************************************************/

namespace LostLifeServerMonitoring.Application.Interfaces
{
    public interface ICommandHandler
    {
        
    }
    
    public interface ICommandHandler<TCommand, TResult> : ICommandHandler where TCommand : ICommand<TResult>
    {
        Task<TResult> Handle(TCommand command);
    }
}