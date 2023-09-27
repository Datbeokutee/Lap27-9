using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyWebAppLab1.Models;

namespace MyWebAppLab1.Controllers
{
    [Route("Admin/Student")]
    public class StudentController : Controller
    {

        private static List<Student> listStudents = new List<Student>();

        private static int id = 0;

        public StudentController()
        {
            if (listStudents.Count == 0)

                listStudents.AddRange(new List<Student>
    {
                new Student() { Id = ++id, Name = "Hải Nam", Branch = Branch.IT, Gender = Gender.Male,
                IsRegular=true, Address = "A1-2018", Email = "nam@g.com",DateOfBorth = new DateTime(2000, 1, 15),Password = "secure123"},

                new Student() { Id = ++id, Name = "Minh Tú", Branch = Branch.BE, Gender = Gender.Female,
                    IsRegular=true,
                    Address = "A1-2019", Email = "tu@g.com" ,DateOfBorth = new DateTime(2000, 1, 15),Password = "secure123"},
                new Student() { Id = ++id, Name = "Hoàng Phong", Branch = Branch.CE, Gender = Gender.Male,
                IsRegular=false,
                Address = "A1-2020",DateOfBorth = new DateTime(2000, 1, 15),Password = "secure123" },
                new Student() { Id = ++id, Name = "Xuân Mai", Branch = Branch.EE, Gender = Gender.Female,
                IsRegular = false,
                Address = "A1-2021", Email = "mai@g.com",DateOfBorth = new DateTime(2000, 1, 15),Password = "secure123" }

                });
        }

        [HttpGet("List")]
        public IActionResult Index()
        {
            return View(listStudents);
        }

        [Route("Add")]
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.AllGenders = Enum.GetValues(typeof(Gender)).Cast<Gender>().ToList();
            ViewBag.AllBranches = new List<SelectListItem>()
            {
            new SelectListItem { Text = "IT", Value = "1" },
            new SelectListItem { Text = "BE", Value = "2" },
            new SelectListItem { Text = "CE", Value = "3" },
            new SelectListItem { Text = "EE", Value = "4" }
              };
            return View();
        }


        [HttpPost("Add")]
        public IActionResult Create(Student s)

        { if (ModelState.IsValid)
    {
        s.Id = ++id;
        listStudents.Add(s);
        return RedirectToAction("Index"); // Redirect to the list view after successful addition.
    }

    ViewBag.AllGenders = Enum.GetValues(typeof(Gender)).Cast<Gender>().ToList();
    ViewBag.AllBranches = new List<SelectListItem>()
    {
        new SelectListItem { Text = "IT", Value = "1" },
        new SelectListItem { Text = "BE", Value = "2" },
        new SelectListItem { Text = "CE", Value = "3" },
        new SelectListItem { Text = "EE", Value = "4" }
    };
    return View(s);
        }


    }

}
