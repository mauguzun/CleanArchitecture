using System.Linq.Expressions;

namespace WebApp.Interfaces
{
    public interface IBackgoundJobService
    { 
        void Schedule<T>(Expression<Func<T, Task>> expression);
    }
}
