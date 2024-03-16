using _01_Framework.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace MB.Infrastructure.EFCore
{
    public class UnitofWorkEf:IUnitofWork
    {
        private readonly MasterBloggerContext _context;

        public UnitofWorkEf(MasterBloggerContext context)
        {
            _context = context;
        }
        public void BeginTran()
        {
            _context.Database.BeginTransaction();
        }

        public void CommitTran()
        {
            _context.SaveChanges();
            _context.Database.CommitTransaction();
        }

        public void RollBackTran()
        {
            _context.Database.RollbackTransaction();
        }
    }
}
