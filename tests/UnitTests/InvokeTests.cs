namespace ThrowGuard.Tests
{
	[TestClass]
	public class InvokeTests
	{
		[TestMethod]
		[DataRow(true, DisplayName = "Should-Execute-Action")]
		[DataRow(false, DisplayName = "Should-Not-Execute-Action")]
		public void Invoke_Test(bool condition)
		{
			// arrange...
			bool predicate() => condition;
			var actionCalled = false;

			// act...
			Invoke.When(predicate, () => actionCalled = true);

			// assert...
			Assert.AreEqual(condition, actionCalled);
		}
	}
}
