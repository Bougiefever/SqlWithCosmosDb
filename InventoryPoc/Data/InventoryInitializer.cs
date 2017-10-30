using System;
using System.Collections.Generic;
using InventoryPoc.Data.Enums;
using InventoryPoc.Data.Models;
using InventoryPoc.Data.Models.Inventory;
using InventoryPoc.Data.Models.Profile;

namespace InventoryPoc.Data
{
  public class InventoryInitializer : System.Data.Entity.DropCreateDatabaseAlways<InventoryContext>
    //System.Data.Entity.DropCreateDatabaseIfModelChanges<InventoryContext>
    //System.Data.Entity.CreateDatabaseIfNotExists<InventoryContext>
  {
    protected override void Seed(InventoryContext context)
    {
      // Addresses
      var a1 = new Address
               {
                 AddressLine1 = "101 Main Street",
                 AddressLine2 = "Suite 100",
                 City = "Green Bay",
                 State = "WI",
                 ZipCode = "54303",
                 Country = "USA"
               };
      var a2 = new Address
               {
                 AddressLine1 = "555 Fifth St.",
                 City = "Appleton",
                 State = "WI",
                 ZipCode = "54914",
                 Country = "USA"
               };
      var addresses = new List<Address> {a1, a2};

      addresses.ForEach(a => context.Addresses.Add(a));
      context.SaveChanges();

      // Add sample client
      var client = new Client
                   {
                     ClientName = "Sample Client",
                     Industry = IndustryType.IndustryOne,
                     SubIndustry = SubIndustryType.SubIndustryTypeOne,
                     Address = a1
                   };
      context.Clients.Add(client);
      context.SaveChanges();

      // Add sample contract
      var contract = new Contract
                     {
                       Client = client,
                       ContractName = "Sample Contract",
                       ProjectCode = "Lawson1",
                       ServiceType = ServiceType.Famis
                     };
      context.Contracts.Add(contract);
      context.SaveChanges();

      // Add sample group
      var group = new Group {Contract = contract, GroupName = "Sample Group"};
      context.Groups.Add(group);
      context.SaveChanges();

      // add sample member
      var member = new Member
                   {
                     Group = group,
                     GroupId = group.Id,
                     MemberName = "Sample Member",
                     MemberNumber = "ABC123"
                   };
      context.Members.Add(member);
      context.SaveChanges();

      // add inventory entities
      var entities = new List<InventoryEntity>();
      var e1 = new InventoryEntity
               {
                 Description = "Main Office Building",
                 Group = group,
                 InventoryEntityType = InventoryEntityType.Asset,
                 Name = "Main Office Building"
               };
      entities.Add(e1);
      var e2 = new InventoryEntity
               {
                 Name = "Computers",
                 Group = group,
                 Description = "All the computers in the building",
                 InventoryEntityType = InventoryEntityType.Asset
               };
      entities.Add(e2);
      var e3 = new InventoryEntity
               {
                 Name = "Floor 1",
                 Description = "Floor 1 of Main Office Building",
                 Group = group,
                 InventoryEntityType = InventoryEntityType.Location
               };
      entities.Add(e3);
      var e4 = new InventoryEntity
               {
                 Name = "Room 1",
                 Description = "Room 1 on Floor 1",
                 Group = group,
                 InventoryEntityType = InventoryEntityType.Location
               };
      entities.Add(e4);
      var e5 = new InventoryEntity
               {
                 Name = "Furniture",
                 Description = "Furniture in Main Office Building",
                 InventoryEntityType = InventoryEntityType.Asset,
                 Group = group
               };
      entities.Add(e5);
      entities.ForEach(e => context.InventoryEntities.Add(e));
      context.SaveChanges();

      // add asset relationship to existing inventory entity
      var assets = new List<InventoryAsset>();
      var asset1 = new InventoryAsset
                   {
                     InventoryEntity = e1,
                     InventoryEntityId = e1.Id,
                     InventoryAssetType = InventoryAssetType.Building,
                     CostReplacementNew = 500000,
                     OriginalCost = 400000,
                     AcquisitionDate = new DateTime(2013, 4, 1)
                   };
      var asset2 = new InventoryAsset
                   {
                     InventoryEntity = e2,
                     InventoryEntityId = e2.Id,
                     InventoryAssetType = InventoryAssetType.Content,
                     CostReplacementNew = 50000,
                     OriginalCost = 45000,
                     AcquisitionDate = new DateTime(2013, 4, 1)
                   };
      var asset3 = new InventoryAsset
                   {
                     InventoryEntity = e5,
                     InventoryEntityId = e5.Id,
                     InventoryAssetType = InventoryAssetType.Content,
                     CostReplacementNew = 50000,
                     OriginalCost = 60000,
                     AcquisitionDate = new DateTime(2013, 4, 1)
                   };
      assets.Add(asset1);
      assets.Add(asset2);
      assets.Add(asset3);
      assets.ForEach(a => context.InventoryAssets.Add(a));
      context.SaveChanges();

      // add insurance asset relationship to existing inventory asset
      var insuranceAssets = new List<InsuranceAsset>();
      var i1 = new InsuranceAsset
               {
                 InventoryAsset = asset1,
                 InventoryAssetId = asset1.Id,
                 ExclusionPercent = 11.11d,
                 Member = member,
                 MemberId = member.Id
               };
      var i2 = new InsuranceAsset
               {
                 InventoryAsset = asset2,
                 InventoryAssetId = asset2.Id,
                 ExclusionPercent = 22.22d,
                 Member = member,
                 MemberId = member.Id
               };
      var i3 = new InsuranceAsset
               {
                 InventoryAsset = asset3,
                 InventoryAssetId = asset3.Id,
                 ExclusionPercent = 33.33d,
                 Member = member,
                 MemberId = member.Id
               };
      insuranceAssets.Add(i1);
      insuranceAssets.Add(i2);
      insuranceAssets.Add(i3);
      insuranceAssets.ForEach(i => context.InsuranceAssets.Add(i));
      context.SaveChanges();

      // Add AccountingHeader records
      var accountingHeaders = new List<AccountingHeader>();
      var ah1 = new AccountingHeader
                {
                  BookNumber = 1,
                  DepreciationMethod = DepreciationMethod.Method1,
                  Group = group,
                  GroupId = group.Id
                };
      var ah2 = new AccountingHeader
                {
                  BookNumber = 2,
                  DepreciationMethod = DepreciationMethod.Method2,
                  Group = group,
                  GroupId = group.Id
                };
      accountingHeaders.Add(ah1);
      accountingHeaders.Add(ah2);
      accountingHeaders.ForEach(h => context.AccountingHeaders.Add(h));
      context.SaveChanges();

      // Add inventory assets as accounting assets
      var accountingAssets = new List<AccountingAsset>();
      var aa1_1 = new AccountingAsset
                  {
                    InventoryAsset = asset2,
                    InventoryAssetId = asset2.Id,
                    AccountingHeader = ah1,
                    AccountingHeaderId = ah1.Id,
                    DepreciationBasis = 111.11m
                  };
      var aah1_2 = new AccountingAsset
                   {
                     InventoryAsset = asset2,
                     InventoryAssetId = asset2.Id,
                     AccountingHeader = ah2,
                     AccountingHeaderId = ah2.Id,
                     DepreciationBasis = 222.223m
                   };
      var aah2_1 = new AccountingAsset
                   {
                     InventoryAsset = asset3,
                     InventoryAssetId = asset3.Id,
                     AccountingHeader = ah1,
                     AccountingHeaderId = ah1.Id,
                     DepreciationBasis = 1.11m
                   };
      var aah2_2 = new AccountingAsset
                   {
                     InventoryAsset = asset3,
                     InventoryAssetId = asset3.Id,
                     AccountingHeader = ah2,
                     AccountingHeaderId = ah2.Id,
                     DepreciationBasis = 2.22m
                   };
      accountingAssets.Add(aa1_1);
      accountingAssets.Add(aah1_2);
      accountingAssets.Add(aah2_1);
      accountingAssets.Add(aah2_2);
      accountingAssets.ForEach(a => context.AccountingAssets.Add(a));
      context.SaveChanges();
    }
  }
}