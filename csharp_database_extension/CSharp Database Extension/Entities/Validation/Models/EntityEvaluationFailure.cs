using System.Reflection;

using CSharp_Database_Extension.Entities.Validation.Abstractions.Bases;

namespace CSharp_Database_Extension.Entities.Validation.Models;

/// <summary>
///     Represents types of <see cref="EntityEvaluationFailure"/>.
/// </summary>
public enum EntityEvaluationFailures {
    /// <summary>
    ///     When a property validator has unsupported type for that property.
    /// </summary>
    WRONG_VALIDATOR_TYPE,
}

/// <summary>
///     Represents an entity validation result data.
/// </summary>
public record EntityEvaluationFailure {

    /// <summary>
    ///     Property caught in validation process.
    /// </summary>
    public PropertyInfo Property { get; init; } = default!;

    /// <summary>
    ///     Validator that was used to validate the property.
    /// </summary>
    public ValidatorBase Validator { get; init; } = default!;

    /// <summary>
    ///     Type of validation result.
    /// </summary>
    public EntityEvaluationFailures Type { get; init; } = default!;

}
