namespace ThrowGuard.UnitTests
{
	[TestClass]
	public class GuardsStringTests
	{
		[TestMethod]
		public void IfNullOrEmpty_HasVal_Shd_Not_Throw()
		{
			string? arg = "test";
			string? exp = arg;
			string? ret = null;

			var action = () => ret = Throw.IfNullOrEmpty(arg);

			action.Should().NotThrow();
			Assert.AreEqual(exp, ret);
		}


		[TestMethod]
		public void IfNullOrEmpty_IsEmpty_Shd_Throw_CustEx()
		{
			string? arg = string.Empty;
			string? exp = null;
			string? ret = null;
			var msg = "Null or empty error.";

			var action = () => ret = Throw.IfNullOrEmpty(
				arg, ex: argName => new ApplicationException(argName + msg));

			action.Should()
				.ThrowExactly<ApplicationException>()
				.WithMessage($"{nameof(arg)}{msg}*")
				;

			Assert.AreEqual(exp, ret);
		}

		[TestMethod]
		public void IfNullOrEmpty_IsEmpty_Shd_Throw_w_CustMsg()
		{
			string? arg = string.Empty;
			string? exp = null;
			string? ret = null;
			var msg = "Null or empty error.";

			var action = () => ret = Throw.IfNullOrEmpty(arg, msg);

			action.Should()
				.ThrowExactly<ArgumentException>()
				.WithMessage($"{msg}*")
				.And.ParamName.Should()
				.BeEquivalentTo(nameof(arg))
				;

			Assert.AreEqual(exp, ret);
		}

		[TestMethod]
		public void IfNullOrEmpty_IsEmpty_Shd_Throw_w_DefMsg()
		{
			string? arg = string.Empty;
			string? exp = null;
			string? ret = null;
			var msg = SR.Err_Str_Empty;

			var action = () => ret = Throw.IfNullOrEmpty(arg);

			action.Should()
				.ThrowExactly<ArgumentException>()
				.WithMessage($"{msg}*")
				.And.ParamName.Should()
				.BeEquivalentTo(nameof(arg))
				;

			Assert.AreEqual(exp, ret);
		}


		[TestMethod]
		public void IfNullOrEmpty_IsNull_Shd_Throw_CustEx()
		{
			string? arg = null;
			string? exp = null;
			string? ret = null;
			var msg = "Null ref error.";

			var action = () => ret = Throw.IfNullOrEmpty(
				arg, ex: argName => new ApplicationException(argName + msg));

			action.Should()
				.ThrowExactly<ApplicationException>()
				.WithMessage($"{nameof(arg)}{msg}*")
				;

			Assert.AreEqual(exp, ret);
		}

		[TestMethod]
		public void IfNullOrEmpty_IsNull_Shd_Throw_w_CustMsg()
		{
			string? arg = null;
			string? exp = null;
			string? ret = null;
			var msg = "Null or empty error.";

			var action = () => ret = Throw.IfNullOrEmpty(arg, msg);

			action.Should()
				.ThrowExactly<ArgumentNullException>()
				.WithMessage($"{msg}*")
				.And.ParamName.Should()
				.BeEquivalentTo(nameof(arg))
				;

			Assert.AreEqual(exp, ret);
		}

		[TestMethod]
		public void IfNullOrEmpty_IsNull_Shd_Throw_w_DefMsg()
		{
			string? arg = null;
			string? exp = null;
			string? ret = null;
			var msg = SR.Err_NullArg;

			var action = () => ret = Throw.IfNullOrEmpty(arg);

			action.Should()
				.ThrowExactly<ArgumentNullException>()
				.WithMessage($"{msg}*")
				.And.ParamName.Should()
				.BeEquivalentTo(nameof(arg))
				;

			Assert.AreEqual(exp, ret);
		}

		//--

		[TestMethod]
		public void IfNullOrEmpty_HasVal_WhenFalse_Shd_Not_Throw()
		{
			string? arg = "test";
			string? exp = arg;
			string? ret = null;
			var flg = false;

			var action = () => ret = Throw.IfNullOrEmpty(arg, () => flg);

			action.Should().NotThrow();
			Assert.AreEqual(exp, ret);
		}

		[TestMethod]
		public void IfNullOrEmpty_HasVal_WhenTrue_Shd_Not_Throw()
		{
			string? arg = "test";
			string? exp = arg;
			string? ret = null;
			var flg = true;

			var action = () => ret = Throw.IfNullOrEmpty(arg, () => flg);

			action.Should().NotThrow();
			Assert.AreEqual(exp, ret);
		}


		[TestMethod]
		public void IfNullOrEmpty_IsEmpty_WhenFalse_Shd_Not_Throw()
		{
			string? arg = string.Empty;
			string? exp = arg;
			string? ret = null;
			var flg = false;

			var action = () => ret = Throw.IfNullOrEmpty(arg, () => flg);

			action.Should().NotThrow();
			Assert.AreEqual(exp, ret);
		}

		[TestMethod]
		public void IfNullOrEmpty_IsEmpty_WhenTrue_Shd_Throw_CustEx()
		{
			string? arg = string.Empty;
			string? exp = null;
			string? ret = null;
			var flg = true;
			var msg = "Null or empty error.";

			var action = () => ret = Throw.IfNullOrEmpty(
				arg, () => flg, ex: argName => new ApplicationException(argName + msg));

			action.Should()
				.ThrowExactly<ApplicationException>()
				.WithMessage($"{nameof(arg)}{msg}*")
				;

			Assert.AreEqual(exp, ret);
		}

		[TestMethod]
		public void IfNullOrEmpty_IsEmpty_WhenTrue_Shd_Throw_w_CustMsg()
		{
			string? arg = string.Empty;
			string? exp = null;
			string? ret = null;
			var flg = true;
			var msg = "Null or empty error.";

			var action = () => ret = Throw.IfNullOrEmpty(arg, () => flg, msg);

			action.Should()
				.ThrowExactly<ArgumentException>()
				.WithMessage($"{msg}*")
				.And.ParamName.Should()
				.BeEquivalentTo(nameof(arg))
				;

			Assert.AreEqual(exp, ret);
		}

		[TestMethod]
		public void IfNullOrEmpty_IsEmpty_WhenTrue_Shd_Throw_w_DefMsg()
		{
			string? arg = string.Empty;
			string? exp = null;
			string? ret = null;
			var flg = true;
			var msg = SR.Err_Str_Empty;

			var action = () => ret = Throw.IfNullOrEmpty(arg, () => flg);

			action.Should()
				.ThrowExactly<ArgumentException>()
				.WithMessage($"{msg}*")
				.And.ParamName.Should()
				.BeEquivalentTo(nameof(arg))
				;

			Assert.AreEqual(exp, ret);
		}


		[TestMethod]
		public void IfNullOrEmpty_IsNull_WhenFalse_Shd_Not_Throw()
		{
			string? arg = null;
			string? exp = arg;
			string? ret = null;
			var flg = false;

			var action = () => ret = Throw.IfNullOrEmpty(arg, () => flg);

			action.Should().NotThrow();
			Assert.AreEqual(exp, ret);
		}

		[TestMethod]
		public void IfNullOrEmpty_IsNull_WhenTrue_Shd_Throw_CustEx()
		{
			string? arg = null;
			string? exp = null;
			string? ret = null;
			var flg = true;
			var msg = "Null or empty error.";

			var action = () => ret = Throw.IfNullOrEmpty(
				arg, () => flg, ex: argName => new ApplicationException(argName + msg));

			action.Should()
				.ThrowExactly<ApplicationException>()
				.WithMessage($"{nameof(arg)}{msg}*")
				;

			Assert.AreEqual(exp, ret);
		}

		[TestMethod]
		public void IfNullOrEmpty_IsNull_WhenTrue_Shd_Throw_w_CustMsg()
		{
			string? arg = null;
			string? exp = null;
			string? ret = null;
			var flg = true;
			var msg = "Null or empty error.";

			var action = () => ret = Throw.IfNullOrEmpty(arg, () => flg, msg);

			action.Should()
				.ThrowExactly<ArgumentNullException>()
				.WithMessage($"{msg}*")
				.And.ParamName.Should()
				.BeEquivalentTo(nameof(arg))
				;

			Assert.AreEqual(exp, ret);
		}

		[TestMethod]
		public void IfNullOrEmpty_IsNull_WhenTrue_Shd_Throw_w_DefMsg()
		{
			string? arg = null;
			string? exp = null;
			string? ret = null;
			var flg = true;
			var msg = SR.Err_NullArg;

			var action = () => ret = Throw.IfNullOrEmpty(arg, () => flg);

			action.Should()
				.ThrowExactly<ArgumentNullException>()
				.WithMessage($"{msg}*")
				.And.ParamName.Should()
				.BeEquivalentTo(nameof(arg))
				;

			Assert.AreEqual(exp, ret);
		}

		//----
		//----

		[TestMethod]
		public void IfNullOrWhitespace_HasVal_Shd_Not_Throw()
		{
			string? arg = "test";
			string? exp = arg;
			string? ret = null;

			var action = () => ret = Throw.IfNullOrWhitespace(arg);

			action.Should().NotThrow();
			Assert.AreEqual(exp, ret);
		}


		[TestMethod]
		public void IfNullOrWhitespace_IsSpace_Shd_Throw_CustEx()
		{
			string? arg = "  ";
			string? exp = null;
			string? ret = null;
			var msg = "Whitepace string error.";

			var action = () => ret = Throw.IfNullOrWhitespace(
				arg, ex: argName => new ApplicationException(argName + msg));

			action.Should()
				.ThrowExactly<ApplicationException>()
				.WithMessage($"{nameof(arg)}{msg}*")
				;

			Assert.AreEqual(exp, ret);
		}

		[TestMethod]
		public void IfNullOrWhitespace_IsSpace_Shd_Throw_w_CustMsg()
		{
			string? arg = "  ";
			string? exp = null;
			string? ret = null;
			var msg = "Whitespace string error.";

			var action = () => ret = Throw.IfNullOrWhitespace(arg, msg);

			action.Should()
				.ThrowExactly<ArgumentException>()
				.WithMessage($"{msg}*")
				.And.ParamName.Should()
				.BeEquivalentTo(nameof(arg))
				;

			Assert.AreEqual(exp, ret);
		}

		[TestMethod]
		public void IfNullOrWhitespace_IsSpace_Shd_Throw_w_DefMsg()
		{
			string? arg = "  ";
			string? exp = null;
			string? ret = null;
			var msg = SR.Err_Str_Whitespace;

			var action = () => ret = Throw.IfNullOrWhitespace(arg);

			action.Should()
				.ThrowExactly<ArgumentException>()
				.WithMessage($"{msg}*")
				.And.ParamName.Should()
				.BeEquivalentTo(nameof(arg))
				;

			Assert.AreEqual(exp, ret);
		}


		[TestMethod]
		public void IfNullOrWhitespace_IsEmpty_Shd_Throw_CustEx()
		{
			string? arg = string.Empty;
			string? exp = null;
			string? ret = null;
			var msg = "Empty string error.";

			var action = () => ret = Throw.IfNullOrWhitespace(
				arg, ex: argName => new ApplicationException(argName + msg));

			action.Should()
				.ThrowExactly<ApplicationException>()
				.WithMessage($"{nameof(arg)}{msg}*")
				;

			Assert.AreEqual(exp, ret);
		}

		[TestMethod]
		public void IfNullOrWhitespace_IsEmpty_Shd_Throw_w_CustMsg()
		{
			string? arg = string.Empty;
			string? exp = null;
			string? ret = null;
			var msg = "Empty string error.";

			var action = () => ret = Throw.IfNullOrWhitespace(arg, msg);

			action.Should()
				.ThrowExactly<ArgumentException>()
				.WithMessage($"{msg}*")
				.And.ParamName.Should()
				.BeEquivalentTo(nameof(arg))
				;

			Assert.AreEqual(exp, ret);
		}

		[TestMethod]
		public void IfNullOrWhitespace_IsEmpty_Shd_Throw_w_DefMsg()
		{
			string? arg = string.Empty;
			string? exp = null;
			string? ret = null;
			var msg = SR.Err_Str_Whitespace;

			var action = () => ret = Throw.IfNullOrWhitespace(arg);

			action.Should()
				.ThrowExactly<ArgumentException>()
				.WithMessage($"{msg}*")
				.And.ParamName.Should()
				.BeEquivalentTo(nameof(arg))
				;

			Assert.AreEqual(exp, ret);
		}


		[TestMethod]
		public void IfNullOrWhitespace_IsNull_Shd_Throw_CustEx()
		{
			string? arg = null;
			string? exp = null;
			string? ret = null;
			var msg = "Null ref error.";

			var action = () => ret = Throw.IfNullOrWhitespace(
				arg, ex: argName => new ApplicationException(argName + msg));

			action.Should()
				.ThrowExactly<ApplicationException>()
				.WithMessage($"{nameof(arg)}{msg}*")
				;

			Assert.AreEqual(exp, ret);
		}

		[TestMethod]
		public void IfNullOrWhitespace_IsNull_Shd_Throw_w_CustMsg()
		{
			string? arg = null;
			string? exp = null;
			string? ret = null;
			var msg = "Null or empty error.";

			var action = () => ret = Throw.IfNullOrWhitespace(arg, msg);

			action.Should()
				.ThrowExactly<ArgumentNullException>()
				.WithMessage($"{msg}*")
				.And.ParamName.Should()
				.BeEquivalentTo(nameof(arg))
				;

			Assert.AreEqual(exp, ret);
		}

		[TestMethod]
		public void IfNullOrWhitespace_IsNull_Shd_Throw_w_DefMsg()
		{
			string? arg = null;
			string? exp = null;
			string? ret = null;
			var msg = SR.Err_NullArg;

			var action = () => ret = Throw.IfNullOrWhitespace(arg);

			action.Should()
				.ThrowExactly<ArgumentNullException>()
				.WithMessage($"{msg}*")
				.And.ParamName.Should()
				.BeEquivalentTo(nameof(arg))
				;

			Assert.AreEqual(exp, ret);
		}

		//--

		[TestMethod]
		public void IfNullOrWhitespace_HasVal_WhenFalse_Shd_Not_Throw()
		{
			string? arg = "test";
			string? exp = arg;
			string? ret = null;
			var flg = false;

			var action = () => ret = Throw.IfNullOrWhitespace(arg, () => flg);

			action.Should().NotThrow();
			Assert.AreEqual(exp, ret);
		}

		[TestMethod]
		public void IfNullOrWhitespace_HasVal_WhenTrue_Shd_Not_Throw()
		{
			string? arg = "test";
			string? exp = arg;
			string? ret = null;
			var flg = true;

			var action = () => ret = Throw.IfNullOrWhitespace(arg, () => flg);

			action.Should().NotThrow();
			Assert.AreEqual(exp, ret);
		}


		[TestMethod]
		public void IfNullOrWhitespace_IsSpace_WhenFalse_Shd_Not_Throw()
		{
			string? arg = "  ";
			string? exp = arg;
			string? ret = null;
			var flg = false;

			var action = () => ret = Throw.IfNullOrWhitespace(arg, () => flg);

			action.Should().NotThrow();
			Assert.AreEqual(exp, ret);
		}

		[TestMethod]
		public void IfNullOrWhitespace_IsSpace_WhenTrue_Shd_Throw_CustEx()
		{
			string? arg = "  ";
			string? exp = null;
			string? ret = null;
			var flg = true;
			var msg = "Whitespace string error.";

			var action = () => ret = Throw.IfNullOrWhitespace(
				arg, () => flg, ex: argName => new ApplicationException(argName + msg));

			action.Should()
				.ThrowExactly<ApplicationException>()
				.WithMessage($"{nameof(arg)}{msg}*")
				;

			Assert.AreEqual(exp, ret);
		}

		[TestMethod]
		public void IfNullOrWhitespace_IsSpace_WhenTrue_Shd_Throw_w_CustMsg()
		{
			string? arg = "  ";
			string? exp = null;
			string? ret = null;
			var flg = true;
			var msg = "Whitespace string error.";

			var action = () => ret = Throw.IfNullOrWhitespace(arg, () => flg, msg);

			action.Should()
				.ThrowExactly<ArgumentException>()
				.WithMessage($"{msg}*")
				.And.ParamName.Should()
				.BeEquivalentTo(nameof(arg))
				;

			Assert.AreEqual(exp, ret);
		}

		[TestMethod]
		public void IfNullOrWhitespace_IsSpace_WhenTrue_Shd_Throw_w_DefMsg()
		{
			string? arg = "  ";
			string? exp = null;
			string? ret = null;
			var flg = true;
			var msg = SR.Err_Str_Whitespace;

			var action = () => ret = Throw.IfNullOrWhitespace(arg, () => flg);

			action.Should()
				.ThrowExactly<ArgumentException>()
				.WithMessage($"{msg}*")
				.And.ParamName.Should()
				.BeEquivalentTo(nameof(arg))
				;

			Assert.AreEqual(exp, ret);
		}


		[TestMethod]
		public void IfNullOrWhitespace_IsEmpty_WhenFalse_Shd_Not_Throw()
		{
			string? arg = string.Empty;
			string? exp = arg;
			string? ret = null;
			var flg = false;

			var action = () => ret = Throw.IfNullOrWhitespace(arg, () => flg);

			action.Should().NotThrow();
			Assert.AreEqual(exp, ret);
		}

		[TestMethod]
		public void IfNullOrWhitespace_IsEmpty_WhenTrue_Shd_Throw_CustEx()
		{
			string? arg = string.Empty;
			string? exp = null;
			string? ret = null;
			var flg = true;
			var msg = "Empty string error.";

			var action = () => ret = Throw.IfNullOrWhitespace(
				arg, () => flg, ex: argName => new ApplicationException(argName + msg));

			action.Should()
				.ThrowExactly<ApplicationException>()
				.WithMessage($"{nameof(arg)}{msg}*")
				;

			Assert.AreEqual(exp, ret);
		}

		[TestMethod]
		public void IfNullOrWhitespace_IsEmpty_WhenTrue_Shd_Throw_w_CustMsg()
		{
			string? arg = string.Empty;
			string? exp = null;
			string? ret = null;
			var flg = true;
			var msg = "Empty string error.";

			var action = () => ret = Throw.IfNullOrWhitespace(arg, () => flg, msg);

			action.Should()
				.ThrowExactly<ArgumentException>()
				.WithMessage($"{msg}*")
				.And.ParamName.Should()
				.BeEquivalentTo(nameof(arg))
				;

			Assert.AreEqual(exp, ret);
		}

		[TestMethod]
		public void IfNullOrWhitespace_IsEmpty_WhenTrue_Shd_Throw_w_DefMsg()
		{
			string? arg = string.Empty;
			string? exp = null;
			string? ret = null;
			var flg = true;
			var msg = SR.Err_Str_Whitespace;

			var action = () => ret = Throw.IfNullOrWhitespace(arg, () => flg);

			action.Should()
				.ThrowExactly<ArgumentException>()
				.WithMessage($"{msg}*")
				.And.ParamName.Should()
				.BeEquivalentTo(nameof(arg))
				;

			Assert.AreEqual(exp, ret);
		}


		[TestMethod]
		public void IfNullOrWhitespace_IsNull_WhenFalse_Shd_Not_Throw()
		{
			string? arg = null;
			string? exp = arg;
			string? ret = null;
			var flg = false;

			var action = () => ret = Throw.IfNullOrWhitespace(arg, () => flg);

			action.Should().NotThrow();
			Assert.AreEqual(exp, ret);
		}

		[TestMethod]
		public void IfNullOrWhitespace_IsNull_WhenTrue_Shd_Throw_CustEx()
		{
			string? arg = null;
			string? exp = null;
			string? ret = null;
			var flg = true;
			var msg = "Null or empty error.";

			var action = () => ret = Throw.IfNullOrWhitespace(
				arg, () => flg, ex: argName => new ApplicationException(argName + msg));

			action.Should()
				.ThrowExactly<ApplicationException>()
				.WithMessage($"{nameof(arg)}{msg}*")
				;

			Assert.AreEqual(exp, ret);
		}

		[TestMethod]
		public void IfNullOrWhitespace_IsNull_WhenTrue_Shd_Throw_w_CustMsg()
		{
			string? arg = null;
			string? exp = null;
			string? ret = null;
			var flg = true;
			var msg = "Null or empty error.";

			var action = () => ret = Throw.IfNullOrWhitespace(arg, () => flg, msg);

			action.Should()
				.ThrowExactly<ArgumentNullException>()
				.WithMessage($"{msg}*")
				.And.ParamName.Should()
				.BeEquivalentTo(nameof(arg))
				;

			Assert.AreEqual(exp, ret);
		}

		[TestMethod]
		public void IfNullOrWhitespace_IsNull_WhenTrue_Shd_Throw_w_DefMsg()
		{
			string? arg = null;
			string? exp = null;
			string? ret = null;
			var flg = true;
			var msg = SR.Err_NullArg;

			var action = () => ret = Throw.IfNullOrWhitespace(arg, () => flg);

			action.Should()
				.ThrowExactly<ArgumentNullException>()
				.WithMessage($"{msg}*")
				.And.ParamName.Should()
				.BeEquivalentTo(nameof(arg))
				;

			Assert.AreEqual(exp, ret);
		}

		//----
		//----

		[TestMethod]
		public void IfNullOrWhitespace_Char_HasVal_Shd_Not_Throw()
		{
			char arg = 't';
			char exp = arg;
			char ret = 'x';

			var action = () => ret = Throw.IfNullOrWhitespace(arg);

			action.Should().NotThrow();
			Assert.AreEqual(exp, ret);
		}


		[TestMethod]
		public void IfNullOrWhitespace_Char_IsNull_Shd_Throw_CustEx()
		{
			char? arg = null;
			char? exp = null;
			char? ret = null;
			var msg = "Whitepace char error.";

			var action = () => ret = Throw.IfNullOrWhitespace(
				arg, ex: argName => new ApplicationException(argName + msg));

			action.Should()
				.ThrowExactly<ApplicationException>()
				.WithMessage($"{nameof(arg)}{msg}*")
				;

			Assert.AreEqual(exp, ret);
		}

		[TestMethod]
		public void IfNullOrWhitespace_Char_IsNull_Shd_Throw_w_CustMsg()
		{
			char? arg = null;
			char? exp = null;
			char? ret = null;
			var msg = "Whitepace char error.";

			var action = () => ret = Throw.IfNullOrWhitespace(arg, msg);

			action.Should()
				.ThrowExactly<ArgumentNullException>()
				.WithMessage($"{msg}*")
				.And.ParamName.Should()
				.BeEquivalentTo(nameof(arg))
				;

			Assert.AreEqual(exp, ret);
		}

		[TestMethod]
		public void IfNullOrWhitespace_Char_IsNull_Shd_Throw_w_DefMsg()
		{
			char? arg = null;
			char? exp = null;
			char? ret = null;
			var msg = SR.Err_NullArg;

			var action = () => ret = Throw.IfNullOrWhitespace(arg);

			action.Should()
				.ThrowExactly<ArgumentNullException>()
				.WithMessage($"{msg}*")
				.And.ParamName.Should()
				.BeEquivalentTo(nameof(arg))
				;

			Assert.AreEqual(exp, ret);
		}


		[TestMethod]
		public void IfNullOrWhitespace_Char_IsSpace_Shd_Throw_CustEx()
		{
			char? arg = ' ';
			char? exp = null;
			char? ret = null;
			var msg = "Whitepace char error.";

			var action = () => ret = Throw.IfNullOrWhitespace(
				arg, ex: argName => new ApplicationException(argName + msg));

			action.Should()
				.ThrowExactly<ApplicationException>()
				.WithMessage($"{nameof(arg)}{msg}*")
				;

			Assert.AreEqual(exp, ret);
		}

		[TestMethod]
		public void IfNullOrWhitespace_Char_IsSpace_Shd_Throw_w_CustMsg()
		{
			char? arg = ' ';
			char? exp = null;
			char? ret = null;
			var msg = "Whitepace char error.";

			var action = () => ret = Throw.IfNullOrWhitespace(arg, msg);

			action.Should()
				.ThrowExactly<ArgumentException>()
				.WithMessage($"{msg}*")
				.And.ParamName.Should()
				.BeEquivalentTo(nameof(arg))
				;

			Assert.AreEqual(exp, ret);
		}

		[TestMethod]
		public void IfNullOrWhitespace_Char_IsSpace_Shd_Throw_w_DefMsg()
		{
			char? arg = ' ';
			char? exp = null;
			char? ret = null;
			var msg = SR.Err_Char_Whitespace;

			var action = () => ret = Throw.IfNullOrWhitespace(arg);

			action.Should()
				.ThrowExactly<ArgumentException>()
				.WithMessage($"{msg}*")
				.And.ParamName.Should()
				.BeEquivalentTo(nameof(arg))
				;

			Assert.AreEqual(exp, ret);
		}


		[TestMethod]
		public void IfNullOrWhitespace_Char_IsTab_Shd_Throw_CustEx()
		{
			char? arg = '\t';
			char? exp = null;
			char? ret = null;
			var msg = "Whitepace char error.";

			var action = () => ret = Throw.IfNullOrWhitespace(
				arg, ex: argName => new ApplicationException(argName + msg));

			action.Should()
				.ThrowExactly<ApplicationException>()
				.WithMessage($"{nameof(arg)}{msg}*")
				;

			Assert.AreEqual(exp, ret);
		}

		[TestMethod]
		public void IfNullOrWhitespace_Char_IsTab_Shd_Throw_w_CustMsg()
		{
			char? arg = '\t';
			char? exp = null;
			char? ret = null;
			var msg = "Whitepace char error.";

			var action = () => ret = Throw.IfNullOrWhitespace(arg, msg);

			action.Should()
				.ThrowExactly<ArgumentException>()
				.WithMessage($"{msg}*")
				.And.ParamName.Should()
				.BeEquivalentTo(nameof(arg))
				;

			Assert.AreEqual(exp, ret);
		}

		[TestMethod]
		public void IfNullOrWhitespace_Char_IsTab_Shd_Throw_w_DefMsg()
		{
			char? arg = '\t';
			char? exp = null;
			char? ret = null;
			var msg = SR.Err_Char_Whitespace;

			var action = () => ret = Throw.IfNullOrWhitespace(arg);

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
		public void IfNullOrWhitespace_Char_HasVal_WhenFalse_Shd_Not_Throw()
		{
			char? arg = 't';
			char? exp = arg;
			char? ret = 'x';
			var flg = false;

			var action = () => ret = Throw.IfNullOrWhitespace(arg, () => flg);

			action.Should().NotThrow();
			Assert.AreEqual(exp, ret);
		}

		[TestMethod]
		public void IfNullOrWhitespace_Char_HasVal_WhenTrue_Shd_Not_Throw()
		{
			char? arg = 't';
			char? exp = arg;
			char? ret = 'x';
			var flg = true;

			var action = () => ret = Throw.IfNullOrWhitespace(arg, () => flg);

			action.Should().NotThrow();
			Assert.AreEqual(exp, ret);
		}


		[TestMethod]
		public void IfNullOrWhitespace_Char_IsNull_WhenFalse_Shd_Not_Throw()
		{
			char? arg = null;
			char? exp = null;
			char? ret = null;
			var flg = false;

			var action = () => ret = Throw.IfNullOrWhitespace(arg, () => flg);

			action.Should().NotThrow();
			Assert.AreEqual(exp, ret);
		}

		[TestMethod]
		public void IfNullOrWhitespace_Char_IsNull_WhenTrue_Shd_Throw_CustEx()
		{
			char? arg = null;
			char? exp = null;
			char? ret = null;
			var flg = true;
			var msg = "Whitepace char error.";

			var action = () => ret = Throw.IfNullOrWhitespace(
				arg, () => flg, ex: argName => new ApplicationException(argName + msg));

			action.Should()
				.ThrowExactly<ApplicationException>()
				.WithMessage($"{nameof(arg)}{msg}*")
				;

			Assert.AreEqual(exp, ret);
		}

		[TestMethod]
		public void IfNullOrWhitespace_Char_IsNull_WhenTrue_Shd_Throw_w_CustMsg()
		{
			char? arg = null;
			char? exp = null;
			char? ret = null;
			var flg = true;
			var msg = "Whitepace char error.";

			var action = () => ret = Throw.IfNullOrWhitespace(arg, () => flg, msg);

			action.Should()
				.ThrowExactly<ArgumentNullException>()
				.WithMessage($"{msg}*")
				.And.ParamName.Should()
				.BeEquivalentTo(nameof(arg))
				;

			Assert.AreEqual(exp, ret);
		}

		[TestMethod]
		public void IfNullOrWhitespace_Char_IsNull_WhenTrue_Shd_Throw_w_DefMsg()
		{
			char? arg = null;
			char? exp = null;
			char? ret = null;
			var flg = true;
			var msg = SR.Err_NullArg;

			var action = () => ret = Throw.IfNullOrWhitespace(arg, () => flg);

			action.Should()
				.ThrowExactly<ArgumentNullException>()
				.WithMessage($"{msg}*")
				.And.ParamName.Should()
				.BeEquivalentTo(nameof(arg))
				;

			Assert.AreEqual(exp, ret);
		}


		[TestMethod]
		public void IfNullOrWhitespace_Char_IsSpace_WhenFalse_Shd_Not_Throw()
		{
			char? arg = ' ';
			char? exp = arg;
			char? ret = null;
			var flg = false;

			var action = () => ret = Throw.IfNullOrWhitespace(arg, () => flg);

			action.Should().NotThrow();
			Assert.AreEqual(exp, ret);
		}

		[TestMethod]
		public void IfNullOrWhitespace_Char_IsSpace_WhenTrue_Shd_Throw_CustEx()
		{
			char? arg = ' ';
			char? exp = null;
			char? ret = null;
			var flg = true;
			var msg = "Whitepace char error.";

			var action = () => ret = Throw.IfNullOrWhitespace(
				arg, () => flg, ex: argName => new ApplicationException(argName + msg));

			action.Should()
				.ThrowExactly<ApplicationException>()
				.WithMessage($"{nameof(arg)}{msg}*")
				;

			Assert.AreEqual(exp, ret);
		}

		[TestMethod]
		public void IfNullOrWhitespace_Char_IsSpace_WhenTrue_Shd_Throw_w_CustMsg()
		{
			char? arg = ' ';
			char? exp = null;
			char? ret = null;
			var flg = true;
			var msg = "Whitepace char error.";

			var action = () => ret = Throw.IfNullOrWhitespace(arg, () => flg, msg);

			action.Should()
				.ThrowExactly<ArgumentException>()
				.WithMessage($"{msg}*")
				.And.ParamName.Should()
				.BeEquivalentTo(nameof(arg))
				;

			Assert.AreEqual(exp, ret);
		}

		[TestMethod]
		public void IfNullOrWhitespace_Char_IsSpace_WhenTrue_Shd_Throw_w_DefMsg()
		{
			char? arg = ' ';
			char? exp = null;
			char? ret = null;
			var flg = true;
			var msg = SR.Err_Char_Whitespace;

			var action = () => ret = Throw.IfNullOrWhitespace(arg, () => flg);

			action.Should()
				.ThrowExactly<ArgumentException>()
				.WithMessage($"{msg}*")
				.And.ParamName.Should()
				.BeEquivalentTo(nameof(arg))
				;

			Assert.AreEqual(exp, ret);
		}


		[TestMethod]
		public void IfNullOrWhitespace_Char_IsTab_WhenFalse_Shd_Not_Throw()
		{
			char? arg = '\t';
			char? exp = arg;
			char? ret = null;
			var flg = false;

			var action = () => ret = Throw.IfNullOrWhitespace(arg, () => flg);

			action.Should().NotThrow();
			Assert.AreEqual(exp, ret);
		}

		[TestMethod]
		public void IfNullOrWhitespace_Char_IsTab_WhenTrue_Shd_Throw_CustEx()
		{
			char? arg = '\t';
			char? exp = null;
			char? ret = null;
			var flg = true;
			var msg = "Whitepace char error.";

			var action = () => ret = Throw.IfNullOrWhitespace(
				arg, () => flg, ex: argName => new ApplicationException(argName + msg));

			action.Should()
				.ThrowExactly<ApplicationException>()
				.WithMessage($"{nameof(arg)}{msg}*")
				;

			Assert.AreEqual(exp, ret);
		}

		[TestMethod]
		public void IfNullOrWhitespace_Char_IsTab_WhenTrue_Shd_Throw_w_CustMsg()
		{
			char? arg = '\t';
			char? exp = null;
			char? ret = null;
			var flg = true;
			var msg = "Whitepace char error.";

			var action = () => ret = Throw.IfNullOrWhitespace(arg, () => flg, msg);

			action.Should()
				.ThrowExactly<ArgumentException>()
				.WithMessage($"{msg}*")
				.And.ParamName.Should()
				.BeEquivalentTo(nameof(arg))
				;

			Assert.AreEqual(exp, ret);
		}

		[TestMethod]
		public void IfNullOrWhitespace_Char_IsTab_WhenTrue_Shd_Throw_w_DefMsg()
		{
			char? arg = '\t';
			char? exp = null;
			char? ret = null;
			var flg = true;
			var msg = SR.Err_Char_Whitespace;

			var action = () => ret = Throw.IfNullOrWhitespace(arg, () => flg);

			action.Should()
				.ThrowExactly<ArgumentException>()
				.WithMessage($"{msg}*")
				.And.ParamName.Should()
				.BeEquivalentTo(nameof(arg))
				;

			Assert.AreEqual(exp, ret);
		}
	}
}
