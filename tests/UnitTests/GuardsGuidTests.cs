namespace ThrowGuard.UnitTests
{
	[TestClass]
	public class GuardsGuidTests
	{
		[TestMethod]
		public void IfEmpty_NotEmpty_Shd_NotThrow()
		{
			var arg = Guid.NewGuid();
			var exp = arg;
			var ret = Guid.Empty;

			var action = () => ret = Throw.IfEmpty(arg);

			action.Should().NotThrow();
			Assert.AreEqual(exp, ret);
		}

		[TestMethod]
		public void IfEmpty_Empty_Shd_Throw_CustEx()
		{
			var arg = Guid.Empty;
			var exp = arg;
			var ret = Guid.Empty;
			var msg = "Guid-Empty error.";

			var action = () => ret = Throw.IfEmpty(
				arg, ex: argName => new ApplicationException(msg));

			action.Should()
				.ThrowExactly<ApplicationException>()
				.WithMessage($"{msg}*")
				;

			Assert.AreEqual(exp, ret);
		}

		[TestMethod]
		public void IfEmpty_Empty_Shd_Throw_w_CustMsg()
		{
			var arg = Guid.Empty;
			var exp = arg;
			var ret = Guid.Empty;
			var msg = "Guid-Empty error.";

			var action = () => ret = Throw.IfEmpty(arg, msg);

			action.Should()
				.ThrowExactly<ArgumentException>()
				.WithMessage($"{msg}*")
				;

			Assert.AreEqual(exp, ret);
		}

		[TestMethod]
		public void IfEmpty_Empty_Shd_Throw_w_DefMsg()
		{
			var arg = Guid.Empty;
			var exp = arg;
			var ret = Guid.Empty;
			var msg = SR.Err_GuidEmpty;

			var action = () => ret = Throw.IfEmpty(arg);

			action.Should()
				.ThrowExactly<ArgumentException>()
				.WithMessage($"{msg}*")
				;

			Assert.AreEqual(exp, ret);
		}

		//--

		[TestMethod]
		public void IfEmptyWhen_NotEmpty_WhenFalse_Shd_NotThrow()
		{
			var arg = Guid.NewGuid();
			var con = false;
			var exp = arg;
			var ret = Guid.Empty;

			var action = () => ret = Throw.IfEmpty(arg, () => con);

			action.Should().NotThrow();
			Assert.AreEqual(exp, ret);
		}

		[TestMethod]
		public void IfEmptyWhen_NotEmpty_WhenTrue_Shd_NotThrow()
		{
			var arg = Guid.NewGuid();
			var con = true;
			var exp = arg;
			var ret = Guid.Empty;

			var action = () => ret = Throw.IfEmpty(arg, () => con);

			action.Should().NotThrow();
			Assert.AreEqual(exp, ret);
		}

		[TestMethod]
		public void IfEmptyWhen_Empty_WhenFalse_Shd_NotThrow()
		{
			var arg = Guid.Empty;
			var con = false;
			var exp = arg;
			var ret = Guid.Empty;

			var action = () => ret = Throw.IfEmpty(arg, () => con);

			action.Should().NotThrow();
			Assert.AreEqual(exp, ret);
		}


		[TestMethod]
		public void IfEmptyWhen_Empty_WhenTrue_Shd_Throw_CustEx()
		{
			var arg = Guid.Empty;
			var con = true;
			var exp = arg;
			var ret = Guid.Empty;
			var msg = "Guid-Empty error.";

			var action = () => ret = Throw.IfEmpty(
				arg, () => con, ex: argName => new ApplicationException(msg));

			action.Should()
				.ThrowExactly<ApplicationException>()
				.WithMessage($"{msg}*")
				;

			Assert.AreEqual(exp, ret);
		}

		[TestMethod]
		public void IfEmptyWhen_Empty_WhenTrue_Shd_Throw_w_CustMsg()
		{
			var arg = Guid.Empty;
			var con = true;
			var exp = arg;
			var ret = Guid.Empty;
			var msg = "Guid-Empty error.";

			var action = () => ret = Throw.IfEmpty(arg, () => con, msg);

			action.Should()
				.ThrowExactly<ArgumentException>()
				.WithMessage($"{msg}*")
				;

			Assert.AreEqual(exp, ret);
		}

		[TestMethod]
		public void IfEmptyWhen_Empty_WhenTrue_Shd_Throw_w_DefMsg()
		{
			var arg = Guid.Empty;
			var con = true;
			var exp = arg;
			var ret = Guid.Empty;
			var msg = SR.Err_GuidEmpty;

			var action = () => ret = Throw.IfEmpty(arg, () => con);

			action.Should()
				.ThrowExactly<ArgumentException>()
				.WithMessage($"{msg}*")
				;

			Assert.AreEqual(exp, ret);
		}

		//--

		[TestMethod]
		public void IfNullOrEmpty_NotNull_NotEmpty_Shd_NotThrow()
		{
			var arg = Guid.NewGuid();
			var exp = arg;
			var ret = Guid.Empty;

			var action = () => ret = Throw.IfNullOrEmpty(arg);

			action.Should().NotThrow();
			Assert.AreEqual(exp, ret);
		}


		[TestMethod]
		public void IfNullOrEmpty_NotNull_Empty_ThrowsCustEx()
		{
			var arg = Guid.Empty;
			var exp = arg;
			var ret = Guid.Empty;
			var msg = "Guid-Empty error.";

			var action = () => ret = Throw.IfNullOrEmpty(
				arg, ex: argName => new ApplicationException(msg));

			action.Should()
				.ThrowExactly<ApplicationException>()
				.WithMessage($"{msg}*")
				;

			Assert.AreEqual(exp, ret);
		}

		[TestMethod]
		public void IfNullOrEmpty_NotNull_Empty_Shd_Throw_w_CustMsg()
		{
			var arg = Guid.Empty;
			var exp = arg;
			var ret = Guid.Empty;
			var msg = "Guid-Empty error.";

			var action = () => ret = Throw.IfNullOrEmpty(arg, msg);

			action.Should()
				.ThrowExactly<ArgumentException>()
				.WithMessage($"{msg}*")
				;

			Assert.AreEqual(exp, ret);
		}

		[TestMethod]
		public void IfNullOrEmpty_NotNull_Empty_ThrowsDefMsg()
		{
			var arg = Guid.Empty;
			var exp = arg;
			var ret = Guid.Empty;
			var msg = SR.Err_GuidEmpty;

			var action = () => ret = Throw.IfNullOrEmpty(arg);

			action.Should()
				.ThrowExactly<ArgumentException>()
				.WithMessage($"{msg}*")
				;

			Assert.AreEqual(exp, ret);
		}


		[TestMethod]
		public void IfNullOrEmpty_Null_ThrowsCustEx()
		{
			Guid? arg = null;
			Guid? exp = arg;
			Guid? ret = null;
			var msg = "Guid null error.";

			var action = () => ret = Throw.IfNullOrEmpty(
				arg, ex: argName => new ApplicationException(msg));

			action.Should()
				.ThrowExactly<ApplicationException>()
				.WithMessage($"{msg}*")
				;

			Assert.AreEqual(exp, ret);
		}

		[TestMethod]
		public void IfNullOrEmpty_Null_Shd_Throw_w_CustMsg()
		{
			Guid? arg = null;
			Guid? exp = arg;
			Guid? ret = null;
			var msg = "Guid null error.";

			var action = () => ret = Throw.IfNullOrEmpty(arg, msg);

			action.Should()
				.ThrowExactly<ArgumentNullException>()
				.WithMessage($"{msg}*")
				;

			Assert.AreEqual(exp, ret);
		}

		[TestMethod]
		public void IfNullOrEmpty_Null_ThrowsDefMsg()
		{
			Guid? arg = null;
			Guid? exp = arg;
			Guid? ret = null;
			var msg = SR.Err_NullArg;

			var action = () => ret = Throw.IfNullOrEmpty(arg);

			action.Should()
				.ThrowExactly<ArgumentNullException>()
				.WithMessage($"{msg}*")
				;

			Assert.AreEqual(exp, ret);
		}

		//--

		[TestMethod]
		public void IfNullOrEmptyWhen_NotNull_WhenFalse_Shd_NotThrow()
		{
			Guid? arg = Guid.NewGuid();
			var con = false;
			Guid? exp = arg;
			Guid? ret = null;

			var action = () => ret = Throw.IfNullOrEmpty(arg, () => con);

			action.Should().NotThrow();
			Assert.AreEqual(exp, ret);
		}

		[TestMethod]
		public void IfNullOrEmptyWhen_NotNull_WhenTrue_Shd_NotThrow()
		{
			Guid? arg = Guid.NewGuid();
			var con = true;
			Guid? exp = arg;
			Guid? ret = null;

			var action = () => ret = Throw.IfNullOrEmpty(arg, () => con);

			action.Should().NotThrow();
			Assert.AreEqual(exp, ret);
		}

		[TestMethod]
		public void IfNullOrEmptyWhen_Null_WhenFalse_Shd_NotThrow()
		{
			Guid? arg = null;
			var con = false;
			Guid? exp = arg;
			Guid? ret = null;

			var action = () => ret = Throw.IfNullOrEmpty(arg, () => con);

			action.Should().NotThrow();
			Assert.AreEqual(exp, ret);
		}


		[TestMethod]
		public void IfNullOrEmptyWhen_Null_WhenTrue_Shd_Throw_CustEx()
		{
			Guid? arg = null;
			var con = true;
			Guid? exp = arg;
			Guid? ret = null;
			var msg = "Guid null error.";

			var action = () => ret = Throw.IfNullOrEmpty(
				arg, () => con, ex: argName => new ApplicationException(msg));

			action.Should()
				.ThrowExactly<ApplicationException>()
				.WithMessage($"{arg}*")
				;

			Assert.AreEqual(exp, ret);
		}

		[TestMethod]
		public void IfNullOrEmptyWhen_Null_WhenTrue_Shd_Throw_w_CustMsg()
		{
			Guid? arg = null;
			var con = true;
			Guid? exp = arg;
			Guid? ret = null;
			var msg = "Guid null error.";

			var action = () => ret = Throw.IfNullOrEmpty(arg, () => con, msg);

			action.Should()
				.ThrowExactly<ArgumentNullException>()
				.WithMessage($"{arg}*")
				;

			Assert.AreEqual(exp, ret);
		}

		[TestMethod]
		public void IfNullOrEmptyWhen_Null_WhenTrue_Shd_Throw_w_DefMsg()
		{
			Guid? arg = null;
			var con = true;
			Guid? exp = arg;
			Guid? ret = null;
			var msg = SR.Err_NullArg;

			var action = () => ret = Throw.IfNullOrEmpty(arg, () => con);

			action.Should()
				.ThrowExactly<ArgumentNullException>()
				.WithMessage($"{arg}*")
				;

			Assert.AreEqual(exp, ret);
		}
	}
}
