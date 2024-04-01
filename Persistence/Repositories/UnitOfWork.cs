using AutoMapper;
using BlogPost.Application.Contracts.Persistence;
using Microsoft.AspNetCore.Http;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Persistence.Repositories;
public class UnitOfWork : IUnitOfWork
{

    private readonly RateDbContext _context;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private IRateRepository _RateRepository;


    public UnitOfWork(RateDbContext context, IHttpContextAccessor httpContextAccessor)
    {
        _context = context;
        this._httpContextAccessor = httpContextAccessor;
    }

    

    public IRateRepository RateRepository => 
        _RateRepository ??= new RateRepository(_context);
    
    public void Dispose()
    {
        _context.Dispose();
        GC.SuppressFinalize(this);
    }

    public async Task Save() 
    {
        // var username = _httpContextAccessor.HttpContext.User.FindFirst(CustomClaimTypes.Uid)?.Value;

        // await _context.SaveChangesAsync(username);
    }
}

