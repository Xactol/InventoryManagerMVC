using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using WebApplication3.Models;
using WebApplication3.ViewModels.Employee;

namespace WebApplication3.Controllers
{
    public class EmployeeController : Controller
    {

        
        InventoryManagerContext db = new InventoryManagerContext();
        public IActionResult Index()
        {

            return View();
        }


        public ActionResult Create() {
            return View();
        }

        public ActionResult Delete() {
            return View();
        }

        public ActionResult Edit() {
            return View();
        }

        public ActionResult FindModifyById() {
            return View();
        }


        [HttpPost]
        public ActionResult New (Employee employe ){
            // Por que convierte el view model en un emplyee directamente ??
            int resultOfSave = -1;
            try{
                db.Employees.Add(employe);
                resultOfSave = db.SaveChanges();
            }
            catch (ArgumentNullException ex){
                Console.WriteLine("Employee is null " + ex.Message);          // In future versions, this will be update to log message
            }
            catch (DbUpdateException ex){
                Console.WriteLine("An error ocurred when Employee Entity is going to be saved " + ex.Message);
            }
            catch (Exception ex){
                Console.WriteLine("The method called New in EmployeeController catch the excepcion : " + ex.Message);
            }
            if (resultOfSave < 1) return Content("The entity hasn´t been saved ");
            return View(employe);
        }

        public ActionResult Remove(Employee employe) {
            var result = db.Employees.Find(employe.Email);
            if (result == null) return Content("Employee not found");
            try
            {
                db.Employees.Remove(result);
                db.SaveChanges();
            }
            catch (DbUpdateException ex){
                Console.WriteLine("An exception ocurred when the employee is going to be removed " + ex.Message);
            }
            catch (Exception ex) {
                Console.WriteLine("An excepcion ocurred "+ ex.Message);
            } 
            return View(result);
        }

        //TODO como consigo asignar una vista que se llame distinta al metodo

        public ActionResult fillFields(String employeEmail, int SelectedOption) {
            Employee employee = db.Employees.Find(employeEmail);
            if(employee != null)
                if(SelectedOption == 0 )
                    return View(employee);
                return View("Show", employee);
            return Content("Employee not found");
        }

        public ActionResult Modify(Employee employe) {
            db.Entry(employe).State = EntityState.Modified;
            db.Entry(employe).CurrentValues.SetValues(employe);
            db.SaveChanges();
            return Content("The modifications have been made correctly");
        }

        public ActionResult GetAll() {
            AllEmployeeViewModel list = new AllEmployeeViewModel();
            list.list = db.Employees.ToList();
            return View(list);
        }
    }
}
