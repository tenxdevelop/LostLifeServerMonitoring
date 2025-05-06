/**************************************************************************\
    Copyright (C) 2024-2025 SkyForge Corporation. All Rights Reserved.
    Author: Stepan Myasnikov --> tenxdeveloper.
\**************************************************************************/

namespace LostLifeServerMonitoring.Application.Interfaces
{
    public interface ICommandHandler
    {
        Task<TResult> BaseHandle<TResult>(ICommand<TResult> command);
    }
    
    public interface ICommandHandler<in TCommand, TResult> : ICommandHandler where TCommand : ICommand<TResult>
    {
        Task<TResult> Handle(TCommand command);

        Task<TResult1> ICommandHandler.BaseHandle<TResult1>(ICommand<TResult1> command)
        {
            return Handle((TCommand)command) as Task<TResult1>;
        }
    }
}