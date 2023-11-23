/*--------------------------------------------------------------------------------------------------------------------------------
Copyright 2023 Zareh DerGevorkian

Licensed under the Apache License, Version 2.0 (the "License"); 
you may not use this file except in compliance with the License. 
You may obtain a copy of the License at http://www.apache.org/licenses/LICENSE-2.0

Unless required by applicable law or agreed to in writing, software distributed under the License is distributed 
on an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. See the License for 
the specific language governing permissions and limitations under the License.
--------------------------------------------------------------------------------------------------------------------------------*/

#if NET7_0_OR_GREATER
using System.Numerics;
#endif

namespace ThrowGuard
{
	public static partial class Throw
	{
#if NET7_0_OR_GREATER

		/// <summary>
		///		Throws an <see cref="ArgumentException"/> if specified value is zero.
		/// </summary>
		/// <typeparam name="T">The numeric type.</typeparam>
		/// <param name="arg">The value or expression to evaluate.</param>
		/// <param name="msg">The message to use for the exception.</param>
		/// <param name="argName">The name of the evaluated expression in <paramref name="arg"/>.</param>
		/// <param name="ex">
		///		A function that accepts the <paramref name="argName"/> 
		///		string and returns the exception instance to be thrown 
		///		(instead of the default exception type).
		/// </param>
		/// <returns>The value specified in <paramref name="arg"/>.</returns>
		/// <exception cref="ArgumentException" />
		[Pure, MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static T IfZero<T>(
			T arg, string? msg = default,
			[CallerArgumentExpression(nameof(arg))] string? argName = default,
			Func<string, Exception>? ex = default)
			where T : INumber<T>
		{
			if (0 == arg.CompareTo(default))
			{
				if (ex is null)
				{
					BadArg(
						argName ?? SR.Msg_NoArgName,
						msg ?? SR.Err_Num_Zero);
				}
				else
				{
					This(ex.Invoke(argName ?? SR.Msg_NoArgName));
				}
			}
			return arg;
		}

		/// <summary>
		///		Throws an <see cref="ArgumentException"/> if specified value is not zero.
		/// </summary>
		/// <typeparam name="T">The numeric type.</typeparam>
		/// <param name="arg">The value or expression to evaluate.</param>
		/// <param name="msg">The message to use for the exception.</param>
		/// <param name="argName">The name of the evaluated expression in <paramref name="arg"/>.</param>
		/// <param name="ex">
		///		A function that accepts the <paramref name="argName"/> 
		///		string and returns the exception instance to be thrown 
		///		(instead of the default exception type).
		/// </param>
		/// <returns>The value specified in <paramref name="arg"/>.</returns>
		/// <exception cref="ArgumentException" />
		[Pure, MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static T IfNotZero<T>(
			T arg, string? msg = default,
			[CallerArgumentExpression(nameof(arg))] string? argName = default,
			Func<string, Exception>? ex = default)
			where T : INumber<T>
		{
			if (0 != arg.CompareTo(default))
			{
				if (ex is null)
				{
					BadArg(
						argName ?? SR.Msg_NoArgName,
						msg ?? SR.Err_Num_NotZero);
				}
				else
				{
					This(ex.Invoke(argName ?? SR.Msg_NoArgName));
				}
			}
			return arg;
		}


		/// <summary>
		///		Throws an <see cref="ArgumentException"/> if specified value 
		///		is positive (is greater than zero).
		/// </summary>
		/// <typeparam name="T">The numeric type.</typeparam>
		/// <param name="arg">The value or expression to evaluate.</param>
		/// <param name="msg">The message to use for the exception.</param>
		/// <param name="argName">The name of the evaluated expression in <paramref name="arg"/>.</param>
		/// <param name="ex">
		///		A function that accepts the <paramref name="argName"/> 
		///		string and returns the exception instance to be thrown 
		///		(instead of the default exception type).
		/// </param>
		/// <returns>The value specified in <paramref name="arg"/>.</returns>
		/// <exception cref="ArgumentException" />
		[Pure, MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static T IfPositive<T>(
			T arg, string? msg = default,
			[CallerArgumentExpression(nameof(arg))] string? argName = default,
			Func<string, Exception>? ex = default)
			where T : INumber<T>
		{
			if (0 < arg.CompareTo(default))
			{
				if (ex is null)
				{
					BadArg(
						argName ?? SR.Msg_NoArgName,
						msg ?? SR.Err_Num_Positive.SF(arg));
				}
				else
				{
					This(ex.Invoke(argName ?? SR.Msg_NoArgName));
				}
			}
			return arg;
		}

		/// <summary>
		///		Throws an <see cref="ArgumentException"/> if specified value 
		///		is not positive (is not greater than zero).
		/// </summary>
		/// <typeparam name="T">The numeric type.</typeparam>
		/// <param name="arg">The value or expression to evaluate.</param>
		/// <param name="msg">The message to use for the exception.</param>
		/// <param name="argName">The name of the evaluated expression in <paramref name="arg"/>.</param>
		/// <param name="ex">
		///		A function that accepts the <paramref name="argName"/> 
		///		string and returns the exception instance to be thrown 
		///		(instead of the default exception type).
		/// </param>
		/// <returns>The value specified in <paramref name="arg"/>.</returns>
		/// <exception cref="ArgumentException" />
		[Pure, MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static T IfNotPositive<T>(
			T arg, string? msg = default,
			[CallerArgumentExpression(nameof(arg))] string? argName = default,
			Func<string, Exception>? ex = default)
			where T : INumber<T>
		{
			if (0 >= arg.CompareTo(default))
			{
				if (ex is null)
				{
					BadArg(
						argName ?? SR.Msg_NoArgName,
						msg ?? SR.Err_Num_NotPositive.SF(arg));
				}
				else
				{
					This(ex.Invoke(argName ?? SR.Msg_NoArgName));
				}
			}
			return arg;
		}


		/// <summary>
		///		Throws an <see cref="ArgumentException"/> if specified value 
		///		is negative (is less than zero).
		/// </summary>
		/// <typeparam name="T">The numeric type.</typeparam>
		/// <param name="arg">The value or expression to evaluate.</param>
		/// <param name="msg">The message to use for the exception.</param>
		/// <param name="argName">The name of the evaluated expression in <paramref name="arg"/>.</param>
		/// <param name="ex">
		///		A function that accepts the <paramref name="argName"/> 
		///		string and returns the exception instance to be thrown 
		///		(instead of the default exception type).
		/// </param>
		/// <returns>The value specified in <paramref name="arg"/>.</returns>
		/// <exception cref="ArgumentException" />
		[Pure, MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static T IfNegative<T>(
			T arg, string? msg = default,
			[CallerArgumentExpression(nameof(arg))] string? argName = default,
			Func<string, Exception>? ex = default)
			where T : INumber<T>
		{
			if (0 > arg.CompareTo(default))
			{
				if (ex is null)
				{
					BadArg(
						argName ?? SR.Msg_NoArgName,
						msg ?? SR.Err_Num_Negative.SF(arg));
				}
				else
				{
					This(ex.Invoke(argName ?? SR.Msg_NoArgName));
				}
			}
			return arg;
		}

		/// <summary>
		///		Throws an <see cref="ArgumentException"/> if specified value 
		///		is not negative (is not less than zero).
		/// </summary>
		/// <typeparam name="T">The numeric type.</typeparam>
		/// <param name="arg">The value or expression to evaluate.</param>
		/// <param name="msg">The message to use for the exception.</param>
		/// <param name="argName">The name of the evaluated expression in <paramref name="arg"/>.</param>
		/// <param name="ex">
		///		A function that accepts the <paramref name="argName"/> 
		///		string and returns the exception instance to be thrown 
		///		(instead of the default exception type).
		/// </param>
		/// <returns>The value specified in <paramref name="arg"/>.</returns>
		/// <exception cref="ArgumentException" />
		[Pure, MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static T IfNotNegative<T>(
			T arg, string? msg = default,
			[CallerArgumentExpression(nameof(arg))] string? argName = default,
			Func<string, Exception>? ex = default)
			where T : INumber<T>
		{
			if (0 <= arg.CompareTo(default))
			{
				if (ex is null)
				{
					BadArg(
						argName ?? SR.Msg_NoArgName,
						msg ?? SR.Err_Num_NotNegative.SF(arg));
				}
				else
				{
					This(ex.Invoke(argName ?? SR.Msg_NoArgName));
				}
			}
			return arg;
		}

		//--

		/// <summary>
		///		Throws an <see cref="ArgumentOutOfRangeException"/> if specified value 
		///		is equal to the specified value.
		/// </summary>
		/// <typeparam name="T">The numeric type.</typeparam>
		/// <param name="arg">The value or expression to evaluate.</param>
		/// <param name="val">The value to compare with.</param>
		/// <param name="msg">The message to use for the exception.</param>
		/// <param name="argName">The name of the evaluated expression in <paramref name="arg"/>.</param>
		/// <param name="ex">
		///		A function that accepts the <paramref name="argName"/> 
		///		string and returns the exception instance to be thrown 
		///		(instead of the default exception type).
		/// </param>
		/// <returns>The value specified in <paramref name="arg"/>.</returns>
		/// <exception cref="ArgumentOutOfRangeException" />
		[Pure, MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static T IfEqualTo<T>(
			T arg, T val, string? msg = default,
			[CallerArgumentExpression(nameof(arg))] string? argName = default,
			Func<string, Exception>? ex = default)
			where T : INumber<T>
		{
			if (0 <= arg.CompareTo(val))
			{
				if (ex is null)
				{
					ValueOutOfRange(
						argName ?? SR.Msg_NoArgName,
						msg ?? SR.Err_Num_EqualTo.SF(arg));
				}
				else
				{
					This(ex.Invoke(argName ?? SR.Msg_NoArgName));
				}
			}
			return arg;
		}

		/// <summary>
		///		Throws an <see cref="ArgumentOutOfRangeException"/> if specified value 
		///		is not equal to the specified value.
		/// </summary>
		/// <typeparam name="T">The numeric type.</typeparam>
		/// <param name="arg">The value or expression to evaluate.</param>
		/// <param name="val">The value to compare with.</param>
		/// <param name="msg">The message to use for the exception.</param>
		/// <param name="argName">The name of the evaluated expression in <paramref name="arg"/>.</param>
		/// <param name="ex">
		///		A function that accepts the <paramref name="argName"/> 
		///		string and returns the exception instance to be thrown 
		///		(instead of the default exception type).
		/// </param>
		/// <returns>The value specified in <paramref name="arg"/>.</returns>
		/// <exception cref="ArgumentOutOfRangeException" />
		[Pure, MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static T IfNotEqualTo<T>(
			T arg, T val, string? msg = default,
			[CallerArgumentExpression(nameof(arg))] string? argName = default,
			Func<string, Exception>? ex = default)
			where T : INumber<T>
		{
			if (0 != arg.CompareTo(val))
			{
				if (ex is null)
				{
					ValueOutOfRange(
						argName ?? SR.Msg_NoArgName,
						msg ?? SR.Err_Num_NotEqualTo.SF(arg, val));
				}
				else
				{
					This(ex.Invoke(argName ?? SR.Msg_NoArgName));
				}
			}
			return arg;
		}


		/// <summary>
		///		Throws an <see cref="ArgumentOutOfRangeException"/> if specified value 
		///		is less than the specified limit.
		/// </summary>
		/// <typeparam name="T">The numeric type.</typeparam>
		/// <param name="arg">The value or expression to evaluate.</param>
		/// <param name="limit">The value to compare with.</param>
		/// <param name="msg">The message to use for the exception.</param>
		/// <param name="argName">The name of the evaluated expression in <paramref name="arg"/>.</param>
		/// <param name="ex">
		///		A function that accepts the <paramref name="argName"/> 
		///		string and returns the exception instance to be thrown 
		///		(instead of the default exception type).
		/// </param>
		/// <returns>The value specified in <paramref name="arg"/>.</returns>
		/// <exception cref="ArgumentOutOfRangeException" />
		[Pure, MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static T IfLessThan<T>(
			T arg, T limit, string? msg = default,
			[CallerArgumentExpression(nameof(arg))] string? argName = default,
			Func<string, Exception>? ex = default)
			where T : INumber<T>
		{
			if (0 > arg.CompareTo(limit))
			{
				if (ex is null)
				{
					ValueOutOfRange(
						argName ?? SR.Msg_NoArgName,
						msg ?? SR.Err_Num_LessThan.SF(arg, limit));
				}
				else
				{
					This(ex.Invoke(argName ?? SR.Msg_NoArgName));
				}
			}
			return arg;
		}

		/// <summary>
		///		Throws an <see cref="ArgumentOutOfRangeException"/> if specified value 
		///		is less than or equal to the specified limit.
		/// </summary>
		/// <typeparam name="T">The numeric type.</typeparam>
		/// <param name="arg">The value or expression to evaluate.</param>
		/// <param name="limit">The value to compare with.</param>
		/// <param name="msg">The message to use for the exception.</param>
		/// <param name="argName">The name of the evaluated expression in <paramref name="arg"/>.</param>
		/// <param name="ex">
		///		A function that accepts the <paramref name="argName"/> 
		///		string and returns the exception instance to be thrown 
		///		(instead of the default exception type).
		/// </param>
		/// <returns>The value specified in <paramref name="arg"/>.</returns>
		/// <exception cref="ArgumentOutOfRangeException" />
		[Pure, MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static T IfLessThanOrEqualTo<T>(
			T arg, T limit, string? msg = default,
			[CallerArgumentExpression(nameof(arg))] string? argName = default,
			Func<string, Exception>? ex = default)
			where T : INumber<T>
		{
			if (0 >= arg.CompareTo(limit))
			{
				if (ex is null)
				{
					ValueOutOfRange(
						argName ?? SR.Msg_NoArgName,
						msg ?? SR.Err_Num_LessThanOrEqualTo.SF(arg, limit));
				}
				else
				{
					This(ex.Invoke(argName ?? SR.Msg_NoArgName));
				}
			}
			return arg;
		}


		/// <summary>
		///		Throws an <see cref="ArgumentOutOfRangeException"/> if specified value 
		///		is greater than the specified limit.
		/// </summary>
		/// <typeparam name="T">The numeric type.</typeparam>
		/// <param name="arg">The value or expression to evaluate.</param>
		/// <param name="limit">The value to compare with.</param>
		/// <param name="msg">The message to use for the exception.</param>
		/// <param name="argName">The name of the evaluated expression in <paramref name="arg"/>.</param>
		/// <param name="ex">
		///		A function that accepts the <paramref name="argName"/> 
		///		string and returns the exception instance to be thrown 
		///		(instead of the default exception type).
		/// </param>
		/// <returns>The value specified in <paramref name="arg"/>.</returns>
		/// <exception cref="ArgumentOutOfRangeException" />
		[Pure, MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static T IfGreaterThan<T>(
			T arg, T limit, string? msg = default,
			[CallerArgumentExpression(nameof(arg))] string? argName = default,
			Func<string, Exception>? ex = default)
			where T : INumber<T>
		{
			if (0 < arg.CompareTo(limit))
			{
				if (ex is null)
				{
					ValueOutOfRange(
						argName ?? SR.Msg_NoArgName,
						msg ?? SR.Err_Num_GreaterThan.SF(arg, limit));
				}
				else
				{
					This(ex.Invoke(argName ?? SR.Msg_NoArgName));
				}
			}
			return arg;
		}

		/// <summary>
		///		Throws an <see cref="ArgumentOutOfRangeException"/> if specified value 
		///		is greater than or equal to the specified limit.
		/// </summary>
		/// <typeparam name="T">The numeric type.</typeparam>
		/// <param name="arg">The value or expression to evaluate.</param>
		/// <param name="limit">The value to compare with.</param>
		/// <param name="msg">The message to use for the exception.</param>
		/// <param name="argName">The name of the evaluated expression in <paramref name="arg"/>.</param>
		/// <param name="ex">
		///		A function that accepts the <paramref name="argName"/> 
		///		string and returns the exception instance to be thrown 
		///		(instead of the default exception type).
		/// </param>
		/// <returns>The value specified in <paramref name="arg"/>.</returns>
		/// <exception cref="ArgumentOutOfRangeException" />
		[Pure, MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static T IfGreaterThanOrEqualTo<T>(
			T arg, T limit, string? msg = default,
			[CallerArgumentExpression(nameof(arg))] string? argName = default,
			Func<string, Exception>? ex = default)
			where T : INumber<T>
		{
			if (0 <= arg.CompareTo(limit))
			{
				if (ex is null)
				{
					ValueOutOfRange(
						argName ?? SR.Msg_NoArgName,
						msg ?? SR.Err_Num_GreaterThanOrEqualTo.SF(arg, limit));
				}
				else
				{
					This(ex.Invoke(argName ?? SR.Msg_NoArgName));
				}
			}
			return arg;
		}


		/// <summary>
		///		Throws an <see cref="ArgumentOutOfRangeException"/> if specified value 
		///		is between the supplied min and max values inclusively.
		/// </summary>
		/// <typeparam name="T">The numeric type.</typeparam>
		/// <param name="arg">The value or expression to evaluate.</param>
		/// <param name="min">The min value, inclusive.</param>
		/// <param name="max">The max value, inclusive.</param>
		/// <param name="msg">The message to use for the exception.</param>
		/// <param name="argName">The name of the evaluated expression in <paramref name="arg"/>.</param>
		/// <param name="ex">
		///		A function that accepts the <paramref name="argName"/> 
		///		string and returns the exception instance to be thrown 
		///		(instead of the default exception type).
		/// </param>
		/// <returns>The value specified in <paramref name="arg"/>.</returns>
		/// <exception cref="ArgumentOutOfRangeException" />
		[Pure, MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static T IfBetween<T>(
			T arg, T min, T max, string? msg = default,
			[CallerArgumentExpression(nameof(arg))] string? argName = default,
			Func<string, Exception>? ex = default)
			where T : INumber<T>
		{
			if ((0 <= arg.CompareTo(min)) &&
				(0 >= arg.CompareTo(max)))
			{
				if (ex is null)
				{
					ValueOutOfRange(
						argName ?? SR.Msg_NoArgName,
						msg ?? SR.Err_Num_Between.SF(arg, min, max));
				}
				else
				{
					This(ex.Invoke(argName ?? SR.Msg_NoArgName));
				}
			}
			return arg;
		}

		/// <summary>
		///		Throws an <see cref="ArgumentOutOfRangeException"/> if specified value 
		///		is not between the supplied min and max values inclusively.
		/// </summary>
		/// <typeparam name="T">The numeric type.</typeparam>
		/// <param name="arg">The value or expression to evaluate.</param>
		/// <param name="min">The min value, inclusive.</param>
		/// <param name="max">The max value, inclusive.</param>
		/// <param name="msg">The message to use for the exception.</param>
		/// <param name="argName">The name of the evaluated expression in <paramref name="arg"/>.</param>
		/// <param name="ex">
		///		A function that accepts the <paramref name="argName"/> 
		///		string and returns the exception instance to be thrown 
		///		(instead of the default exception type).
		/// </param>
		/// <returns>The value specified in <paramref name="arg"/>.</returns>
		/// <exception cref="ArgumentOutOfRangeException" />
		[Pure, MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static T IfNotBetween<T>(
			T arg, T min, T max, string? msg = default,
			[CallerArgumentExpression(nameof(arg))] string? argName = default,
			Func<string, Exception>? ex = default)
			where T : INumber<T>
		{
			if ((0 > arg.CompareTo(min)) ||
				(0 < arg.CompareTo(max)))
			{
				if (ex is null)
				{
					ValueOutOfRange(
						argName ?? SR.Msg_NoArgName,
						msg ?? SR.Err_Num_NotBetween.SF(arg, min, max));
				}
				else
				{
					This(ex.Invoke(argName ?? SR.Msg_NoArgName));
				}
			}
			return arg;
		}

#elif NET6_0

		/// <summary>
		///		Throws an <see cref="ArgumentException"/> if specified value is zero.
		/// </summary>
		/// <param name="arg">The value or expression to evaluate.</param>
		/// <param name="msg">The message to use for the exception.</param>
		/// <param name="argName">The name of the evaluated expression in <paramref name="arg"/>.</param>
		/// <param name="ex">
		///		A function that accepts the <paramref name="argName"/> 
		///		string and returns the exception instance to be thrown 
		///		(instead of the default exception type).
		/// </param>
		/// <returns>The value specified in <paramref name="arg"/>.</returns>
		/// <exception cref="ArgumentException" />
		[Pure, MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static long IfZero(
			long arg, string? msg = default,
			[CallerArgumentExpression(nameof(arg))] string? argName = default,
			Func<string, Exception>? ex = default)
		{
			if (0 == arg.CompareTo(0))
			{
				if (ex is null)
				{
					BadArg(
						argName ?? SR.Msg_NoArgName,
						msg ?? SR.Err_Num_Zero);
				}
				else
				{
					This(ex.Invoke(argName ?? SR.Msg_NoArgName));
				}
			}
			return arg;
		}

		/// <summary>
		///		Throws an <see cref="ArgumentException"/> if specified value is not zero.
		/// </summary>
		/// <param name="arg">The value or expression to evaluate.</param>
		/// <param name="msg">The message to use for the exception.</param>
		/// <param name="argName">The name of the evaluated expression in <paramref name="arg"/>.</param>
		/// <param name="ex">
		///		A function that accepts the <paramref name="argName"/> 
		///		string and returns the exception instance to be thrown 
		///		(instead of the default exception type).
		/// </param>
		/// <returns>The value specified in <paramref name="arg"/>.</returns>
		/// <exception cref="ArgumentException" />
		[Pure, MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static long IfNotZero(
			long arg, string? msg = default,
			[CallerArgumentExpression(nameof(arg))] string? argName = default,
			Func<string, Exception>? ex = default)
		{
			if (0 != arg.CompareTo(0))
			{
				if (ex is null)
				{
					BadArg(
						argName ?? SR.Msg_NoArgName,
						msg ?? SR.Err_Num_NotZero);
				}
				else
				{
					This(ex.Invoke(argName ?? SR.Msg_NoArgName));
				}
			}
			return arg;
		}


		/// <summary>
		///		Throws an <see cref="ArgumentException"/> if specified value 
		///		is positive (is greater than zero).
		/// </summary>
		/// <param name="arg">The value or expression to evaluate.</param>
		/// <param name="msg">The message to use for the exception.</param>
		/// <param name="argName">The name of the evaluated expression in <paramref name="arg"/>.</param>
		/// <param name="ex">
		///		A function that accepts the <paramref name="argName"/> 
		///		string and returns the exception instance to be thrown 
		///		(instead of the default exception type).
		/// </param>
		/// <returns>The value specified in <paramref name="arg"/>.</returns>
		/// <exception cref="ArgumentException" />
		[Pure, MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static long IfPositive(
			long arg, string? msg = default,
			[CallerArgumentExpression(nameof(arg))] string? argName = default,
			Func<string, Exception>? ex = default)
		{
			if (0 < arg.CompareTo(0))
			{
				if (ex is null)
				{
					BadArg(
						argName ?? SR.Msg_NoArgName,
						msg ?? SR.Err_Num_Positive.SF(arg));
				}
				else
				{
					This(ex.Invoke(argName ?? SR.Msg_NoArgName));
				}
			}
			return arg;
		}

		/// <summary>
		///		Throws an <see cref="ArgumentException"/> if specified value 
		///		is not positive (is not greater than zero).
		/// </summary>
		/// <param name="arg">The value or expression to evaluate.</param>
		/// <param name="msg">The message to use for the exception.</param>
		/// <param name="argName">The name of the evaluated expression in <paramref name="arg"/>.</param>
		/// <param name="ex">
		///		A function that accepts the <paramref name="argName"/> 
		///		string and returns the exception instance to be thrown 
		///		(instead of the default exception type).
		/// </param>
		/// <returns>The value specified in <paramref name="arg"/>.</returns>
		/// <exception cref="ArgumentException" />
		[Pure, MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static long IfNotPositive(
			long arg, string? msg = default,
			[CallerArgumentExpression(nameof(arg))] string? argName = default,
			Func<string, Exception>? ex = default)
		{
			if (0 >= arg.CompareTo(0))
			{
				if (ex is null)
				{
					BadArg(
						argName ?? SR.Msg_NoArgName,
						msg ?? SR.Err_Num_NotPositive.SF(arg));
				}
				else
				{
					This(ex.Invoke(argName ?? SR.Msg_NoArgName));
				}
			}
			return arg;
		}


		/// <summary>
		///		Throws an <see cref="ArgumentException"/> if specified value 
		///		is negative (is less than zero).
		/// </summary>
		/// <param name="arg">The value or expression to evaluate.</param>
		/// <param name="msg">The message to use for the exception.</param>
		/// <param name="argName">The name of the evaluated expression in <paramref name="arg"/>.</param>
		/// <param name="ex">
		///		A function that accepts the <paramref name="argName"/> 
		///		string and returns the exception instance to be thrown 
		///		(instead of the default exception type).
		/// </param>
		/// <returns>The value specified in <paramref name="arg"/>.</returns>
		/// <exception cref="ArgumentException" />
		[Pure, MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static long IfNegative(
			long arg, string? msg = default,
			[CallerArgumentExpression(nameof(arg))] string? argName = default,
			Func<string, Exception>? ex = default)
		{
			if (0 > arg.CompareTo(0))
			{
				if (ex is null)
				{
					BadArg(
						argName ?? SR.Msg_NoArgName,
						msg ?? SR.Err_Num_Negative.SF(arg));
				}
				else
				{
					This(ex.Invoke(argName ?? SR.Msg_NoArgName));
				}
			}
			return arg;
		}

		/// <summary>
		///		Throws an <see cref="ArgumentException"/> if specified value 
		///		is not negative (is not less than zero).
		/// </summary>
		/// <param name="arg">The value or expression to evaluate.</param>
		/// <param name="msg">The message to use for the exception.</param>
		/// <param name="argName">The name of the evaluated expression in <paramref name="arg"/>.</param>
		/// <param name="ex">
		///		A function that accepts the <paramref name="argName"/> 
		///		string and returns the exception instance to be thrown 
		///		(instead of the default exception type).
		/// </param>
		/// <returns>The value specified in <paramref name="arg"/>.</returns>
		/// <exception cref="ArgumentException" />
		[Pure, MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static long IfNotNegative(
			long arg, string? msg = default,
			[CallerArgumentExpression(nameof(arg))] string? argName = default,
			Func<string, Exception>? ex = default)
		{
			if (0 <= arg.CompareTo(0))
			{
				if (ex is null)
				{
					BadArg(
						argName ?? SR.Msg_NoArgName,
						msg ?? SR.Err_Num_NotNegative.SF(arg));
				}
				else
				{
					This(ex.Invoke(argName ?? SR.Msg_NoArgName));
				}
			}
			return arg;
		}

		//--

		/// <summary>
		///		Throws an <see cref="ArgumentOutOfRangeException"/> if specified value 
		///		is equal to the specified value.
		/// </summary>
		/// <param name="arg">The value or expression to evaluate.</param>
		/// <param name="value">The value to compare with.</param>
		/// <param name="msg">The message to use for the exception.</param>
		/// <param name="argName">The name of the evaluated expression in <paramref name="arg"/>.</param>
		/// <param name="ex">
		///		A function that accepts the <paramref name="argName"/> 
		///		string and returns the exception instance to be thrown 
		///		(instead of the default exception type).
		/// </param>
		/// <returns>The value specified in <paramref name="arg"/>.</returns>
		/// <exception cref="ArgumentOutOfRangeException" />
		[Pure, MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static long IfEqualTo(
			long arg, long value, string? msg = default,
			[CallerArgumentExpression(nameof(arg))] string? argName = default,
			Func<string, Exception>? ex = default)
		{
			if (0 <= arg.CompareTo(value))
			{
				if (ex is null)
				{
					ValueOutOfRange(
						argName ?? SR.Msg_NoArgName,
						msg ?? SR.Err_Num_EqualTo.SF(arg));
				}
				else
				{
					This(ex.Invoke(argName ?? SR.Msg_NoArgName));
				}
			}
			return arg;
		}

		/// <summary>
		///		Throws an <see cref="ArgumentOutOfRangeException"/> if specified value 
		///		is not equal to the specified value.
		/// </summary>
		/// <param name="arg">The value or expression to evaluate.</param>
		/// <param name="value">The value to compare with.</param>
		/// <param name="msg">The message to use for the exception.</param>
		/// <param name="argName">The name of the evaluated expression in <paramref name="arg"/>.</param>
		/// <param name="ex">
		///		A function that accepts the <paramref name="argName"/> 
		///		string and returns the exception instance to be thrown 
		///		(instead of the default exception type).
		/// </param>
		/// <returns>The value specified in <paramref name="arg"/>.</returns>
		/// <exception cref="ArgumentOutOfRangeException" />
		[Pure, MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static long IfNotEqualTo(
			long arg, long value, string? msg = default,
			[CallerArgumentExpression(nameof(arg))] string? argName = default,
			Func<string, Exception>? ex = default)
		{
			if (0 != arg.CompareTo(value))
			{
				if (ex is null)
				{
					ValueOutOfRange(
						argName ?? SR.Msg_NoArgName,
						msg ?? SR.Err_Num_NotEqualTo.SF(arg, value));
				}
				else
				{
					This(ex.Invoke(argName ?? SR.Msg_NoArgName));
				}
			}
			return arg;
		}


		/// <summary>
		///		Throws an <see cref="ArgumentOutOfRangeException"/> if specified value 
		///		is less than the specified limit.
		/// </summary>
		/// <param name="arg">The value or expression to evaluate.</param>
		/// <param name="limit">The value to compare with.</param>
		/// <param name="msg">The message to use for the exception.</param>
		/// <param name="argName">The name of the evaluated expression in <paramref name="arg"/>.</param>
		/// <param name="ex">
		///		A function that accepts the <paramref name="argName"/> 
		///		string and returns the exception instance to be thrown 
		///		(instead of the default exception type).
		/// </param>
		/// <returns>The value specified in <paramref name="arg"/>.</returns>
		/// <exception cref="ArgumentOutOfRangeException" />
		[Pure, MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static long IfLessThan(
			long arg, long limit, string? msg = default,
			[CallerArgumentExpression(nameof(arg))] string? argName = default,
			Func<string, Exception>? ex = default)
		{
			if (0 > arg.CompareTo(limit))
			{
				if (ex is null)
				{
					ValueOutOfRange(
						argName ?? SR.Msg_NoArgName,
						msg ?? SR.Err_Num_LessThan.SF(arg, limit));
				}
				else
				{
					This(ex.Invoke(argName ?? SR.Msg_NoArgName));
				}
			}
			return arg;
		}

		/// <summary>
		///		Throws an <see cref="ArgumentOutOfRangeException"/> if specified value 
		///		is less than or equal to the specified limit.
		/// </summary>
		/// <param name="arg">The value or expression to evaluate.</param>
		/// <param name="limit">The value to compare with.</param>
		/// <param name="msg">The message to use for the exception.</param>
		/// <param name="argName">The name of the evaluated expression in <paramref name="arg"/>.</param>
		/// <param name="ex">
		///		A function that accepts the <paramref name="argName"/> 
		///		string and returns the exception instance to be thrown 
		///		(instead of the default exception type).
		/// </param>
		/// <returns>The value specified in <paramref name="arg"/>.</returns>
		/// <exception cref="ArgumentOutOfRangeException" />
		[Pure, MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static long IfLessThanOrEqualTo(
			long arg, long limit, string? msg = default,
			[CallerArgumentExpression(nameof(arg))] string? argName = default,
			Func<string, Exception>? ex = default)
		{
			if (0 >= arg.CompareTo(limit))
			{
				if (ex is null)
				{
					ValueOutOfRange(
						argName ?? SR.Msg_NoArgName,
						msg ?? SR.Err_Num_LessThanOrEqualTo.SF(arg, limit));
				}
				else
				{
					This(ex.Invoke(argName ?? SR.Msg_NoArgName));
				}
			}
			return arg;
		}


		/// <summary>
		///		Throws an <see cref="ArgumentOutOfRangeException"/> if specified value 
		///		is greater than the specified limit.
		/// </summary>
		/// <param name="arg">The value or expression to evaluate.</param>
		/// <param name="limit">The value to compare with.</param>
		/// <param name="msg">The message to use for the exception.</param>
		/// <param name="argName">The name of the evaluated expression in <paramref name="arg"/>.</param>
		/// <param name="ex">
		///		A function that accepts the <paramref name="argName"/> 
		///		string and returns the exception instance to be thrown 
		///		(instead of the default exception type).
		/// </param>
		/// <returns>The value specified in <paramref name="arg"/>.</returns>
		/// <exception cref="ArgumentOutOfRangeException" />
		[Pure, MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static long IfGreaterThan(
			long arg, long limit, string? msg = default,
			[CallerArgumentExpression(nameof(arg))] string? argName = default,
			Func<string, Exception>? ex = default)
		{
			if (0 < arg.CompareTo(limit))
			{
				if (ex is null)
				{
					ValueOutOfRange(
						argName ?? SR.Msg_NoArgName,
						msg ?? SR.Err_Num_GreaterThan.SF(arg, limit));
				}
				else
				{
					This(ex.Invoke(argName ?? SR.Msg_NoArgName));
				}
			}
			return arg;
		}

		/// <summary>
		///		Throws an <see cref="ArgumentOutOfRangeException"/> if specified value 
		///		is greater than or equal to the specified limit.
		/// </summary>
		/// <param name="arg">The value or expression to evaluate.</param>
		/// <param name="limit">The value to compare with.</param>
		/// <param name="msg">The message to use for the exception.</param>
		/// <param name="argName">The name of the evaluated expression in <paramref name="arg"/>.</param>
		/// <param name="ex">
		///		A function that accepts the <paramref name="argName"/> 
		///		string and returns the exception instance to be thrown 
		///		(instead of the default exception type).
		/// </param>
		/// <returns>The value specified in <paramref name="arg"/>.</returns>
		/// <exception cref="ArgumentOutOfRangeException" />
		[Pure, MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static long IfGreaterThanOrEqualTo(
			long arg, long limit, string? msg = default,
			[CallerArgumentExpression(nameof(arg))] string? argName = default,
			Func<string, Exception>? ex = default)
		{
			if (0 <= arg.CompareTo(limit))
			{
				if (ex is null)
				{
					ValueOutOfRange(
						argName ?? SR.Msg_NoArgName,
						msg ?? SR.Err_Num_GreaterThanOrEqualTo.SF(arg, limit));
				}
				else
				{
					This(ex.Invoke(argName ?? SR.Msg_NoArgName));
				}
			}
			return arg;
		}


		/// <summary>
		///		Throws an <see cref="ArgumentOutOfRangeException"/> if specified value 
		///		is between the supplied min and max values inclusively.
		/// </summary>
		/// <param name="arg">The value or expression to evaluate.</param>
		/// <param name="min">The min value, inclusive.</param>
		/// <param name="max">The max value, inclusive.</param>
		/// <param name="msg">The message to use for the exception.</param>
		/// <param name="argName">The name of the evaluated expression in <paramref name="arg"/>.</param>
		/// <param name="ex">
		///		A function that accepts the <paramref name="argName"/> 
		///		string and returns the exception instance to be thrown 
		///		(instead of the default exception type).
		/// </param>
		/// <returns>The value specified in <paramref name="arg"/>.</returns>
		/// <exception cref="ArgumentOutOfRangeException" />
		[Pure, MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static long IfBetween(
			long arg, long min, long max, string? msg = default,
			[CallerArgumentExpression(nameof(arg))] string? argName = default,
			Func<string, Exception>? ex = default)
		{
			if ((0 <= arg.CompareTo(min)) &&
				(0 >= arg.CompareTo(max)))
			{
				if (ex is null)
				{
					ValueOutOfRange(
						argName ?? SR.Msg_NoArgName,
						msg ?? SR.Err_Num_Between.SF(arg, min, max));
				}
				else
				{
					This(ex.Invoke(argName ?? SR.Msg_NoArgName));
				}
			}
			return arg;
		}

		/// <summary>
		///		Throws an <see cref="ArgumentOutOfRangeException"/> if specified value 
		///		is not between the supplied min and max values inclusively.
		/// </summary>
		/// <param name="arg">The value or expression to evaluate.</param>
		/// <param name="min">The min value, inclusive.</param>
		/// <param name="max">The max value, inclusive.</param>
		/// <param name="msg">The message to use for the exception.</param>
		/// <param name="argName">The name of the evaluated expression in <paramref name="arg"/>.</param>
		/// <param name="ex">
		///		A function that accepts the <paramref name="argName"/> 
		///		string and returns the exception instance to be thrown 
		///		(instead of the default exception type).
		/// </param>
		/// <returns>The value specified in <paramref name="arg"/>.</returns>
		/// <exception cref="ArgumentOutOfRangeException" />
		[Pure, MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static long IfNotBetween(
			long arg, long min, long max, string? msg = default,
			[CallerArgumentExpression(nameof(arg))] string? argName = default,
			Func<string, Exception>? ex = default)
		{
			if ((0 > arg.CompareTo(min)) ||
				(0 < arg.CompareTo(max)))
			{
				if (ex is null)
				{
					ValueOutOfRange(
						argName ?? SR.Msg_NoArgName,
						msg ?? SR.Err_Num_NotBetween.SF(arg, min, max));
				}
				else
				{
					This(ex.Invoke(argName ?? SR.Msg_NoArgName));
				}
			}
			return arg;
		}

#else
#error Target framwrork is unsupported.
#endif
	}
}
