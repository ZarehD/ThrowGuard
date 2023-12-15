namespace ThrowGuard.UnitTests
{
	[TestClass]
	public class GuardsFileSystemTests
	{
		[TestMethod]
		public void IfDirectoryNotFound_NotNull_Exists_Shd_Not_Throw()
		{
			var pth = Directory.GetCurrentDirectory();
			var exp = pth;
			var ret = default(string);

			var action = () => ret = Throw.IfDirectoryNotFound(pth);

			action.Should().NotThrow();
			Assert.AreEqual(exp, ret);
		}


		[TestMethod]
		public void IfDirectoryNotFound_NotNull_NotExist_Throw_CustEx()
		{
			var pth = "/no-such-path/no-such-folder";
			var exp = default(string);
			var ret = default(string);
			var msg = SR.Err_Directory_NotFound_Path.SF(pth);

			var action = () => ret = Throw.IfDirectoryNotFound(
				pth, ex: argName => new ApplicationException(msg));

			action.Should()
				.ThrowExactly<ApplicationException>()
				.WithMessage($"{msg}*")
				;

			Assert.AreEqual(exp, ret);
		}

		[TestMethod]
		public void IfDirectoryNotFound_NotNull_NotExist_Throw_w_CustMsg()
		{
			var pth = "/no-such-path/no-such-folder";
			var exp = default(string);
			var ret = default(string);
			var msg = "No such folder error.";

			var action = () => ret = Throw.IfDirectoryNotFound(pth, msg);

			action.Should()
				.ThrowExactly<DirectoryNotFoundException>()
				.WithMessage($"{msg}*")
				;

			Assert.AreEqual(exp, ret);
		}

		[TestMethod]
		public void IfDirectoryNotFound_NotNull_NotExist_Throw_w_DefMsg()
		{
			var pth = "/no-such-path/no-such-folder";
			var exp = default(string);
			var ret = default(string);
			var msg = SR.Err_Directory_NotFound_Path.SF(pth);

			var action = () => ret = Throw.IfDirectoryNotFound(pth);

			action.Should()
				.ThrowExactly<DirectoryNotFoundException>()
				.WithMessage($"{msg}*")
				;

			Assert.AreEqual(exp, ret);
		}


		[TestMethod]
		public void IfDirectoryNotFound_Null_Shd_Throw_CustEx()
		{
			var pth = default(string?);
			var exp = default(string?);
			var ret = default(string?);
			var msg = "Folder path is null error.";

			var action = () => ret = Throw.IfDirectoryNotFound(
				pth, ex: argName => new ApplicationException(msg));

			action.Should()
				.ThrowExactly<ApplicationException>()
				.WithMessage($"{msg}*")
				;

			Assert.AreEqual(exp, ret);
		}

		[TestMethod]
		public void IfDirectoryNotFound_Null_Shd_Throw_w_CustMsg()
		{
			var pth = default(string?);
			var exp = default(string?);
			var ret = default(string?);
			var msg = "Folder path is null error.";

			var action = () => ret = Throw.IfDirectoryNotFound(pth, msg);

			action.Should()
				.ThrowExactly<ArgumentNullException>()
				.WithMessage($"{msg}*")
				;

			Assert.AreEqual(exp, ret);
		}

		[TestMethod]
		public void IfDirectoryNotFound_Null_Shd_Throw_w_DefMsg()
		{
			var pth = default(string?);
			var exp = default(string?);
			var ret = default(string?);
			var msg = SR.Err_NullArg;

			var action = () => ret = Throw.IfDirectoryNotFound(pth);

			action.Should()
				.ThrowExactly<ArgumentNullException>()
				.WithMessage($"{msg}*")
				;

			Assert.AreEqual(exp, ret);
		}

		//--

		[TestMethod]
		public void IfFileNotFound_NotNull_Exists_Shd_Not_Throw()
		{
			var pth = Directory.GetCurrentDirectory();
			var nam = Directory.GetFiles(pth).First();
			var exp = nam;
			var ret = default(string);

			var action = () => ret = Throw.IfFileNotFound(nam);

			action.Should().NotThrow();
			Assert.AreEqual(exp, ret);
		}


		[TestMethod]
		public void IfFileNotFound_NotNull_NotExist_Throw_CustEx()
		{
			var pth = "/no-such-path/no-such-folder";
			var exp = default(string);
			var ret = default(string);
			var msg = SR.Err_File_NotFound_Path.SF(pth);

			var action = () => ret = Throw.IfFileNotFound(
				pth, ex: argName => new ApplicationException(msg));

			action.Should()
				.ThrowExactly<ApplicationException>()
				.WithMessage($"{msg}*")
				;

			Assert.AreEqual(exp, ret);
		}

		[TestMethod]
		public void IfFileNotFound_NotNull_NotExist_Throw_w_CustMsg()
		{
			var pth = "/no-such-path/no-such-folder";
			var exp = default(string);
			var ret = default(string);
			var msg = "No such folder error.";

			var action = () => ret = Throw.IfFileNotFound(pth, msg);

			action.Should()
				.ThrowExactly<FileNotFoundException>()
				.WithMessage($"{msg}*")
				;

			Assert.AreEqual(exp, ret);
		}

		[TestMethod]
		public void IfFileNotFound_NotNull_NotExist_Throw_w_DefMsg()
		{
			var pth = "/no-such-path/no-such-folder";
			var exp = default(string);
			var ret = default(string);
			var msg = SR.Err_File_NotFound_Path.SF(pth);

			var action = () => ret = Throw.IfFileNotFound(pth);

			action.Should()
				.ThrowExactly<FileNotFoundException>()
				.WithMessage($"{msg}*")
				;

			Assert.AreEqual(exp, ret);
		}


		[TestMethod]
		public void IfFileNotFound_Null_Shd_Throw_CustEx()
		{
			var pth = default(string?);
			var exp = default(string?);
			var ret = default(string?);
			var msg = "File pathname is null error.";

			var action = () => ret = Throw.IfFileNotFound(
				pth, ex: argName => new ApplicationException(msg));

			action.Should()
				.ThrowExactly<ApplicationException>()
				.WithMessage($"{msg}*")
				;

			Assert.AreEqual(exp, ret);
		}

		[TestMethod]
		public void IfFileNotFound_Null_Shd_Throw_w_CustMsg()
		{
			var pth = default(string?);
			var exp = default(string?);
			var ret = default(string?);
			var msg = "File pathname is null error.";

			var action = () => ret = Throw.IfFileNotFound(pth, msg);

			action.Should()
				.ThrowExactly<ArgumentNullException>()
				.WithMessage($"{msg}*")
				;

			Assert.AreEqual(exp, ret);
		}

		[TestMethod]
		public void IfFileNotFound_Null_Shd_Throw_w_DefMsg()
		{
			var pth = default(string?);
			var exp = default(string?);
			var ret = default(string?);
			var msg = SR.Err_NullArg;

			var action = () => ret = Throw.IfFileNotFound(pth);

			action.Should()
				.ThrowExactly<ArgumentNullException>()
				.WithMessage($"{msg}*")
				;

			Assert.AreEqual(exp, ret);
		}
	}
}
