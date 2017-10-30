using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using Microsoft.Azure.Documents.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace InventoryPoc.Data.Repos
{
  public class DocumentDbRepo<T>
  {
    private readonly string _databaseId = ConfigurationManager.AppSettings["DocDbName"];
    private readonly string _collectionId = ConfigurationManager.AppSettings["DocDbCollectionName"];
    private readonly string _endpoint = ConfigurationManager.AppSettings["DocDbEndpoint"];
    private readonly string _authkey = ConfigurationManager.AppSettings["DocDbAuthKey"];
    private DocumentClient _client;

    private Uri _collectionLink;


    public DocumentDbRepo()
    {
      _collectionLink = UriFactory.CreateDocumentCollectionUri(_databaseId, _collectionId);
    }

    private DocumentClient Client
    {
      get => _client ?? (_client = new DocumentClient(new Uri(_endpoint), _authkey));
      set => _client = value;
    }

    public async Task<T> GetItemAsync(string id, string partitionKey)
    {
      try
      {
        var documentLink = UriFactory.CreateDocumentUri(_databaseId, _collectionId, id);
        Document document = await Client.ReadDocumentAsync(documentLink,
                                                           new RequestOptions
                                                           {
                                                             PartitionKey =
                                                               new PartitionKey(partitionKey)
                                                           });
        return (T) (dynamic) document;
      }
      catch (DocumentClientException e)
      {
        if (e.StatusCode == System.Net.HttpStatusCode.NotFound)
        {
          return default(T);
        }
        else
        {
          throw;
        }
      }
    }

    public async Task<IEnumerable<T>> GetItemsAsync(Expression<Func<T, bool>> predicate)
    {
      IDocumentQuery<T> query = Client
        .CreateDocumentQuery<T>(_collectionLink, new FeedOptions {MaxItemCount = -1, EnableCrossPartitionQuery = true})
        .Where(predicate)
        .AsDocumentQuery();

      List<T> results = new List<T>();
      while (query.HasMoreResults)
      {
        results.AddRange(await query.ExecuteNextAsync<T>());
      }

      return results;
    }

    public async Task<IEnumerable<T>> GetItemsAsync(IEnumerable<string> ids, string partitionKey)
    {
      var items = new List<T>();

      foreach (var id in ids)
      {
        items.Add(await GetItemAsync(id, partitionKey));
      }

      return items;
    }

    public async Task<Document> CreateItemAsync(T item, string partitionKey)
    {
      return await Client.CreateDocumentAsync(_collectionLink, item,
                                              new RequestOptions {PartitionKey = new PartitionKey(partitionKey)});
    }

    public async Task<Document> UpdateItemAsync(string id, string partitionKey, T item)
    {
      var documentLink = UriFactory.CreateDocumentUri(_databaseId, _collectionId, id);
      return await Client.ReplaceDocumentAsync(documentLink, item,
                                               new RequestOptions {PartitionKey = new PartitionKey(partitionKey)});
    }

    public async Task<Document> UpsertItemAsync(string partitionKey, T item)
    {
      var l = UriFactory.CreateCollectionUri(_databaseId, _collectionId);
      string json = JsonConvert.SerializeObject(item, Formatting.Indented);
      Document d = new Document();
      d.LoadFrom(new JsonTextReader(new StringReader(json)));
      return await Client.UpsertDocumentAsync(l, d,
                                              new RequestOptions {PartitionKey = new PartitionKey(partitionKey)});
    }

    public async Task DeleteItemAsync(string id)
    {
      var documentLink = UriFactory.CreateDocumentUri(_databaseId, _collectionId, id);
      await Client.DeleteDocumentAsync(documentLink);
    }

    public void Initialize()
    {
      Client = new DocumentClient(new Uri(_endpoint), _authkey);
      CreateDatabaseIfNotExistsAsync().Wait();
      CreateCollectionIfNotExistsAsync().Wait();
    }

    public async Task<Document> CreateItemAsync(string json, string partitionKey)
    {
      Document d = new Document();
      var reader = new JsonTextReader(new StringReader(json));
      d.LoadFrom(reader);
      return await Client.CreateDocumentAsync(_collectionLink, d,
                                              new RequestOptions {PartitionKey = new PartitionKey(partitionKey)});
    }

    public async Task<Document> UpsertItemAsync(string json, string partitionKey)
    {
      Document d = new Document();
      var reader = new JsonTextReader(new StringReader(json));
      d.LoadFrom(reader);
      var l = UriFactory.CreateCollectionUri(_databaseId, _collectionId);
      return await Client.UpsertDocumentAsync(l, d,
                                              new RequestOptions {PartitionKey = new PartitionKey(partitionKey)});
    }

    private async Task CreateDatabaseIfNotExistsAsync()
    {
      try
      {
        await Client.ReadDatabaseAsync(UriFactory.CreateDatabaseUri(_databaseId));
      }
      catch (DocumentClientException e)
      {
        if (e.StatusCode == System.Net.HttpStatusCode.NotFound)
        {
          await Client.CreateDatabaseAsync(new Database {Id = _databaseId});
        }
        else
        {
          throw;
        }
      }
    }

    private async Task CreateCollectionIfNotExistsAsync()
    {
      try
      {
        await Client.ReadDocumentCollectionAsync(_collectionLink);
      }
      catch (DocumentClientException e)
      {
        if (e.StatusCode == System.Net.HttpStatusCode.NotFound)
        {
          await Client.CreateDocumentCollectionAsync(
                                                     UriFactory.CreateDatabaseUri(_databaseId),
                                                     new DocumentCollection {Id = _collectionId},
                                                     new RequestOptions {OfferThroughput = 1000});
        }
        else
        {
          throw;
        }
      }
    }
  }
}