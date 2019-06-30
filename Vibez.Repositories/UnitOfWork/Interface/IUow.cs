using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vibez.Repositories.Repositories.Interface;

namespace Vibez.Repositories.UnitOfWork.Interface
{
    public interface IUow : IDisposable
    {
        IPostRepository Posts { get; }
        ICommentRepository Comments { get; }
        ICategoryRepository Categories { get; }        
        IImageRepository Images { get; }        
        void SaveChanges();
        void Dispose(bool disposing);
    }
}
