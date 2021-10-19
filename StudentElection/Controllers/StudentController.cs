using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using StudentElection.Models;

namespace StudentElection.Controllers
{
    public class StudentController : Controller
    {
        private Student_ElectionEntities db = new Student_ElectionEntities();
        public ActionResult Index()
        {
            if (Session["rollno"] == null)
            {
                return RedirectToAction("Login");
            }
            var rollno = int.Parse(Session["rollno"].ToString());
            Student student = db.Students.FirstOrDefault(x => x.rollno == rollno);
            if (student == null)
            {
                return RedirectToAction("Login");
            }
            return View(student);
        }

        public ActionResult Elections()
        {
            if (Session["rollno"] == null)
            {
                return RedirectToAction("Login");
            }
            var elections = db.Elections.ToList();
            return View(elections);
        }

        public ActionResult Candidates(int? id)
        {
           
            if (Session["rollno"] == null)
            {
                return RedirectToAction("Login");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Session["electionId"] = id.ToString();
            var candidates = db.Elections.Find(id).ElectionCandidates.Select(x => x.Candidate).ToList();
            return View(candidates);
        }
        public ActionResult Vote(int? id)
        {
            if (Session["rollno"] == null)
            {
                return RedirectToAction("Login");
            }
            if (id == null)
            {
            }
            var electionId = int.Parse(Session["electionId"].ToString());
            var rollno = int.Parse(Session["rollno"].ToString());
            ElectionVote electionVote = new ElectionVote();
            electionVote.CandidatId = id;
            electionVote.ElectionId = electionId;
            electionVote.StudentRollNumber = rollno;
            db.ElectionVotes.Add(electionVote);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult Edit()
        {
            if (Session["rollno"] == null)
            {
                return RedirectToAction("Login");
            }
            var rollno = int.Parse(Session["rollno"].ToString());

            Student student = db.Students.FirstOrDefault(x => x.rollno == rollno);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "studentname,DOB,branch,yearofjoining,mobilenumber")] Student student)
        {
            if (Session["rollno"] == null)
            {
                return RedirectToAction("Login");
            }
            var rollno = int.Parse(Session["rollno"].ToString());
            if (ModelState.IsValid)
            {
                Student studentdb = db.Students.FirstOrDefault(x => x.rollno == rollno);
                studentdb.studentname = student.studentname;
                studentdb.DOB = student.DOB;
                studentdb.branch = student.branch;
                studentdb.yearofjoining = student.yearofjoining;
                student.mobilenumber = student.mobilenumber;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(student);
        }


        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Student student)
        {
            if (ModelState.IsValid)
            {
                using (Student_ElectionEntities db = new Student_ElectionEntities())
                {
                    var obj = db.Students.FirstOrDefault(x => x.rollno == student.rollno && x.password == student.password);
                    if (obj != null)
                    {
                        Session["rollno"] = obj.rollno.ToString();
                        Session["password"] = obj.password.ToString();
                        return RedirectToAction("Index");
                    }


                }

            }
            return View(student);
        }

        public ActionResult StudentHomePage()
        {
            if (Session["rollno"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
