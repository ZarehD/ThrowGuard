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
		///		Throws the supplied exception object when the specified 
		///		predicate condition is true.
		/// </summary>
		/// <param name="predicate">The condition that must be true for the exception to be thrown.</param>
		/// <param name="ex">The instance of the exception to throw.</param>
		[Pure, MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void When(
			Func<bool> predicate, Exception ex)
		{
			if (predicate.Invoke()) This(ex);
		}

		/// <summary>
		///		Throws an instance of <see cref="ArgumentException"/> 
		///		if <paramref name="condition"/> is true.
		/// </summary>
		/// <param name="condition">Condition that must be true for the exception to be thrown.</param>
		/// <param name="msg">The message to use for the exception.</param>
		/// <exception cref="ArgumentException" />
		[Pure, MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void BadArgWhen(
			Func<bool> condition, string? msg = default)
		{
			if (condition.Invoke())
			{
				BadArg(
					string.Empty,
					msg ?? $"{SR.Msg_PredicateIsTrue} {SR.Err_BadArg}");
			}
		}

		/// <summary>
		///		Throws an instance of <see cref="InvalidCastException"/> 
		///		if <paramref name="condition"/> is true.
		/// </summary>
		/// <param name="condition">Condition that must be true for the exception to be thrown.</param>
		/// <param name="msg">The message to use for the exception.</param>
		/// <exception cref="InvalidCastException" />
		[Pure, MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void InvalidCastWhen(
			Func<bool> condition, string? msg = default)
		{
			if (condition.Invoke())
			{
				InvalidCast(
					msg ?? $"{SR.Msg_PredicateIsTrue} {SR.Err_InvalidCast}");
			}
		}

		/// <summary>
		///		Throws an instance of <see cref="InvalidOperationException"/> 
		///		if <paramref name="condition"/> is true.
		/// </summary>
		/// <param name="condition">Condition that must be true for the exception to be thrown.</param>
		/// <param name="msg">The message to use for the exception.</param>
		/// <exception cref="InvalidOperationException" />
		[Pure, MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void InvalidOpWhen(
			Func<bool> condition, string? msg = default)
		{
			if (condition.Invoke())
			{
				InvalidOp(
					msg ?? $"{SR.Msg_PredicateIsTrue} {SR.Err_InvalidOp}");
			}
		}

		/// <summary>
		///		Throws an instance of <see cref="ValidationException"/> if <paramref name="condition"/> is true.
		/// </summary>
		/// <param name="condition">Condition that must be true for the exception to be thrown.</param>
		/// <param name="msg">The message to use for the exception.</param>
		/// <exception cref="ValidationException" />
		[Pure, MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ValidationErrorWhen(
			Func<bool> condition, string? msg = default)
		{
			if (condition.Invoke())
			{
				ValidationError(
					msg ?? SR.Msg_PredicateIsTrue);
			}
		}
	}
}
