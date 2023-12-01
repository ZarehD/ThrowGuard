namespace ThrowGuard.UnitTests
{
	[TestClass]
	public class GuardsCollectionTests
	{
		[TestMethod]
		public void IfNullOrEmpty_No_Shd_NotThrow()
		{
			var arg = new List<int>() { 1, 2, 3 };
			var exp = arg;
			var ret = default(List<int>);

			var action = () => ret = Throw.IfNullOrEmpty(arg);

			action.Should().NotThrow();
			Assert.AreSame(exp, ret);
		}


		[TestMethod]
		public void IfNullOrEmpty_Null_Shd_Throw_CustEx()
		{
			var arg = default(IEnumerable<int>?);
			var exp = default(IEnumerable<int>?);
			var ret = default(IEnumerable<int>?);
			var msg = "Collection error.";

			var action = () => ret = Throw.IfNullOrEmpty(
				arg, ex: argName => new ApplicationException(argName + msg));

			action.Should()
				.ThrowExactly<ApplicationException>()
				.WithMessage($"{nameof(arg)}{msg}*")
				;

			Assert.AreEqual(exp, ret);
		}

		[TestMethod]
		public void IfNullOrEmpty_Null_Shd_Throw_w_CustMsg()
		{
			var arg = default(IEnumerable<int>?);
			var exp = default(IEnumerable<int>?);
			var ret = default(IEnumerable<int>?);
			var msg = "Collection error.";

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
		public void IfNullOrEmpty_Null_Shd_Throw_w_DefMsg()
		{
			var arg = default(IEnumerable<int>?);
			var exp = default(IEnumerable<int>?);
			var ret = default(IEnumerable<int>?);
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



		[TestMethod]
		public void IfNullOrEmpty_Empty_Shd_Throw_CustEx()
		{
			var arg = new List<int>();
			var exp = default(IEnumerable<int>?);
			var ret = default(IEnumerable<int>?);
			var msg = "Collection error.";

			var action = () => ret = Throw.IfNullOrEmpty(
				arg, ex: argName => new ApplicationException(argName + msg));

			action.Should()
				.ThrowExactly<ApplicationException>()
				.WithMessage($"{nameof(arg)}{msg}*")
				;

			Assert.AreEqual(exp, ret);
		}

		[TestMethod]
		public void IfNullOrEmpty_Empty_Shd_Throw_w_CustMsg()
		{
			var arg = new List<int>();
			var exp = default(IEnumerable<int>?);
			var ret = default(IEnumerable<int>?);
			var msg = "Collection error.";

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
		public void IfNullOrEmpty_Empty_Shd_Throw_w_DefMsg()
		{
			var arg = new List<int>();
			var exp = default(IEnumerable<int>?);
			var ret = default(IEnumerable<int>?);
			var msg = SR.Err_Collection_IsEmpty;

			var action = () => ret = Throw.IfNullOrEmpty(arg);

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
		public void IfNullOrEmpty_No_WhenFalse_Shd_NotThrow()
		{
			var arg = new List<int>() { 1, 2, 3 };
			var exp = arg;
			var ret = default(List<int>);
			var flg = false;

			var action = () => ret = Throw.IfNullOrEmpty(arg, () => flg);

			action.Should().NotThrow();
			Assert.AreSame(exp, ret);
		}

		[TestMethod]
		public void IfNullOrEmpty_No_WhenTrue_Shd_NotThrow()
		{
			var arg = new List<int>() { 1, 2, 3 };
			var exp = arg;
			var ret = default(List<int>);
			var flg = true;

			var action = () => ret = Throw.IfNullOrEmpty(arg, () => flg);

			action.Should().NotThrow();
			Assert.AreSame(exp, ret);
		}


		[TestMethod]
		public void IfNullOrEmpty_Null_WhenFalse_Shd_NotThrow()
		{
			var arg = default(IEnumerable<int>?);
			var exp = default(IEnumerable<int>?);
			var ret = default(IEnumerable<int>?);
			var flg = false;

			var action = () => ret = Throw.IfNullOrEmpty(arg, () => flg);

			action.Should().NotThrow();
			Assert.AreSame(exp, ret);
		}

		[TestMethod]
		public void IfNullOrEmpty_Null_WhenTrue_Shd_Throw_CustEx()
		{
			var arg = default(IEnumerable<int>?);
			var exp = default(IEnumerable<int>?);
			var ret = default(IEnumerable<int>?);
			var flg = true;
			var msg = "Collection error.";

			var action = () => ret = Throw.IfNullOrEmpty(
				arg, () => flg, ex: argName => new ApplicationException(argName + msg));

			action.Should()
				.ThrowExactly<ApplicationException>()
				.WithMessage($"{nameof(arg)}{msg}*")
				;

			Assert.AreEqual(exp, ret);
		}

		[TestMethod]
		public void IfNullOrEmpty_Null_WhenTrue_Shd_Throw_w_CustMsg()
		{
			var arg = default(IEnumerable<int>?);
			var exp = default(IEnumerable<int>?);
			var ret = default(IEnumerable<int>?);
			var flg = true;
			var msg = "Collection error.";

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
		public void IfNullOrEmpty_Null_WhenTrue_Shd_Throw_w_DefMsg()
		{
			var arg = default(IEnumerable<int>?);
			var exp = default(IEnumerable<int>?);
			var ret = default(IEnumerable<int>?);
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


		[TestMethod]
		public void IfNullOrEmpty_Empty_WhenFalse_Shd_NotThrow()
		{
			var arg = new List<int>();
			var exp = arg;
			var ret = default(List<int>);
			var flg = false;

			var action = () => ret = Throw.IfNullOrEmpty(arg, () => flg);

			action.Should().NotThrow();
			Assert.AreSame(exp, ret);
		}

		[TestMethod]
		public void IfNullOrEmpty_Empty_WhenTrue_Shd_Throw_CustEx()
		{
			var arg = new List<int>();
			var exp = default(IEnumerable<int>?);
			var ret = default(IEnumerable<int>?);
			var flg = true;
			var msg = "Collection error.";

			var action = () => ret = Throw.IfNullOrEmpty(
				arg, () => flg, ex: argName => new ApplicationException(argName + msg));

			action.Should()
				.ThrowExactly<ApplicationException>()
				.WithMessage($"{nameof(arg)}{msg}*")
				;

			Assert.AreEqual(exp, ret);
		}

		[TestMethod]
		public void IfNullOrEmpty_Empty_WhenTrue_Shd_Throw_w_CustMsg()
		{
			var arg = new List<int>();
			var exp = default(IEnumerable<int>?);
			var ret = default(IEnumerable<int>?);
			var flg = true;
			var msg = "Collection error.";

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
		public void IfNullOrEmpty_Empty_WhenTrue_Shd_Throw_w_DefMsg()
		{
			var arg = new List<int>();
			var exp = default(IEnumerable<int>?);
			var ret = default(IEnumerable<int>?);
			var flg = true;
			var msg = SR.Err_Collection_IsEmpty;

			var action = () => ret = Throw.IfNullOrEmpty(arg, () => flg);

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
		public void IfCountLessThan_IsNull_Shd_Throw()
		{
			var arg = default(List<byte>?);
			var exp = default(List<byte>?);
			var ret = default(List<byte>?);

			var action = () => ret = Throw.IfCountLessThan(arg!, 0);

			action.Should().ThrowExactly<ArgumentNullException>();
			Assert.AreEqual(exp, ret);
		}

		[TestMethod]
		public void IfCountLessThan_IsMore_Shd_NotThrow()
		{
			var arg = new List<byte> { 1, 2, 3 };
			var exp = arg;
			var ret = default(List<byte>);
			var lmt = (uint) 1;

			var action = () => ret = Throw.IfCountLessThan(arg, lmt);

			action.Should().NotThrow();
			Assert.AreEqual(exp, ret);
		}

		[TestMethod]
		public void IfCountLessThan_IsSame_Shd_NotThrow()
		{
			var arg = new List<byte> { 1, 2, 3 };
			var exp = arg;
			var ret = default(List<byte>);
			var lmt = (uint) arg.Count;

			var action = () => ret = Throw.IfCountLessThan(arg, lmt);

			action.Should().NotThrow();
			Assert.AreEqual(exp, ret);
		}

		[TestMethod]
		public void IfCountLessThan_IsLess_Shd_Throw_CustEx()
		{
			var arg = new List<byte> { 1, 2, 3 };
			var exp = default(List<byte>);
			var ret = default(List<byte>);
			var lmt = (uint) 10;
			var msg = "Collection count error";

			var action = () => ret = Throw.IfCountLessThan(
				arg, lmt, ex: argName => new ApplicationException(argName + msg));

			action.Should()
				.ThrowExactly<ApplicationException>()
				.WithMessage($"{nameof(arg)}{msg}*")
				;

			Assert.AreEqual(exp, ret);
		}

		[TestMethod]
		public void IfCountLessThan_IsLess_Shd_Throw_w_CustMsg()
		{
			var arg = new List<byte> { 1, 2, 3 };
			var exp = default(List<byte>);
			var ret = default(List<byte>);
			var lmt = (uint) 10;
			var msg = "Collection count error";

			var action = () => ret = Throw.IfCountLessThan(arg, lmt, msg);

			action.Should()
				.ThrowExactly<ArgumentException>()
				.WithMessage($"{msg}*")
				.And.ParamName.Should()
				.BeEquivalentTo(nameof(arg))
				;

			Assert.AreEqual(exp, ret);
		}

		[TestMethod]
		public void IfCountLessThan_IsLess_Shd_Throw_w_DefMsg()
		{
			var arg = new List<byte> { 1, 2, 3 };
			var exp = default(List<byte>);
			var ret = default(List<byte>);
			var lmt = (uint) 10;
			var msg = SR.Err_Collection_Count_LessThan.SF(arg.Count, lmt);

			var action = () => ret = Throw.IfCountLessThan(arg, lmt);

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
		public void IfCountLessThanOrEqualTo_IsNull_Shd_Throw()
		{
			var arg = default(List<byte>?);
			var exp = default(List<byte>?);
			var ret = default(List<byte>?);

			var action = () => ret = Throw.IfCountLessThanOrEqualTo(arg!, 0);

			action.Should().ThrowExactly<ArgumentNullException>();
			Assert.AreEqual(exp, ret);
		}

		[TestMethod]
		public void IfCountLessThanOrEqualTo_IsMore_Shd_NotThrow()
		{
			var arg = new List<byte> { 1, 2, 3 };
			var exp = arg;
			var ret = default(List<byte>);
			var lmt = (uint) 1;

			var action = () => ret = Throw.IfCountLessThanOrEqualTo(arg, lmt);

			action.Should().NotThrow();
			Assert.AreEqual(exp, ret);
		}


		[TestMethod]
		public void IfCountLessThanOrEqualTo_IsSame_Shd_Throw_CustEx()
		{
			var arg = new List<byte> { 1, 2, 3 };
			var exp = default(List<byte>);
			var ret = default(List<byte>);
			var lmt = (uint) arg.Count;
			var msg = "Collection count error";

			var action = () => ret = Throw.IfCountLessThanOrEqualTo(
				arg, lmt, ex: argName => new ApplicationException(argName + msg));

			action.Should()
				.ThrowExactly<ApplicationException>()
				.WithMessage($"{nameof(arg)}{msg}*")
				;

			Assert.AreEqual(exp, ret);
		}

		[TestMethod]
		public void IfCountLessThanOrEqualTo_IsSame_Shd_Throw_w_CustMsg()
		{
			var arg = new List<byte> { 1, 2, 3 };
			var exp = default(List<byte>);
			var ret = default(List<byte>);
			var lmt = (uint) arg.Count;
			var msg = "Collection count error";

			var action = () => ret = Throw.IfCountLessThanOrEqualTo(arg, lmt, msg);

			action.Should()
				.ThrowExactly<ArgumentException>()
				.WithMessage($"{msg}*")
				.And.ParamName.Should()
				.BeEquivalentTo(nameof(arg))
				;

			Assert.AreEqual(exp, ret);
		}

		[TestMethod]
		public void IfCountLessThanOrEqualTo_IsSame_Shd_Throw_w_DefMsg()
		{
			var arg = new List<byte> { 1, 2, 3 };
			var exp = default(List<byte>);
			var ret = default(List<byte>);
			var lmt = (uint) arg.Count;
			var msg = SR.Err_Collection_Count_LessThanOrEqualTo.SF(arg.Count, lmt);

			var action = () => ret = Throw.IfCountLessThanOrEqualTo(arg, lmt);

			action.Should()
				.ThrowExactly<ArgumentException>()
				.WithMessage($"{msg}*")
				.And.ParamName.Should()
				.BeEquivalentTo(nameof(arg))
				;

			Assert.AreEqual(exp, ret);
		}


		[TestMethod]
		public void IfCountLessThanOrEqualTo_IsLess_Shd_Throw_CustEx()
		{
			var arg = new List<byte> { 1, 2, 3 };
			var exp = default(List<byte>);
			var ret = default(List<byte>);
			var lmt = (uint) 10;
			var msg = "Collection count error";

			var action = () => ret = Throw.IfCountLessThanOrEqualTo(
				arg, lmt, ex: argName => new ApplicationException(argName + msg));

			action.Should()
				.ThrowExactly<ApplicationException>()
				.WithMessage($"{nameof(arg)}{msg}*")
				;

			Assert.AreEqual(exp, ret);
		}

		[TestMethod]
		public void IfCountLessThanOrEqualTo_IsLess_Shd_Throw_w_CustMsg()
		{
			var arg = new List<byte> { 1, 2, 3 };
			var exp = default(List<byte>);
			var ret = default(List<byte>);
			var lmt = (uint) 10;
			var msg = "Collection count error";

			var action = () => ret = Throw.IfCountLessThanOrEqualTo(arg, lmt, msg);

			action.Should()
				.ThrowExactly<ArgumentException>()
				.WithMessage($"{msg}*")
				.And.ParamName.Should()
				.BeEquivalentTo(nameof(arg))
				;

			Assert.AreEqual(exp, ret);
		}

		[TestMethod]
		public void IfCountLessThanOrEqualTo_IsLess_Shd_Throw_w_DefMsg()
		{
			var arg = new List<byte> { 1, 2, 3 };
			var exp = default(List<byte>);
			var ret = default(List<byte>);
			var lmt = (uint) 10;
			var msg = SR.Err_Collection_Count_LessThanOrEqualTo.SF(arg.Count, lmt);

			var action = () => ret = Throw.IfCountLessThanOrEqualTo(arg, lmt);

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
		public void IfCountMoreThan_IsNull_Shd_Throw()
		{
			var arg = default(List<byte>?);
			var exp = default(List<byte>?);
			var ret = default(List<byte>?);

			var action = () => ret = Throw.IfCountMoreThan(arg!, 0);

			action.Should().ThrowExactly<ArgumentNullException>();
			Assert.AreEqual(exp, ret);
		}

		[TestMethod]
		public void IfCountMoreThan_IsLess_Shd_NotThrow()
		{
			var arg = new List<byte> { 1, 2, 3 };
			var exp = arg;
			var ret = default(List<byte>);
			var lmt = (uint) 10;

			var action = () => ret = Throw.IfCountMoreThan(arg, lmt);

			action.Should().NotThrow();
			Assert.AreEqual(exp, ret);
		}

		[TestMethod]
		public void IfCountMoreThan_IsSame_Shd_NotThrow()
		{
			var arg = new List<byte> { 1, 2, 3 };
			var exp = arg;
			var ret = default(List<byte>);
			var lmt = (uint) arg.Count;

			var action = () => ret = Throw.IfCountMoreThan(arg, lmt);

			action.Should().NotThrow();
			Assert.AreEqual(exp, ret);
		}

		[TestMethod]
		public void IfCountMoreThan_IsMore_Shd_Throw_CustEx()
		{
			var arg = new List<byte> { 1, 2, 3 };
			var exp = default(List<byte>);
			var ret = default(List<byte>);
			var lmt = (uint) 1;
			var msg = "Collection count error";

			var action = () => ret = Throw.IfCountMoreThan(
				arg, lmt, ex: argName => new ApplicationException(argName + msg));

			action.Should()
				.ThrowExactly<ApplicationException>()
				.WithMessage($"{nameof(arg)}{msg}*")
				;

			Assert.AreEqual(exp, ret);
		}

		[TestMethod]
		public void IfCountMoreThan_IsMore_Shd_Throw_w_CustMsg()
		{
			var arg = new List<byte> { 1, 2, 3 };
			var exp = default(List<byte>);
			var ret = default(List<byte>);
			var lmt = (uint) 1;
			var msg = "Collection count error";

			var action = () => ret = Throw.IfCountMoreThan(arg, lmt, msg);

			action.Should()
				.ThrowExactly<ArgumentException>()
				.WithMessage($"{msg}*")
				.And.ParamName.Should()
				.BeEquivalentTo(nameof(arg))
				;

			Assert.AreEqual(exp, ret);
		}

		[TestMethod]
		public void IfCountMoreThan_IsMore_Shd_Throw_w_DefMsg()
		{
			var arg = new List<byte> { 1, 2, 3 };
			var exp = default(List<byte>);
			var ret = default(List<byte>);
			var lmt = (uint) 1;
			var msg = SR.Err_Collection_Count_MoreThan.SF(arg.Count, lmt);

			var action = () => ret = Throw.IfCountMoreThan(arg, lmt);

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
		public void IfCountMoreThanOrEqualTo_IsNull_Shd_Throw()
		{
			var arg = default(List<byte>?);
			var exp = default(List<byte>?);
			var ret = default(List<byte>?);

			var action = () => ret = Throw.IfCountMoreThanOrEqualTo(arg!, 0);

			action.Should().ThrowExactly<ArgumentNullException>();
			Assert.AreEqual(exp, ret);
		}

		[TestMethod]
		public void IfCountMoreThanOrEqualTo_IsLess_Shd_NotThrow()
		{
			var arg = new List<byte> { 1, 2, 3 };
			var exp = arg;
			var ret = default(List<byte>);
			var lmt = (uint) 10;

			var action = () => ret = Throw.IfCountMoreThanOrEqualTo(arg, lmt);

			action.Should().NotThrow();
			Assert.AreEqual(exp, ret);
		}


		[TestMethod]
		public void IfCountMoreThanOrEqualTo_IsSame_Shd_Throw_CustEx()
		{
			var arg = new List<byte> { 1, 2, 3 };
			var exp = default(List<byte>);
			var ret = default(List<byte>);
			var lmt = (uint) arg.Count;
			var msg = "Collection count error";

			var action = () => ret = Throw.IfCountMoreThanOrEqualTo(
				arg, lmt, ex: argName => new ApplicationException(argName + msg));

			action.Should()
				.ThrowExactly<ApplicationException>()
				.WithMessage($"{nameof(arg)}{msg}*")
				;

			Assert.AreEqual(exp, ret);
		}

		[TestMethod]
		public void IfCountMoreThanOrEqualTo_IsSame_Shd_Throw_w_CustMsg()
		{
			var arg = new List<byte> { 1, 2, 3 };
			var exp = default(List<byte>);
			var ret = default(List<byte>);
			var lmt = (uint) arg.Count;
			var msg = "Collection count error";

			var action = () => ret = Throw.IfCountMoreThanOrEqualTo(arg, lmt, msg);

			action.Should()
				.ThrowExactly<ArgumentException>()
				.WithMessage($"{msg}*")
				.And.ParamName.Should()
				.BeEquivalentTo(nameof(arg))
				;

			Assert.AreEqual(exp, ret);
		}

		[TestMethod]
		public void IfCountMoreThanOrEqualTo_IsSame_Shd_Throw_w_DefMsg()
		{
			var arg = new List<byte> { 1, 2, 3 };
			var exp = default(List<byte>);
			var ret = default(List<byte>);
			var lmt = (uint) arg.Count;
			var msg = SR.Err_Collection_Count_MoreThanOrEqualTo.SF(arg.Count, lmt);

			var action = () => ret = Throw.IfCountMoreThanOrEqualTo(arg, lmt);

			action.Should()
				.ThrowExactly<ArgumentException>()
				.WithMessage($"{msg}*")
				.And.ParamName.Should()
				.BeEquivalentTo(nameof(arg))
				;

			Assert.AreEqual(exp, ret);
		}


		[TestMethod]
		public void IfCountMoreThanOrEqualTo_IsMore_Shd_Throw_CustEx()
		{
			var arg = new List<byte> { 1, 2, 3 };
			var exp = default(List<byte>);
			var ret = default(List<byte>);
			var lmt = (uint) 1;
			var msg = "Collection count error";

			var action = () => ret = Throw.IfCountMoreThanOrEqualTo(
				arg, lmt, ex: argName => new ApplicationException(argName + msg));

			action.Should()
				.ThrowExactly<ApplicationException>()
				.WithMessage($"{nameof(arg)}{msg}*")
				;

			Assert.AreEqual(exp, ret);
		}

		[TestMethod]
		public void IfCountMoreThanOrEqualTo_IsMore_Shd_Throw_w_CustMsg()
		{
			var arg = new List<byte> { 1, 2, 3 };
			var exp = default(List<byte>);
			var ret = default(List<byte>);
			var lmt = (uint) 1;
			var msg = "Collection count error";

			var action = () => ret = Throw.IfCountMoreThanOrEqualTo(arg, lmt, msg);

			action.Should()
				.ThrowExactly<ArgumentException>()
				.WithMessage($"{msg}*")
				.And.ParamName.Should()
				.BeEquivalentTo(nameof(arg))
				;

			Assert.AreEqual(exp, ret);
		}

		[TestMethod]
		public void IfCountMoreThanOrEqualTo_IsMore_Shd_Throw_w_DefMsg()
		{
			var arg = new List<byte> { 1, 2, 3 };
			var exp = default(List<byte>);
			var ret = default(List<byte>);
			var lmt = (uint) 1;
			var msg = SR.Err_Collection_Count_MoreThanOrEqualTo.SF(arg.Count, lmt);

			var action = () => ret = Throw.IfCountMoreThanOrEqualTo(arg, lmt);

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
		public void IfCountIs_IsNull_Shd_Throw()
		{
			var arg = default(List<byte>?);
			var exp = default(List<byte>?);
			var ret = default(List<byte>?);

			var action = () => ret = Throw.IfCountIs(arg!, 0);

			action.Should().ThrowExactly<ArgumentNullException>();
			Assert.AreEqual(exp, ret);
		}

		[TestMethod]
		public void IfCountIs_No_Shd_NotThrow()
		{
			var arg = new List<byte> { 1, 2, 3 };
			var exp = arg;
			var ret = default(List<byte>);
			var lmt = (uint) 99;

			var action = () => ret = Throw.IfCountIs(arg, lmt);

			action.Should().NotThrow();
			Assert.AreEqual(exp, ret);
		}

		[TestMethod]
		public void IfCountIs_Yes_Shd_Throw_CustEx()
		{
			var arg = new List<byte> { 1, 2, 3 };
			var exp = default(List<byte>);
			var ret = default(List<byte>);
			var lmt = (uint) arg.Count;
			var msg = "Collection count error";

			var action = () => ret = Throw.IfCountIs(
				arg, lmt, ex: argName => new ApplicationException(argName + msg));

			action.Should()
				.ThrowExactly<ApplicationException>()
				.WithMessage($"{nameof(arg)}{msg}*")
				;

			Assert.AreEqual(exp, ret);
		}

		[TestMethod]
		public void IfCountIs_Yes_Shd_Throw_w_CustMsg()
		{
			var arg = new List<byte> { 1, 2, 3 };
			var exp = default(List<byte>);
			var ret = default(List<byte>);
			var lmt = (uint) arg.Count;
			var msg = "Collection count error";

			var action = () => ret = Throw.IfCountIs(arg, lmt, msg);

			action.Should()
				.ThrowExactly<ArgumentException>()
				.WithMessage($"{msg}*")
				.And.ParamName.Should()
				.BeEquivalentTo(nameof(arg))
				;

			Assert.AreEqual(exp, ret);
		}

		[TestMethod]
		public void IfCountIs_Yes_Shd_Throw_w_DefMsg()
		{
			var arg = new List<byte> { 1, 2, 3 };
			var exp = default(List<byte>);
			var ret = default(List<byte>);
			var lmt = (uint) arg.Count;
			var msg = SR.Err_Collection_Count_Is.SF(lmt);

			var action = () => ret = Throw.IfCountIs(arg, lmt);

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
		public void IfCountIsNot_IsNull_Shd_Throw()
		{
			var arg = default(List<byte>?);
			var exp = default(List<byte>?);
			var ret = default(List<byte>?);

			var action = () => ret = Throw.IfCountIsNot(arg!, 0);

			action.Should().ThrowExactly<ArgumentNullException>();
			Assert.AreEqual(exp, ret);
		}

		[TestMethod]
		public void IfCountIsNot_No_Shd_NotThrow()
		{
			var arg = new List<byte> { 1, 2, 3 };
			var exp = arg;
			var ret = default(List<byte>);
			var lmt = (uint) arg.Count;

			var action = () => ret = Throw.IfCountIsNot(arg, lmt);

			action.Should().NotThrow();
			Assert.AreEqual(exp, ret);
		}

		[TestMethod]
		public void IfCountIsNot_Yes_Shd_Throw_CustEx()
		{
			var arg = new List<byte> { 1, 2, 3 };
			var exp = default(List<byte>);
			var ret = default(List<byte>);
			var lmt = (uint) 99;
			var msg = "Collection count error";

			var action = () => ret = Throw.IfCountIsNot(
				arg, lmt, ex: argName => new ApplicationException(argName + msg));

			action.Should()
				.ThrowExactly<ApplicationException>()
				.WithMessage($"{nameof(arg)}{msg}*")
				;

			Assert.AreEqual(exp, ret);
		}

		[TestMethod]
		public void IfCountIsNot_Yes_Shd_Throw_w_CustMsg()
		{
			var arg = new List<byte> { 1, 2, 3 };
			var exp = default(List<byte>);
			var ret = default(List<byte>);
			var lmt = (uint) 99;
			var msg = "Collection count error";

			var action = () => ret = Throw.IfCountIsNot(arg, lmt, msg);

			action.Should()
				.ThrowExactly<ArgumentException>()
				.WithMessage($"{msg}*")
				.And.ParamName.Should()
				.BeEquivalentTo(nameof(arg))
				;

			Assert.AreEqual(exp, ret);
		}

		[TestMethod]
		public void IfCountIsNot_Yes_Shd_Throw_w_DefMsg()
		{
			var arg = new List<byte> { 1, 2, 3 };
			var exp = default(List<byte>);
			var ret = default(List<byte>);
			var lmt = (uint) 99;
			var msg = SR.Err_Collection_Count_IsNot.SF(arg.Count, lmt);

			var action = () => ret = Throw.IfCountIsNot(arg, lmt);

			action.Should()
				.ThrowExactly<ArgumentException>()
				.WithMessage($"{msg}*")
				.And.ParamName.Should()
				.BeEquivalentTo(nameof(arg))
				;

			Assert.AreEqual(exp, ret);
		}

		//--

		static bool FuncTrue<T>(T t) => true;
		static bool FuncFalse<T>(T t) => false;

		//--

		[TestMethod]
		public void IfAnyElement_IsNull_Shd_Throw()
		{
			var arg = default(List<byte>);
			var exp = default(List<byte>);
			var ret = default(IEnumerable<byte>);

			var action = () => ret = Throw.IfAnyElement(arg!, FuncFalse);

			action.Should().ThrowExactly<ArgumentNullException>();
			Assert.AreEqual(exp, ret);
		}

		[TestMethod]
		public void IfAnyElement_No_Shd_NotThrow()
		{
			var arg = new List<byte>() { 1, 2, 3 };
			var exp = arg;
			var ret = default(IEnumerable<byte>);

			var action = () => ret = Throw.IfAnyElement(arg, FuncFalse);

			action.Should().NotThrow();
			Assert.AreEqual(exp, ret);
		}

		[TestMethod]
		public void IfAnyElement_Yes_Shd_Throw_CustEx()
		{
			var arg = new List<byte>() { 1, 2, 3 };
			var exp = default(List<byte>);
			var ret = default(IEnumerable<byte>);
			var msg = "Collection count error";

			var action = () => ret = Throw.IfAnyElement(
				arg, FuncTrue, ex: argName => new ApplicationException(argName + msg));

			action.Should()
				.ThrowExactly<ApplicationException>()
				.WithMessage($"{nameof(arg)}{msg}*")
				;

			Assert.AreEqual(exp, ret);
		}

		[TestMethod]
		public void IfAnyElement_Yes_Shd_Throw_w_CustMsg()
		{
			var arg = new List<byte>() { 1, 2, 3 };
			var exp = default(List<byte>);
			var ret = default(IEnumerable<byte>);
			var msg = "Collection count error";

			var action = () => ret = Throw.IfAnyElement(arg, FuncTrue, msg);

			action.Should()
				.ThrowExactly<ArgumentException>()
				.WithMessage($"{msg}*")
				.And.ParamName.Should()
				.BeEquivalentTo(nameof(arg))
				;

			Assert.AreEqual(exp, ret);
		}

		[TestMethod]
		public void IfAnyElement_Yes_Shd_Throw_w_DefMsg()
		{
			var arg = new List<byte>() { 1, 2, 3 };
			var exp = default(List<byte>);
			var ret = default(IEnumerable<byte>);
			var msg = SR.Err_Collection_Item_Any;

			var action = () => ret = Throw.IfAnyElement(arg, FuncTrue);

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
		public void IfAnyElementNot_IsNull_Shd_Throw()
		{
			var arg = default(List<byte>);
			var exp = default(List<byte>);
			var ret = default(IEnumerable<byte>);

			var action = () => ret = Throw.IfAnyElementNot(arg!, FuncFalse);

			action.Should().ThrowExactly<ArgumentNullException>();
			Assert.AreEqual(exp, ret);
		}

		[TestMethod]
		public void IfAnyElementNot_No_Shd_NotThrow()
		{
			var arg = new List<byte>() { 1, 2, 3 };
			var exp = arg;
			var ret = default(IEnumerable<byte>);

			var action = () => ret = Throw.IfAnyElementNot(arg, FuncTrue);

			action.Should().NotThrow();
			Assert.AreEqual(exp, ret);
		}

		[TestMethod]
		public void IfAnyElementNot_Yes_Shd_Throw_CustEx()
		{
			var arg = new List<byte>() { 1, 2, 3 };
			var exp = default(List<byte>);
			var ret = default(IEnumerable<byte>);
			var msg = "Collection count error";

			var action = () => ret = Throw.IfAnyElementNot(
				arg, FuncFalse, ex: argName => new ApplicationException(argName + msg));

			action.Should()
				.ThrowExactly<ApplicationException>()
				.WithMessage($"{nameof(arg)}{msg}*")
				;

			Assert.AreEqual(exp, ret);
		}

		[TestMethod]
		public void IfAnyElementNot_Yes_Shd_Throw_w_CustMsg()
		{
			var arg = new List<byte>() { 1, 2, 3 };
			var exp = default(List<byte>);
			var ret = default(IEnumerable<byte>);
			var msg = "Collection count error";

			var action = () => ret = Throw.IfAnyElementNot(arg, FuncFalse, msg);

			action.Should()
				.ThrowExactly<ArgumentException>()
				.WithMessage($"{msg}*")
				.And.ParamName.Should()
				.BeEquivalentTo(nameof(arg))
				;

			Assert.AreEqual(exp, ret);
		}

		[TestMethod]
		public void IfAnyElementNot_Yes_Shd_Throw_w_DefMsg()
		{
			var arg = new List<byte>() { 1, 2, 3 };
			var exp = default(List<byte>);
			var ret = default(IEnumerable<byte>);
			var msg = SR.Err_Collection_Item_AnyNot;

			var action = () => ret = Throw.IfAnyElementNot(arg, FuncFalse);

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
		public void IfAnyElementNullOrEmpty_CollectionNull_Shd_Throw()
		{
			var arg = default(List<string>?);
			var exp = default(List<string>?);
			var ret = default(List<string>?);

			var action = () => ret = Throw.IfAnyElementNullOrEmpty(arg!);

			action.Should().ThrowExactly<ArgumentNullException>();
			Assert.AreEqual(exp, ret);
		}

		[TestMethod]
		public void IfAnyElementNullOrEmpty_No_Shd_NotThrow()
		{
			var arg = new List<string?>() { "one", "two" };
			var exp = arg;
			var ret = default(IEnumerable<string?>?);

			var action = () => ret = Throw.IfAnyElementNullOrEmpty(arg);

			action.Should().NotThrow();
			Assert.AreEqual(exp, ret);
		}


		[TestMethod]
		public void IfAnyElementNullOrEmpty_YesNull_Shd_Throw_CustEx()
		{
			var arg = new List<string?>() { "one", "two", null };
			var exp = default(List<string?>?);
			var ret = default(IEnumerable<string?>?);
			var msg = "Collection count error";

			var action = () => ret = Throw.IfAnyElementNullOrEmpty(
				arg, ex: argName => new ApplicationException(argName + msg));

			action.Should()
				.ThrowExactly<ApplicationException>()
				.WithMessage($"{nameof(arg)}{msg}*")
				;

			Assert.AreEqual(exp, ret);
		}

		[TestMethod]
		public void IfAnyElementNullOrEmpty_YesNull_Shd_Throw_w_CustMsg()
		{
			var arg = new List<string?>() { "one", "two", null };
			var exp = default(List<string?>?);
			var ret = default(IEnumerable<string?>?);
			var msg = "Collection count error";

			var action = () => ret = Throw.IfAnyElementNullOrEmpty(arg, msg);

			action.Should()
				.ThrowExactly<ArgumentException>()
				.WithMessage($"{msg}*")
				.And.ParamName.Should()
				.BeEquivalentTo(nameof(arg))
				;

			Assert.AreEqual(exp, ret);
		}

		[TestMethod]
		public void IfAnyElementNullOrEmpty_YesNull_Shd_Throw_w_DefMsg()
		{
			var arg = new List<string?>() { "one", "two", null };
			var exp = default(List<string?>?);
			var ret = default(IEnumerable<string?>?);
			var msg = SR.Err_Collection_Item_NullOrEmpty;

			var action = () => ret = Throw.IfAnyElementNullOrEmpty(arg);

			action.Should()
				.ThrowExactly<ArgumentException>()
				.WithMessage($"{msg}*")
				.And.ParamName.Should()
				.BeEquivalentTo(nameof(arg))
				;

			Assert.AreEqual(exp, ret);
		}


		[TestMethod]
		public void IfAnyElementNullOrEmpty_YesEmpty_Shd_Throw_CustEx()
		{
			var arg = new List<string?>() { "one", "two", "" };
			var exp = default(List<string?>?);
			var ret = default(IEnumerable<string?>?);
			var msg = "Collection count error";

			var action = () => ret = Throw.IfAnyElementNullOrEmpty(
				arg, ex: argName => new ApplicationException(argName + msg));

			action.Should()
				.ThrowExactly<ApplicationException>()
				.WithMessage($"{nameof(arg)}{msg}*")
				;

			Assert.AreEqual(exp, ret);
		}

		[TestMethod]
		public void IfAnyElementNullOrEmpty_YesEmpty_Shd_Throw_w_CustMsg()
		{
			var arg = new List<string?>() { "one", "two", "" };
			var exp = default(List<string?>?);
			var ret = default(IEnumerable<string?>?);
			var msg = "Collection count error";

			var action = () => ret = Throw.IfAnyElementNullOrEmpty(arg, msg);

			action.Should()
				.ThrowExactly<ArgumentException>()
				.WithMessage($"{msg}*")
				.And.ParamName.Should()
				.BeEquivalentTo(nameof(arg))
				;

			Assert.AreEqual(exp, ret);
		}

		[TestMethod]
		public void IfAnyElementNullOrEmpty_YesEmpty_Shd_Throw_w_DefMsg()
		{
			var arg = new List<string?>() { "one", "two", "" };
			var exp = default(List<string?>?);
			var ret = default(IEnumerable<string?>?);
			var msg = SR.Err_Collection_Item_NullOrEmpty;

			var action = () => ret = Throw.IfAnyElementNullOrEmpty(arg);

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
		public void IfAnyElementNullOrWhitespace_CollectionNull_Shd_Throw()
		{
			var arg = default(List<string>?);
			var exp = default(List<string>?);
			var ret = default(List<string>?);

			var action = () => ret = Throw.IfAnyElementNullOrWhitespace(arg!);

			action.Should().ThrowExactly<ArgumentNullException>();
			Assert.AreEqual(exp, ret);
		}

		[TestMethod]
		public void IfAnyElementNullOrWhitespace_No_Shd_NotThrow()
		{
			var arg = new List<string?>() { "one", "two" };
			var exp = arg;
			var ret = default(IEnumerable<string?>?);

			var action = () => ret = Throw.IfAnyElementNullOrWhitespace(arg);

			action.Should().NotThrow();
			Assert.AreEqual(exp, ret);
		}


		[TestMethod]
		public void IfAnyElementNullOrWhitespace_YesNull_Shd_Throw_CustEx()
		{
			var arg = new List<string?>() { "one", "two", null };
			var exp = default(List<string?>?);
			var ret = default(IEnumerable<string?>?);
			var msg = "Collection count error";

			var action = () => ret = Throw.IfAnyElementNullOrWhitespace(
				arg, ex: argName => new ApplicationException(argName + msg));

			action.Should()
				.ThrowExactly<ApplicationException>()
				.WithMessage($"{nameof(arg)}{msg}*")
				;

			Assert.AreEqual(exp, ret);
		}

		[TestMethod]
		public void IfAnyElementNullOrWhitespace_YesNull_Shd_Throw_w_CustMsg()
		{
			var arg = new List<string?>() { "one", "two", null };
			var exp = default(List<string?>?);
			var ret = default(IEnumerable<string?>?);
			var msg = "Collection count error";

			var action = () => ret = Throw.IfAnyElementNullOrWhitespace(arg, msg);

			action.Should()
				.ThrowExactly<ArgumentException>()
				.WithMessage($"{msg}*")
				.And.ParamName.Should()
				.BeEquivalentTo(nameof(arg))
				;

			Assert.AreEqual(exp, ret);
		}

		[TestMethod]
		public void IfAnyElementNullOrWhitespace_YesNull_Shd_Throw_w_DefMsg()
		{
			var arg = new List<string?>() { "one", "two", null };
			var exp = default(List<string?>?);
			var ret = default(IEnumerable<string?>?);
			var msg = SR.Err_Collection_Item_NullOrWhitespace;

			var action = () => ret = Throw.IfAnyElementNullOrWhitespace(arg);

			action.Should()
				.ThrowExactly<ArgumentException>()
				.WithMessage($"{msg}*")
				.And.ParamName.Should()
				.BeEquivalentTo(nameof(arg))
				;

			Assert.AreEqual(exp, ret);
		}


		[TestMethod]
		public void IfAnyElementNullOrWhitespace_YesEmpty_Shd_Throw_CustEx()
		{
			var arg = new List<string?>() { "one", "two", "" };
			var exp = default(List<string?>?);
			var ret = default(IEnumerable<string?>?);
			var msg = "Collection count error";

			var action = () => ret = Throw.IfAnyElementNullOrWhitespace(
				arg, ex: argName => new ApplicationException(argName + msg));

			action.Should()
				.ThrowExactly<ApplicationException>()
				.WithMessage($"{nameof(arg)}{msg}*")
				;

			Assert.AreEqual(exp, ret);
		}

		[TestMethod]
		public void IfAnyElementNullOrWhitespace_YesEmpty_Shd_Throw_w_CustMsg()
		{
			var arg = new List<string?>() { "one", "two", "" };
			var exp = default(List<string?>?);
			var ret = default(IEnumerable<string?>?);
			var msg = "Collection count error";

			var action = () => ret = Throw.IfAnyElementNullOrWhitespace(arg, msg);

			action.Should()
				.ThrowExactly<ArgumentException>()
				.WithMessage($"{msg}*")
				.And.ParamName.Should()
				.BeEquivalentTo(nameof(arg))
				;

			Assert.AreEqual(exp, ret);
		}

		[TestMethod]
		public void IfAnyElementNullOrWhitespace_YesEmpty_Shd_Throw_w_DefMsg()
		{
			var arg = new List<string?>() { "one", "two", "" };
			var exp = default(List<string?>?);
			var ret = default(IEnumerable<string?>?);
			var msg = SR.Err_Collection_Item_NullOrWhitespace;

			var action = () => ret = Throw.IfAnyElementNullOrWhitespace(arg);

			action.Should()
				.ThrowExactly<ArgumentException>()
				.WithMessage($"{msg}*")
				.And.ParamName.Should()
				.BeEquivalentTo(nameof(arg))
				;

			Assert.AreEqual(exp, ret);
		}


		[TestMethod]
		public void IfAnyElementNullOrWhitespace_YesWhitespace_Shd_Throw_CustEx()
		{
			var arg = new List<string?>() { "one", "two", " " };
			var exp = default(List<string?>?);
			var ret = default(IEnumerable<string?>?);
			var msg = "Collection count error";

			var action = () => ret = Throw.IfAnyElementNullOrWhitespace(
				arg, ex: argName => new ApplicationException(argName + msg));

			action.Should()
				.ThrowExactly<ApplicationException>()
				.WithMessage($"{nameof(arg)}{msg}*")
				;

			Assert.AreEqual(exp, ret);
		}

		[TestMethod]
		public void IfAnyElementNullOrWhitespace_YesWhitespace_Shd_Throw_w_CustMsg()
		{
			var arg = new List<string?>() { "one", "two", " " };
			var exp = default(List<string?>?);
			var ret = default(IEnumerable<string?>?);
			var msg = "Collection count error";

			var action = () => ret = Throw.IfAnyElementNullOrWhitespace(arg, msg);

			action.Should()
				.ThrowExactly<ArgumentException>()
				.WithMessage($"{msg}*")
				.And.ParamName.Should()
				.BeEquivalentTo(nameof(arg))
				;

			Assert.AreEqual(exp, ret);
		}

		[TestMethod]
		public void IfAnyElementNullOrWhitespace_YesWhitespace_Shd_Throw_w_DefMsg()
		{
			var arg = new List<string?>() { "one", "two", " " };
			var exp = default(List<string?>?);
			var ret = default(IEnumerable<string?>?);
			var msg = SR.Err_Collection_Item_NullOrWhitespace;

			var action = () => ret = Throw.IfAnyElementNullOrWhitespace(arg);

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
