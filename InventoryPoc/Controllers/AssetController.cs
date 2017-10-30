using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using InventoryPoc.Data;
using InventoryPoc.Data.Enums;
using InventoryPoc.Data.Models.Inventory;
using InventoryPoc.Data.Repos;
using InventoryPoc.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace InventoryPoc.Controllers
{
  public class AssetController : Controller
  {
    private InventoryContext db = new InventoryContext();
    private DocumentDbRepo<Building> _docDbBuilding = new DocumentDbRepo<Building>();

    private DocumentDbRepo<Content> _docDbContent = new DocumentDbRepo<Content>();

    // GET: Asset
    public ActionResult Index(int? groupId)
    {
      if (groupId == null)
      {
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      }
      var entities = (from e in db.InventoryEntities
                      join a in db.InventoryAssets on e.Id equals a.InventoryEntityId
                      where e.GroupId == groupId
                      select new AssetEntityModel()
                             {
                               Id = e.Id,
                               Name = e.Name,
                               Description = e.Description,
                               OriginalCost = a.OriginalCost,
                               InventoryAssetType = a.InventoryAssetType
                             }).ToList();
      return View(entities);
    }

    [HttpGet, ActionName("EditBuilding")]
    public async Task<ActionResult> EditBuilding(int? groupId, int? entityId)
    {
      if (groupId == null || entityId == null)
      {
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      }
      var asset = db.InventoryAssets.First(x => x.InventoryEntity.Id == entityId &&
                                                x.InventoryEntity.GroupId == groupId);
      var buildingAttributes = await _docDbBuilding.GetItemAsync(entityId.ToString(), groupId.ToString());
      Building building;

      if (buildingAttributes != null)
      {
        building = buildingAttributes;
        building.Id = entityId.ToString();
        building.InventoryAssetType = asset.InventoryAssetType;
        building.BuildingName = asset.InventoryEntity.Name;
      }
      else
      {
        building = new Building
                   {
                     Id = entityId.ToString(),
                     GroupId = groupId.ToString(),
                     InventoryAssetType = InventoryAssetType.Building,
                     BuildingName = asset.InventoryEntity.Name
                   };
      }
      if (building.OccupancyList == null)
      {
        var list = new List<Occupancy>();
        building.OccupancyList = list.ToArray();
      }
      if (building.CustomDataList == null)
      {
        building.CustomDataList = new List<CustomData>().ToArray();
      }


      return View(building);
    }

    [HttpPost]
    public async Task<ActionResult> EditBuilding(Building building)
    {
      string json;
      if (building.FreeformData != null)
      {
        string freeformJson = building.FreeformData[0];
        building.FreeformData = "";
        string buildingJson = JsonConvert.SerializeObject(building, Formatting.Indented);
        dynamic result2 = JObject.Parse(buildingJson);
        dynamic freeform = JObject.Parse(freeformJson);
        result2.freeformData = freeform;
        json = JsonConvert.SerializeObject(result2);
      }
      else
      {
        json = JsonConvert.SerializeObject(building);
      }

      await _docDbBuilding.UpsertItemAsync(json, building.GroupId);
      return RedirectToAction("Index", new {groupId = building.GroupId});
    }

    [HttpGet, ActionName("EditContent")]
    public async Task<ActionResult> EditContent(int? groupId, int? entityId)
    {
      if (groupId == null || entityId == null)
      {
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      }

      var asset = db.InventoryAssets.First(x => x.InventoryEntity.Id == entityId &&
                                                x.InventoryEntity.GroupId == groupId);
      var contentAttributes = await _docDbContent.GetItemAsync(entityId.ToString(), groupId.ToString());
      Content content;

      if (contentAttributes != null)
      {
        content = contentAttributes;
        content.Id = entityId.ToString();
        content.InventoryAssetType = asset.InventoryAssetType;
        content.Name = asset.InventoryEntity.Name;
      }
      else
      {
        content = new Content()
                  {
                    Id = entityId.ToString(),
                    GroupId = groupId.ToString(),
                    InventoryAssetType = InventoryAssetType.Content,
                    Name = asset.InventoryEntity.Name
                  };
      }

      if (content.CustomDataList == null)
      {
        content.CustomDataList = new List<CustomData>().ToArray();
      }

      return View(content);
    }

    [HttpPost]
    public async Task<ActionResult> EditContent(Content content)
    {
      await _docDbContent.UpsertItemAsync(content.GroupId, content);

      return RedirectToAction("Index", new {groupId = content.GroupId});
    }
  }
}