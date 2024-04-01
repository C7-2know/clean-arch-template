using System;
using System.Threading.Tasks;
using BlogPost.Domain.Entities;

namespace BlogPost.Application.Contracts.Persistence;

public interface IUnitOfWork : IDisposable
{
    IRateRepository RateRepository { get; }
    Task Save();
}
