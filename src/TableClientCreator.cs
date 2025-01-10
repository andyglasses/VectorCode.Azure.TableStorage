using Azure.Data.Tables;

namespace VectorCode.Azure.TableStorage;

/// <summary>
/// Interface for creating table clients to allow Mocking.
/// </summary>
public interface ITableClientCreator
{
  /// <summary>
  /// Creates a table client.
  /// </summary>
  /// <param name="tableName">Name of the table to connect to</param>
  /// <param name="connectionString">Connection string to use</param>
  /// <returns></returns>
  TableClient CreateTableClient(string tableName, string connectionString);
}

/// <summary>
/// Use this class to create table clients when not testing
/// </summary>
public class DefaultTableClientCreator : ITableClientCreator
{
  /// <inheritdoc />
  public TableClient CreateTableClient(string tableName, string connectionString)
  {
    return new TableClient(connectionString, tableName);
  }
}
