﻿using DevFramework.Core.DataAccess;
using DevFramework.Core.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.Core.EntityFramework
{
    public class EfQueryableRepository<T> : IQuerableRepository<T> where T : class, IEntity, new()
    {
        private DbContext _context;
        private IDbSet<T> _entities;
        public EfQueryableRepository(DbContext context)
        {
            _context = context;
        }

        public IQueryable<T> Table => this.Entities;
        protected virtual IDbSet<T> Entities
        {
            get { return _entities ?? (_entities = _context.Set<T>());  }
        }
    }
}
