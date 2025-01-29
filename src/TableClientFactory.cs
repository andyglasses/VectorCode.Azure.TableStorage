using Azure.Data.Tables;
using System.Collections.Concurrent;

namespace VectorCode.Azure.TableStorage;

/// <summary>
/// Factory for creating TableClients.
/// </summary>
/// <param name="connectionString"></param>
/// <param name="tableClientCreator"></param>
public class TableClientFactory(string connectionString, ITableClientCreator tableClientCreator)
{
  private ConcurrentDictionary<string, TableClient> _tableClients = new ConcurrentDictionary<string, TableClient>();

  /// <summary>
  /// Gets an instance of a TableClient for the given table name.
  /// </summary>
  /// <param name="tableName">the table to get</param>
  /// <param name="cancellationToken"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentException"></exception>
  /// <exception cref="InvalidOperationException"></exception>
  public async Task<TableClient> GetTableClient(string tableName, CancellationToken cancellationToken)
  {
    if (_tableClients.TryGetValue(tableName, out TableClient? value))
    {
      return value;
    }

    if (string.IsNullOrWhiteSpace(tableName))
    {
      throw new ArgumentException("Table name cannot be blank", nameof(tableName));
    }

    if (string.IsNullOrWhiteSpace(connectionString))
    {
      throw new InvalidOperationException("Table connection string cannot be blank");
    }


    var newClient = tableClientCreator.CreateTableClient(tableName, connectionString);
    await newClient.CreateIfNotExistsAsync(cancellationToken);
    _tableClients.TryAdd(tableName, newClient);

    return newClient;
  }
}

