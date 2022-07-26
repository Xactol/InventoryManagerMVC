using System.ComponentModel.DataAnnotations;

namespace WebApplication3.ViewModels.Employee
{
    public class NewEmployeeViewModel
    {
        [Display(Name = "Employee´s name")]
        public String Name;
        [Display(Name = "Employee´s surname")]
        public String Surname;
        [Display(Name = "Employee´s main mail")]
        [Required(ErrorMessage = "Email es required")]
        public String Email;
        [Display(Name = "City where worker will work")]
        public String City;
    }
}
