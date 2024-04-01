using BlogPost.Application.Contracts.Persistence;
using BlogPost.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories;

public class RateRepository : GenericRepository<Rate>, IRateRepository
{
    private readonly RateDbContext _dbContext;

    public RateRepository(RateDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }
}

