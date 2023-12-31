﻿namespace ThrowGuard.UnitTests
{
	[TestClass]
	public class GuardsWhenTests
	{
		[TestMethod]
		public void When_False_Shd_Not_Throw()
		{
			var con = false;

			var action = () => Throw.When(() => con, new ApplicationException());

			action.Should().NotThrow();
		}

		[TestMethod]
		public void When_True_Shd_Throw()
		{
			var con = true;
			var msg = "error message";

			var action = () => Throw.When(() => con, new ApplicationException(msg));

			action.Should()
				.ThrowExactly<ApplicationException>()
				.WithMessage($"{msg}*")
				;
		}

		//--

		[TestMethod]
		public void ArgNullWhen_False_Shd_Not_Throw()
		{
			var con = false;

			var action = () => Throw.ArgNullWhen(() => con);

			action.Should().NotThrow();
		}

		[TestMethod]
		public void ArgNullWhen_True_Shd_Throw()
		{
			var con = true;
			var msg = "error message";
			var arg = "arg-name";

			var action = () => Throw.ArgNullWhen(() => con, msg, arg);

			action.Should()
				.ThrowExactly<ArgumentNullException>()
				.WithMessage($"{msg}*")
				.And.ParamName.Should()
				.BeEquivalentTo(arg)
				;
		}

		//--

		[TestMethod]
		public void BadArgWhen_False_Shd_Not_Throw()
		{
			var con = false;

			var action = () => Throw.BadArgWhen(() => con);

			action.Should().NotThrow();
		}

		[TestMethod]
		public void BadArgWhen_True_Shd_Throw()
		{
			var con = true;
			var msg = "error message";
			var arg = "arg-name";

			var action = () => Throw.BadArgWhen(() => con, msg, arg);

			action.Should()
				.ThrowExactly<ArgumentException>()
				.WithMessage($"{msg}*")
				.And.ParamName.Should()
				.BeEquivalentTo(arg)
				;
		}

		//--

		[TestMethod]
		public void DirectoryNotFoundWhen_False_Shd_Not_Throw()
		{
			var con = false;

			var action = () => Throw.DirectoryNotFoundWhen(() => con);

			action.Should().NotThrow();
		}

		[TestMethod]
		public void DirectoryNotFoundWhen_True_Shd_Throw_wo_Path()
		{
			var con = true;
			var msg = "error message";


			var action = () => Throw.DirectoryNotFoundWhen(() => con, msg);

			action.Should()
				.ThrowExactly<DirectoryNotFoundException>()
				.WithMessage($"{msg}*")
				;
		}

		[TestMethod]
		public void DirectoryNotFoundWhen_True_Shd_Throw_w_Path()
		{
			var con = true;
			var pth = @"\\path\to\folder";
			var msg = $"error message. ({pth}).";


			var action = () => Throw.DirectoryNotFoundWhen(() => con, msg);

			action.Should()
				.ThrowExactly<DirectoryNotFoundException>()
				.WithMessage($"{msg}*")
				;
		}

		//--

		[TestMethod]
		public void FileNotFoundWhen_False_Shd_Not_Throw()
		{
			var con = false;

			var action = () => Throw.FileNotFoundWhen(() => con);

			action.Should().NotThrow();
		}

		[TestMethod]
		public void FileNotFoundWhen_True_Shd_Throw_wo_Pathname()
		{
			var con = true;
			var msg = "error message";

			var action = () => Throw.FileNotFoundWhen(() => con, msg);

			action.Should()
				.ThrowExactly<FileNotFoundException>()
				.WithMessage($"{msg}*")
				;
		}

		[TestMethod]
		public void FileNotFoundWhen_True_Shd_Throw_w_Pathname()
		{
			var con = true;
			var pth = @"\\path\to\file";
			var msg = "error message";

			var action = () => Throw.FileNotFoundWhen(() => con, msg, pth);

			action.Should()
				.ThrowExactly<FileNotFoundException>()
				.WithMessage($"{msg}*")
				.And.FileName.Should()
				.BeEquivalentTo(pth)
				;
		}

		//--

		[TestMethod]
		public void InvalidCastWhen_False_Shd_Not_Throw()
		{
			var con = false;

			var action = () => Throw.InvalidCastWhen(() => con);

			action.Should().NotThrow();
		}

		[TestMethod]
		public void InvalidCastWhen_True_Shd_Throw()
		{
			var con = true;
			var msg = "error message";

			var action = () => Throw.InvalidCastWhen(() => con, msg);

			action.Should()
				.ThrowExactly<InvalidCastException>()
				.WithMessage($"{msg}*")
				;
		}

		//--

		[TestMethod]
		public void InvalidOpWhen_False_Shd_Not_Throw()
		{
			var con = false;

			var action = () => Throw.InvalidOpWhen(() => con);

			action.Should().NotThrow();
		}

		[TestMethod]
		public void InvalidOpWhen_True_Shd_Throw()
		{
			var con = true;
			var msg = "error message";

			var action = () => Throw.InvalidOpWhen(() => con, msg);

			action.Should()
				.ThrowExactly<InvalidOperationException>()
				.WithMessage($"{msg}*")
				;
		}

		//--

		[TestMethod]
		public void ValidationErrorWhen_False_Shd_Not_Throw()
		{
			var con = false;

			var action = () => Throw.ValidationErrorWhen(() => con);

			action.Should().NotThrow();
		}

		[TestMethod]
		public void ValidationErrorWhen_True_Shd_Throw()
		{
			var con = true;
			var msg = "error message";

			var action = () => Throw.ValidationErrorWhen(() => con, msg);

			action.Should()
				.ThrowExactly<ValidationException>()
				.WithMessage($"{msg}*")
				;
		}
	}
}
