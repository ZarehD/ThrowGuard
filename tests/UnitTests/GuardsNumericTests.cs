namespace ThrowGuard.UnitTests
{
	[TestClass]
	public class GuardsNumericTests
	{
		[TestMethod]
		public void IfZero_NotZero_Shd_NotThrow()
		{
			long arg = 123;
			long exp = arg;
			long ret = -1;

			var action = () => ret = Throw.IfZero(arg);

			action.Should().NotThrow();
			Assert.AreEqual(exp, ret);
		}


		[TestMethod]
		public void IfZero_Zero_Shd_Throw_CustEx()
		{
			long arg = 0;
			long exp = -1;
			long ret = -1;
			var msg = "Value is 0 error.";

			var action = () => ret = Throw.IfZero(
				arg, ex: argName => new ApplicationException(argName + msg));

			action.Should()
				.ThrowExactly<ApplicationException>()
				.WithMessage($"{nameof(arg)}{msg}*")
				;

			Assert.AreEqual(exp, ret);
		}

		[TestMethod]
		public void IfZero_Zero_Shd_Throw_w_CustMsg()
		{
			long arg = 0;
			long exp = -1;
			long ret = -1;
			var msg = "Value is 0 error.";

			var action = () => ret = Throw.IfZero(arg, msg);

			action.Should()
				.ThrowExactly<ArgumentException>()
				.WithMessage($"{msg}*")
				.And.ParamName.Should()
				.BeEquivalentTo(nameof(arg))
				;

			Assert.AreEqual(exp, ret);
		}

		[TestMethod]
		public void IfZero_Zero_Shd_Throw_w_DefMsg()
		{
			long arg = 0;
			long exp = -1;
			long ret = -1;
			var msg = SR.Err_Num_Zero;

			var action = () => ret = Throw.IfZero(arg);

			action.Should()
				.ThrowExactly<ArgumentException>()
				.WithMessage($"{msg}*")
				.And.ParamName.Should()
				.BeEquivalentTo(nameof(arg))
				;

			Assert.AreEqual(exp, ret);
		}

		//--

		[TestMethod]
		public void IfNotZero_Zero_Shd_NotThrow()
		{
			long arg = 0;
			long exp = arg;
			long ret = -1;

			var action = () => ret = Throw.IfNotZero(arg);

			action.Should().NotThrow();
			Assert.AreEqual(exp, ret);
		}


		[TestMethod]
		public void IfNotZero_NotZero_Shd_Throw_CustEx()
		{
			long arg = 123;
			long exp = -1;
			long ret = -1;
			var msg = "Value is not 0 error.";

			var action = () => ret = Throw.IfNotZero(
				arg, ex: argName => new ApplicationException(argName + msg));

			action.Should()
				.ThrowExactly<ApplicationException>()
				.WithMessage($"{nameof(arg)}{msg}*")
				;

			Assert.AreEqual(exp, ret);
		}

		[TestMethod]
		public void IfNotZero_NotZero_Shd_Throw_w_CustMsg()
		{
			long arg = 123;
			long exp = -1;
			long ret = -1;
			var msg = "Value is not 0 error.";

			var action = () => ret = Throw.IfNotZero(arg, msg);

			action.Should()
				.ThrowExactly<ArgumentException>()
				.WithMessage($"{msg}*")
				.And.ParamName.Should()
				.BeEquivalentTo(nameof(arg))
				;

			Assert.AreEqual(exp, ret);
		}

		[TestMethod]
		public void IfNotZero_NotZero_Shd_Throw_w_DefMsg()
		{
			long arg = 123;
			long exp = -1;
			long ret = -1;
			var msg = SR.Err_Num_NotZero;

			var action = () => ret = Throw.IfNotZero(arg);

			action.Should()
				.ThrowExactly<ArgumentException>()
				.WithMessage($"{msg}*")
				.And.ParamName.Should()
				.BeEquivalentTo(nameof(arg))
				;

			Assert.AreEqual(exp, ret);
		}

		//--

		[TestMethod]
		public void IfPositive_No_Shd_NotThrow()
		{
			long arg = 0;
			long exp = arg;
			long ret = -1;

			var action = () => ret = Throw.IfPositive(arg);

			action.Should().NotThrow();
			Assert.AreEqual(exp, ret);
		}


		[TestMethod]
		public void IfPositive_Yes_Shd_Throw_CustEx()
		{
			long arg = 123;
			long exp = -1;
			long ret = -1;
			var msg = "Value is positive error.";

			var action = () => ret = Throw.IfPositive(
				arg, ex: argName => new ApplicationException(argName + msg));

			action.Should()
				.ThrowExactly<ApplicationException>()
				.WithMessage($"{nameof(arg)}{msg}*")
				;

			Assert.AreEqual(exp, ret);
		}

		[TestMethod]
		public void IfPositive_Yes_Shd_Throw_w_CustMsg()
		{
			long arg = 123;
			long exp = -1;
			long ret = -1;
			var msg = "Value is positive error.";

			var action = () => ret = Throw.IfPositive(arg, msg);

			action.Should()
				.ThrowExactly<ArgumentException>()
				.WithMessage($"{msg}*")
				.And.ParamName.Should()
				.BeEquivalentTo(nameof(arg))
				;

			Assert.AreEqual(exp, ret);
		}

		[TestMethod]
		public void IfPositive_Yes_Shd_Throw_w_DefMsg()
		{
			long arg = 123;
			long exp = -1;
			long ret = -1;
			var msg = SR.Err_Num_Positive.SF(arg);

			var action = () => ret = Throw.IfPositive(arg);

			action.Should()
				.ThrowExactly<ArgumentException>()
				.WithMessage($"{msg}*")
				.And.ParamName.Should()
				.BeEquivalentTo(nameof(arg))
				;

			Assert.AreEqual(exp, ret);
		}

		//--

		[TestMethod]
		public void IfNotPositive_No_Shd_NotThrow()
		{
			long arg = 123;
			long exp = arg;
			long ret = -1;

			var action = () => ret = Throw.IfNotPositive(arg);

			action.Should().NotThrow();
			Assert.AreEqual(exp, ret);
		}


		[TestMethod]
		public void IfNotPositive_Yes_Shd_Throw_CustEx()
		{
			long arg = -123;
			long exp = -1;
			long ret = -1;
			var msg = "Value is not positive error.";

			var action = () => ret = Throw.IfNotPositive(
				arg, ex: argName => new ApplicationException(argName + msg));

			action.Should()
				.ThrowExactly<ApplicationException>()
				.WithMessage($"{nameof(arg)}{msg}*")
				;

			Assert.AreEqual(exp, ret);
		}

		[TestMethod]
		public void IfNotPositive_Yes_Shd_Throw_w_CustMsg()
		{
			long arg = -123;
			long exp = -1;
			long ret = -1;
			var msg = "Value is not positive error.";

			var action = () => ret = Throw.IfNotPositive(arg, msg);

			action.Should()
				.ThrowExactly<ArgumentException>()
				.WithMessage($"{msg}*")
				.And.ParamName.Should()
				.BeEquivalentTo(nameof(arg))
				;

			Assert.AreEqual(exp, ret);
		}

		[TestMethod]
		public void IfNotPositive_Yes_Shd_Throw_w_DefMsg()
		{
			long arg = -123;
			long exp = -1;
			long ret = -1;
			var msg = SR.Err_Num_NotPositive.SF(arg);

			var action = () => ret = Throw.IfNotPositive(arg);

			action.Should()
				.ThrowExactly<ArgumentException>()
				.WithMessage($"{msg}*")
				.And.ParamName.Should()
				.BeEquivalentTo(nameof(arg))
				;

			Assert.AreEqual(exp, ret);
		}

		//--

		[TestMethod]
		public void IfNegative_No_Shd_NotThrow()
		{
			long arg = 0;
			long exp = arg;
			long ret = -1;

			var action = () => ret = Throw.IfNegative(arg);

			action.Should().NotThrow();
			Assert.AreEqual(exp, ret);
		}


		[TestMethod]
		public void IfNegative_Yes_Shd_Throw_CustEx()
		{
			long arg = -123;
			long exp = -1;
			long ret = -1;
			var msg = "Value is negative error.";

			var action = () => ret = Throw.IfNegative(
				arg, ex: argName => new ApplicationException(argName + msg));

			action.Should()
				.ThrowExactly<ApplicationException>()
				.WithMessage($"{nameof(arg)}{msg}*")
				;

			Assert.AreEqual(exp, ret);
		}

		[TestMethod]
		public void IfNegative_Yes_Shd_Throw_w_CustMsg()
		{
			long arg = -123;
			long exp = -1;
			long ret = -1;
			var msg = "Value is negative error.";

			var action = () => ret = Throw.IfNegative(arg, msg);

			action.Should()
				.ThrowExactly<ArgumentException>()
				.WithMessage($"{msg}*")
				.And.ParamName.Should()
				.BeEquivalentTo(nameof(arg))
				;

			Assert.AreEqual(exp, ret);
		}

		[TestMethod]
		public void IfNegative_Yes_Shd_Throw_w_DefMsg()
		{
			long arg = -123;
			long exp = -1;
			long ret = -1;
			var msg = SR.Err_Num_Negative.SF(arg);

			var action = () => ret = Throw.IfNegative(arg);

			action.Should()
				.ThrowExactly<ArgumentException>()
				.WithMessage($"{msg}*")
				.And.ParamName.Should()
				.BeEquivalentTo(nameof(arg))
				;

			Assert.AreEqual(exp, ret);
		}

		//--

		[TestMethod]
		public void IfNotNegative_No_Shd_NotThrow()
		{
			long arg = -123;
			long exp = arg;
			long ret = -1;

			var action = () => ret = Throw.IfNotNegative(arg);

			action.Should().NotThrow();
			Assert.AreEqual(exp, ret);
		}


		[TestMethod]
		public void IfNotNegative_Yes_Shd_Throw_CustEx()
		{
			long arg = 123;
			long exp = -1;
			long ret = -1;
			var msg = "Value is not negative error.";

			var action = () => ret = Throw.IfNotNegative(
				arg, ex: argName => new ApplicationException(argName + msg));

			action.Should()
				.ThrowExactly<ApplicationException>()
				.WithMessage($"{nameof(arg)}{msg}*")
				;

			Assert.AreEqual(exp, ret);
		}

		[TestMethod]
		public void IfNotNegative_Yes_Shd_Throw_w_CustMsg()
		{
			long arg = 123;
			long exp = -1;
			long ret = -1;
			var msg = "Value is not negative error.";

			var action = () => ret = Throw.IfNotNegative(arg, msg);

			action.Should()
				.ThrowExactly<ArgumentException>()
				.WithMessage($"{msg}*")
				.And.ParamName.Should()
				.BeEquivalentTo(nameof(arg))
				;

			Assert.AreEqual(exp, ret);
		}

		[TestMethod]
		public void IfNotNegative_Yes_Shd_Throw_w_DefMsg()
		{
			long arg = 123;
			long exp = -1;
			long ret = -1;
			var msg = SR.Err_Num_NotNegative.SF(arg);

			var action = () => ret = Throw.IfNotNegative(arg);

			action.Should()
				.ThrowExactly<ArgumentException>()
				.WithMessage($"{msg}*")
				.And.ParamName.Should()
				.BeEquivalentTo(nameof(arg))
				;

			Assert.AreEqual(exp, ret);
		}

		//--

		[TestMethod]
		public void IfEqualTo_No_Shd_NotThrow()
		{
			long arg = 123;
			long oth = 456;
			long exp = arg;
			long ret = 0;

			var action = () => ret = Throw.IfEqualTo(arg, oth);

			action.Should().NotThrow();
			Assert.AreEqual(exp, ret);
		}


		[TestMethod]
		public void IfEqualTo_Yes_Shd_Throw_CustEx()
		{
			long arg = 123;
			long oth = arg;
			long exp = 0;
			long ret = 0;
			var msg = "EqualTo error.";

			var action = () => ret = Throw.IfEqualTo(
				arg, oth, ex: argName => new ApplicationException(argName + msg));

			action.Should()
				.ThrowExactly<ApplicationException>()
				.WithMessage($"{nameof(arg)}{msg}*")
				;

			Assert.AreEqual(exp, ret);
		}

		[TestMethod]
		public void IfEqualTo_Yes_Shd_Throw_w_CustMsg()
		{
			long arg = 123;
			long oth = arg;
			long exp = 0;
			long ret = 0;
			var msg = "EqualTo error.";

			var action = () => ret = Throw.IfEqualTo(arg, oth, msg);

			action.Should()
				.ThrowExactly<ArgumentOutOfRangeException>()
				.WithMessage($"{msg}*")
				.And.ParamName.Should()
				.BeEquivalentTo(nameof(arg))
				;

			Assert.AreEqual(exp, ret);
		}

		[TestMethod]
		public void IfEqualTo_Yes_Shd_Throw_w_DefMsg()
		{
			long arg = 123;
			long oth = arg;
			long exp = 0;
			long ret = 0;
			var msg = SR.Err_Num_EqualTo.SF(arg);

			var action = () => ret = Throw.IfEqualTo(arg, oth);

			action.Should()
				.ThrowExactly<ArgumentOutOfRangeException>()
				.WithMessage($"{msg}*")
				.And.ParamName.Should()
				.BeEquivalentTo(nameof(arg))
				;

			Assert.AreEqual(exp, ret);
		}

		//--

		[TestMethod]
		public void IfNotEqualTo_No_Shd_NotThrow()
		{
			long arg = 123;
			long oth = arg;
			long exp = arg;
			long ret = 0;

			var action = () => ret = Throw.IfNotEqualTo(arg, oth);

			action.Should().NotThrow();
			Assert.AreEqual(exp, ret);
		}


		[TestMethod]
		public void IfNotEqualTo_Yes_Shd_Throw_CustEx()
		{
			long arg = 123;
			long oth = 456;
			long exp = 0;
			long ret = 0;
			var msg = "NotEqualTo error.";

			var action = () => ret = Throw.IfNotEqualTo(
				arg, oth, ex: argName => new ApplicationException(argName + msg));

			action.Should()
				.ThrowExactly<ApplicationException>()
				.WithMessage($"{nameof(arg)}{msg}*")
				;

			Assert.AreEqual(exp, ret);
		}

		[TestMethod]
		public void IfNotEqualTo_Yes_Shd_Throw_w_CustMsg()
		{
			long arg = 123;
			long oth = 456;
			long exp = 0;
			long ret = 0;
			var msg = "NotEqualTo error.";

			var action = () => ret = Throw.IfNotEqualTo(arg, oth, msg);

			action.Should()
				.ThrowExactly<ArgumentOutOfRangeException>()
				.WithMessage($"{msg}*")
				.And.ParamName.Should()
				.BeEquivalentTo(nameof(arg))
				;

			Assert.AreEqual(exp, ret);
		}

		[TestMethod]
		public void IfNotEqualTo_Yes_Shd_Throw_w_DefMsg()
		{
			long arg = 123;
			long oth = 456;
			long exp = 0;
			long ret = 0;
			var msg = SR.Err_Num_NotEqualTo.SF(arg, oth);

			var action = () => ret = Throw.IfNotEqualTo(arg, oth);

			action.Should()
				.ThrowExactly<ArgumentOutOfRangeException>()
				.WithMessage($"{msg}*")
				.And.ParamName.Should()
				.BeEquivalentTo(nameof(arg))
				;

			Assert.AreEqual(exp, ret);
		}

		//--

		[TestMethod]
		public void IfLessThan_IsGreater_Shd_NotThrow()
		{
			long arg = 123;
			long oth = 100;
			long exp = arg;
			long ret = 0;

			var action = () => ret = Throw.IfLessThan(arg, oth);

			action.Should().NotThrow();
			Assert.AreEqual(exp, ret);
		}


		[TestMethod]
		public void IfLessThan_IsSame_Shd_NotThrow()
		{
			long arg = 123;
			long oth = arg;
			long exp = arg;
			long ret = 0;

			var action = () => ret = Throw.IfLessThan(arg, oth);

			action.Should().NotThrow();
			Assert.AreEqual(exp, ret);
		}


		[TestMethod]
		public void IfLessThan_IsLess_Shd_Throw_CustEx()
		{
			long arg = 123;
			long oth = 456;
			long exp = 0;
			long ret = 0;
			var msg = "LessThan error.";

			var action = () => ret = Throw.IfLessThan(
				arg, oth, ex: argName => new ApplicationException(argName + msg));

			action.Should()
				.ThrowExactly<ApplicationException>()
				.WithMessage($"{nameof(arg)}{msg}*")
				;

			Assert.AreEqual(exp, ret);
		}

		[TestMethod]
		public void IfLessThan_IsLess_Shd_Throw_w_CustMsg()
		{
			long arg = 123;
			long oth = 456;
			long exp = 0;
			long ret = 0;
			var msg = "LessThan error.";

			var action = () => ret = Throw.IfLessThan(arg, oth, msg);

			action.Should()
				.ThrowExactly<ArgumentOutOfRangeException>()
				.WithMessage($"{msg}*")
				.And.ParamName.Should()
				.BeEquivalentTo(nameof(arg))
				;

			Assert.AreEqual(exp, ret);
		}

		[TestMethod]
		public void IfLessThan_IsLess_Shd_Throw_w_DefMsg()
		{
			long arg = 123;
			long oth = 456;
			long exp = 0;
			long ret = 0;
			var msg = SR.Err_Num_LessThan.SF(arg, oth);

			var action = () => ret = Throw.IfLessThan(arg, oth);

			action.Should()
				.ThrowExactly<ArgumentOutOfRangeException>()
				.WithMessage($"{msg}*")
				.And.ParamName.Should()
				.BeEquivalentTo(nameof(arg))
				;

			Assert.AreEqual(exp, ret);
		}

		//--

		[TestMethod]
		public void IfLessThanOrEqualTo_IsGreater_Shd_NotThrow()
		{
			long arg = 123;
			long oth = 100;
			long exp = arg;
			long ret = 0;

			var action = () => ret = Throw.IfLessThanOrEqualTo(arg, oth);

			action.Should().NotThrow();
			Assert.AreEqual(exp, ret);
		}


		[TestMethod]
		public void IfLessThanOrEqualTo_IsSame_Shd_Throw_CustEx()
		{
			long arg = 123;
			long oth = arg;
			long exp = 0;
			long ret = 0;
			var msg = "LessThanOrEqualTo error.";

			var action = () => ret = Throw.IfLessThanOrEqualTo(
				arg, oth, ex: argName => new ApplicationException(argName + msg));

			action.Should()
				.ThrowExactly<ApplicationException>()
				.WithMessage($"{nameof(arg)}{msg}*")
				;

			Assert.AreEqual(exp, ret);
		}

		[TestMethod]
		public void IfLessThanOrEqualTo_IsSame_Shd_Throw_w_CustMsg()
		{
			long arg = 123;
			long oth = arg;
			long exp = 0;
			long ret = 0;
			var msg = "LessThanOrEqualTo error.";

			var action = () => ret = Throw.IfLessThanOrEqualTo(arg, oth, msg);

			action.Should()
				.ThrowExactly<ArgumentOutOfRangeException>()
				.WithMessage($"{msg}*")
				.And.ParamName.Should()
				.BeEquivalentTo(nameof(arg))
				;

			Assert.AreEqual(exp, ret);
		}


		[TestMethod]
		public void IfLessThanOrEqualTo_IsSame_Shd_Throw_w_DefMsg()
		{
			long arg = 123;
			long oth = arg;
			long exp = 0;
			long ret = 0;
			var msg = SR.Err_Num_LessThanOrEqualTo.SF(arg, oth);

			var action = () => ret = Throw.IfLessThanOrEqualTo(arg, oth);

			action.Should()
				.ThrowExactly<ArgumentOutOfRangeException>()
				.WithMessage($"{msg}*")
				.And.ParamName.Should()
				.BeEquivalentTo(nameof(arg))
				;

			Assert.AreEqual(exp, ret);
		}

		[TestMethod]
		public void IfLessThanOrEqualTo_IsLess_Shd_Throw_CustEx()
		{
			long arg = 123;
			long oth = 456;
			long exp = 0;
			long ret = 0;
			var msg = "LessThanOrEqualTo error.";

			var action = () => ret = Throw.IfLessThanOrEqualTo(
				arg, oth, ex: argName => new ApplicationException(argName + msg));

			action.Should()
				.ThrowExactly<ApplicationException>()
				.WithMessage($"{nameof(arg)}{msg}*")
				;

			Assert.AreEqual(exp, ret);
		}

		[TestMethod]
		public void IfLessThanOrEqualTo_IsLess_Shd_Throw_w_CustMsg()
		{
			long arg = 123;
			long oth = 456;
			long exp = 0;
			long ret = 0;
			var msg = "LessThanOrEqualTo error.";

			var action = () => ret = Throw.IfLessThanOrEqualTo(arg, oth, msg);

			action.Should()
				.ThrowExactly<ArgumentOutOfRangeException>()
				.WithMessage($"{msg}*")
				.And.ParamName.Should()
				.BeEquivalentTo(nameof(arg))
				;

			Assert.AreEqual(exp, ret);
		}

		[TestMethod]
		public void IfLessThanOrEqualTo_IsLess_Shd_Throw_w_DefMsg()
		{
			long arg = 123;
			long oth = 456;
			long exp = 0;
			long ret = 0;
			var msg = SR.Err_Num_LessThanOrEqualTo.SF(arg, oth);

			var action = () => ret = Throw.IfLessThanOrEqualTo(arg, oth);

			action.Should()
				.ThrowExactly<ArgumentOutOfRangeException>()
				.WithMessage($"{msg}*")
				.And.ParamName.Should()
				.BeEquivalentTo(nameof(arg))
				;

			Assert.AreEqual(exp, ret);
		}

		//--

		[TestMethod]
		public void IfGreaterThan_IsLess_Shd_NotThrow()
		{
			long arg = 123;
			long oth = 456;
			long exp = arg;
			long ret = 0;

			var action = () => ret = Throw.IfGreaterThan(arg, oth);

			action.Should().NotThrow();
			Assert.AreEqual(exp, ret);
		}


		[TestMethod]
		public void IfGreaterThan_IsSame_Shd_NotThrow()
		{
			long arg = 123;
			long oth = arg;
			long exp = arg;
			long ret = 0;

			var action = () => ret = Throw.IfGreaterThan(arg, oth);

			action.Should().NotThrow();
			Assert.AreEqual(exp, ret);
		}


		[TestMethod]
		public void IfGreaterThan_IsGreater_Shd_Throw_CustEx()
		{
			long arg = 123;
			long oth = 100;
			long exp = 0;
			long ret = 0;
			var msg = "GreaterThan error.";

			var action = () => ret = Throw.IfGreaterThan(
				arg, oth, ex: argName => new ApplicationException(argName + msg));

			action.Should()
				.ThrowExactly<ApplicationException>()
				.WithMessage($"{nameof(arg)}{msg}*")
				;

			Assert.AreEqual(exp, ret);
		}

		[TestMethod]
		public void IfGreaterThan_IsGreater_Shd_Throw_w_CustMsg()
		{
			long arg = 123;
			long oth = 100;
			long exp = 0;
			long ret = 0;
			var msg = "GreaterThan error.";

			var action = () => ret = Throw.IfGreaterThan(arg, oth, msg);

			action.Should()
				.ThrowExactly<ArgumentOutOfRangeException>()
				.WithMessage($"{msg}*")
				.And.ParamName.Should()
				.BeEquivalentTo(nameof(arg))
				;

			Assert.AreEqual(exp, ret);
		}

		[TestMethod]
		public void IfGreaterThan_IsGreater_Shd_Throw_w_DefMsg()
		{
			long arg = 123;
			long oth = 100;
			long exp = 0;
			long ret = 0;
			var msg = SR.Err_Num_GreaterThan.SF(arg, oth);

			var action = () => ret = Throw.IfGreaterThan(arg, oth);

			action.Should()
				.ThrowExactly<ArgumentOutOfRangeException>()
				.WithMessage($"{msg}*")
				.And.ParamName.Should()
				.BeEquivalentTo(nameof(arg))
				;

			Assert.AreEqual(exp, ret);
		}

		//--

		[TestMethod]
		public void IfGreaterThanOrEqualTo_IsLess_Shd_NotThrow()
		{
			long arg = 123;
			long oth = 456;
			long exp = arg;
			long ret = 0;

			var action = () => ret = Throw.IfGreaterThanOrEqualTo(arg, oth);

			action.Should().NotThrow();
			Assert.AreEqual(exp, ret);
		}


		[TestMethod]
		public void IfGreaterThanOrEqualTo_IsSame_Shd_Throw_CustEx()
		{
			long arg = 123;
			long oth = arg;
			long exp = 0;
			long ret = 0;
			var msg = "GreaterThanOrEqualTo error.";

			var action = () => ret = Throw.IfGreaterThanOrEqualTo(
				arg, oth, ex: argName => new ApplicationException(argName + msg));

			action.Should()
				.ThrowExactly<ApplicationException>()
				.WithMessage($"{nameof(arg)}{msg}*")
				;

			Assert.AreEqual(exp, ret);
		}

		[TestMethod]
		public void IfGreaterThanOrEqualTo_IsSame_Shd_Throw_w_CustMsg()
		{
			long arg = 123;
			long oth = arg;
			long exp = 0;
			long ret = 0;
			var msg = "GreaterThanOrEqualTo error.";

			var action = () => ret = Throw.IfGreaterThanOrEqualTo(arg, oth, msg);

			action.Should()
				.ThrowExactly<ArgumentOutOfRangeException>()
				.WithMessage($"{msg}*")
				.And.ParamName.Should()
				.BeEquivalentTo(nameof(arg))
				;

			Assert.AreEqual(exp, ret);
		}

		[TestMethod]
		public void IfGreaterThanOrEqualTo_IsSame_Shd_Throw_w_DefMsg()
		{
			long arg = 123;
			long oth = arg;
			long exp = 0;
			long ret = 0;
			var msg = SR.Err_Num_GreaterThanOrEqualTo.SF(arg, oth);

			var action = () => ret = Throw.IfGreaterThanOrEqualTo(arg, oth);

			action.Should()
				.ThrowExactly<ArgumentOutOfRangeException>()
				.WithMessage($"{msg}*")
				.And.ParamName.Should()
				.BeEquivalentTo(nameof(arg))
				;

			Assert.AreEqual(exp, ret);
		}


		[TestMethod]
		public void IfGreaterThanOrEqualTo_IsGreater_Shd_Throw_CustEx()
		{
			long arg = 123;
			long oth = 100;
			long exp = 0;
			long ret = 0;
			var msg = "GreaterThanOrEqualTo error.";

			var action = () => ret = Throw.IfGreaterThanOrEqualTo(
				arg, oth, ex: argName => new ApplicationException(argName + msg));

			action.Should()
				.ThrowExactly<ApplicationException>()
				.WithMessage($"{nameof(arg)}{msg}*")
				;

			Assert.AreEqual(exp, ret);
		}

		[TestMethod]
		public void IfGreaterThanOrEqualTo_IsGreater_Shd_Throw_w_CustMsg()
		{
			long arg = 123;
			long oth = 100;
			long exp = 0;
			long ret = 0;
			var msg = "GreaterThanOrEqualTo error.";

			var action = () => ret = Throw.IfGreaterThanOrEqualTo(arg, oth, msg);

			action.Should()
				.ThrowExactly<ArgumentOutOfRangeException>()
				.WithMessage($"{msg}*")
				.And.ParamName.Should()
				.BeEquivalentTo(nameof(arg))
				;

			Assert.AreEqual(exp, ret);
		}

		[TestMethod]
		public void IfGreaterThanOrEqualTo_IsGreater_Shd_Throw_w_DefMsg()
		{
			long arg = 123;
			long oth = 100;
			long exp = 0;
			long ret = 0;
			var msg = SR.Err_Num_GreaterThanOrEqualTo.SF(arg, oth);

			var action = () => ret = Throw.IfGreaterThanOrEqualTo(arg, oth);

			action.Should()
				.ThrowExactly<ArgumentOutOfRangeException>()
				.WithMessage($"{msg}*")
				.And.ParamName.Should()
				.BeEquivalentTo(nameof(arg))
				;

			Assert.AreEqual(exp, ret);
		}

		//--

		[TestMethod]
		public void IfBetween_No_Shd_NotThrow()
		{
			long arg = 1000;
			long min = 10;
			long max = 100;
			long exp = arg;
			long ret = 0;

			var action = () => ret = Throw.IfBetween(arg, min, max);

			action.Should().NotThrow();
			Assert.AreEqual(exp, ret);
		}


		[TestMethod]
		public void IfBetween_Yes_Shd_Throw_CustEx()
		{
			long arg = 100;
			long min = 10;
			long max = 1000;
			long exp = 0;
			long ret = 0;
			var msg = "Between error.";

			var action = () => ret = Throw.IfBetween(
				arg, min, max, ex: argName => new ApplicationException(argName + msg));

			action.Should()
				.ThrowExactly<ApplicationException>()
				.WithMessage($"{nameof(arg)}{msg}*")
				;

			Assert.AreEqual(exp, ret);
		}

		[TestMethod]
		public void IfBetween_Yes_Shd_Throw_w_CustMsg()
		{
			long arg = 100;
			long min = 10;
			long max = 1000;
			long exp = 0;
			long ret = 0;
			var msg = "Between error.";

			var action = () => ret = Throw.IfBetween(arg, min, max, msg);

			action.Should()
				.ThrowExactly<ArgumentOutOfRangeException>()
				.WithMessage($"{msg}*")
				.And.ParamName.Should()
				.BeEquivalentTo(nameof(arg))
				;

			Assert.AreEqual(exp, ret);
		}

		[TestMethod]
		public void IfBetween_Yes_Shd_Throw_w_DefMsg()
		{
			long arg = 100;
			long min = 10;
			long max = 1000;
			long exp = 0;
			long ret = 0;
			var msg = SR.Err_Num_Between.SF(arg, min, max);

			var action = () => ret = Throw.IfBetween(arg, min, max);

			action.Should()
				.ThrowExactly<ArgumentOutOfRangeException>()
				.WithMessage($"{msg}*")
				.And.ParamName.Should()
				.BeEquivalentTo(nameof(arg))
				;

			Assert.AreEqual(exp, ret);
		}


		[TestMethod]
		public void IfBetween_EqualsMin_Shd_Throw_CustEx()
		{
			long arg = 10;
			long min = 10;
			long max = 1000;
			long exp = 0;
			long ret = 0;
			var msg = "Between error.";

			var action = () => ret = Throw.IfBetween(
				arg, min, max, ex: argName => new ApplicationException(argName + msg));

			action.Should()
				.ThrowExactly<ApplicationException>()
				.WithMessage($"{nameof(arg)}{msg}*")
				;

			Assert.AreEqual(exp, ret);
		}

		[TestMethod]
		public void IfBetween_EqualsMin_Shd_Throw_w_CustMsg()
		{
			long arg = 10;
			long min = 10;
			long max = 1000;
			long exp = 0;
			long ret = 0;
			var msg = "Between error.";

			var action = () => ret = Throw.IfBetween(arg, min, max, msg);

			action.Should()
				.ThrowExactly<ArgumentOutOfRangeException>()
				.WithMessage($"{msg}*")
				.And.ParamName.Should()
				.BeEquivalentTo(nameof(arg))
				;

			Assert.AreEqual(exp, ret);
		}

		[TestMethod]
		public void IfBetween_EqualsMin_Shd_Throw_w_DefMsg()
		{
			long arg = 10;
			long min = 10;
			long max = 1000;
			long exp = 0;
			long ret = 0;
			var msg = SR.Err_Num_Between.SF(arg, min, max);

			var action = () => ret = Throw.IfBetween(arg, min, max);

			action.Should()
				.ThrowExactly<ArgumentOutOfRangeException>()
				.WithMessage($"{msg}*")
				.And.ParamName.Should()
				.BeEquivalentTo(nameof(arg))
				;

			Assert.AreEqual(exp, ret);
		}


		[TestMethod]
		public void IfBetween_EqualsMax_Shd_Throw_CustEx()
		{
			long arg = 1000;
			long min = 10;
			long max = 1000;
			long exp = 0;
			long ret = 0;
			var msg = "Between error.";

			var action = () => ret = Throw.IfBetween(
				arg, min, max, ex: argName => new ApplicationException(argName + msg));

			action.Should()
				.ThrowExactly<ApplicationException>()
				.WithMessage($"{nameof(arg)}{msg}*")
				;

			Assert.AreEqual(exp, ret);
		}

		[TestMethod]
		public void IfBetween_EqualsMax_Shd_Throw_w_CustMsg()
		{
			long arg = 1000;
			long min = 10;
			long max = 1000;
			long exp = 0;
			long ret = 0;
			var msg = "Between error.";

			var action = () => ret = Throw.IfBetween(arg, min, max, msg);

			action.Should()
				.ThrowExactly<ArgumentOutOfRangeException>()
				.WithMessage($"{msg}*")
				.And.ParamName.Should()
				.BeEquivalentTo(nameof(arg))
				;

			Assert.AreEqual(exp, ret);
		}

		[TestMethod]
		public void IfBetween_EqualsMax_Shd_Throw_w_DefMsg()
		{
			long arg = 1000;
			long min = 10;
			long max = 1000;
			long exp = 0;
			long ret = 0;
			var msg = SR.Err_Num_Between.SF(arg, min, max);

			var action = () => ret = Throw.IfBetween(arg, min, max);

			action.Should()
				.ThrowExactly<ArgumentOutOfRangeException>()
				.WithMessage($"{msg}*")
				.And.ParamName.Should()
				.BeEquivalentTo(nameof(arg))
				;

			Assert.AreEqual(exp, ret);
		}

		//--

		[TestMethod]
		public void IfNotBetween_No_Shd_NotThrow()
		{
			long arg = 100;
			long min = 10;
			long max = 1000;
			long exp = arg;
			long ret = 0;

			var action = () => ret = Throw.IfNotBetween(arg, min, max);

			action.Should().NotThrow();
			Assert.AreEqual(exp, ret);
		}

		[TestMethod]
		public void IfNotBetween_EqualsMin_Shd_NotThrow()
		{
			long arg = 10;
			long min = 10;
			long max = 1000;
			long exp = arg;
			long ret = 0;

			var action = () => ret = Throw.IfNotBetween(arg, min, max);

			action.Should().NotThrow();
			Assert.AreEqual(exp, ret);
		}

		[TestMethod]
		public void IfNotBetween_EqualsMax_Shd_NotThrow()
		{
			long arg = 1000;
			long min = 10;
			long max = 1000;
			long exp = arg;
			long ret = 0;

			var action = () => ret = Throw.IfNotBetween(arg, min, max);

			action.Should().NotThrow();
			Assert.AreEqual(exp, ret);
		}


		[TestMethod]
		public void IfNotBetween_Yes_Shd_Throw_CustEx()
		{
			long arg = 1000;
			long min = 10;
			long max = 100;
			long exp = 0;
			long ret = 0;
			var msg = "NotBetween error.";

			var action = () => ret = Throw.IfNotBetween(
				arg, min, max, ex: argName => new ApplicationException(argName + msg));

			action.Should()
				.ThrowExactly<ApplicationException>()
				.WithMessage($"{nameof(arg)}{msg}*")
				;

			Assert.AreEqual(exp, ret);
		}

		[TestMethod]
		public void IfNotBetween_Yes_Shd_Throw_w_CustMsg()
		{
			long arg = 1000;
			long min = 10;
			long max = 100;
			long exp = 0;
			long ret = 0;
			var msg = "NotBetween error.";

			var action = () => ret = Throw.IfNotBetween(arg, min, max, msg);

			action.Should()
				.ThrowExactly<ArgumentOutOfRangeException>()
				.WithMessage($"{msg}*")
				.And.ParamName.Should()
				.BeEquivalentTo(nameof(arg))
				;

			Assert.AreEqual(exp, ret);
		}

		[TestMethod]
		public void IfNotBetween_Yes_Shd_Throw_w_DefMsg()
		{
			long arg = 1000;
			long min = 10;
			long max = 100;
			long exp = 0;
			long ret = 0;
			var msg = SR.Err_Num_NotBetween.SF(arg, min, max);

			var action = () => ret = Throw.IfNotBetween(arg, min, max);

			action.Should()
				.ThrowExactly<ArgumentOutOfRangeException>()
				.WithMessage($"{msg}*")
				.And.ParamName.Should()
				.BeEquivalentTo(nameof(arg))
				;

			Assert.AreEqual(exp, ret);
		}
	}
}
