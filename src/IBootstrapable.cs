using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VectorCode.Azure.TableStorage;

/// <summary>
/// Interface for bootstrapping repositories.
/// </summary>
public interface IBootstrapable
{
  /// <summary>
  /// Bootstraps the repository.
  /// </summary>
  Task Bootstrap();
}
