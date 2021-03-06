﻿using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Storage;

namespace Asdf.Users.Services.Contexts
{
    public class EntityFrameworkAccelerator : IDataAccelerator
    {
        private ApplicationContext _context;

        public ApplicationContext Context
        {
            get => _context;
            private set => _context = value;
        }

        public EntityFrameworkAccelerator(ApplicationContext context)
        {
            this.Context = context;
        }

        public IDbContextTransaction BeginTransaction()
        {
            return this.Context.Database.BeginTransaction();
        }

        public void SaveChanges()
        {
            this.Context.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await this.Context.SaveChangesAsync();
        }
    }
}