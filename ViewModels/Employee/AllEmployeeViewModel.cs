using Microsoft.AspNetCore.Mvc;


namespace WebApplication3.ViewModels.Employee
{
    public class AllEmployeeViewModel 
    {
        public List<WebApplication3.Models.Employee>? list { get; set; }

        public AllEmployeeViewModel() {
            list = new List<Models.Employee> { };
        }
    }
}
