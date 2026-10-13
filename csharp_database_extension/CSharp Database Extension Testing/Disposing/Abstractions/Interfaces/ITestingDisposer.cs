using CSharp_Database_Extension;

using CSharp_Extension.Common.Abstractions.Interfaces;

namespace CSharp_Database_Extension_Testing.Disposing.Abstractions.Interfaces;

/// <summary>
///     Represents a testing data disposer context handler.
/// </summary>
public interface ITestingDisposer
    : IDisposer<IEntity> {
}
