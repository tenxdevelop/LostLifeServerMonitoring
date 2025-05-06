/**************************************************************************\
    Copyright (C) 2024-2025 SkyForge Corporation. All Rights Reserved.
    Author: Stepan Myasnikov --> tenxdeveloper.
\**************************************************************************/

namespace LostLifeServerMonitoring.Application.Interfaces
{
    public interface ICommandProcessor
    {
        void RegisterHandler<TCommand, TResult>(ICommandHandler<TCommand, TResult> handler) where TCommand : ICommand<TResult>;
        
        Task<T> Process<T>(ICommand<T> command);
    }
}