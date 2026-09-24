using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using TestWebProjec3T.DAL.Context;
using TestWebProjec3T.DAL.Entites;
using TestWebProjec3T.Helper;
using TestWebProjec3T.ModelVM.EmployeeVM;

namespace TestWebProjec3T.Controllers
{
    public class InfoController : Controller
    {
        private readonly EmployeeDbContext _db;

        public InfoController(EmployeeDbContext db)
        {
            _db = db;
        }

        public IActionResult GetAll()
        {
            List<Employee>? result = _db.employees.ToList(); 

            //Custem map
            List<GetEmployeeVM> list = new List<GetEmployeeVM>();
            foreach (Employee item in result)
            {
                list.Add(new GetEmployeeVM
                {
                    Id = item.Id,
                    Age = item.Age,
                    Name = item.Name,
                    CreatedOn = item.CreatedOn,
                    Grade = item.Grade,
                    Image = item.Image,
                    Email = item.Email,
                    Address = item.Address
                });
            }


            return View(list);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SaveData(CreateEmployeeVM employee)
        {
            if (!ModelState.IsValid)
            {
                return View("Create", employee);
            }

            Employee newEmployee = new Employee()
            {
                Name = employee.Name,
                Age = employee.Age,
                Grade = employee.Grade,
                CreatedOn = DateTime.Now,
                Password = employee.Password,
                Email = employee.Email,
                Address = employee.Address
            };

            if (employee.Image != null && employee.Image.Length > 0)
            {
                string fileName = Upload.UploadFile("Files", employee.Image);
                newEmployee.Image = "/Files/" + fileName;
            }

            _db.employees.Add(newEmployee);
            _db.SaveChanges();

            return RedirectToAction("GetAll");
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
                return RedirectToAction("GetAll");   // من الـ Sidebar: يودّيك لقائمة الموظفين تختار منها

            var result = _db.employees.Find(id);
            if (result == null)
                return NotFound();

            return View(result);
        }

        [HttpPost]
        public IActionResult SaveEditData(Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return View("Edit", employee);
            }

            var oldEmployee = _db.employees.Find(employee.Id);

            if (oldEmployee != null)
            {
                oldEmployee.Name = employee.Name;
                oldEmployee.Age = employee.Age;
                oldEmployee.Grade = employee.Grade;
                oldEmployee.Address = employee.Address;
                oldEmployee.Password = employee.Password;
                oldEmployee.Email = employee.Email;

                _db.SaveChanges();
                return RedirectToAction("GetAll");
            }

            return NotFound();
        }

        public IActionResult Delete(int empId)
        {
            var employee = _db.employees.Find(empId);
            if (employee == null)
            {
                return NotFound();
            }

            _db.employees.Remove(employee);
            _db.SaveChanges();

            return RedirectToAction("GetAll");
        }

        public IActionResult GetByID(int empId)
        {
            var res = _db.employees.Find(empId);
            if (res == null)
            {
                return NotFound();
            }

            return View("Card", res);
        }

        public IActionResult Card(int empId)
        {
            var res = _db.employees.Find(empId);
            if (res == null)
            {
                return NotFound();
            }

            return View(res);
        }
    }
}
