using System.ComponentModel.DataAnnotations;

namespace LeaveManagement.Common.Models
{
    public class LeaveAllocationVM
    {
        [Required]
        public int Id { get; set; } //Giving this an Id so the admin can adit the leave allocations

        [Display(Name ="Number of Days")]
        [Required]
        [Range(1, 90, ErrorMessage ="Invalid Number Entered")]
        public int NumberOfDays { get; set; }

        [Required]
        [Display(Name ="Allocation Period")]
        public int Period { get; set; }


        public LeaveTypeVM? LeaveType { get; set; }
    }
}