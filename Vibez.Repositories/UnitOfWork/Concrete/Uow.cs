using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vibez.Domain.Context;
using Vibez.Repositories.Repositories.Concrete;
using Vibez.Repositories.Repositories.Interface;
using Vibez.Repositories.UnitOfWork.Interface;

namespace Vibez.Repositories.UnitOfWork.Concrete
{
    public class Uow : IUow
    {
        private VibezContext _context;
        private bool disposed = false;

        public Uow()
        {
            _context = new VibezContext();
        }
        public IPostRepository Posts
        {
            get
            {
                return new PostRepository(_context);
            }
        }

        public ICommentRepository Comments
        {
            get
            {
                return new CommentRepository(_context);
            }
        }

        public ICategoryRepository Categories
        {
            get
            {
                return new CategoryRepository(_context);
            }
        }

        public IImageRepository Images
        {
            get
            {
                return new ImageRepository(_context);
            }
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
