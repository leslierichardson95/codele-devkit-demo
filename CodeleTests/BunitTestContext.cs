using Bunit;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodeleTests;

/// <summary>
/// Test context wrapper for bUnit.
/// Read more about using <see cref="BunitTestContext"/> <seealso href="https://bunit.dev/docs/getting-started/writing-tests.html#remove-boilerplate-code-from-tests">here</seealso>.
/// </summary>
public abstract class BunitTestContext : TestContextWrapper
{
	[TestInitialize]
	public void Setup() => TestContext = new Bunit.TestContext();

	[TestCleanup]
	public void TearDown() => TestContext?.Dispose();
}
