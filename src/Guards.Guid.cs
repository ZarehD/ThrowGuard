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
		///		Throws an exception if <paramref name="arg"/> is the Guid.Empty value.
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
		/// <exception cref="ArgumentException">When <paramref name="arg"/> is Guid.Empty.</exception>
		[Pure, MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Guid IfEmpty(
			Guid arg, string? msg = default,
			[CallerArgumentExpression(nameof(arg))] string? argName = default,
			Func<string, Exception>? ex = default)
		{
			if (Guid.Empty == arg)
			{
				if (ex is null)
				{
					BadArg(
						argName ?? SR.Msg_NoArgName,
						msg ?? SR.Err_GuidEmpty);
				}
				else
				{
					This(ex.Invoke(argName ?? SR.Msg_NoArgName));
				}
			}
			return arg;
		}

		/// <summary>
		///		Throws an exception if <paramref name="arg"/> is the Guid.Empty value,
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
		/// <exception cref="ArgumentException">When <paramref name="arg"/> is Guid.Empty.</exception>
		[Pure, MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Guid IfEmpty(
			Guid arg, Func<bool> condition, string? msg = default,
			[CallerArgumentExpression(nameof(arg))] string? argName = default,
			Func<string, Exception>? ex = default)
		{
			_ = IfNull(condition);
			if ((Guid.Empty == arg) && condition.Invoke())
			{
				if (ex is null)
				{
					BadArg(
						argName ?? SR.Msg_NoArgName,
						msg ?? SR.Err_GuidEmpty);
				}
				else
				{
					This(ex.Invoke(argName ?? SR.Msg_NoArgName));
				}
			}
			return arg;
		}


		/// <summary>
		///		Throws an exception if <paramref name="arg"/> is null or the Guid.Empty value.
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
		/// <exception cref="ArgumentException">When <paramref name="arg"/> is Guid.Empty.</exception>
		[Pure, MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Guid IfNullOrEmpty(
			[NotNull] Guid? arg, string? msg = default,
			[CallerArgumentExpression(nameof(arg))] string? argName = default,
			Func<string, Exception>? ex = default)
		{
			_ = IfNull(arg, msg, argName, ex);
			_ = IfEmpty(arg.Value, msg, argName, ex);
			return arg!.Value;
		}

		/// <summary>
		///		Throws an exception if <paramref name="arg"/> is null or the Guid.Empty value,
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
		/// <exception cref="ArgumentException">When <paramref name="arg"/> is Guid.Empty.</exception>
		[Pure, MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Guid? IfNullOrEmpty(
			Guid? arg, Func<bool> condition, string? msg = default,
			[CallerArgumentExpression(nameof(arg))] string? argName = default,
			Func<string, Exception>? ex = default)
		{
			_ = IfNull(condition);
			_ = IfNull(arg, condition, msg, argName, ex);
			_ = IfEmpty(arg ?? Guid.Empty, condition, msg, argName, ex);
			return arg;
		}
	}
}
