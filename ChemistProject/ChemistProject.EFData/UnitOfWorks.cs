using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChemistProject.DALInterfaces;

namespace ChemistProject.EFData
{
    public class UnitOfWorks : IUnitOfWork
    {
        private readonly ChemistContext _context;
        private readonly DbContextTransaction _transaction;
        private bool _isTransactionActive;
        private bool _disposed;

        public UnitOfWorks(ChemistContext context)
        {
            _context = context;
            _transaction = _context.Database.BeginTransaction();
            _isTransactionActive = true;
        }

        public void Commit()
        {
            try
            {
                if (_isTransactionActive && !_disposed)
                {
                    _context.SaveChanges();
                    _transaction.Commit();
                    _isTransactionActive = false;
                }
            }
            catch (Exception e)
            {
                _transaction.Rollback();
                _isTransactionActive = false;
                throw;
            }
        }

        public void PreSave()
        {
            _context.SaveChanges();
        }

        public void Rollback()
        {
            if (_isTransactionActive && !_disposed)
            {
                _transaction.Rollback();
                _isTransactionActive = false;
            }
        }

        public void Dispose()
        {
            if (_isTransactionActive)
            {
                try
                {
                    _context.SaveChanges();
                    _transaction.Commit();
                    _isTransactionActive = false;
                }
                catch (Exception e)
                {
                    _transaction.Rollback();
                    _isTransactionActive = false;
                    _context.Dispose();
                    _disposed = true;
                    throw;
                }
            }
        }
    }
}
