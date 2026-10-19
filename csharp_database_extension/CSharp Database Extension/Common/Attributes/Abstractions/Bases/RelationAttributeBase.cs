using CSharp_Database_Extension.Common.Attributes.Abstractions.Interfaces;

namespace CSharp_Database_Extension.Common.Attributes.Abstractions.Bases;

/// <inheritdoc cref="IRelationAttribute"/>
public abstract class RelationAttributeBase
     : Attribute, IRelationAttribute {

    /// <inheritdoc/>
    public string? Name { get; set; }

    /// <inheritdoc/>
    public bool IsCrossDatabase { get; set; }

    /// <summary>
    ///     Creates a new instance.
    /// </summary>
    /// <param name="name">
    ///     Relation's name.
    /// </param>
    /// <param name="isCrossDatabase">
    ///     Whether the relation references an entity on a different database.
    /// </param>
    public RelationAttributeBase(string? name = null, bool isCrossDatabase = false) {
        Name = name;
        IsCrossDatabase = isCrossDatabase;
    }
}
