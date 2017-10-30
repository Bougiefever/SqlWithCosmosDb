using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using InventoryPoc.Data;
using InventoryPoc.Data.Models.Inventory;
using InventoryPoc.Data.Models.Profile;
using InventoryPoc.Models;

namespace InventoryPoc.Controllers
{
  public class GroupController : Controller
  {
    private InventoryContext db = new InventoryContext();

    // GET: Group
    public ActionResult Index()
    {
      ViewBag.Title = "Groups";
      var groups = db.Groups.Include(g => g.Contract).Include(g => g.Member);
      return View(groups.ToList());
    }

    // GET: Group/Details/5
    public ActionResult Details(int? id)
    {
      if (id == null)
      {
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      }
      Group group = db.Groups.Find(id);
      if (group == null)
      {
        return HttpNotFound();
      }
      ViewBag.GroupId = id;
      return View(group);
    }

    // GET: Group/Create
    public ActionResult Create()
    {
      ViewBag.ContractId = new SelectList(db.Contracts, "Id", "ProjectCode");
      ViewBag.Id = new SelectList(db.Members, "Id", "MemberName");
      return View();
    }

    // POST: Group/Create
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(
      [Bind(Include =
        "Id,GroupName,GroupNumber,ProcessingType,YearsProjected,CostReplacementNewTrendDate,GroupFeatures,AtReportedCost,ContractId")]
      Group group)
    {
      if (ModelState.IsValid)
      {
        db.Groups.Add(group);
        db.SaveChanges();
        return RedirectToAction("Index");
      }

      ViewBag.ContractId = new SelectList(db.Contracts, "Id", "ProjectCode", group.ContractId);
      ViewBag.Id = new SelectList(db.Members, "Id", "MemberName", group.Id);
      return View(group);
    }

    // GET: Group/Edit/5
    public ActionResult Edit(int? id)
    {
      if (id == null)
      {
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      }
      Group group = db.Groups.Find(id);
      if (group == null)
      {
        return HttpNotFound();
      }
      ViewBag.ContractId = new SelectList(db.Contracts, "Id", "ProjectCode", group.ContractId);
      ViewBag.Id = new SelectList(db.Members, "Id", "MemberName", group.Id);
      return View(group);
    }

    // POST: Group/Edit/5
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(
      [Bind(Include =
        "Id,GroupName,GroupNumber,ProcessingType,YearsProjected,CostReplacementNewTrendDate,GroupFeatures,AtReportedCost,ContractId")]
      Group group)
    {
      if (ModelState.IsValid)
      {
        db.Entry(group).State = EntityState.Modified;
        db.SaveChanges();
        return RedirectToAction("Index");
      }
      ViewBag.ContractId = new SelectList(db.Contracts, "Id", "ProjectCode", group.ContractId);
      ViewBag.Id = new SelectList(db.Members, "Id", "MemberName", group.Id);
      return View(group);
    }

    // GET: Group/Delete/5
    public ActionResult Delete(int? id)
    {
      if (id == null)
      {
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      }
      Group group = db.Groups.Find(id);
      if (group == null)
      {
        return HttpNotFound();
      }
      return View(group);
    }

    // POST: Group/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public ActionResult DeleteConfirmed(int id)
    {
      Group group = db.Groups.Find(id);
      db.Groups.Remove(group);
      db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult GetAssets(int? id)
    {
      if (id == null)
      {
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      }
      var entities = (from e in db.InventoryEntities
                      join a in db.InventoryAssets on e.Id equals a.InventoryEntityId
                      where e.GroupId == id
                      select new AssetEntityModel()
                             {
                               Id = e.Id,
                               Name = e.Name,
                               Description = e.Description,
                               OriginalCost = a.OriginalCost,
                               InventoryAssetType = a.InventoryAssetType
                             }).ToList();

      ViewBag.GroupId = id;
      return PartialView("_AssetView", entities);
    }

    public ActionResult GetInsuranceAssets(int? id)
    {
      if (id == null)
      {
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      }
      IQueryable<InventoryAsset> aes = db.InventoryAssets.Where(x => x.InventoryEntity.GroupId == id);
      var insuranceAssets = aes.Join(db.InsuranceAssets, a => a.Id, i => i.Id, (a, i) => new {a, i}).ToList();

      var models = insuranceAssets.Select(x => new InsuranceAssetModel
                                               {
                                                 Id = x.i.Id,
                                                 Name = x.a.InventoryEntity.Name,
                                                 Description = x.a.InventoryEntity.Description,
                                                 ExclusionPercent = x.i.ExclusionPercent,
                                                 InventoryAssetType = x.a.InventoryAssetType,
                                                 MemberName = x.i.Member.MemberName,
                                                 OriginalCost = x.a.OriginalCost
                                               });
      return PartialView("_InsuranceAssetView", models);
    }

    public ActionResult GetAccountingAssets(int? id)
    {
      if (id == null)
      {
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      }
      IQueryable<InventoryAsset> aes = db.InventoryAssets.Where(x => x.InventoryEntity.GroupId == id);
      var accountingAssets = aes.Join(db.AccountingAssets, a => a.Id, acc => acc.InventoryAssetId,
                                      (a, acc) => new {a, acc});
      var list = accountingAssets.ToList();
      var models = list.Select(x => new AccountingAssetModel
                                    {
                                      Id = x.acc.Id,
                                      BookNumber = x.acc.AccountingHeader.BookNumber,
                                      DepreciationMethod = x.acc.AccountingHeader.DepreciationMethod,
                                      DepreciationBasis = x.acc.DepreciationBasis,
                                      Name = x.a.InventoryEntity.Name,
                                      Description = x.a.InventoryEntity.Description,
                                      InventoryAssetType = x.a.InventoryAssetType,
                                      OriginalCost = x.a.OriginalCost
                                    });

      return PartialView("_AccountingAssetView", models);
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