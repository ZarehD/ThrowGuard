/*--------------------------------------------------------------------------------------------------------------------------------
Copyright 2023 Zareh DerGevorkian

Licensed under the Apache License, Version 2.0 (the "License"); 
you may not use this file except in compliance with the License. 
You may obtain a copy of the License at http://www.apache.org/licenses/LICENSE-2.0

Unless required by applicable law or agreed to in writing, software distributed under the License is distributed 
on an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. See the License for 
the specific language governing permissions and limitations under the License.
--------------------------------------------------------------------------------------------------------------------------------*/

namespace ThrowGuard
{
	public static partial class Throw
	{
		/// <summary>
		///		Throws an exception of type <see cref="ApplicationException"/>.
		/// </summary>
		/// <param name="message">The exception message.</param>
		/// <exception cref="ApplicationException"></exception>
		[DoesNotReturn]
		public static void AppException(string? message = default) =>
			throw new ApplicationException(
				(message ?? SR.Err_AppException));

		/// <summary>
		///		Throws an exception of type <see cref="ArgumentException"/>.
		/// </summary>
		/// <param name="argName">The name of the argument.</param>
		/// <param name="message">The exception message.</param>
		/// <exception cref="ArgumentException"></exception>
		[DoesNotReturn]
		public static void BadArg(string? argName = default, string? message = default) =>
			throw new ArgumentException(
				(message ?? SR.Err_BadArg),
				argName ?? SR.Msg_NoArgName);

		/// <summary>
		///		Throws an exception of type <see cref="DirectoryNotFoundException"/>.
		/// </summary>
		/// <param name="message">The exception message.</param>
		/// <exception cref="DirectoryNotFoundException"></exception>
		[DoesNotReturn]
		public static void DirectoryNotFound(string? message = default) =>
			throw new DirectoryNotFoundException(
				(message ?? SR.Err_Directory_NotFound));

		/// <summary>
		///		Throws an exception of type <see cref="Exception"/>.
		/// </summary>
		/// <param name="message">The exception message.</param>
		/// <exception cref="Exception"></exception>
		[DoesNotReturn]
		public static void Exception(string? message = default) =>
			throw new Exception(
				(message ?? SR.Err_Exception));

		/// <summary>
		///		Throws an exception of type <see cref="FileNotFoundException"/>.
		/// </summary>
		/// <param name="filePathname">The full pathname of the file.</param>
		/// <param name="message">The exception message.</param>
		/// <exception cref="FileNotFoundException"></exception>
		[DoesNotReturn]
		public static void FileNotFound(string? filePathname, string? message = default)
		{
			if (string.IsNullOrWhiteSpace(filePathname))
			{
				throw new FileNotFoundException(
					message ?? SR.Err_File_NotFound);
			}
			else
			{
				throw new FileNotFoundException(
					(message ?? SR.Err_File_NotFound),
					filePathname);
			}
		}

		/// <summary>
		///		Throws an exception of type <see cref="IndexOutOfRangeException"/>.
		/// </summary>
		/// <param name="message">The exception message.</param>
		/// <exception cref="IndexOutOfRangeException"></exception>
		[DoesNotReturn]
		public static void IndexOutOfRange(string? message = default) =>
			throw new IndexOutOfRangeException(
				(message ?? SR.Err_OutOfRange));

		/// <summary>
		///		Throws an exception of type <see cref="InvalidCastException"/>.
		/// </summary>
		/// <param name="message">The exception message.</param>
		/// <exception cref="InvalidCastException"></exception>
		[DoesNotReturn]
		public static void InvalidCast(string? message = default) =>
			throw new InvalidCastException(
				(message ?? SR.Err_InvalidCast));

		/// <summary>
		///		Throws an exception of type <see cref="InvalidEnumArgumentException"/>.
		/// </summary>
		/// <param name="message">The exception message.</param>
		/// <exception cref="InvalidEnumArgumentException"></exception>
		[DoesNotReturn]
		public static void InvalidEnum(string? message = default) =>
			throw new InvalidEnumArgumentException(
				(message ?? SR.Err_Enum_NotMember));

		/// <summary>
		///		Throws an exception of type <see cref="InvalidEnumArgumentException"/>.
		/// </summary>
		/// <typeparam name="TEnum"></typeparam>
		/// <param name="argName">The name of the argument.</param>
		/// <param name="invalidValue">The invalid argument value.</param>
		/// <exception cref="InvalidEnumArgumentException"></exception>
		[DoesNotReturn]
		public static void InvalidEnum<TEnum>(string argName, int invalidValue) =>
			throw new InvalidEnumArgumentException(
				argName ?? SR.Msg_NoArgName,
				invalidValue,
				typeof(TEnum));

		/// <summary>
		///		Throws an exception of type <see cref="InvalidOperationException"/>.
		/// </summary>
		/// <param name="message">The exception message.</param>
		/// <exception cref="InvalidOperationException"></exception>
		[DoesNotReturn]
		public static void InvalidOp(string? message = default) =>
			throw new InvalidOperationException(
				(message ?? SR.Err_InvalidOp));

		/// <summary>
		///		Throws an exception of type <see cref="NotImplementedException"/>.
		/// </summary>
		/// <param name="message">The exception message.</param>
		/// <exception cref="NotImplementedException"></exception>
		[DoesNotReturn]
		public static void NotImplemented(string? message = default) =>
			throw new NotImplementedException(
				(message ?? SR.Err_NotImplemented));

		/// <summary>
		///		Throws an exception of type <see cref="ArgumentNullException"/>.
		/// </summary>
		/// <param name="argName">The name of the argument.</param>
		/// <param name="message">The exception message.</param>
		/// <exception cref="ArgumentNullException"></exception>
		[DoesNotReturn]
		public static void NullArg(string? argName = default, string? message = default) =>
			throw new ArgumentNullException(
				argName ?? SR.Msg_NoArgName,
				(message ?? SR.Err_NullArg));

		/// <summary>
		///		Throws an exception of type <see cref="ValidationException"/>.
		/// </summary>
		/// <param name="message">The exception message.</param>
		/// <exception cref="ValidationException"></exception>
		[DoesNotReturn]
		public static void ValidationError(string? message = default) =>
			throw new ValidationException(
				(message ?? SR.Err_ValidationError));

		/// <summary>
		///		Throws an exception of type <see cref="ArgumentOutOfRangeException"/>.
		/// </summary>
		/// <param name="argName">The name of the argument.</param>
		/// <param name="message">The exception message.</param>
		/// <exception cref="ArgumentOutOfRangeException"></exception>
		[DoesNotReturn]
		public static void ValueOutOfRange(string? argName, string? message = default) =>
			throw new ArgumentOutOfRangeException(
				argName ?? SR.Msg_NoArgName,
				(message ?? SR.Err_OutOfRange));


		/// <summary>
		///		Throws the supplied exception instance.
		/// </summary>
		/// <param name="ex">The exception instance to be thrown.</param>
		[DoesNotReturn]
		public static void This(Exception ex) => throw ex;

		/// <summary>
		///		Throws the supplied exception instance.
		/// </summary>
		/// <typeparam name="T">
		///		Type of the return value.
		///		<para>
		///			No value is actually returned.
		///			This syntax is usefull when the exception is 
		///			thrown in a null-coalescense expression.
		///		</para>
		///		<code>var x = myInt ?? Throw.This{int}(new Exception())</code>
		/// </typeparam>
		/// <param name="ex">The exception instance to be thrown.</param>
		/// <returns></returns>
		[DoesNotReturn]
		public static T This<T>(Exception ex) => throw ex;
	}


	/// <summary>
	///		Contains methods that use an alternate syntax 
	///		for throwing exceptions.
	/// </summary>
	[StackTraceHidden]
	public static class AltStyleThrowHelperExtensions
	{
		/// <summary>
		///		Throws the supplied exception instance.
		/// </summary>
		/// <param name="ex">The exception instance to be thrown.</param>
		[DoesNotReturn]
		public static void Throw(this Exception ex) => throw ex;

		/// <summary>
		///		Throws the supplied exception instance.
		/// </summary>
		/// <typeparam name="T">
		///		Type of the return value.
		///		<para>
		///			No value is actually returned.
		///			This syntax is usefull when the exception is 
		///			thrown in a null-coalescense expression.
		///		</para>
		///		<code>var x = myInt ?? Throw.This{int}(new Exception())</code>
		/// </typeparam>
		/// <param name="ex">The exception instance to be thrown.</param>
		/// <returns></returns>
		[DoesNotReturn]
		public static T Throw<T>(this Exception ex) => throw ex;
	}
}
