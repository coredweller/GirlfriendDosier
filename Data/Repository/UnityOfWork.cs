using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core;
using Core.Infrastructure;
using Core.Helpers;

namespace Data.Repository
{
    public class UnitOfWork : DisposableResource, IUnitOfWork
    {
        private readonly IRelationshipsDatabase _database;
        private bool _isDisposed;

        public UnitOfWork(IRelationshipsDatabase database)
        {
            Checks.Argument.IsNotNull(database, "database");
            _database = database;
        }


        public UnitOfWork(IRelationshipsDatabaseFactory factory)
            : this(factory.Get())
        {
        }

        public virtual void Commit()
        {
            if (_isDisposed)
            {
                throw new ObjectDisposedException(GetType().Name);
            }
            
            _database.SubmitChanges();
        }

        protected override void Dispose(bool disposing)
        {
            if (!_isDisposed)
            {
                _isDisposed = true;
            }

            base.Dispose(disposing);
        }
    }
}
