namespace ThrowGuard.UnitTests
{
	[TestClass]
	public class GuardsObjectTests
	{
		[TestMethod]
		public void IfNull_NullInt_HasVal_Shd_NotThrow()
		{
			int? arg = 5;
			int? ret = null;
			var msg = SR.Err_NullArg;

			var action = () => ret = Throw.IfNull(arg);

			action.Should().NotThrow();
			Assert.AreEqual(arg, ret);
		}

		[TestMethod]
		public void IfNull_NullInt_IfNull_Shd_Throw_CustEx()
		{
			int? arg = null;
			int? ret = null;
			var msg = SR.Err_BadArg;

			var action = () => ret = Throw.IfNull(
				arg, ex: argName => new ArgumentException(msg, argName));

			action.Should()
				.ThrowExactly<ArgumentException>()
				.WithMessage($"{msg}*")
				.And.ParamName.Should()
				.BeEquivalentTo(nameof(arg))
				;

			Assert.IsNull(ret);
		}

		[TestMethod]
		public void IfNull_NullInt_IfNull_Shd_Throw_w_CustMsg()
		{
			int? arg = null;
			int? ret = null;
			var msg = "Null ref error.";

			var action = () => ret = Throw.IfNull(arg, msg);

			action.Should()
				.ThrowExactly<ArgumentNullException>()
				.WithMessage($"{msg}*")
				.And.ParamName.Should()
				.BeEquivalentTo(nameof(arg))
				;

			Assert.IsNull(ret);
		}

		[TestMethod]
		public void IfNull_NullInt_IfNull_Shd_Throw_w_DefMsg()
		{
			int? arg = null;
			int? ret = null;
			var msg = SR.Err_NullArg;

			var action = () => ret = Throw.IfNull(arg);

			action.Should()
				.ThrowExactly<ArgumentNullException>()
				.WithMessage($"{msg}*")
				.And.ParamName.Should()
				.BeEquivalentTo(nameof(arg))
				;

			Assert.IsNull(ret);
		}


		[TestMethod]
		public void IfNull_String_HasVal_Shd_NotThrow()
		{
			string? arg = "test";
			string? ret = null;

			var action = () => ret = Throw.IfNull(arg);

			action.Should().NotThrow();
			Assert.AreEqual(ret, arg, true);
		}

		[TestMethod]
		public void IfNull_String_IfNull_Shd_Throw_CustEx()
		{
			string? arg = null;
			string? ret = null;
			var msg = SR.Err_BadArg;

			var action = () => ret = Throw.IfNull(
				arg, ex: argName => new ArgumentException(msg, argName));

			action.Should()
				.ThrowExactly<ArgumentException>()
				.WithMessage($"{msg}*")
				.And.ParamName.Should()
				.BeEquivalentTo(nameof(arg))
				;

			Assert.IsNull(ret);
		}

		[TestMethod]
		public void IfNull_String_IfNull_Shd_Throw_w_CustMsg()
		{
			string? arg = null;
			string? ret = null;
			var msg = "Null ref error.";

			var action = () => ret = Throw.IfNull(arg, msg);

			action.Should()
				.ThrowExactly<ArgumentNullException>()
				.WithMessage($"{msg}*")
				.And.ParamName.Should()
				.BeEquivalentTo(nameof(arg))
				;

			Assert.IsNull(ret);
		}

		[TestMethod]
		public void IfNull_String_IfNull_Shd_Throw_w_DefMsg()
		{
			string? arg = null;
			string? ret = null;
			var msg = SR.Err_NullArg;

			var action = () => ret = Throw.IfNull(arg);

			action.Should()
				.ThrowExactly<ArgumentNullException>()
				.WithMessage($"{msg}*")
				.And.ParamName.Should()
				.BeEquivalentTo(nameof(arg))
				;

			Assert.IsNull(ret);
		}

		//--

		[TestMethod]
		public void IfNull_NullInt_HasVal_WhenFalse_Shd_NotThrow()
		{
			int? arg = 5;
			int? ret = null;
			var flg = false;

			var action = () => ret = Throw.IfNull(arg, () => flg);

			action.Should().NotThrow();
			Assert.AreEqual(arg, ret);
		}

		[TestMethod]
		public void IfNull_NullInt_HasVal_WhenTrue_Shd_NotThrow()
		{
			int? arg = 5;
			int? ret = null;
			var flg = true;

			var action = () => ret = Throw.IfNull(arg, () => flg);

			action.Should().NotThrow();
			Assert.AreEqual(arg, ret);
		}

		[TestMethod]
		public void IfNull_NullInt_IfNull_WhenFalse_Shd_NotThrow()
		{
			int? arg = null;
			int? ret = null;
			var flg = false;

			var action = () => ret = Throw.IfNull(arg, () => flg);

			action.Should().NotThrow();
			Assert.IsNull(ret);
		}

		[TestMethod]
		public void IfNull_NullInt_IfNull_WhenTrue_Shd_Throw_CustEx()
		{
			int? arg = null;
			int? ret = null;
			var flg = true;
			var msg = "Null ref error.";

			var action = () => ret = Throw.IfNull(
				arg, () => flg,
				ex: argName => new ApplicationException(msg));

			action.Should()
				.ThrowExactly<ApplicationException>()
				.WithMessage($"{msg}*")
				;

			Assert.IsNull(ret);
		}

		[TestMethod]
		public void IfNull_NullInt_IfNull_WhenTrue_Shd_Throw_w_CustMsg()
		{
			int? arg = null;
			int? ret = null;
			var flg = true;
			var msg = "Null ref error.";

			var action = () => ret = Throw.IfNull(arg, () => flg, msg);

			action.Should()
				.ThrowExactly<ArgumentNullException>()
				.WithMessage($"{msg}*")
				.And.ParamName.Should()
				.BeEquivalentTo(nameof(arg))
				;

			Assert.IsNull(ret);
		}

		[TestMethod]
		public void IfNull_NullInt_IfNull_WhenTrue_Shd_Throw_w_DefMsg()
		{
			int? arg = null;
			int? ret = null;
			var flg = true;
			var msg = SR.Err_NullArg;

			var action = () => ret = Throw.IfNull(arg, () => flg);

			action.Should()
				.ThrowExactly<ArgumentNullException>()
				.WithMessage($"{msg}*")
				.And.ParamName.Should()
				.BeEquivalentTo(nameof(arg))
				;

			Assert.IsNull(ret);
		}


		[TestMethod]
		public void IfNull_String_HasVal_WhenFalse_Shd_NotThrow()
		{
			string? arg = "test";
			string? ret = null;
			var flg = false;

			var action = () => ret = Throw.IfNull(arg, () => flg);

			action.Should().NotThrow();
			Assert.AreEqual(arg, ret);
		}

		[TestMethod]
		public void IfNull_String_HasVal_WhenTrue_Shd_NotThrow()
		{
			string? arg = "test";
			string? ret = null;
			var flg = true;

			var action = () => ret = Throw.IfNull(arg, () => flg);

			action.Should().NotThrow();
			Assert.AreEqual(arg, ret);
		}

		[TestMethod]
		public void IfNull_String_IfNull_WhenFalse_Shd_NotThrow()
		{
			string? arg = null;
			string? ret = null;
			var flg = false;

			var action = () => ret = Throw.IfNull(arg, () => flg);

			action.Should().NotThrow();
			Assert.IsNull(ret);
		}

		[TestMethod]
		public void IfNull_String_IfNull_WhenTrue_Shd_Throw_CustEx()
		{
			string? arg = null;
			string? ret = null;
			var flg = true;
			var msg = "Null ref error.";

			var action = () => ret = Throw.IfNull(
				arg, () => flg,
				ex: argName => new ApplicationException(msg));

			action.Should()
				.ThrowExactly<ApplicationException>()
				.WithMessage($"{msg}*")
				;

			Assert.IsNull(ret);
		}

		[TestMethod]
		public void IfNull_String_IfNull_WhenTrue_Shd_Throw_w_CustMsg()
		{
			string? arg = null;
			string? ret = null;
			var flg = true;
			var msg = "Null ref error.";

			var action = () => ret = Throw.IfNull(arg, () => flg, msg);

			action.Should()
				.ThrowExactly<ArgumentNullException>()
				.WithMessage($"{msg}*")
				.And.ParamName.Should()
				.BeEquivalentTo(nameof(arg))
				;

			Assert.IsNull(ret);
		}

		[TestMethod]
		public void IfNull_String_IfNull_WhenTrue_Shd_Throw_w_DefMsg()
		{
			string? arg = null;
			string? ret = null;
			var flg = true;
			var msg = SR.Err_NullArg;

			var action = () => ret = Throw.IfNull(arg, () => flg);

			action.Should()
				.ThrowExactly<ArgumentNullException>()
				.WithMessage($"{msg}*")
				.And.ParamName.Should()
				.BeEquivalentTo(nameof(arg))
				;

			Assert.IsNull(ret);
		}
	}
}
