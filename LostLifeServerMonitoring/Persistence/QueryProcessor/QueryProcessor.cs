/**************************************************************************\
    Copyright (C) 2024-2025 SkyForge Corporation. All Rights Reserved.
    Author: Stepan Myasnikov --> tenxdeveloper.
\**************************************************************************/

using LostLifeServerMonitoring.Application.Interfaces;

namespace LostLifeServerMonitoring.Persistence
{
    public class QueryProcessor : IQueryProcessor
    {
        private Dictionary<Type, IQueryHandler> m_queryHandlers = new();
        
        public void RegisterQueryHandler<TQuery, TResult>(IQueryHandler<TQuery, TResult> handler) where TQuery : IQuery<TResult>
        {
            var handlerType = typeof(TQuery);
            
            if (!m_queryHandlers.ContainsKey(handlerType))
            {
                m_queryHandlers.Add(handlerType, handler);
            }
        }

        public Task<TResult> Send<TResult>(IQuery<TResult> query)
        {
            var handlerType = query.GetType();
            
            if (m_queryHandlers.ContainsKey(handlerType))
            {
                var handler = m_queryHandlers[handlerType];
                return handler.BaseHandle(query);
            }

            return Task.FromResult(default(TResult));
        }
    }
}