using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using InventoryPoc.Data;
using InventoryPoc.Data.Models.Profile;

namespace InventoryPoc.Controllers
{
  public class ContractController : Controller
  {
    private InventoryContext db = new InventoryContext();

    // GET: Contract
    public ActionResult Index()
    {
      ViewBag.Title = "Contracts";
      var contracts = db.Contracts.Include(c => c.Client);
      return View(contracts.ToList());
    }

    // GET: Contract/Details/5
    public ActionResult Details(int? id)
    {
      if (id == null)
      {
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      }
      Contract contract = db.Contracts.Find(id);
      if (contract == null)
      {
        return HttpNotFound();
      }
      return View(contract);
    }

    // GET: Contract/Create
    public ActionResult Create()
    {
      ViewBag.ClientId = new SelectList(db.Clients, "Id", "ClientName");
      return View();
    }

    // POST: Contract/Create
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(
      [Bind(Include = "Id,ProjectCode,ServiceType,ContractName,ContractStatus,ClientId")] Contract contract)
    {
      if (ModelState.IsValid)
      {
        db.Contracts.Add(contract);
        db.SaveChanges();
        return RedirectToAction("Index");
      }

      ViewBag.ClientId = new SelectList(db.Clients, "Id", "ClientName", contract.ClientId);
      return View(contract);
    }

    // GET: Contract/Edit/5
    public ActionResult Edit(int? id)
    {
      if (id == null)
      {
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      }
      Contract contract = db.Contracts.Find(id);
      if (contract == null)
      {
        return HttpNotFound();
      }
      ViewBag.ClientId = new SelectList(db.Clients, "Id", "ClientName", contract.ClientId);
      return View(contract);
    }

    // POST: Contract/Edit/5
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(
      [Bind(Include = "Id,ProjectCode,ServiceType,ContractName,ContractStatus,ClientId")] Contract contract)
    {
      if (ModelState.IsValid)
      {
        db.Entry(contract).State = EntityState.Modified;
        db.SaveChanges();
        return RedirectToAction("Index");
      }
      ViewBag.ClientId = new SelectList(db.Clients, "Id", "ClientName", contract.ClientId);
      return View(contract);
    }

    // GET: Contract/Delete/5
    public ActionResult Delete(int? id)
    {
      if (id == null)
      {
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      }
      Contract contract = db.Contracts.Find(id);
      if (contract == null)
      {
        return HttpNotFound();
      }
      return View(contract);
    }

    // POST: Contract/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public ActionResult DeleteConfirmed(int id)
    {
      Contract contract = db.Contracts.Find(id);
      db.Contracts.Remove(contract);
      db.SaveChanges();
      return RedirectToAction("Index");
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