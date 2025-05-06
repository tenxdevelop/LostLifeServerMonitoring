/**************************************************************************\
    Copyright (C) 2024-2025 SkyForge Corporation. All Rights Reserved.
    Author: Stepan Myasnikov --> tenxdeveloper.
\**************************************************************************/

using LostLifeServerMonitoring.Application.Interfaces;

namespace LostLifeServerMonitoring.Persistence.CommandProcessor
{
    public class CommandProcessor : ICommandProcessor
    {
        private Dictionary<Type, ICommandHandler> m_commandHandlers = new();
        
        public void RegisterHandler<TCommand, TResult>(ICommandHandler<TCommand, TResult> handler) where TCommand : ICommand<TResult>
        {
            var commandType = typeof(TCommand);
            
            if (!m_commandHandlers.ContainsKey(commandType))
            {
                m_commandHandlers.Add(commandType, handler);    
            }
        }

        public Task<T> Process<T>(ICommand<T> command)
        {
            var commandType = command.GetType();
            var handler = m_commandHandlers[commandType];
            
            return handler.BaseHandle(command);
        }
    }    
}

