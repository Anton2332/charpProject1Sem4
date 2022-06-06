using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project1.Repositories.Interface
{
    public interface IUnitOfWork : IDisposable
    {
        public IUserRepository UserRepository { get; }

        public IPostRepository PostRepository { get; }

        public IRepliesRepository RepliesRepository { get; }
        void Commit();
    }
}
