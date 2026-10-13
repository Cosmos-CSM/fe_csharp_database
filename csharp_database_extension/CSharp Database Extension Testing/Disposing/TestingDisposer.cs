using CSharp_Database_Extension_Testing.Disposing.Abstractions.Bases;

namespace CSharp_Database_Extension_Testing.Disposing;

/// <inheritdoc cref="TestingDisposerBase"/>
public class TestingDisposer
    : TestingDisposerBase {

    /// <summary>
    ///     Creates a new instance.
    /// </summary>
    /// <param name="dbFactories">
    ///     Database factories used during testing data creation for data disposition.
    /// </param>
    public TestingDisposer(params DatabaseFactory[] dbFactories)
        : base(dbFactories) {
    }
}
