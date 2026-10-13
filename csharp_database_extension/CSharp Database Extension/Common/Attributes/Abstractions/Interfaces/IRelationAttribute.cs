using CSharp_Database_Extension.Entities.Abstractions.Interfaces;

namespace CSharp_Database_Extension.Common.Attributes.Abstractions.Interfaces;

/// <summary>
///     Represents an <see cref="IEntity"/> relation attribute.
/// </summary>
public interface IRelationAttribute {
    /// <summary>
    ///     Relation name.
    /// </summary>
    string? Name { get; set; }

    /// <summary>
    ///     Wheter this relation references an entity on a different database.
    /// </summary>
    bool IsCrossDatabase { get; set; }
}
