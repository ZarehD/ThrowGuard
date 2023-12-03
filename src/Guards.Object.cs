/*--------------------------------------------------------------------------------------------------------------------------------
Copyright 2023 Zareh DerGevorkian

Licensed under the Apache License, Version 2.0 (the "License"); 
you may not use this file except in compliance with the License. 
You may obtain a copy of the License at http://www.apache.org/licenses/LICENSE-2.0

Unless required by applicable law or agreed to in writing, software distributed under the License is distributed 
on an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. See the License for 
the specific language governing permissions and limitations under the License.
--------------------------------------------------------------------------------------------------------------------------------*/

using System;

namespace ThrowGuard
{
	/// <summary>
	///		Contains throw-helpers and guard methods.
	/// </summary>
	[StackTraceHidden]
	public static partial class Throw
	{
		/// <summary>
		///		Throws an instance of <see cref="ArgumentNullException"/> if <paramref name="arg"/> is null.
		/// </summary>
		/// <typeparam name="T">The type of the <paramref name="arg"/> value.</typeparam>
		/// <param name="arg">The value or expression to evaluate.</param>
		/// <param name="msg">The message to use for the exception.</param>
		/// <param name="argName">The name of the evaluated expression in <paramref name="arg"/>.</param>
		/// <param name="ex">
		///		A function that accepts the <paramref name="argName"/> 
		///		string and returns the exception instance to be thrown 
		///		(instead of the default exception type).
		/// </param>
		/// <returns>The non-null value specified in <paramref name="arg"/>.</returns>
		/// <exception cref="ArgumentNullException" />
		[Pure, MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static T IfNull<T>(
			[NotNull] T? arg, string? msg = default,
			[CallerArgumentExpression(nameof(arg))] string? argName = default,
			Func<string, Exception>? ex = default)
		{
			if (arg is null)
			{
				if (ex is null)
				{
					NullArg(
						argName ?? SR.Msg_NoArgName,
						msg ?? SR.Err_NullArg);
				}
				else
				{
					This(ex.Invoke(argName ?? SR.Msg_NoArgName));
				}
			}
			return arg;
		}

		/// <summary>
		///		Throws an instance of <see cref="ArgumentNullException"/> if <paramref name="arg"/> is null
		///		and <paramref name="condition"/> is true.
		/// </summary>
		/// <typeparam name="T">The type of the <paramref name="arg"/> value.</typeparam>
		/// <param name="arg">The value or expression to evaluate.</param>
		/// <param name="condition">Condition that must also be true for the exception to be thrown.</param>
		/// <param name="msg">The message to use for the exception.</param>
		/// <param name="argName">The name of the evaluated expression in <paramref name="arg"/>.</param>
		/// <param name="ex">
		///		A function that accepts the <paramref name="argName"/> 
		///		string and returns the exception instance to be thrown 
		///		(instead of the default exception type).
		/// </param>
		/// <returns>The non-null value specified in <paramref name="arg"/>.</returns>
		/// <exception cref="ArgumentNullException" />
		[Pure, MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static T? IfNull<T>(
			T? arg, Func<bool> condition, string? msg = default,
			[CallerArgumentExpression(nameof(arg))] string? argName = default,
			Func<string, Exception>? ex = default)
		{
			_ = IfNull(condition);
			if ((arg is null) && condition.Invoke())
			{
				if (ex is null)
				{
					NullArg(
						argName ?? SR.Msg_NoArgName,
						msg ?? SR.Err_NullArg);
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
