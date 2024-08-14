using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVC_UsingEF.Context;
using MVC_UsingEF.Models;

namespace MVC_UsingEF.Controllers
{
    public class StudentController : Controller
    {
        // Dependencies are injected at constructor level
        //StudentDbContext dbContext = new StudentDbContext();
        StudentDbContext dbContext;
        public StudentController(StudentDbContext _context)
        {
            dbContext = _context;
        }
        // GET: StudentController
        public ActionResult Index()
        {
            List<Student> list = dbContext.Students.ToList();
            if(list.Count==0)
            {
                ViewBag.msg = "There are no records";
            }
            return View(list);
        }

        // GET: StudentController/Details/5
        public ActionResult Details(int id)
        {
            Student temp = new Student() ;
            foreach (var stu in dbContext.Students)
            {
                if (stu.Id == id)
                {
                    temp = stu;
                    break;
                }
            }  
            return View(temp);
        }

        // GET: StudentController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StudentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Student student)
        {
            try
            {
                dbContext.Students.Add(student);
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: StudentController/Edit/5
        public ActionResult Edit(int id)
        {
            Student temp = new Student();
            foreach (var stu in dbContext.Students)
            {
                if (stu.Id == id)
                {
                    temp = stu;
                    break;
                }
            }
            return View(temp);
        }

        // POST: StudentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Student student)
        {
            try

            {
                Student temp = new Student();
                foreach (var stu in dbContext.Students)
                {
                    if (stu.Id == id)
                    {
                        stu.Batch = student.Batch;
                        break;
                    }
                }
                dbContext.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: StudentController/Delete/5
        public ActionResult Delete(int id)
        {
            Student temp = new Student();
            foreach (var stu in dbContext.Students)
            {
                if (stu.Id == id)
                {
                    temp = stu;
                    break;
                }
            }
            return View(temp);
        }

        // POST: StudentController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Student student)
        {
            try
            {
                foreach (var stu in dbContext.Students)
                {
                    if (stu.Id == id)
                    {
                        dbContext.Students.Remove(stu);
                        break;
                    }
                }
                dbContext.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
