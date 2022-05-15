using LeaveManagement.Data;
using LeaveManagement.Business.Contracts;

namespace LeaveManagement.Business.Repositories
{
    public class LeaveTypeRepository : GenericRepository<LeaveType>, ILeaveTypeRepository
    {
        private readonly ApplicationDbContext _context;

        public LeaveTypeRepository(ApplicationDbContext context) : base(context)
        {
        }


    }
}
