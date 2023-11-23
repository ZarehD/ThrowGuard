namespace ThrowGuard.UnitTests
{
	[TestClass]
	public class GuardsUriTests
	{
		[TestMethod]
		public void IfAbsolute_No_Shd_NotThrow()
		{
			var arg = new Uri("test", UriKind.Relative);
			var exp = arg;
			var ret = default(Uri);

			var action = () => ret = Throw.IfAbsolute(arg);

			action.Should().NotThrow();
			Assert.AreEqual(exp, ret);
		}

		[TestMethod]
		public void IfAbsolute_Yes_Shd_Throw_CustEx()
		{
			var arg = new Uri("//test/path", UriKind.Absolute);
			var exp = default(Uri);
			var ret = default(Uri);
			var msg = "Absolute uri error.";

			var action = () => ret = Throw.IfAbsolute(
				arg, ex: argName => new ApplicationException(argName + msg));

			action.Should()
				.ThrowExactly<ApplicationException>()
				.WithMessage($"{nameof(arg)}{msg}*")
				;

			Assert.AreEqual(exp, ret);
		}

		[TestMethod]
		public void IfAbsolute_Yes_Shd_Throw_w_CustMsg()
		{
			var arg = new Uri("//test/path", UriKind.Absolute);
			var exp = default(Uri);
			var ret = default(Uri);
			var msg = "Absolute uri error.";

			var action = () => ret = Throw.IfAbsolute(arg, msg);

			action.Should()
				.ThrowExactly<ArgumentException>()
				.WithMessage($"{msg}*")
				.And.ParamName.Should()
				.BeEquivalentTo(nameof(arg))
				;

			Assert.AreEqual(exp, ret);
		}

		[TestMethod]
		public void IfAbsolute_Yes_Shd_Throw_w_DefMsg()
		{
			var arg = new Uri("//test/path", UriKind.Absolute);
			var exp = default(Uri);
			var ret = default(Uri);
			var msg = SR.Err_Uri_IsAbsolute;

			var action = () => ret = Throw.IfAbsolute(arg);

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
		public void IfRelative_No_Shd_NotThrow()
		{
			var arg = new Uri("//test", UriKind.Absolute);
			var exp = arg;
			var ret = default(Uri);

			var action = () => ret = Throw.IfRelative(arg);

			action.Should().NotThrow();
			Assert.AreEqual(exp, ret);
		}

		[TestMethod]
		public void IfRelative_Yes_Shd_Throw_CustEx()
		{
			var arg = new Uri("test/path", UriKind.Relative);
			var exp = default(Uri);
			var ret = default(Uri);
			var msg = "Relative uri error.";

			var action = () => ret = Throw.IfRelative(
				arg, ex: argName => new ApplicationException(argName + msg));

			action.Should()
				.ThrowExactly<ApplicationException>()
				.WithMessage($"{nameof(arg)}{msg}*")
				;

			Assert.AreEqual(exp, ret);
		}

		[TestMethod]
		public void IfRelative_Yes_Shd_Throw_w_CustMsg()
		{
			var arg = new Uri("test/path", UriKind.Relative);
			var exp = default(Uri);
			var ret = default(Uri);
			var msg = "Relative uri error.";

			var action = () => ret = Throw.IfRelative(arg, msg);

			action.Should()
				.ThrowExactly<ArgumentException>()
				.WithMessage($"{msg}*")
				.And.ParamName.Should()
				.BeEquivalentTo(nameof(arg))
				;

			Assert.AreEqual(exp, ret);
		}

		[TestMethod]
		public void IfRelative_Yes_Shd_Throw_w_DefMsg()
		{
			var arg = new Uri("test/path", UriKind.Relative);
			var exp = default(Uri);
			var ret = default(Uri);
			var msg = SR.Err_Uri_IsRelative;

			var action = () => ret = Throw.IfRelative(arg);

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
		public void IfSchemeIs_No_Shd_NotThrow()
		{
			var sch = UriScheme.Http;
			var arg = new Uri("ftp://test");
			var exp = arg;
			var ret = default(Uri);

			var action = () => ret = Throw.IfSchemeIs(arg, sch);

			action.Should().NotThrow();
			Assert.AreEqual(exp, ret);
		}

		[TestMethod]
		public void IfSchemeIs_Yes_Shd_Throw_CustEx()
		{
			var sch = UriScheme.Http;
			var arg = new Uri($"{sch}://test/path");
			var exp = default(Uri);
			var ret = default(Uri);
			var msg = "Uri scheme error.";

			var action = () => ret = Throw.IfSchemeIs(
				arg, sch, ex: argName => new ApplicationException(argName + msg));

			action.Should()
				.ThrowExactly<ApplicationException>()
				.WithMessage($"{nameof(arg)}{msg}*")
				;

			Assert.AreEqual(exp, ret);
		}

		[TestMethod]
		public void IfSchemeIs_Yes_Shd_Throw_w_CustMsg()
		{
			var sch = UriScheme.Http;
			var arg = new Uri($"{sch}://test/path");
			var exp = default(Uri);
			var ret = default(Uri);
			var msg = "Uri scheme error.";

			var action = () => ret = Throw.IfSchemeIs(arg, sch, msg);

			action.Should()
				.ThrowExactly<ArgumentException>()
				.WithMessage($"{msg}*")
				.And.ParamName.Should()
				.BeEquivalentTo(nameof(arg))
				;

			Assert.AreEqual(exp, ret);
		}

		[TestMethod]
		public void IfSchemeIs_Yes_Shd_Throw_w_DefMsg()
		{
			var sch = UriScheme.Http;
			var arg = new Uri($"{sch}://test/path");
			var exp = default(Uri);
			var ret = default(Uri);
			var msg = SR.Err_Uri_SchemeIs.SF(sch);

			var action = () => ret = Throw.IfSchemeIs(arg, sch);

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
		public void IfSchemeIsNot_No_Shd_NotThrow()
		{
			var sch = UriScheme.Http;
			var arg = new Uri($"{sch}://test/path");
			var exp = arg;
			var ret = default(Uri);

			var action = () => ret = Throw.IfSchemeIsNot(arg, sch);

			action.Should().NotThrow();
			Assert.AreEqual(exp, ret);
		}

		[TestMethod]
		public void IfSchemeIsNot_Yes_Shd_Throw_CustEx()
		{
			var sch = UriScheme.Http;
			var arg = new Uri("ftp://test");
			var exp = default(Uri);
			var ret = default(Uri);
			var msg = "Uri scheme error.";

			var action = () => ret = Throw.IfSchemeIsNot(
				arg, sch, ex: argName => new ApplicationException(argName + msg));

			action.Should()
				.ThrowExactly<ApplicationException>()
				.WithMessage($"{nameof(arg)}{msg}*")
				;

			Assert.AreEqual(exp, ret);
		}

		[TestMethod]
		public void IfSchemeIsNot_Yes_Shd_Throw_w_CustMsg()
		{
			var sch = UriScheme.Http;
			var arg = new Uri("ftp://test");
			var exp = default(Uri);
			var ret = default(Uri);
			var msg = "Uri scheme error.";

			var action = () => ret = Throw.IfSchemeIsNot(arg, sch, msg);

			action.Should()
				.ThrowExactly<ArgumentException>()
				.WithMessage($"{msg}*")
				.And.ParamName.Should()
				.BeEquivalentTo(nameof(arg))
				;

			Assert.AreEqual(exp, ret);
		}

		[TestMethod]
		public void IfSchemeIsNot_Yes_Shd_Throw_w_DefMsg()
		{
			var sch = UriScheme.Http;
			var arg = new Uri("ftp://test");
			var exp = default(Uri);
			var ret = default(Uri);
			var msg = SR.Err_Uri_SchemeIsNot.SF(sch);

			var action = () => ret = Throw.IfSchemeIsNot(arg, sch);

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
		public void IfPortIs_No_Shd_NotThrow()
		{
			var prt = 8080;
			var arg = new Uri("ftp://test:1234");
			var exp = arg;
			var ret = default(Uri);

			var action = () => ret = Throw.IfPortIs(arg, prt);

			action.Should().NotThrow();
			Assert.AreEqual(exp, ret);
		}

		[TestMethod]
		public void IfPortIs_Yes_Shd_Throw_CustEx()
		{
			var prt = 8080;
			var arg = new Uri($"http://test:{prt}/path");
			var exp = default(Uri);
			var ret = default(Uri);
			var msg = "Uri port error.";

			var action = () => ret = Throw.IfPortIs(
				arg, prt, ex: argName => new ApplicationException(argName + msg));

			action.Should()
				.ThrowExactly<ApplicationException>()
				.WithMessage($"{nameof(arg)}{msg}*")
				;

			Assert.AreEqual(exp, ret);
		}

		[TestMethod]
		public void IfPortIs_Yes_Shd_Throw_w_CustMsg()
		{
			var prt = 8080;
			var arg = new Uri($"http://test:{prt}/path");
			var exp = default(Uri);
			var ret = default(Uri);
			var msg = "Uri port error.";

			var action = () => ret = Throw.IfPortIs(arg, prt, msg);

			action.Should()
				.ThrowExactly<ArgumentException>()
				.WithMessage($"{msg}*")
				.And.ParamName.Should()
				.BeEquivalentTo(nameof(arg))
				;

			Assert.AreEqual(exp, ret);
		}

		[TestMethod]
		public void IfPortIs_Yes_Shd_Throw_w_DefMsg()
		{
			var prt = 8080;
			var arg = new Uri($"http://test:{prt}/path");
			var exp = default(Uri);
			var ret = default(Uri);
			var msg = SR.Err_Uri_PortIs.SF(prt);

			var action = () => ret = Throw.IfPortIs(arg, prt);

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
		public void IfPortIsNot_No_Shd_NotThrow()
		{
			var prt = 8080;
			var arg = new Uri($"http://test:{prt}/path");
			var exp = arg;
			var ret = default(Uri);

			var action = () => ret = Throw.IfPortIsNot(arg, prt);

			action.Should().NotThrow();
			Assert.AreEqual(exp, ret);
		}

		[TestMethod]
		public void IfPortIsNot_Yes_Shd_Throw_CustEx()
		{
			var prt = 8080;
			var arg = new Uri("ftp://test:1234");
			var exp = default(Uri);
			var ret = default(Uri);
			var msg = "Uri port error.";

			var action = () => ret = Throw.IfPortIsNot(
				arg, prt, ex: argName => new ApplicationException(argName + msg));

			action.Should()
				.ThrowExactly<ApplicationException>()
				.WithMessage($"{nameof(arg)}{msg}*")
				;

			Assert.AreEqual(exp, ret);
		}

		[TestMethod]
		public void IfPortIsNot_Yes_Shd_Throw_w_CustMsg()
		{
			var prt = 8080;
			var arg = new Uri("ftp://test:1234");
			var exp = default(Uri);
			var ret = default(Uri);
			var msg = "Uri port error.";

			var action = () => ret = Throw.IfPortIsNot(arg, prt, msg);

			action.Should()
				.ThrowExactly<ArgumentException>()
				.WithMessage($"{msg}*")
				.And.ParamName.Should()
				.BeEquivalentTo(nameof(arg))
				;

			Assert.AreEqual(exp, ret);
		}

		[TestMethod]
		public void IfPortIsNot_Yes_Shd_Throw_w_DefMsg()
		{
			var prt = 8080;
			var arg = new Uri("ftp://test:1234");
			var exp = default(Uri);
			var ret = default(Uri);
			var msg = SR.Err_Uri_PortIsNot.SF(prt);

			var action = () => ret = Throw.IfPortIsNot(arg, prt);

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
		public void IfPortIsDefault_No_Shd_NotThrow()
		{
			var arg = new Uri("http://test:1234");
			var exp = arg;
			var ret = default(Uri);

			var action = () => ret = Throw.IfPortIsDefault(arg);

			action.Should().NotThrow();
			Assert.AreEqual(exp, ret);
		}

		[TestMethod]
		public void IfPortIsDefault_Yes_Shd_Throw_CustEx()
		{
			var arg = new Uri($"http://test/path");
			var exp = default(Uri);
			var ret = default(Uri);
			var msg = "Uri port error.";

			var action = () => ret = Throw.IfPortIsDefault(
				arg, ex: argName => new ApplicationException(argName + msg));

			action.Should()
				.ThrowExactly<ApplicationException>()
				.WithMessage($"{nameof(arg)}{msg}*")
				;

			Assert.AreEqual(exp, ret);
		}

		[TestMethod]
		public void IfPortIsDefault_Yes_Shd_Throw_w_CustMsg()
		{
			var arg = new Uri($"http://test/path");
			var exp = default(Uri);
			var ret = default(Uri);
			var msg = "Uri port error.";

			var action = () => ret = Throw.IfPortIsDefault(arg, msg);

			action.Should()
				.ThrowExactly<ArgumentException>()
				.WithMessage($"{msg}*")
				.And.ParamName.Should()
				.BeEquivalentTo(nameof(arg))
				;

			Assert.AreEqual(exp, ret);
		}

		[TestMethod]
		public void IfPortIsDefault_Yes_Shd_Throw_w_DefMsg()
		{
			var arg = new Uri($"http://test/path");
			var exp = default(Uri);
			var ret = default(Uri);
			var msg = SR.Err_Uri_PortIsDefault;

			var action = () => ret = Throw.IfPortIsDefault(arg);

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
		public void IfPortIsNotDefault_No_Shd_NotThrow()
		{
			var arg = new Uri($"http://test/path");
			var exp = arg;
			var ret = default(Uri);

			var action = () => ret = Throw.IfPortIsNotDefault(arg);

			action.Should().NotThrow();
			Assert.AreEqual(exp, ret);
		}

		[TestMethod]
		public void IfPortIsNotDefault_Yes_Shd_Throw_CustEx()
		{
			var arg = new Uri("http://test:1234");
			var exp = default(Uri);
			var ret = default(Uri);
			var msg = "Uri port error.";

			var action = () => ret = Throw.IfPortIsNotDefault(
				arg, ex: argName => new ApplicationException(argName + msg));

			action.Should()
				.ThrowExactly<ApplicationException>()
				.WithMessage($"{nameof(arg)}{msg}*")
				;

			Assert.AreEqual(exp, ret);
		}

		[TestMethod]
		public void IfPortIsNotDefault_Yes_Shd_Throw_w_CustMsg()
		{
			var arg = new Uri("http://test:1234");
			var exp = default(Uri);
			var ret = default(Uri);
			var msg = "Uri port error.";

			var action = () => ret = Throw.IfPortIsNotDefault(arg, msg);

			action.Should()
				.ThrowExactly<ArgumentException>()
				.WithMessage($"{msg}*")
				.And.ParamName.Should()
				.BeEquivalentTo(nameof(arg))
				;

			Assert.AreEqual(exp, ret);
		}

		[TestMethod]
		public void IfPortIsNotDefault_Yes_Shd_Throw_w_DefMsg()
		{
			var arg = new Uri("http://test:1234");
			var exp = default(Uri);
			var ret = default(Uri);
			var msg = SR.Err_Uri_PortIsNotDefault;

			var action = () => ret = Throw.IfPortIsNotDefault(arg);

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
		public void IfHostIs_No_Shd_NotThrow()
		{
			var hst = "test";
			var arg = new Uri("ftp://host");
			var exp = arg;
			var ret = default(Uri);

			var action = () => ret = Throw.IfHostIs(arg, hst);

			action.Should().NotThrow();
			Assert.AreEqual(exp, ret);
		}

		[TestMethod]
		public void IfHostIs_Yes_Shd_Throw_CustEx()
		{
			var hst = "test";
			var arg = new Uri($"ftp://{hst}");
			var exp = default(Uri);
			var ret = default(Uri);
			var msg = "Uri host error.";

			var action = () => ret = Throw.IfHostIs(
				arg, hst, ex: argName => new ApplicationException(argName + msg));

			action.Should()
				.ThrowExactly<ApplicationException>()
				.WithMessage($"{nameof(arg)}{msg}*")
				;

			Assert.AreEqual(exp, ret);
		}

		[TestMethod]
		public void IfHostIs_Yes_Shd_Throw_w_CustMsg()
		{
			var hst = "test";
			var arg = new Uri($"ftp://{hst}");
			var exp = default(Uri);
			var ret = default(Uri);
			var msg = "Uri host error.";

			var action = () => ret = Throw.IfHostIs(arg, hst, msg);

			action.Should()
				.ThrowExactly<ArgumentException>()
				.WithMessage($"{msg}*")
				.And.ParamName.Should()
				.BeEquivalentTo(nameof(arg))
				;

			Assert.AreEqual(exp, ret);
		}

		[TestMethod]
		public void IfHostIs_Yes_Shd_Throw_w_DefMsg()
		{
			var hst = "test";
			var arg = new Uri($"ftp://{hst}");
			var exp = default(Uri);
			var ret = default(Uri);
			var msg = SR.Err_Uri_HostIs.SF(hst);

			var action = () => ret = Throw.IfHostIs(arg, hst);

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
		public void IfHostIsNot_No_Shd_NotThrow()
		{
			var hst = "test";
			var arg = new Uri($"ftp://{hst}");
			var exp = arg;
			var ret = default(Uri);

			var action = () => ret = Throw.IfHostIsNot(arg, hst);

			action.Should().NotThrow();
			Assert.AreEqual(exp, ret);
		}

		[TestMethod]
		public void IfHostIsNot_Yes_Shd_Throw_CustEx()
		{
			var hst = "test";
			var arg = new Uri("ftp://host");
			var exp = default(Uri);
			var ret = default(Uri);
			var msg = "Uri host error.";

			var action = () => ret = Throw.IfHostIsNot(
				arg, hst, ex: argName => new ApplicationException(argName + msg));

			action.Should()
				.ThrowExactly<ApplicationException>()
				.WithMessage($"{nameof(arg)}{msg}*")
				;

			Assert.AreEqual(exp, ret);
		}

		[TestMethod]
		public void IfHostIsNot_Yes_Shd_Throw_w_CustMsg()
		{
			var hst = "test";
			var arg = new Uri("ftp://host");
			var exp = default(Uri);
			var ret = default(Uri);
			var msg = "Uri host error.";

			var action = () => ret = Throw.IfHostIsNot(arg, hst, msg);

			action.Should()
				.ThrowExactly<ArgumentException>()
				.WithMessage($"{msg}*")
				.And.ParamName.Should()
				.BeEquivalentTo(nameof(arg))
				;

			Assert.AreEqual(exp, ret);
		}

		[TestMethod]
		public void IfHostIsNot_Yes_Shd_Throw_w_DefMsg()
		{
			var hst = "test";
			var arg = new Uri("ftp://host");
			var exp = default(Uri);
			var ret = default(Uri);
			var msg = SR.Err_Uri_HostIsNot.SF(hst);

			var action = () => ret = Throw.IfHostIsNot(arg, hst);

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
		public void IfHostNameTypeIs_No_Shd_NotThrow()
		{
			var hnt = UriHostNameType.Unknown;
			var arg = new Uri("ftp://host-name");
			var exp = arg;
			var ret = default(Uri);

			var action = () => ret = Throw.IfHostNameTypeIs(arg, hnt);

			action.Should().NotThrow();
			Assert.AreEqual(exp, ret);
		}

		[TestMethod]
		public void IfHostNameTypeIs_Yes_Shd_Throw_CustEx()
		{
			var hnt = UriHostNameType.Dns;
			var arg = new Uri($"ftp://host-name.dom");
			var exp = default(Uri);
			var ret = default(Uri);
			var msg = "Uri HostNameType error.";

			var action = () => ret = Throw.IfHostNameTypeIs(
				arg, hnt, ex: argName => new ApplicationException(argName + msg));

			action.Should()
				.ThrowExactly<ApplicationException>()
				.WithMessage($"{nameof(arg)}{msg}*")
				;

			Assert.AreEqual(exp, ret);
		}

		[TestMethod]
		public void IfHostNameTypeIs_Yes_Shd_Throw_w_CustMsg()
		{
			var hnt = UriHostNameType.Dns;
			var arg = new Uri($"ftp://host-name.dom");
			var exp = default(Uri);
			var ret = default(Uri);
			var msg = "Uri HostNameType error.";

			var action = () => ret = Throw.IfHostNameTypeIs(arg, hnt, msg);

			action.Should()
				.ThrowExactly<ArgumentException>()
				.WithMessage($"{msg}*")
				.And.ParamName.Should()
				.BeEquivalentTo(nameof(arg))
				;

			Assert.AreEqual(exp, ret);
		}

		[TestMethod]
		public void IfHostNameTypeIs_Yes_Shd_Throw_w_DefMsg()
		{
			var hnt = UriHostNameType.Dns;
			var arg = new Uri($"ftp://host-name.dom");
			var exp = default(Uri);
			var ret = default(Uri);
			var msg = SR.Err_Uri_HostNameTypeIs.SF(hnt);

			var action = () => ret = Throw.IfHostNameTypeIs(arg, hnt);

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
		public void IfHostNameTypeIsNot_No_Shd_NotThrow()
		{
			var hnt = UriHostNameType.Dns;
			var arg = new Uri($"ftp://host-name.dom");
			var exp = arg;
			var ret = default(Uri);

			var action = () => ret = Throw.IfHostNameTypeIsNot(arg, hnt);

			action.Should().NotThrow();
			Assert.AreEqual(exp, ret);
		}

		[TestMethod]
		public void IfHostNameTypeIsNot_Yes_Shd_Throw_CustEx()
		{
			var hnt = UriHostNameType.Unknown;
			var arg = new Uri("ftp://host-name");
			var exp = default(Uri);
			var ret = default(Uri);
			var msg = "Uri HostNameType error.";

			var action = () => ret = Throw.IfHostNameTypeIsNot(
				arg, hnt, ex: argName => new ApplicationException(argName + msg));

			action.Should()
				.ThrowExactly<ApplicationException>()
				.WithMessage($"{nameof(arg)}{msg}*")
				;

			Assert.AreEqual(exp, ret);
		}

		[TestMethod]
		public void IfHostNameTypeIsNot_Yes_Shd_Throw_w_CustMsg()
		{
			var hnt = UriHostNameType.Unknown;
			var arg = new Uri("ftp://host-name");
			var exp = default(Uri);
			var ret = default(Uri);
			var msg = "Uri HostNameType error.";

			var action = () => ret = Throw.IfHostNameTypeIsNot(arg, hnt, msg);

			action.Should()
				.ThrowExactly<ArgumentException>()
				.WithMessage($"{msg}*")
				.And.ParamName.Should()
				.BeEquivalentTo(nameof(arg))
				;

			Assert.AreEqual(exp, ret);
		}

		[TestMethod]
		public void IfHostNameTypeIsNot_Yes_Shd_Throw_w_DefMsg()
		{
			var hnt = UriHostNameType.Unknown;
			var arg = new Uri("ftp://host-name");
			var exp = default(Uri);
			var ret = default(Uri);
			var msg = SR.Err_Uri_HostNameTypeIsNot.SF(hnt);

			var action = () => ret = Throw.IfHostNameTypeIsNot(arg, hnt);

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
		public void IfBaseOf_No_Shd_NotThrow()
		{
			var arg = new Uri("ftp://host-name");
			var uri = new Uri("//host/path");
			var exp = arg;
			var ret = default(Uri);

			var action = () => ret = Throw.IfBaseOf(arg, uri);

			action.Should().NotThrow();
			Assert.AreEqual(exp, ret);
		}

		[TestMethod]
		public void IfBaseOf_Yes_Shd_Throw_CustEx()
		{
			var arg = new Uri("ftp://host-name");
			var uri = new Uri($"{arg}/path");
			var exp = default(Uri);
			var ret = default(Uri);
			var msg = "Uri BaseOf error.";

			var action = () => ret = Throw.IfBaseOf(
				arg, uri, ex: argName => new ApplicationException(argName + msg));

			action.Should()
				.ThrowExactly<ApplicationException>()
				.WithMessage($"{nameof(arg)}{msg}*")
				;

			Assert.AreEqual(exp, ret);
		}

		[TestMethod]
		public void IfBaseOf_Yes_Shd_Throw_w_CustMsg()
		{
			var arg = new Uri("ftp://host-name");
			var uri = new Uri($"{arg}/path");
			var exp = default(Uri);
			var ret = default(Uri);
			var msg = "Uri BaseOf error.";

			var action = () => ret = Throw.IfBaseOf(arg, uri, msg);

			action.Should()
				.ThrowExactly<ArgumentException>()
				.WithMessage($"{msg}*")
				.And.ParamName.Should()
				.BeEquivalentTo(nameof(arg))
				;

			Assert.AreEqual(exp, ret);
		}

		[TestMethod]
		public void IfBaseOf_Yes_Shd_Throw_w_DefMsg()
		{
			var arg = new Uri("ftp://host-name");
			var uri = new Uri($"{arg}/path");
			var exp = default(Uri);
			var ret = default(Uri);
			var msg = SR.Err_Uri_IsBaseOf.SF(arg, uri);

			var action = () => ret = Throw.IfBaseOf(arg, uri);

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
		public void IfNotBaseOf_No_Shd_NotThrow()
		{
			var arg = new Uri("ftp://host-name");
			var uri = new Uri($"{arg}/path");
			var exp = arg;
			var ret = default(Uri);

			var action = () => ret = Throw.IfNotBaseOf(arg, uri);

			action.Should().NotThrow();
			Assert.AreEqual(exp, ret);
		}

		[TestMethod]
		public void IfNotBaseOf_Yes_Shd_Throw_CustEx()
		{
			var arg = new Uri("ftp://host-name");
			var uri = new Uri("//host/path");
			var exp = default(Uri);
			var ret = default(Uri);
			var msg = "Uri BaseOf error.";

			var action = () => ret = Throw.IfNotBaseOf(
				arg, uri, ex: argName => new ApplicationException(argName + msg));

			action.Should()
				.ThrowExactly<ApplicationException>()
				.WithMessage($"{nameof(arg)}{msg}*")
				;

			Assert.AreEqual(exp, ret);
		}

		[TestMethod]
		public void IfNotBaseOf_Yes_Shd_Throw_w_CustMsg()
		{
			var arg = new Uri("ftp://host-name");
			var uri = new Uri("//host/path");
			var exp = default(Uri);
			var ret = default(Uri);
			var msg = "Uri BaseOf error.";

			var action = () => ret = Throw.IfNotBaseOf(arg, uri, msg);

			action.Should()
				.ThrowExactly<ArgumentException>()
				.WithMessage($"{msg}*")
				.And.ParamName.Should()
				.BeEquivalentTo(nameof(arg))
				;

			Assert.AreEqual(exp, ret);
		}

		[TestMethod]
		public void IfNotBaseOf_Yes_Shd_Throw_w_DefMsg()
		{
			var arg = new Uri("ftp://host-name");
			var uri = new Uri("//host/path");
			var exp = default(Uri);
			var ret = default(Uri);
			var msg = SR.Err_Uri_IsNotBaseOf.SF(arg, uri);

			var action = () => ret = Throw.IfNotBaseOf(arg, uri);

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
		public void IfFile_No_Shd_NotThrow()
		{
			var arg = new Uri("http://test");
			var exp = arg;
			var ret = default(Uri);

			var action = () => ret = Throw.IfFile(arg);

			action.Should().NotThrow();
			Assert.AreEqual(exp, ret);
		}

		[TestMethod]
		public void IfFile_Yes_Shd_Throw_CustEx()
		{
			var arg = new Uri($"file://test/path");
			var exp = default(Uri);
			var ret = default(Uri);
			var msg = "Uri file error.";

			var action = () => ret = Throw.IfFile(
				arg, ex: argName => new ApplicationException(argName + msg));

			action.Should()
				.ThrowExactly<ApplicationException>()
				.WithMessage($"{nameof(arg)}{msg}*")
				;

			Assert.AreEqual(exp, ret);
		}

		[TestMethod]
		public void IfFile_Yes_Shd_Throw_w_CustMsg()
		{
			var arg = new Uri($"file://test/path");
			var exp = default(Uri);
			var ret = default(Uri);
			var msg = "Uri file error.";

			var action = () => ret = Throw.IfFile(arg, msg);

			action.Should()
				.ThrowExactly<ArgumentException>()
				.WithMessage($"{msg}*")
				.And.ParamName.Should()
				.BeEquivalentTo(nameof(arg))
				;

			Assert.AreEqual(exp, ret);
		}

		[TestMethod]
		public void IfFile_Yes_Shd_Throw_w_DefMsg()
		{
			var arg = new Uri($"file://test/path");
			var exp = default(Uri);
			var ret = default(Uri);
			var msg = SR.Err_Uri_IsFile;

			var action = () => ret = Throw.IfFile(arg);

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
		public void IfNotFile_No_Shd_NotThrow()
		{
			var arg = new Uri($"file://test/path");
			var exp = arg;
			var ret = default(Uri);

			var action = () => ret = Throw.IfNotFile(arg);

			action.Should().NotThrow();
			Assert.AreEqual(exp, ret);
		}

		[TestMethod]
		public void IfNotFile_Yes_Shd_Throw_CustEx()
		{
			var arg = new Uri("http://test");
			var exp = default(Uri);
			var ret = default(Uri);
			var msg = "Uri file error.";

			var action = () => ret = Throw.IfNotFile(
				arg, ex: argName => new ApplicationException(argName + msg));

			action.Should()
				.ThrowExactly<ApplicationException>()
				.WithMessage($"{nameof(arg)}{msg}*")
				;

			Assert.AreEqual(exp, ret);
		}

		[TestMethod]
		public void IfNotFile_Yes_Shd_Throw_w_CustMsg()
		{
			var arg = new Uri("http://test");
			var exp = default(Uri);
			var ret = default(Uri);
			var msg = "Uri file error.";

			var action = () => ret = Throw.IfNotFile(arg, msg);

			action.Should()
				.ThrowExactly<ArgumentException>()
				.WithMessage($"{msg}*")
				.And.ParamName.Should()
				.BeEquivalentTo(nameof(arg))
				;

			Assert.AreEqual(exp, ret);
		}

		[TestMethod]
		public void IfNotFile_Yes_Shd_Throw_w_DefMsg()
		{
			var arg = new Uri("http://test");
			var exp = default(Uri);
			var ret = default(Uri);
			var msg = SR.Err_Uri_IsNotFile;

			var action = () => ret = Throw.IfNotFile(arg);

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
		public void IfUnc_No_Shd_NotThrow()
		{
			var arg = new Uri("http://test");
			var exp = arg;
			var ret = default(Uri);

			var action = () => ret = Throw.IfUnc(arg);

			action.Should().NotThrow();
			Assert.AreEqual(exp, ret);
		}

		[TestMethod]
		public void IfUnc_Yes_Shd_Throw_CustEx()
		{
			var arg = new Uri($"//test/path");
			var exp = default(Uri);
			var ret = default(Uri);
			var msg = "Uri unc error.";

			var action = () => ret = Throw.IfUnc(
				arg, ex: argName => new ApplicationException(argName + msg));

			action.Should()
				.ThrowExactly<ApplicationException>()
				.WithMessage($"{nameof(arg)}{msg}*")
				;

			Assert.AreEqual(exp, ret);
		}

		[TestMethod]
		public void IfUnc_Yes_Shd_Throw_w_CustMsg()
		{
			var arg = new Uri($"//test/path");
			var exp = default(Uri);
			var ret = default(Uri);
			var msg = "Uri unc error.";

			var action = () => ret = Throw.IfUnc(arg, msg);

			action.Should()
				.ThrowExactly<ArgumentException>()
				.WithMessage($"{msg}*")
				.And.ParamName.Should()
				.BeEquivalentTo(nameof(arg))
				;

			Assert.AreEqual(exp, ret);
		}

		[TestMethod]
		public void IfUnc_Yes_Shd_Throw_w_DefMsg()
		{
			var arg = new Uri($"//test/path");
			var exp = default(Uri);
			var ret = default(Uri);
			var msg = SR.Err_Uri_IsUnc;

			var action = () => ret = Throw.IfUnc(arg);

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
		public void IfNotUnc_No_Shd_NotThrow()
		{
			var arg = new Uri($"//test/path");
			var exp = arg;
			var ret = default(Uri);

			var action = () => ret = Throw.IfNotUnc(arg);

			action.Should().NotThrow();
			Assert.AreEqual(exp, ret);
		}

		[TestMethod]
		public void IfNotUnc_Yes_Shd_Throw_CustEx()
		{
			var arg = new Uri("http://test");
			var exp = default(Uri);
			var ret = default(Uri);
			var msg = "Uri unc error.";

			var action = () => ret = Throw.IfNotUnc(
				arg, ex: argName => new ApplicationException(argName + msg));

			action.Should()
				.ThrowExactly<ApplicationException>()
				.WithMessage($"{nameof(arg)}{msg}*")
				;

			Assert.AreEqual(exp, ret);
		}

		[TestMethod]
		public void IfNotUnc_Yes_Shd_Throw_w_CustMsg()
		{
			var arg = new Uri("http://test");
			var exp = default(Uri);
			var ret = default(Uri);
			var msg = "Uri unc error.";

			var action = () => ret = Throw.IfNotUnc(arg, msg);

			action.Should()
				.ThrowExactly<ArgumentException>()
				.WithMessage($"{msg}*")
				.And.ParamName.Should()
				.BeEquivalentTo(nameof(arg))
				;

			Assert.AreEqual(exp, ret);
		}

		[TestMethod]
		public void IfNotUnc_Yes_Shd_Throw_w_DefMsg()
		{
			var arg = new Uri("http://test");
			var exp = default(Uri);
			var ret = default(Uri);
			var msg = SR.Err_Uri_IsNotUnc;

			var action = () => ret = Throw.IfNotUnc(arg);

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
		public void IfLoopback_No_Shd_NotThrow()
		{
			var arg = new Uri("http://host.dom/path");
			var exp = arg;
			var ret = default(Uri);

			var action = () => ret = Throw.IfLoopback(arg);

			action.Should().NotThrow();
			Assert.AreEqual(exp, ret);
		}


		[TestMethod]
		public void IfLoopback_Yes_Nam_Shd_Throw_CustEx()
		{
			var arg = new Uri("http://localhost");
			var exp = default(Uri);
			var ret = default(Uri);
			var msg = "Uri loopback error.";

			var action = () => ret = Throw.IfLoopback(
				arg, ex: argName => new ApplicationException(argName + msg));

			action.Should()
				.ThrowExactly<ApplicationException>()
				.WithMessage($"{nameof(arg)}{msg}*")
				;

			Assert.AreEqual(exp, ret);
		}

		[TestMethod]
		public void IfLoopback_Yes_Nam_Shd_Throw_w_CustMsg()
		{
			var arg = new Uri("http://localhost");
			var exp = default(Uri);
			var ret = default(Uri);
			var msg = "Uri loopback error.";

			var action = () => ret = Throw.IfLoopback(arg, msg);

			action.Should()
				.ThrowExactly<ArgumentException>()
				.WithMessage($"{msg}*")
				.And.ParamName.Should()
				.BeEquivalentTo(nameof(arg))
				;

			Assert.AreEqual(exp, ret);
		}

		[TestMethod]
		public void IfLoopback_Yes_Nam_Shd_Throw_w_DefMsg()
		{
			var arg = new Uri("http://localhost");
			var exp = default(Uri);
			var ret = default(Uri);
			var msg = SR.Err_Uri_IsLoopback;

			var action = () => ret = Throw.IfLoopback(arg);

			action.Should()
				.ThrowExactly<ArgumentException>()
				.WithMessage($"{msg}*")
				.And.ParamName.Should()
				.BeEquivalentTo(nameof(arg))
				;

			Assert.AreEqual(exp, ret);
		}


		[TestMethod]
		public void IfLoopback_Yes_IP4_Shd_Throw_CustEx()
		{
			var arg = new Uri("http://127.0.0.1");
			var exp = default(Uri);
			var ret = default(Uri);
			var msg = "Uri loopback error.";

			var action = () => ret = Throw.IfLoopback(
				arg, ex: argName => new ApplicationException(argName + msg));

			action.Should()
				.ThrowExactly<ApplicationException>()
				.WithMessage($"{nameof(arg)}{msg}*")
				;

			Assert.AreEqual(exp, ret);
		}

		[TestMethod]
		public void IfLoopback_Yes_IP4_Shd_Throw_w_CustMsg()
		{
			var arg = new Uri("http://127.0.0.1");
			var exp = default(Uri);
			var ret = default(Uri);
			var msg = "Uri loopback error.";

			var action = () => ret = Throw.IfLoopback(arg, msg);

			action.Should()
				.ThrowExactly<ArgumentException>()
				.WithMessage($"{msg}*")
				.And.ParamName.Should()
				.BeEquivalentTo(nameof(arg))
				;

			Assert.AreEqual(exp, ret);
		}

		[TestMethod]
		public void IfLoopback_Yes_IP4_Shd_Throw_w_DefMsg()
		{
			var arg = new Uri("http://127.0.0.1");
			var exp = default(Uri);
			var ret = default(Uri);
			var msg = SR.Err_Uri_IsLoopback;

			var action = () => ret = Throw.IfLoopback(arg);

			action.Should()
				.ThrowExactly<ArgumentException>()
				.WithMessage($"{msg}*")
				.And.ParamName.Should()
				.BeEquivalentTo(nameof(arg))
				;

			Assert.AreEqual(exp, ret);
		}


		[TestMethod]
		public void IfLoopback_Yes_IP6_Shd_Throw_CustEx()
		{
			var arg = new Uri("http://[::1]");
			var exp = default(Uri);
			var ret = default(Uri);
			var msg = "Uri loopback error.";

			var action = () => ret = Throw.IfLoopback(
				arg, ex: argName => new ApplicationException(argName + msg));

			action.Should()
				.ThrowExactly<ApplicationException>()
				.WithMessage($"{nameof(arg)}{msg}*")
				;

			Assert.AreEqual(exp, ret);
		}

		[TestMethod]
		public void IfLoopback_Yes_IP6_Shd_Throw_w_CustMsg()
		{
			var arg = new Uri("http://[::1]");
			var exp = default(Uri);
			var ret = default(Uri);
			var msg = "Uri loopback error.";

			var action = () => ret = Throw.IfLoopback(arg, msg);

			action.Should()
				.ThrowExactly<ArgumentException>()
				.WithMessage($"{msg}*")
				.And.ParamName.Should()
				.BeEquivalentTo(nameof(arg))
				;

			Assert.AreEqual(exp, ret);
		}

		[TestMethod]
		public void IfLoopback_Yes_IP6_Shd_Throw_w_DefMsg()
		{
			var arg = new Uri("http://[::1]");
			var exp = default(Uri);
			var ret = default(Uri);
			var msg = SR.Err_Uri_IsLoopback;

			var action = () => ret = Throw.IfLoopback(arg);

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
		public void IfNotLoopback_No_Dns_Shd_NotThrow()
		{
			var arg = new Uri("http://localhost");
			var exp = arg;
			var ret = default(Uri);

			var action = () => ret = Throw.IfNotLoopback(arg);

			action.Should().NotThrow();
			Assert.AreEqual(exp, ret);
		}

		[TestMethod]
		public void IfNotLoopback_No_IP4_Shd_NotThrow()
		{
			var arg = new Uri("http://127.0.0.1");
			var exp = arg;
			var ret = default(Uri);

			var action = () => ret = Throw.IfNotLoopback(arg);

			action.Should().NotThrow();
			Assert.AreEqual(exp, ret);
		}

		[TestMethod]
		public void IfNotLoopback_No_IP6_Shd_NotThrow()
		{
			var arg = new Uri("http://[::1]");
			var exp = arg;
			var ret = default(Uri);

			var action = () => ret = Throw.IfNotLoopback(arg);

			action.Should().NotThrow();
			Assert.AreEqual(exp, ret);
		}

		[TestMethod]
		public void IfNotLoopback_Yes_Shd_Throw_CustEx()
		{
			var arg = new Uri("http://host.dom/path");
			var exp = default(Uri);
			var ret = default(Uri);
			var msg = "Uri loopback error.";

			var action = () => ret = Throw.IfNotLoopback(
				arg, ex: argName => new ApplicationException(argName + msg));

			action.Should()
				.ThrowExactly<ApplicationException>()
				.WithMessage($"{nameof(arg)}{msg}*")
				;

			Assert.AreEqual(exp, ret);
		}

		[TestMethod]
		public void IfNotLoopback_Yes_Shd_Throw_w_CustMsg()
		{
			var arg = new Uri("http://host.dom/path");
			var exp = default(Uri);
			var ret = default(Uri);
			var msg = "Uri loopback error.";

			var action = () => ret = Throw.IfNotLoopback(arg, msg);

			action.Should()
				.ThrowExactly<ArgumentException>()
				.WithMessage($"{msg}*")
				.And.ParamName.Should()
				.BeEquivalentTo(nameof(arg))
				;

			Assert.AreEqual(exp, ret);
		}

		[TestMethod]
		public void IfNotLoopback_Yes_Shd_Throw_w_DefMsg()
		{
			var arg = new Uri("http://host.dom/path");
			var exp = default(Uri);
			var ret = default(Uri);
			var msg = SR.Err_Uri_IsNotLoopback;

			var action = () => ret = Throw.IfNotLoopback(arg);

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
