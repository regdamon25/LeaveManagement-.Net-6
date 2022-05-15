using AutoMapper;
using AutoMapper.QueryableExtensions;
using LeaveManagement.Web.Contracts;
using LeaveManagement.Web.Data;
using LeaveManagement.Web.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace LeaveManagement.Web.Repositories
{
    public class LeaveRequestRepository : GenericRepository<LeaveRequest>, ILeaveRequestRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly UserManager<Employee> _userManager;
        private readonly ILeaveAllocationRepository _leaveAllocationRepository;
        private readonly AutoMapper.IConfigurationProvider _configurationProvider;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public LeaveRequestRepository(ApplicationDbContext context,
                                      IMapper mapper,
                                      IHttpContextAccessor httpContextAccessor,
                                      UserManager<Employee> userManager,
                                      ILeaveAllocationRepository leaveAllocationRepository,
                                      AutoMapper.IConfigurationProvider configurationProvider) : base(context)
        {
            _context = context;
            _mapper = mapper;
            _userManager = userManager;
            _leaveAllocationRepository = leaveAllocationRepository;
            _configurationProvider = configurationProvider;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task CancelLeaveRequest(int leaveRequestId)
        {
            var leaveRequest = await GetAsync(leaveRequestId);
            leaveRequest.Cancelled = true;
            await UpdateAsync(leaveRequest);
        }

        public async Task ChangeApprovalStatus(int leaveRequestId, bool approved)
        {
            var leaveRequest = await GetAsync(leaveRequestId); //Getting the record that needs to be approved/rejected
            leaveRequest.Approved = approved;

            if(approved)
            {
                var allocation = await _leaveAllocationRepository.GetEmployeeAllocation(leaveRequest.RequestingEmployeeId, leaveRequest.LeaveTypeId); //Get Requesting employees current allocation amount
                int daysRequested = (int)(leaveRequest.EndDate - leaveRequest.StartDate).TotalDays; // Getting the amount of days requesting employees asked for
                allocation.NumberOfDays -= daysRequested;

                await _leaveAllocationRepository.UpdateAsync(allocation);

            }
            await UpdateAsync(leaveRequest);
        }

        public async Task<bool> CreateLeaveRequest(LeaveRequestCreateVM viewModel) //What happens when a leave request comes in
        {
            var user = await _userManager.GetUserAsync(_httpContextAccessor?.HttpContext?.User);

            var leaveAllocation = await _leaveAllocationRepository.GetEmployeeAllocation(user.Id, viewModel.LeaveTypeId);

            if (leaveAllocation == null)
            {
                return false;
            }

            int daysRequested = (int)(viewModel.EndDate.Value - viewModel.StartDate.Value).TotalDays;

            if (daysRequested > leaveAllocation.NumberOfDays)
            {
                return false;
            }

            var leaveRequest = _mapper.Map<LeaveRequest>(viewModel);
            leaveRequest.DateRequested = DateTime.Now;
            leaveRequest.RequestingEmployeeId = user.Id;

            await AddAsync(leaveRequest);

            return true;

        }

        public async Task<AdminLeaveRequestViewVM> GetAdminLeaveRequestList()
        {
            var leaveRequests = await _context.LeaveRequests.Include(q => q.LeaveType).ToListAsync(); //Get all the leave requests
            var viewModel = new AdminLeaveRequestViewVM
            {
                TotalRequests = leaveRequests.Count,
                ApprovedRequests = leaveRequests.Count(q => q.Approved == true), //Count() method acts like a where() 
                PendingRequests = leaveRequests.Count(q => q.Approved == null),
                RejectedRequests = leaveRequests.Count(q => q.Approved == false),
                LeaveRequests = _mapper.Map<List<LeaveRequestVM>>(leaveRequests),
            };

            foreach(var leaveRequest in viewModel.LeaveRequests)
            {
                leaveRequest.Employee = _mapper.Map<EmployeeListVM>(await _userManager.FindByIdAsync(leaveRequest.RequestingEmployeeId));
            }
            return viewModel;
        }

        public async Task<List<LeaveRequestVM>> GetAllAsync(string employeeId)
        {
            return await _context.LeaveRequests.Where(q => q.RequestingEmployeeId == employeeId)
                .ProjectTo<LeaveRequestVM>(_configurationProvider)
                .ToListAsync();
        }

        public async Task<LeaveRequestVM?> GetLeaveRequestAsync(int? id)
        {
            var leaveRequest = await _context.LeaveRequests
                .Include(q => q.LeaveType)
                .ProjectTo<LeaveRequestVM>(_configurationProvider)
                .FirstOrDefaultAsync(q => q.Id == id);

            if (leaveRequest == null)
            {
                return null;
            }

            var viewModel = leaveRequest;
            viewModel.Employee = _mapper.Map<EmployeeListVM>(await _userManager.FindByIdAsync(leaveRequest?.RequestingEmployeeId));
            return viewModel;
        }

        public async Task<EmployeeLeaveRequestViewVM> GetMyLeaveDetails()
        {
            var user = await _userManager.GetUserAsync(_httpContextAccessor?.HttpContext?.User); //This gets the employee who is trying to view the records
            var allocations = (await _leaveAllocationRepository.GetEmployeeAllocations(user.Id)).LeaveAllocations;
            var requests = await GetAllAsync(user.Id);
            var viewModel = new EmployeeLeaveRequestViewVM(allocations, requests);

            return viewModel;
        }
    }
}
