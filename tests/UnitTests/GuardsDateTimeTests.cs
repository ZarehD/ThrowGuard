namespace ThrowGuard.UnitTests
{
	[TestClass]
	public class GuardsDateTimeTests
	{
		[TestMethod]
		public void IfDateTimeKindIs_No_Shd_NotThrow()
		{
			var arg = DateTime.Now;
			var kind = DateTimeKind.Utc;

			var action = () => Throw.IfDateTimeKindIs(arg, kind);

			action.Should().NotThrow();
		}

		[TestMethod]
		public void IfDateTimeKindIs_Yes_Shd_Throw_CustEx()
		{
			var arg = DateTime.Now;
			var kind = arg.Kind;
			var msg = SR.Err_Uri_DateTimeKindIs.SF(kind.ToString());

			var action = () => Throw.IfDateTimeKindIs(
				arg, kind, ex: argName => new ApplicationException(msg));

			action.Should()
				.ThrowExactly<ApplicationException>()
				.WithMessage($"{msg}*")
				;
		}

		[TestMethod]
		public void IfDateTimeKindIs_Yes_Shd_Throw_w_CustMsg()
		{
			var arg = DateTime.Now;
			var kind = arg.Kind;
			var msg = "DateTime kinds are the same error";

			var action = () => Throw.IfDateTimeKindIs(arg, kind, msg);

			action.Should()
				.ThrowExactly<ArgumentException>()
				.WithMessage($"{msg}*")
				;
		}

		[TestMethod]
		public void IfDateTimeKindIs_Yes_Shd_Throw_w_DefMsg()
		{
			var arg = DateTime.Now;
			var kind = arg.Kind;
			var msg = SR.Err_Uri_DateTimeKindIs.SF(kind.ToString());

			var action = () => Throw.IfDateTimeKindIs(arg, kind);

			action.Should()
				.ThrowExactly<ArgumentException>()
				.WithMessage($"{msg}*")
				;
		}

		//--

		[TestMethod]
		public void IfDateTimeKindIsNot_Yes_Shd_NotThrow()
		{
			var arg = DateTime.Now;
			var kind = arg.Kind;

			var action = () => Throw.IfDateTimeKindIsNot(arg, kind);

			action.Should().NotThrow();
		}

		[TestMethod]
		public void IfDateTimeKindIsNot_No_Shd_Throw_CustEx()
		{
			var arg = DateTime.Now;
			var kind = DateTimeKind.Utc;
			var msg = SR.Err_Uri_DateTimeKindIsNot.SF(kind.ToString());

			var action = () => Throw.IfDateTimeKindIsNot(
				arg, kind, ex: argName => new ApplicationException(msg));

			action.Should()
				.ThrowExactly<ApplicationException>()
				.WithMessage($"{msg}*")
				;
		}

		[TestMethod]
		public void IfDateTimeKindIsNot_No_Shd_Throw_w_CustMsg()
		{
			var arg = DateTime.Now;
			var kind = DateTimeKind.Utc;
			var msg = "DateTime kinds are not the same error";

			var action = () => Throw.IfDateTimeKindIsNot(arg, kind, msg);

			action.Should()
				.ThrowExactly<ArgumentException>()
				.WithMessage($"{msg}*")
				;
		}

		[TestMethod]
		public void IfDateTimeKindIsNot_No_Shd_Throw_w_DefMsg()
		{
			var arg = DateTime.Now;
			var kind = DateTimeKind.Utc;
			var msg = SR.Err_Uri_DateTimeKindIsNot.SF(kind.ToString());

			var action = () => Throw.IfDateTimeKindIsNot(arg, kind);

			action.Should()
				.ThrowExactly<ArgumentException>()
				.WithMessage($"{msg}*")
				;
		}
	}
}
