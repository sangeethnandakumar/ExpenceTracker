﻿using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.AppDBContext
{
    public interface IAppDBContext
    {
        public DbSet<Entry> Entries { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
