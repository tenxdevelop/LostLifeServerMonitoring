/**************************************************************************\
    Copyright (C) 2024-2025 SkyForge Corporation. All Rights Reserved.
    Author: Stepan Myasnikov --> tenxdeveloper.
\**************************************************************************/

namespace LostLifeServerMonitoring.Application.Interfaces
{
    public interface IQueryHandler
    {
        Task<TResult> BaseHandle<TResult>(IQuery<TResult> query);
    }
    
    public interface IQueryHandler<TQuery, TResult> : IQueryHandler where TQuery : IQuery<TResult>
    {
        Task<TResult> Handle(TQuery query);

        Task<TResult1> IQueryHandler.BaseHandle<TResult1>(IQuery<TResult1> query)
        {
            return Handle((TQuery)query) as Task<TResult1>;
        }
    }
}