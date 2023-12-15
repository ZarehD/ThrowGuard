namespace ThrowGuard.UnitTests
{
	[TestClass]
	public class GuardsTypeTests
	{
		[TestMethod]
		public void IfTypeEquals_AreEqual_Shd_Throw()
		{
			var arg = 0;
			var other = typeof(int);
			var msg = SR.Err_AppException;

			var action = () => Throw.IfTypeEquals(
				arg, other, argName => new ApplicationException(msg));

			action
				.Should().ThrowExactly<ApplicationException>()
				.WithMessage(msg)
				;
		}

		[TestMethod]
		public void IfTypeEquals_NotEqual_Shd_Not_Throw()
		{
			var arg = 0;
			var other = typeof(string);
			var msg = SR.Err_AppException;

			var action = () => Throw.IfTypeEquals(
				arg, other, argName => new ApplicationException(msg));

			action.Should().NotThrow();
		}

		//--

		[TestMethod]
		public void IfTypeNotEquals_AreEqual_Shd_Not_Throw()
		{
			var arg = 0;
			var other = typeof(int);
			var msg = SR.Err_AppException;

			var action = () => Throw.IfTypeNotEquals(
				arg, other, argName => new ApplicationException(msg));

			action.Should().NotThrow();
		}

		[TestMethod]
		public void IfTypeNotEquals_NotEqual_Shd_Throw()
		{
			var arg = 0;
			var other = typeof(string);
			var msg = SR.Err_AppException;

			var action = () => Throw.IfTypeNotEquals(
				arg, other, argName => new ApplicationException(msg));

			action
				.Should().ThrowExactly<ApplicationException>()
				.WithMessage(msg)
				;
		}
	}
}
