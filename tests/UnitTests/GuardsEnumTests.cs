using System;

namespace ThrowGuard.UnitTests
{
	[TestClass]
	public class GuardsEnumTests
	{
		private enum TestEnum { None = 0, One, Two }

		private static readonly string TestEnumTypeName =
			typeof(TestEnum).FullName ?? typeof(TestEnum).Name;


		[TestMethod]
		public void IfNotMemberOf_Int_IsMember_Shd_NotThrow()
		{
			var arg = 1;
			TestEnum ret = TestEnum.None;
			TestEnum exp = TestEnum.One;

			var action = () => ret = Throw.IfNotMemberOf<TestEnum>(arg);

			action.Should().NotThrow();
			Assert.AreEqual(exp, ret);
		}

		[TestMethod]
		public void IfNotMemberOf_Int_IsNotMember_Shd_Throw_CustEx()
		{
			var arg = 99;
			TestEnum ret = TestEnum.None;
			TestEnum exp = TestEnum.None;
			var msg = "Not a member of enum error.";

			var action = () => ret = Throw.IfNotMemberOf<TestEnum>(
				arg, ex: argName => new ApplicationException(argName + msg));

			action.Should()
				.ThrowExactly<ApplicationException>()
				.WithMessage($"{nameof(arg)}{msg}*")
				;

			Assert.AreEqual(exp, ret);
		}

		[TestMethod]
		public void IfNotMemberOf_Int_IsNotMember_Shd_Throw_w_CustMsg()
		{
			var arg = 99;
			TestEnum ret = TestEnum.None;
			TestEnum exp = TestEnum.None;
			var msg = "Not a member of enum error.";

			var action = () => ret = Throw.IfNotMemberOf<TestEnum>(arg, msg);

			action.Should()
				.ThrowExactly<ArgumentException>()
				.WithMessage($"{msg}*")
				;

			Assert.AreEqual(exp, ret);
		}

		[TestMethod]
		public void IfNotMemberOf_Int_IsNotMember_Shd_Throw_w_DefMsg()
		{
			var arg = 99;
			TestEnum ret = TestEnum.None;
			TestEnum exp = TestEnum.None;
			var msg = SR.Err_Enum_NotMember_Fmt.SF(arg, TestEnumTypeName);

			var action = () => ret = Throw.IfNotMemberOf<TestEnum>(
				arg, ex: argName => new ApplicationException(msg));

			action.Should()
				.ThrowExactly<ApplicationException>()
				.WithMessage($"{msg}*")
				;

			Assert.AreEqual(exp, ret);
		}

		//--

		[TestMethod]
		public void IfNotMemberOf_String_IsMember_Shd_NotThrow()
		{
			var arg = "one";
			TestEnum ret = TestEnum.None;
			TestEnum exp = TestEnum.One;

			var action = () => ret = Throw.IfNotMemberOf<TestEnum>(arg);

			action.Should().NotThrow();
			Assert.AreEqual(exp, ret);
		}

		[TestMethod]
		public void IfNotMemberOf_String_IsNotMember_Shd_Throw_CustEx()
		{
			var arg = "ninety-nine";
			TestEnum ret = TestEnum.None;
			TestEnum exp = TestEnum.None;
			var msg = "Not a member of enum error.";

			var action = () => ret = Throw.IfNotMemberOf<TestEnum>(
				arg, ex: argName => new ApplicationException(argName + msg));

			action.Should()
				.ThrowExactly<ApplicationException>()
				.WithMessage($"{nameof(arg)}{msg}*")
				;

			Assert.AreEqual(exp, ret);
		}

		[TestMethod]
		public void IfNotMemberOf_String_IsNotMember_Shd_Throw_w_CustMsg()
		{
			var arg = "ninety-nine";
			TestEnum ret = TestEnum.None;
			TestEnum exp = TestEnum.None;
			var msg = "Not a member of enum error.";

			var action = () => ret = Throw.IfNotMemberOf<TestEnum>(arg, msg);

			action.Should()
				.ThrowExactly<ArgumentException>()
				.WithMessage($"{msg}*")
				;

			Assert.AreEqual(exp, ret);
		}

		[TestMethod]
		public void IfNotMemberOf_String_IsNotMember_Shd_Throw_w_DefMsg()
		{
			var arg = "ninety-nine";
			TestEnum ret = TestEnum.None;
			TestEnum exp = TestEnum.None;
			var msg = SR.Err_Enum_NotMember_Fmt.SF(arg, TestEnumTypeName);

			var action = () => ret = Throw.IfNotMemberOf<TestEnum>(
				arg, ex: argName => new ApplicationException(msg));

			action.Should()
				.ThrowExactly<ApplicationException>()
				.WithMessage($"{msg}*")
				;

			Assert.AreEqual(exp, ret);
		}
	}
}
