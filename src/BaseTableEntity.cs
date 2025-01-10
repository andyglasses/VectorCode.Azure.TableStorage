using Azure.Data.Tables;
using Azure;

namespace VectorCode.Azure.TableStorage;

/// <summary>
/// Base record for all table entities.
/// </summary>
public abstract record BaseTableEntity : ITableEntity
{
  /// <inheritdoc />
  public required string PartitionKey { get; set; }

  /// <inheritdoc />
  public required string RowKey { get; set; }

  /// <inheritdoc />
  public DateTimeOffset? Timestamp { get; set; }

  /// <inheritdoc />
  public ETag ETag { get; set; }
}
