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
        //public ActionResult Index()
        //{
        //    return View(db.ParkedVehicles.ToList());
        //}




        public ActionResult Index(string searchTerm = null)
        {
            var model = db.ParkedVehicles
                .Where(r => searchTerm == null || r.RegNo.Contains(searchTerm))
                .OrderBy(r => r.RegNo);

            return View(model);
        }





        public ActionResult About()
        {
            ViewBag.Message = "A little bit about us.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Contactinformation.";

            return View();
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
            return View();
        }

        // POST: ParkedVehicles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.

        //parkedVehicle.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Type,RegNo,Color,Brand,Model,NoOfWheels")] ParkedVehicle parkedVehicle)
        {
            parkedVehicle.RegNo = parkedVehicle.RegNo.ToUpper();
            if (ModelState.IsValid) {   
                db.ParkedVehicles.Add(parkedVehicle);
                db.SaveChanges();

                return RedirectToAction("Index");
            }

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
            return View(parkedVehicle);
        }

        // POST: ParkedVehicles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Type,RegNo,Color,Brand,Model,NoOfWheels")] ParkedVehicle parkedVehicle)
        {
            if (ModelState.IsValid)
            {
                db.Entry(parkedVehicle).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
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
            var receiptModel = new ReceiptViewModel
            {
                Type = parkedVehicle.Type,
                Color = parkedVehicle.Color,
                Brand = parkedVehicle.Brand,
                Model = parkedVehicle.Model,
                RegNo = parkedVehicle.RegNo,
                NoOfWheels = parkedVehicle.NoOfWheels,

                CheckOutTime = DateTime.Now,
                CheckInTime =  new DateTime(2018, 2, 9, 8, 30, 0)
                
            };
           receiptModel.ParkingPrice = CalculateParkingPrice(receiptModel.CheckInTime, receiptModel.CheckOutTime);
            db.ParkedVehicles.Remove(parkedVehicle);
            db.SaveChanges();
            return View("Receipt", receiptModel);
            
        }

        private int CalculateParkingPrice(DateTime checkInTime, DateTime checkOutTime)
        {
            TimeSpan span = (checkOutTime - checkInTime);

            //Priset blir 1 öre per sekund
            var ParkingPrice = Convert.ToInt32(span.TotalSeconds * 0.01);

            return ParkingPrice;


           
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
