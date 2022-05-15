using AutoMapper;
using AutoMapper.QueryableExtensions;
using LeaveManagement.Common.Constants;
using LeaveManagement.Business.Contracts;
using LeaveManagement.Data;
using LeaveManagement.Common.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;

namespace LeaveManagement.Business.Repositories
{
    public class LeaveAllocationRepository : GenericRepository<LeaveAllocation>, ILeaveAllocationRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<Employee> _userManager;
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IMapper _mapper;
        private readonly AutoMapper.IConfigurationProvider _configurationProvider;
        private readonly IEmailSender _emailSender;

        public LeaveAllocationRepository(ApplicationDbContext context,
                                         UserManager<Employee> userManager,
                                         ILeaveTypeRepository leaveTypeRepository,
                                         IMapper mapper,
                                         AutoMapper.IConfigurationProvider configurationProvider,
                                         IEmailSender emailSender) : base(context)
                                    
        {
            _context = context;
            _userManager = userManager;
            _leaveTypeRepository = leaveTypeRepository;
            _mapper = mapper;
            _configurationProvider = configurationProvider;
            _emailSender = emailSender;
        }

        public async Task<bool> AllocationExists(string employeeId, int leaveTypeId, int period)
        {
            return await _context.LeaveAllocations.AnyAsync(q => q.EmployeeId == employeeId
            && q.LeaveTypeId == leaveTypeId
            && q.Period == period); 
        }

        public async Task<LeaveAllocationEditVM> GetEmployeeAllocation(int id)
        {
            //here we are fetching all the allocations associated with the given id, we are including the LeaveType and 
            var allocation = await _context.LeaveAllocations 
               .Include(q => q.LeaveType)
               .ProjectTo<LeaveAllocationEditVM>(_configurationProvider)
               .FirstOrDefaultAsync(q => q.Id == id);

            if (allocation == null)
            {
                return null;
            }

            var employee = await _userManager.FindByIdAsync(allocation.EmployeeId);

            var viewModel = allocation; //Used ProjectTo to eliminate the extra mapping of the data model to the viewmodel
            viewModel.Employee = _mapper.Map<EmployeeListVM>(await _userManager.FindByIdAsync(allocation.EmployeeId));

            return viewModel;
        }
        

        public async Task<EmployeeAllocationVM> GetEmployeeAllocations(string employeeId)
        {
            var allocations = await _context.LeaveAllocations //running query to get all the allocations
                .Include(q => q.LeaveType) //we included all the LeaveType details
                .Where(q => q.EmployeeId == employeeId)
                .ProjectTo<LeaveAllocationVM>(_configurationProvider)
                .ToListAsync(); // we are matching the database employee Id with the id given in the parameter


            var employee = await _userManager.FindByIdAsync(employeeId); // we are fetching the employees record

            var employeeAllocationViewModel = _mapper.Map<EmployeeAllocationVM>(employee); //here we are mapping the db model to the viewmodel 
            employeeAllocationViewModel.LeaveAllocations = allocations; //from the return viewmodel we can add on the allocation types
            return employeeAllocationViewModel;
        }

        public async Task LeaveAllocation(int leaveTypeId)
        {
            var employees = await _userManager.GetUsersInRoleAsync(Roles.User);
            var period = DateTime.Now.Year;
            var leaveType = await _leaveTypeRepository.GetAsync(leaveTypeId);
            var allocations = new List<LeaveAllocation>();
            var employeesWithNewAllocations = new List<Employee>();

            foreach (var employee in employees)
            {
                if (await AllocationExists(employee.Id, leaveTypeId, period))
                    continue;
                allocations.Add( new LeaveAllocation
                {
                    EmployeeId = employee.Id,
                    LeaveTypeId = leaveTypeId,
                    Period = period,
                    NumberOfDays = leaveType.DefaultDays
                });
                employeesWithNewAllocations.Add(employee);
            }

            await AddRangeAsync(allocations);

            foreach(var employee in employees)
            {
                

                await _emailSender.SendEmailAsync(employee.Email, $"Leave Allocation Posted for {period}", $"Your {leaveType.Name} " +
                    $"has been posted for the period of {period}. You have been given { leaveType.DefaultDays}.");
            }
        }

        public async Task<bool> UpdateEmployeeAllocation(LeaveAllocationEditVM viewModel)
        {
            var leaveAllocation = await GetAsync(viewModel.Id);
            // is the form valid
            if (leaveAllocation == null)
            {
                return false;
            }
            leaveAllocation.Period = viewModel.Period;
            leaveAllocation.NumberOfDays = viewModel.NumberOfDays;
            await UpdateAsync(leaveAllocation);

            return true;
        }

        public async Task<LeaveAllocation?> GetEmployeeAllocation(string employeeId, int leaveTypeId)
        {
            return await _context.LeaveAllocations.FirstOrDefaultAsync(q => q.EmployeeId == employeeId && q.LeaveTypeId == leaveTypeId);
        }
    }
}
