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
		///		Throws an exception of type <see cref="ArgumentException"/>
		///		if the DateTime is the specified DateTimeKind.
		/// </summary>
		/// <param name="arg">The value or expression to evaluate.</param>
		/// <param name="kind">The DateTimeKind to compare with.</param>
		/// <param name="msg">The message to use for the exception.</param>
		/// <param name="argName">The name of the evaluated expression in <paramref name="arg"/>.</param>
		/// <param name="ex">
		///		A function that accepts the <paramref name="argName"/> 
		///		string and returns the exception instance to be thrown 
		///		(instead of the default exception type).
		/// </param>
		/// <returns>The value specified in <paramref name="arg"/>.</returns>
		/// <exception cref="ArgumentException">When <paramref name="arg"/> is empty or whitespace.</exception>
		[Pure, MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static DateTime IfDateTimeKindIs(
			DateTime arg, DateTimeKind kind, string? msg = default,
			[CallerArgumentExpression(nameof(arg))] string? argName = default,
			Func<string, Exception>? ex = default)
		{
			if (arg.Kind == kind)
			{
				if (ex is null)
				{
					BadArg(
						argName ?? SR.Msg_NoArgName,
						msg ?? SR.Err_Uri_DateTimeKindIs.SF(kind.ToString()));
				}
				else
				{
					This(ex.Invoke(argName ?? SR.Msg_NoArgName));
				}
			}
			return arg;
		}

		/// <summary>
		///		Throws an exception of type <see cref="ArgumentException"/>
		///		if the DateTime is not the specified DateTimeKind.
		/// </summary>
		/// <param name="arg">The value or expression to evaluate.</param>
		/// <param name="kind">The DateTimeKind to compare with.</param>
		/// <param name="msg">The message to use for the exception.</param>
		/// <param name="argName">The name of the evaluated expression in <paramref name="arg"/>.</param>
		/// <param name="ex">
		///		A function that accepts the <paramref name="argName"/> 
		///		string and returns the exception instance to be thrown 
		///		(instead of the default exception type).
		/// </param>
		/// <returns>The value specified in <paramref name="arg"/>.</returns>
		/// <exception cref="ArgumentException">When <paramref name="arg"/> is empty or whitespace.</exception>
		[Pure, MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static DateTime IfDateTimeKindIsNot(
			DateTime arg, DateTimeKind kind, string? msg = default,
			[CallerArgumentExpression(nameof(arg))] string? argName = default,
			Func<string, Exception>? ex = default)
		{
			if (arg.Kind != kind)
			{
				if (ex is null)
				{
					BadArg(
						argName ?? SR.Msg_NoArgName,
						msg ?? SR.Err_Uri_DateTimeKindIsNot.SF(kind.ToString()));
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
