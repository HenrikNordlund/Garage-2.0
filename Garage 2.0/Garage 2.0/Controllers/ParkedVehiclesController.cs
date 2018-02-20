using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Garage_2._0.DataAccessLayer;
using Garage_2._0.Models;

namespace Garage_2._0.Controllers
{
    public class ParkedVehiclesController : Controller
    {
        private RegisterContext db = new RegisterContext();

        // GET: ParkedVehicles
        public ActionResult Index(string searchTerm = null)
        {
            var parkedVehicles = db.ParkedVehicles
                .Where(r => searchTerm == null || r.RegNo.Contains(searchTerm))
                .OrderBy(r => r.RegNo);

           // var parkedVehicles = db.ParkedVehicles.Include(p => p.Member).Include(p => p.VehicleType);
            return View(parkedVehicles.ToList());
        }

        // GET: ParkedVehicles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ParkedVehicle parkedVehicle = db.ParkedVehicles.Find(id);
            if (parkedVehicle == null)
            {
                return HttpNotFound();
            }
            return View(parkedVehicle);
        }

        // GET: ParkedVehicles/Create
        public ActionResult Create()
        {
            ViewBag.MemberId = new SelectList(db.Members, "Id", "MemberSignum");
            ViewBag.VehicleTypeId = new SelectList(db.VehicleTypes, "Id", "FordonsType");
            return View();
        }

        // POST: ParkedVehicles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]

        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,RegNo,Color,Brand,Model,NoOfWheels,CheckInTime,MemberId,VehicleTypeId")] ParkedVehicle parkedVehicle)
        {
            parkedVehicle.RegNo = parkedVehicle.RegNo.ToUpper();
            parkedVehicle.CheckInTime = DateTime.Now;

            if (ModelState.IsValid)
            {
                db.ParkedVehicles.Add(parkedVehicle);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MemberId = new SelectList(db.Members, "Id", "MemberSignum", parkedVehicle.MemberId);
            ViewBag.VehicleTypeId = new SelectList(db.VehicleTypes, "Id", "FordonsType", parkedVehicle.VehicleTypeId);
            return View(parkedVehicle);
        }

        // GET: ParkedVehicles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ParkedVehicle parkedVehicle = db.ParkedVehicles.Find(id);
            if (parkedVehicle == null)
            {
                return HttpNotFound();
            }
            ViewBag.MemberId = new SelectList(db.Members, "Id", "MemberSignum", parkedVehicle.MemberId);
            ViewBag.VehicleTypeId = new SelectList(db.VehicleTypes, "Id", "FordonsType", parkedVehicle.VehicleTypeId);
            return View(parkedVehicle);
        }

        // POST: ParkedVehicles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,RegNo,Color,Brand,Model,NoOfWheels,CheckInTime,MemberId,VehicleTypeId")] ParkedVehicle parkedVehicle)
        {
            if (ModelState.IsValid)
            {
                db.Entry(parkedVehicle).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MemberId = new SelectList(db.Members, "Id", "MemberSignum", parkedVehicle.MemberId);
            ViewBag.VehicleTypeId = new SelectList(db.VehicleTypes, "Id", "FordonsType", parkedVehicle.VehicleTypeId);
            return View(parkedVehicle);
        }

        // GET: ParkedVehicles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ParkedVehicle parkedVehicle = db.ParkedVehicles.Find(id);
            if (parkedVehicle == null)
            {
                return HttpNotFound();
            }
            return View(parkedVehicle);
        }

        // POST: ParkedVehicles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ParkedVehicle parkedVehicle = db.ParkedVehicles.Find(id);
            db.ParkedVehicles.Remove(parkedVehicle);
            db.SaveChanges();
            return RedirectToAction("Index");
        }



        public ActionResult ListMembers()
        {
            return View("ListMembers",db.Members);
        }

        public ActionResult AddMember([Bind(Include = "Id,FirstName,LastName,MemberSignum")] Member member)
        //public ActionResult AddMember(int id)
        {
            if (ModelState.IsValid)
            {
                db.Members.Add(member);
                db.SaveChanges();
                return RedirectToAction("ListMembers");
            }
            return View(); 

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
