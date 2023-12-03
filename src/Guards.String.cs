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
		///		Throws an exception if <paramref name="arg"/> is null or empty.
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
		/// <exception cref="ArgumentNullException">When <paramref name="arg"/> is null.</exception>
		/// <exception cref="ArgumentException">When <paramref name="arg"/> is empty or whitespace.</exception>
		[Pure, MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static string IfNullOrEmpty(
			[NotNull] string? arg, string? msg = default,
			[CallerArgumentExpression(nameof(arg))] string? argName = default,
			Func<string, Exception>? ex = default)
		{
			_ = IfNull(arg, msg, argName, ex);
			if (arg == string.Empty)
			{
				if (ex is null)
				{
					BadArg(
						argName ?? SR.Msg_NoArgName,
						msg ?? SR.Err_Str_Empty);
				}
				else
				{
					This(ex.Invoke(argName ?? SR.Msg_NoArgName));
				}
			}
			return arg;
		}

		/// <summary>
		///		Throws an exception if <paramref name="arg"/> is null or empty,
		///		and <paramref name="condition"/> is true.
		/// </summary>
		/// <param name="arg">The value or expression to evaluate.</param>
		/// <param name="condition">Condition that must also be true for the exception to be thrown.</param>
		/// <param name="msg">The message to use for the exception.</param>
		/// <param name="argName">The name of the evaluated expression in <paramref name="arg"/>.</param>
		/// <param name="ex">
		///		A function that accepts the <paramref name="argName"/> 
		///		string and returns the exception instance to be thrown 
		///		(instead of the default exception type).
		/// </param>
		/// <returns>The value specified in <paramref name="arg"/>.</returns>
		/// <exception cref="ArgumentNullException">When <paramref name="arg"/> is null.</exception>
		/// <exception cref="ArgumentException">When <paramref name="arg"/> is empty or whitespace.</exception>
		[Pure, MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static string? IfNullOrEmpty(
			string? arg, Func<bool> condition, string? msg = default,
			[CallerArgumentExpression(nameof(arg))] string? argName = default,
			Func<string, Exception>? ex = default)
		{
			_ = IfNull(condition);
			_ = IfNull(arg, condition, msg, argName, ex);
			if ((arg == string.Empty) && condition.Invoke())
			{
				if (ex is null)
				{
					BadArg(
						argName ?? SR.Msg_NoArgName,
						msg ?? SR.Err_Str_Empty);
				}
				else
				{
					This(ex.Invoke(argName ?? SR.Msg_NoArgName));
				}
			}
			return arg;
		}



		/// <summary>
		///		Throws an exception if <paramref name="arg"/> is null, empty, or whitespace.
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
		/// <exception cref="ArgumentNullException">When <paramref name="arg"/> is null.</exception>
		/// <exception cref="ArgumentException">When <paramref name="arg"/> is empty or whitespace.</exception>
		[Pure, MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static string IfNullOrWhitespace(
			[NotNull] string? arg, string? msg = default,
			[CallerArgumentExpression(nameof(arg))] string? argName = default,
			Func<string, Exception>? ex = default)
		{
			_ = IfNull(arg, msg, argName, ex);
			if ((arg == string.Empty) || arg.All(c => char.IsWhiteSpace(c)))
			{
				if (ex is null)
				{
					BadArg(
						argName ?? SR.Msg_NoArgName,
						msg ?? SR.Err_Str_Whitespace);
				}
				else
				{
					This(ex.Invoke(argName ?? SR.Msg_NoArgName));
				}
			}
			return arg;
		}

		/// <summary>
		///		Throws an exception if <paramref name="arg"/> is null, empty, or whitespace,
		///		and <paramref name="condition"/> is true.
		/// </summary>
		/// <param name="arg">The value or expression to evaluate.</param>
		/// <param name="condition">Condition that must also be true for the exception to be thrown.</param>
		/// <param name="msg">The message to use for the exception.</param>
		/// <param name="argName">The name of the evaluated expression in <paramref name="arg"/>.</param>
		/// <param name="ex">
		///		A function that accepts the <paramref name="argName"/> 
		///		string and returns the exception instance to be thrown 
		///		(instead of the default exception type).
		/// </param>
		/// <returns>The value specified in <paramref name="arg"/>.</returns>
		/// <exception cref="ArgumentNullException">When <paramref name="arg"/> is null.</exception>
		/// <exception cref="ArgumentException">When <paramref name="arg"/> is empty or whitespace.</exception>
		[Pure, MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static string? IfNullOrWhitespace(
			string? arg, Func<bool> condition, string? msg = default,
			[CallerArgumentExpression(nameof(arg))] string? argName = default,
			Func<string, Exception>? ex = default)
		{
			_ = IfNull(condition);
			_ = IfNull(arg, condition, msg, argName, ex);
			if (string.IsNullOrWhiteSpace(arg) && condition.Invoke())
			{
				if (ex is null)
				{
					BadArg(
						argName ?? SR.Msg_NoArgName,
						msg ?? SR.Err_Str_Whitespace);
				}
				else
				{
					This(ex.Invoke(argName ?? SR.Msg_NoArgName));
				}
			}
			return arg;
		}


		//-- Char

		/// <summary>
		///		Throws an exception if <paramref name="arg"/> is null or a whitespace character.
		/// </summary>
		/// <remarks>Only the space and tab characters are considered to be whitespace.</remarks>
		/// <param name="arg">The value or expression to evaluate.</param>
		/// <param name="msg">The message to use for the exception.</param>
		/// <param name="argName">The name of the evaluated expression in <paramref name="arg"/>.</param>
		/// <param name="ex">
		///		A function that accepts the <paramref name="argName"/> 
		///		string and returns the exception instance to be thrown 
		///		(instead of the default exception type).
		/// </param>
		/// <returns>The value specified in <paramref name="arg"/>.</returns>
		/// <exception cref="ArgumentNullException">When <paramref name="arg"/> is null.</exception>
		/// <exception cref="ArgumentException">When <paramref name="arg"/> is whitespace.</exception>
		[Pure, MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static char IfNullOrWhitespace(
			[NotNull] char? arg, string? msg = default,
			[CallerArgumentExpression(nameof(arg))] string? argName = default,
			Func<string, Exception>? ex = default)
		{
			_ = IfNull(arg, msg, argName, ex);
			if ((' ' == arg) || ('\t' == arg))
			{
				if (ex is null)
				{
					BadArg(
						argName ?? SR.Msg_NoArgName,
						msg ?? SR.Err_Char_Whitespace);
				}
				else
				{
					This(ex.Invoke(argName ?? SR.Msg_NoArgName));
				}
			}
			return arg.Value;
		}

		/// <summary>
		///		Throws an exception if <paramref name="arg"/> is null or a whitespace character,
		///		and <paramref name="condition"/> is true.
		/// </summary>
		/// <remarks>Only the space and tab characters are considered to be whitespace.</remarks>
		/// <param name="arg">The value or expression to evaluate.</param>
		/// <param name="condition">Condition that must also be true for the exception to be thrown.</param>
		/// <param name="msg">The message to use for the exception.</param>
		/// <param name="argName">The name of the evaluated expression in <paramref name="arg"/>.</param>
		/// <param name="ex">
		///		A function that accepts the <paramref name="argName"/> 
		///		string and returns the exception instance to be thrown 
		///		(instead of the default exception type).
		/// </param>
		/// <returns>The value specified in <paramref name="arg"/>.</returns>
		/// <exception cref="ArgumentNullException">When <paramref name="arg"/> is null.</exception>
		/// <exception cref="ArgumentException">When <paramref name="arg"/> is whitespace.</exception>
		[Pure, MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static char? IfNullOrWhitespace(
			char? arg, Func<bool> condition, string? msg = default,
			[CallerArgumentExpression(nameof(arg))] string? argName = default,
			Func<string, Exception>? ex = default)
		{
			_ = IfNull(condition);
			_ = IfNull(arg, condition, msg, argName, ex);
			if (((' ' == arg) || ('\t' == arg)) && condition.Invoke())
			{
				if (ex is null)
				{
					BadArg(
						argName ?? SR.Msg_NoArgName,
						msg ?? SR.Err_Char_Whitespace);
				}
				else
				{
					This(ex.Invoke(argName ?? SR.Msg_NoArgName));
				}
			}
			return arg;
		}
	}
}
