using Microsoft.Data.SqlClient;
using project1.Repositories;
using project1.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project1
{
    public class UnitOfWork : IUnitOfWork
    {
        private IDbConnection _connection;
        private IDbTransaction _transaction;

        private IUserRepository _userRepository;
        private IPostRepository _postRepository;
        private IRepliesRepository _repliesRepository;

        private bool _disposed;

        public UnitOfWork(SqlConnection connection,IDbTransaction transaction)
        {

            _connection = connection;
            _transaction = transaction;
        }

        public IUserRepository UserRepository
        {
            get
            {
                return _userRepository ?? (_userRepository = new UserRepository(_transaction));
            }
        }

        public IPostRepository PostRepository
        {
            get
            {
                return _postRepository ?? (_postRepository = new PostRepository(_transaction));
            }
        }

        public IRepliesRepository RepliesRepository
        {
            get
            {
                return _repliesRepository ?? (_repliesRepository = new RepliesRepository(_transaction));
            }
        }

        public IDbTransaction GetDbTransaction
        {
            get
            {
                return _transaction;
            }
        }


        private void resetRepositories()
        {
            _userRepository = null;
            _postRepository = null;
            _repliesRepository = null;
        }

        

        public void Commit()
        {
            try
            {
                _transaction.Commit();
            }
            catch
            {
                _transaction.Rollback();
                throw;
            }
            finally
            {
                _transaction.Dispose();
                _transaction = _connection.BeginTransaction();
                resetRepositories();
            }
        }

        public void Dispose()
        {
            dispose(true);
            GC.SuppressFinalize(this);
        }

        private void dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    if (_transaction != null)
                    {
                        _transaction.Dispose();
                        _transaction = null;
                    }
                    if (_connection != null)
                    {
                        _connection.Dispose();
                        _connection = null;
                    }
                }
                _disposed = true;
            }
        }

        ~UnitOfWork()
        {
            dispose(false);
        }


    }
}
