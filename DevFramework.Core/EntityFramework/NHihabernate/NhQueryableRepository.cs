﻿using DevFramework.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.Core.EntityFramework.NHihabernate
{
    public class NhQueryableRepository<T> where T:class,IEntity,new()
    {
        private NHibernateHelper _nHibernateHelper;
        private IQueryable<T> _entities;


        private NhQueryableRepository(NHibernateHelper nHibernateHelper)
        {
            _nHibernateHelper = nHibernateHelper;
        }
        public IQueryable<T> Table { get;  }
        public IQueryable<T> Table { get
            {
                return this.Entities;
            } 
        }

        public virtual IQueryable<T> Entities {
            get
            {
                if(_entities==null)
                {
                    _entities = _nHibernateHelper.OpenSession().Query<T>();
                }
                return _entities;
            }
        
                
        }
    }
}
