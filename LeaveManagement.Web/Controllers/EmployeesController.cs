using AutoMapper;
using LeaveManagement.Common.Constants;
using LeaveManagement.Business.Contracts;
using LeaveManagement.Data;
using LeaveManagement.Common.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LeaveManagement.Web.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly UserManager<Employee> _userManager;
        private readonly IMapper _mapper;
        private readonly ILeaveAllocationRepository _leaveAllocationRepository;
        private readonly ILeaveTypeRepository _leaveTypeRepository;

        public EmployeesController(UserManager<Employee> userManager,
                                   IMapper mapper,
                                   ILeaveAllocationRepository leaveAllocationRepository,
                                   ILeaveTypeRepository leaveTypeRepository)
        {
            _userManager = userManager;
            _mapper = mapper;
            _leaveAllocationRepository = leaveAllocationRepository;
            _leaveTypeRepository = leaveTypeRepository;
        }
        // GET: EmployeesController
        public async Task<IActionResult> Index()
        {
            var employees = await _userManager.GetUsersInRoleAsync(Roles.User);
            var viewModel = _mapper.Map<List<EmployeeListVM>>(employees);
            return View(viewModel);
        }

        // GET: EmployeesController/ViewAllocations/employeeId
        public async Task<IActionResult> ViewAllocations(string id)
        {
            var viewModel = await _leaveAllocationRepository.GetEmployeeAllocations(id);
            return View(viewModel);
        }


        // GET: EmployeesController/EditAllocation/5
        public async Task<IActionResult> EditAllocation(int id)
        {
            var viewModel = await _leaveAllocationRepository.GetEmployeeAllocation(id); //Get me a model from repository
            if (viewModel == null)
            {
                return NotFound();
            }

            return View(viewModel);
        }

        // POST: EmployeesController/EditAllocation/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditAllocation(int id, LeaveAllocationEditVM viewModel)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    if (await _leaveAllocationRepository.UpdateEmployeeAllocation(viewModel))
                    {
                        return RedirectToAction(nameof(ViewAllocations), new { id = viewModel.EmployeeId });
                    }
                }
            }
            catch
            {
                ModelState.AddModelError(string.Empty, "An Error Has Occured. Please Try Again Later");

            }
            viewModel.Employee = _mapper.Map<EmployeeListVM>(await _userManager.FindByIdAsync(viewModel.EmployeeId));
            viewModel.LeaveType = _mapper.Map<LeaveTypeVM>(await _leaveTypeRepository.GetAsync(viewModel.LeaveTypeId));
            return View(viewModel);
        }
    }
}
