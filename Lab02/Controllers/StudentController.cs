using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Lab02.Models;

namespace Lab02.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        static IList<Student> studentList = new List<Student>
        {
            new Student() { StudentId = 1,LastName = "Nguyen", FirstMidName="Thanh", EnrollmentDate = DateTime.Now},
            new Student() { StudentId = 2,LastName = "Ngan", FirstMidName="Hieu", EnrollmentDate = DateTime.Now},
            new Student() { StudentId = 3,LastName = "Khai", FirstMidName="Tuan", EnrollmentDate = DateTime.Now},
            new Student() { StudentId = 4,LastName = "Trung", FirstMidName="Duc", EnrollmentDate = DateTime.Now},
            new Student() { StudentId = 5,LastName = "Van", FirstMidName="Dong", EnrollmentDate = DateTime.Now},
            new Student() { StudentId = 6,LastName = "Dai", FirstMidName="Thang", EnrollmentDate = DateTime.Now}
        };
 

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Student std)
        {
            studentList.Add(std);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int Id)

        {
            var std = studentList.Where(s => s.StudentId ==

            Id).FirstOrDefault();

            return View(std);
        }

        [HttpPost]
        public ActionResult Edit(Student std)
        {
            var student = studentList.Where(s => s.StudentId == std.StudentId).FirstOrDefault();
            studentList.Remove(student);
            studentList.Add(std);
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int? id)

        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var std = studentList.Where(s => s.StudentId == id).FirstOrDefault();
            if (std == null)
            {
                return HttpNotFound();
            }
            return View(std);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var std = studentList.Where(s => s.StudentId == id).FirstOrDefault();
            studentList.Remove(std);
            return RedirectToAction("Index");
        }

        public ActionResult Details(int? id)

        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var std = studentList.Where(s => s.StudentId == id).FirstOrDefault();
            if (std == null)
            {
                return HttpNotFound();
            }
            return View(std);
        }
        public ActionResult Index(string searchString)
        {
            if (!String.IsNullOrEmpty(searchString))
            {
                IEnumerable<Student> students = studentList.Where(s => s.LastName.Contains(searchString) || s.FirstMidName.Contains(searchString));
                return View(students);
            }
            return View(studentList);
        }


    }
}