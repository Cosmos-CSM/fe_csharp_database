using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

using CSharp_Database_Extension.Common.Attributes;
using CSharp_Database_Extension.Entities.Validation.Models;

using CSharp_Extension.Convertion.Abstractions.Interfaces;

#pragma warning disable IDE0130 // Namespace does not match folder structure
namespace CSharp_Database_Extension;
#pragma warning restore IDE0130 // Namespace does not match folder structure


/// <summary>
///    Represents a business entity model with status relation.
/// </summary>
/// <typeparam name="TStatus">
///     Type of the status entity model.
/// </typeparam>
/// <typeparam name="TUser">
///     Type of the user entity model.
/// </typeparam>
public partial interface IEntity<TStatus, TUser>
    : IEntity
    where TStatus : class, IEntity<TStatus, TUser>
    where TUser : class, IEntity<TStatus, TUser> {

    /// <summary>
    ///     System level entity status. 
    /// </summary>
    [NotMapped, EntityRelation(IsCrossDatabase = true)]
    TStatus SystemStatus { get; set; }

    /// <summary>
    ///     Last user that owned this entity.
    /// </summary>
    [NotMapped, EntityRelation(IsCrossDatabase = true)]
    TUser EntityOwner { get; set; }
}

/// <summary>
///     Represents a business entity model.
/// </summary>
public partial interface IEntity
    : IConverterVariant {

    /// <summary>
    ///     Database that owns this entity model.
    /// </summary>
    [JsonIgnore, NotMapped]
    Type Database { get; init; }

    /// <summary>
    ///     Database identifier.
    /// </summary>
    long Id { get; set; }

    /// <summary>
    ///     Entity name.
    /// </summary>
    /// <remarks>
    ///     Length min 1, max 200.
    /// </remarks>
    [StringLength(200, MinimumLength = 1)]
    string Name { get; set; }

    /// <summary>
    ///     Entity description.
    /// </summary>
    string? Description { get; set; }

    /// <summary>
    ///     Last entity change timestamp.
    /// </summary>
    DateTime Timestamp { get; set; }

    /// <summary>
    ///     Evaluates current entity data integrity at Read or Write operations in database. This prevents possible user level direct databases
    ///     modifications.
    /// </summary>
    void EvaluateData();

    /// <summary>
    ///     Evaluate that entity model is correctly configured.
    /// </summary>
    /// <returns>
    ///     Evaluation failures.
    /// </returns>
    EntityEvaluationFailure[] EvaluateModel();
}