using System.Threading.Tasks;

namespace TaskManager.DataAccess.Contracts;

public interface IUnitOfWork
{
    Task SaveChanges();
}
