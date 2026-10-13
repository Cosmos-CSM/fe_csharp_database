using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;
using System.Text.Json.Serialization;

using CSharp_Database_Extension.Entities.Validation.Abstractions.Bases;
using CSharp_Database_Extension.Entities.Validation.Models;

using CSharp_Extension.Common.Abstractions.Bases;

namespace CSharp_Database_Extension;

/// <inheritdoc cref="IEntity{TStatus, TUser}"/>
public abstract partial class EntityBase<TStatus, TUser>
    : EntityBase, IEntity<TStatus, TUser>
    where TStatus : class, IEntity<TStatus, TUser>
    where TUser : class, IEntity<TStatus, TUser> {

    /// <inheritdoc/>
    public TStatus SystemStatus { get; set; } = default!;

    /// <inheritdoc/>
    public TUser EntityOwner { get; set; } = default!;
}

/// <inheritdoc cref="IEntity"/>
public abstract partial class EntityBase
    : ObjectBase, IEntity {

    #region Server Side Properties

    /// <inheritdoc/>
    [NotMapped, JsonPropertyOrder(0)]
    public string Discriminator { get; init; }

    /// <inheritdoc/>
    [NotMapped, JsonIgnore]
    public abstract Type Database { get; init; }

    #endregion

    /// <inheritdoc/>
    public long Id { get; set; }

    /// <inheritdoc/>
    public string Name { get; set; } = string.Empty;

    /// <inheritdoc/>
    public string? Description { get; set; }

    /// <inheritdoc/>
    public DateTime Timestamp { get; set; } = DateTime.UtcNow;

    /// <summary>
    ///     Creates a new instance.
    /// </summary>
    public EntityBase() {
        Discriminator = $"{GetType().GUID}";
    }

    /// <inheritdoc/>
    public void EvaluateData() {
        foreach (PropertyInfo property in GetType().GetProperties()) {

            IEnumerable<ValidatorBase> attributes = property.GetCustomAttributes<ValidatorBase>();
            if (!attributes.Any())
                return;

            foreach (ValidatorBase validator in attributes) {
                validator.Validate(this);
            }
        }
    }

    /// <inheritdoc/>
    public EntityEvaluationFailure[] EvaluateModel() {

        Type modelType = GetType();
        PropertyInfo[] modelProps = modelType.GetProperties();

        List<EntityEvaluationFailure> failures = [];
        foreach (PropertyInfo property in modelProps) {

            IEnumerable<ValidatorBase> attributes = property.GetCustomAttributes<ValidatorBase>();
            if (!attributes.Any())
                continue;

            foreach (ValidatorBase validator in attributes) {
                if (!validator.ValidateType(modelType)) {
                    failures.Add(
                            new EntityEvaluationFailure {
                                Property = property,
                                Validator = validator,
                                Type = EntityEvaluationFailures.WRONG_VALIDATOR_TYPE
                            }
                        );
                }
            }
        }

        return [.. failures];
    }
}