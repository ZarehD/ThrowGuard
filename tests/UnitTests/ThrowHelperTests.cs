namespace ThrowGuard.UnitTests
{
	[TestClass]
	public class ThrowHelperTests
	{
		[TestMethod]
		public void Throws_AppException_w_CustMsg()
		{
			var msg = "App Error";

			var action = () => Throw.AppException(msg);

			action.Should()
				.ThrowExactly<ApplicationException>()
				.WithMessage(msg)
				;
		}

		[TestMethod]
		public void Throws_AppException_w_DefMsg()
		{
			var msg = SR.Err_AppException;

			var action = () => Throw.AppException(msg);

			action.Should()
				.ThrowExactly<ApplicationException>()
				.WithMessage(msg)
				;
		}


		[TestMethod]
		public void Throws_BadArg_w_CustMsg()
		{
			var msg = "Arg Error";
			var arg = "arg-name";

			var action = () => Throw.BadArg(arg, msg);

			action.Should()
				.ThrowExactly<ArgumentException>()
				.WithMessage($"*{msg}*")
				.And.ParamName.Should()
				.BeEquivalentTo(arg)
				;
		}

		[TestMethod]
		public void Throws_BadArg_w_DefMsg()
		{
			var msg = SR.Err_BadArg;
			var arg = "arg-name";

			var action = () => Throw.BadArg(arg, msg);

			action.Should()
				.ThrowExactly<ArgumentException>()
				.WithMessage($"*{msg}*")
				.And.ParamName.Should()
				.BeEquivalentTo(arg)
				;
		}


		[TestMethod]
		public void Throws_DirectoryNotFound_w_CustMsg()
		{
			var msg = "Folder path not found.";

			var action = () => Throw.DirectoryNotFound(msg);

			action.Should()
				.ThrowExactly<DirectoryNotFoundException>()
				.WithMessage(msg)
				;
		}

		[TestMethod]
		public void Throws_DirectoryNotFound_w_DefMsg()
		{
			var msg = SR.Err_Directory_NotFound;

			var action = () => Throw.DirectoryNotFound(msg);

			action.Should()
				.ThrowExactly<DirectoryNotFoundException>()
				.WithMessage(msg)
				;
		}


		[TestMethod]
		public void Throws_Exception_w_CustMsg()
		{
			var msg = "Generic error.";

			var action = () => Throw.Exception(msg);

			action.Should()
				.ThrowExactly<Exception>()
				.WithMessage(msg)
				;
		}

		[TestMethod]
		public void Throws_Exception_w_DefMsg()
		{
			var msg = SR.Err_Exception;

			var action = () => Throw.Exception(msg);

			action.Should()
				.ThrowExactly<Exception>()
				.WithMessage(msg)
				;
		}


		[TestMethod]
		public void Throws_FileNotFound_w_CustMsg()
		{
			var msg = "File not found.";
			var pathname = "C:\\folder\\file-name";

			var action = () => Throw.FileNotFound(pathname, msg);

			action.Should()
				.ThrowExactly<FileNotFoundException>()
				.WithMessage(msg)
				.And.FileName.Should()
				.BeEquivalentTo(pathname)
				;
		}

		[TestMethod]
		public void Throws_FileNotFound_w_DefMsg()
		{
			var msg = SR.Err_File_NotFound;
			var pathname = "C:\\folder\\file-name";

			var action = () => Throw.FileNotFound(pathname, msg);

			action.Should()
				.ThrowExactly<FileNotFoundException>()
				.WithMessage(msg)
				.And.FileName.Should()
				.BeEquivalentTo(pathname)
				;
		}


		[TestMethod]
		public void Throws_IndexOutOfRange_w_CustMsg()
		{
			var msg = "Index out of range error.";

			var action = () => Throw.IndexOutOfRange(msg);

			action.Should()
				.ThrowExactly<IndexOutOfRangeException>()
				.WithMessage(msg)
				;
		}

		[TestMethod]
		public void Throws_IndexOutOfRange_w_DefMsg()
		{
			var msg = SR.Err_OutOfRange;

			var action = () => Throw.IndexOutOfRange();

			action.Should()
				.ThrowExactly<IndexOutOfRangeException>()
				.WithMessage(msg)
				;
		}


		[TestMethod]
		public void Throws_InvalidCast_w_CustMsg()
		{
			var msg = "Invalid cast error.";

			var action = () => Throw.InvalidCast(msg);

			action.Should()
				.ThrowExactly<InvalidCastException>()
				.WithMessage(msg)
				;
		}

		[TestMethod]
		public void Throws_InvalidCast_w_DefMsg()
		{
			var msg = SR.Err_InvalidCast;

			var action = () => Throw.InvalidCast();

			action.Should()
				.ThrowExactly<InvalidCastException>()
				.WithMessage(msg)
				;
		}


		private enum TestEnum { None = 0, One, Two }

		[TestMethod]
		public void Throws_InvalidEnum_Arg_and_BadVal()
		{
			var arg = "arg-name";
			var badVal = 12345;

			var action = () => Throw.InvalidEnum<TestEnum>(arg, badVal);

			action.Should()
				.ThrowExactly<InvalidEnumArgumentException>()
				.WithMessage($"*{badVal}*")
				.And.ParamName.Should()
				.BeEquivalentTo(arg)
				;
		}

		[TestMethod]
		public void Throws_InvalidEnum_w_CustMsg()
		{
			var msg = "Value not a member of enum error.";

			var action = () => Throw.InvalidEnum(msg);

			action.Should()
				.ThrowExactly<InvalidEnumArgumentException>()
				.WithMessage(msg)
				;
		}

		[TestMethod]
		public void Throws_InvalidEnum_w_DefMsg()
		{
			var msg = SR.Err_Enum_NotMember;

			var action = () => Throw.InvalidEnum();

			action.Should()
				.ThrowExactly<InvalidEnumArgumentException>()
				.WithMessage(msg)
				;
		}


		[TestMethod]
		public void Throws_InvalidOp_w_CustMsg()
		{
			var msg = "Invalid operation error.";

			var action = () => Throw.InvalidOp(msg);

			action.Should()
				.ThrowExactly<InvalidOperationException>()
				.WithMessage(msg)
				;
		}

		[TestMethod]
		public void Throws_InvalidOp_w_DefMsg()
		{
			var msg = SR.Err_InvalidOp;

			var action = () => Throw.InvalidOp();

			action.Should()
				.ThrowExactly<InvalidOperationException>()
				.WithMessage(msg)
				;
		}


		[TestMethod]
		public void Throws_NotImplementedn_w_CustMsg()
		{
			var msg = "Not implemented error.";

			var action = () => Throw.NotImplemented(msg);

			action.Should()
				.ThrowExactly<NotImplementedException>()
				.WithMessage(msg)
				;
		}

		[TestMethod]
		public void Throws_NotImplemented_w_DefMsg()
		{
			var msg = SR.Err_NotImplemented;

			var action = () => Throw.NotImplemented();

			action.Should()
				.ThrowExactly<NotImplementedException>()
				.WithMessage(msg)
				;
		}


		[TestMethod]
		public void Throws_NotSupportedn_w_CustMsg()
		{
			var msg = "Not supported error.";

			var action = () => Throw.NotSupported(msg);

			action.Should()
				.ThrowExactly<NotSupportedException>()
				.WithMessage(msg)
				;
		}

		[TestMethod]
		public void Throws_NotSupported_w_DefMsg()
		{
			var msg = SR.Err_NotSupported;

			var action = () => Throw.NotSupported();

			action.Should()
				.ThrowExactly<NotSupportedException>()
				.WithMessage(msg)
				;
		}


		[TestMethod]
		public void Throws_NullArg_w_CustMsg()
		{
			var msg = "Arg null error";
			var arg = "arg-name";

			var action = () => Throw.NullArg(arg, msg);

			action.Should()
				.ThrowExactly<ArgumentNullException>()
				.WithMessage($"*{msg}*")
				.And.ParamName.Should()
				.BeEquivalentTo(arg)
				;
		}

		[TestMethod]
		public void Throws_NullArg_w_DefMsg()
		{
			var msg = SR.Err_NullArg;
			var arg = "arg-name";

			var action = () => Throw.NullArg(arg, msg);

			action.Should()
				.ThrowExactly<ArgumentNullException>()
				.WithMessage($"*{msg}*")
				.And.ParamName.Should()
				.BeEquivalentTo(arg)
				;
		}


		[TestMethod]
		public void Throws_ValidationError_w_CustMsg()
		{
			var msg = "Validation error.";

			var action = () => Throw.ValidationError(msg);

			action.Should()
				.ThrowExactly<ValidationException>()
				.WithMessage(msg)
				;
		}

		[TestMethod]
		public void Throws_ValidationError_w_DefMsg()
		{
			var msg = SR.Err_ValidationError;

			var action = () => Throw.ValidationError();

			action.Should()
				.ThrowExactly<ValidationException>()
				.WithMessage(msg)
				;
		}


		[TestMethod]
		public void Throws_ValueOutOfRange_w_CustMsg()
		{
			var msg = "Out of range error.";
			var arg = "arg-name";

			var action = () => Throw.ValueOutOfRange(arg, msg);

			action.Should()
				.ThrowExactly<ArgumentOutOfRangeException>()
				.WithMessage($"{msg}*")
				;
		}

		[TestMethod]
		public void Throws_ValueOutOfRange_w_DefMsg()
		{
			var msg = SR.Err_OutOfRange;
			var arg = "arg-name";

			var action = () => Throw.ValueOutOfRange(arg);

			action.Should()
				.ThrowExactly<ArgumentOutOfRangeException>()
				.WithMessage($"{msg}*")
				;
		}



		[TestMethod]
		public void Throws_This()
		{
			var msg = SR.Err_AppException;
			var ex = new ApplicationException(msg);

			var action = () => Throw.This(ex);

			action.Should()
				.ThrowExactly<ApplicationException>()
				.WithMessage(msg)
				;
		}

		[TestMethod]
		public void Throws_This_TypeParm()
		{
			var msg = SR.Err_AppException;
			var ex = new ApplicationException(msg);

			var action = () => { int x = Throw.This<int>(ex); };

			action.Should()
				.ThrowExactly<ApplicationException>()
				.WithMessage(msg)
				;
		}


		[TestMethod]
		public void Throws_This_Alt()
		{
			var msg = SR.Err_AppException;
			var ex = new ApplicationException(msg);

			var action = () => ex.Throw();

			action.Should()
				.ThrowExactly<ApplicationException>()
				.WithMessage(msg)
				;
		}

		[TestMethod]
		public void Throws_This_Alt_TypeParm()
		{
			var msg = SR.Err_AppException;
			var ex = new ApplicationException(msg);

			var action = () => { int x = ex.Throw<int>(); };

			action.Should()
				.ThrowExactly<ApplicationException>()
				.WithMessage(msg)
				;
		}
	}
}
