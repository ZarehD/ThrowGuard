/*--------------------------------------------------------------------------------------------------------------------------------
Copyright 2023 Zareh DerGevorkian

Licensed under the Apache License, Version 2.0 (the "License"); 
you may not use this file except in compliance with the License. 
You may obtain a copy of the License at http://www.apache.org/licenses/LICENSE-2.0

Unless required by applicable law or agreed to in writing, software distributed under the License is distributed 
on an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. See the License for 
the specific language governing permissions and limitations under the License.
--------------------------------------------------------------------------------------------------------------------------------*/

using System.Collections;
using System.Linq;
using System.Numerics;
using System.Xml.Linq;

namespace ThrowGuard
{
	public static partial class Throw
	{
		/// <summary>
		///		Throws an exception if the collection referenced by 
		///		<paramref name="arg"/> is null or contains no elements.
		/// </summary>
		/// <typeparam name="TCollection">The type of the collection.</typeparam>
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
		/// <exception cref="ArgumentException">When <paramref name="arg"/> is empty.</exception>
		[Pure, MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static TCollection IfNullOrEmpty<TCollection>(
			[AllowNull, NotNull] TCollection? arg, string? msg = default,
			[CallerArgumentExpression(nameof(arg))] string? argName = default,
			Func<string, Exception>? ex = default)
			where TCollection : IEnumerable
		{
			_ = IfNull(arg, msg, argName, ex);
			if (!arg.GetEnumerator().MoveNext())
			{
				if (ex is null)
				{
					BadArg(
						argName ?? SR.Msg_NoArgName,
						msg ?? SR.Err_Collection_IsEmpty);
				}
				else
				{
					This(ex.Invoke(argName ?? SR.Msg_NoArgName));
				}
			}
			return arg;
		}

		/// <summary>
		///		Throws an exception if the collection referenced by 
		///		<paramref name="arg"/> is null or contains no elements,
		///		and <paramref name="condition"/> is true.
		/// </summary>
		/// <typeparam name="TCollection">The type of the collection.</typeparam>
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
		/// <exception cref="ArgumentException">When <paramref name="arg"/> is empty.</exception>
		[Pure, MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static TCollection? IfNullOrEmpty<TCollection>(
			[AllowNull] TCollection? arg, Func<bool> condition, string? msg = default,
			[CallerArgumentExpression(nameof(arg))] string? argName = default,
			Func<string, Exception>? ex = default)
			where TCollection : IEnumerable
		{
			_ = IfNull(arg, condition, msg, argName, ex);
			if ((!arg?.GetEnumerator().MoveNext() ?? true) && condition.Invoke())
			{
				if (ex is null)
				{
					BadArg(
						argName ?? SR.Msg_NoArgName,
						msg ?? SR.Err_Collection_IsEmpty);
				}
				else
				{
					This(ex.Invoke(argName ?? SR.Msg_NoArgName));
				}
			}
			return arg;
		}


		/// <summary>
		///		Throws an exception if the collection referenced by <paramref name="arg"/> 
		///		contains fewer elements than specified in <paramref name="count"/>.
		/// </summary>
		/// <typeparam name="TCollection">The type of elements in the collection.</typeparam>
		/// <param name="arg">The value or expression to evaluate.</param>
		/// <param name="count">The element count limit.</param>
		/// <param name="msg">The message to use for the exception.</param>
		/// <param name="argName">The name of the evaluated expression in <paramref name="arg"/>.</param>
		/// <param name="ex">
		///		A function that accepts the <paramref name="argName"/> 
		///		string and returns the exception instance to be thrown 
		///		(instead of the default exception type).
		/// </param>
		/// <returns>The value specified in <paramref name="arg"/>.</returns>
		/// <exception cref="ArgumentException">When <paramref name="arg"/> does not contain at least <paramref name="count"/> elements.</exception>
		[Pure, MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static TCollection IfCountLessThan<TCollection>(
			[DisallowNull] TCollection arg, uint count, string? msg = default,
			[CallerArgumentExpression(nameof(arg))] string? argName = default,
			Func<string, Exception>? ex = default)
			where TCollection : IEnumerable
		{
			_ = IfNull(arg, msg, argName, ex);
			var argCount = arg.EnumerableCount();
			if (count > argCount)
			{
				if (ex is null)
				{
					BadArg(
						argName ?? SR.Msg_NoArgName,
						msg ?? SR.Err_Collection_Count_LessThan.SF(argCount, count));
				}
				else
				{
					This(ex.Invoke(argName ?? SR.Msg_NoArgName));
				}
			}
			return arg;
		}

		/// <summary>
		///		Throws an exception if the collection referenced by <paramref name="arg"/> 
		///		contains same or fewer elements than specified in <paramref name="count"/>.
		/// </summary>
		/// <typeparam name="TCollection">The type of elements in the collection.</typeparam>
		/// <param name="arg">The value or expression to evaluate.</param>
		/// <param name="count">The element count limit.</param>
		/// <param name="msg">The message to use for the exception.</param>
		/// <param name="argName">The name of the evaluated expression in <paramref name="arg"/>.</param>
		/// <param name="ex">
		///		A function that accepts the <paramref name="argName"/> 
		///		string and returns the exception instance to be thrown 
		///		(instead of the default exception type).
		/// </param>
		/// <returns>The value specified in <paramref name="arg"/>.</returns>
		/// <exception cref="ArgumentException">When <paramref name="arg"/> does not contain at least <paramref name="count"/> elements.</exception>
		[Pure, MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static TCollection IfCountLessThanOrEqualTo<TCollection>(
			[DisallowNull] TCollection arg, uint count, string? msg = default,
			[CallerArgumentExpression(nameof(arg))] string? argName = default,
			Func<string, Exception>? ex = default)
			where TCollection : IEnumerable
		{
			_ = IfNull(arg, msg, argName, ex);
			var argCount = arg.EnumerableCount();
			if (count >= argCount)
			{
				if (ex is null)
				{
					BadArg(
						argName ?? SR.Msg_NoArgName,
						msg ?? SR.Err_Collection_Count_LessThanOrEqualTo.SF(argCount, count));
				}
				else
				{
					This(ex.Invoke(argName ?? SR.Msg_NoArgName));
				}
			}
			return arg;
		}


		/// <summary>
		///		Throws an exception if the collection referenced by <paramref name="arg"/> 
		///		contains more elements than specified in <paramref name="count"/>.
		/// </summary>
		/// <typeparam name="TCollection">The type of elements in the collection.</typeparam>
		/// <param name="arg">The value or expression to evaluate.</param>
		/// <param name="count">The element count limit.</param>
		/// <param name="msg">The message to use for the exception.</param>
		/// <param name="argName">The name of the evaluated expression in <paramref name="arg"/>.</param>
		/// <param name="ex">
		///		A function that accepts the <paramref name="argName"/> 
		///		string and returns the exception instance to be thrown 
		///		(instead of the default exception type).
		/// </param>
		/// <returns>The value specified in <paramref name="arg"/>.</returns>
		/// <exception cref="ArgumentException">When <paramref name="arg"/> does not contain at least <paramref name="count"/> elements.</exception>
		[Pure, MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static TCollection IfCountMoreThan<TCollection>(
			[DisallowNull] TCollection arg, uint count, string? msg = default,
			[CallerArgumentExpression(nameof(arg))] string? argName = default,
			Func<string, Exception>? ex = default)
			where TCollection : IEnumerable
		{
			_ = IfNull(arg, msg, argName, ex);
			var argCount = arg.EnumerableCount();
			if (count < argCount)
			{
				if (ex is null)
				{
					BadArg(
						argName ?? SR.Msg_NoArgName,
						msg ?? SR.Err_Collection_Count_MoreThan.SF(argCount, count));
				}
				else
				{
					This(ex.Invoke(argName ?? SR.Msg_NoArgName));
				}
			}
			return arg;
		}

		/// <summary>
		///		Throws an exception if the collection referenced by <paramref name="arg"/> 
		///		contains the same or more elements than specified in <paramref name="count"/>.
		/// </summary>
		/// <typeparam name="TCollection">The type of elements in the collection.</typeparam>
		/// <param name="arg">The value or expression to evaluate.</param>
		/// <param name="count">The element count limit.</param>
		/// <param name="msg">The message to use for the exception.</param>
		/// <param name="argName">The name of the evaluated expression in <paramref name="arg"/>.</param>
		/// <param name="ex">
		///		A function that accepts the <paramref name="argName"/> 
		///		string and returns the exception instance to be thrown 
		///		(instead of the default exception type).
		/// </param>
		/// <returns>The value specified in <paramref name="arg"/>.</returns>
		/// <exception cref="ArgumentException">When <paramref name="arg"/> does not contain at least <paramref name="count"/> elements.</exception>
		[Pure, MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static TCollection IfCountMoreThanOrEqualTo<TCollection>(
			[DisallowNull] TCollection arg, uint count, string? msg = default,
			[CallerArgumentExpression(nameof(arg))] string? argName = default,
			Func<string, Exception>? ex = default)
			where TCollection : IEnumerable
		{
			_ = IfNull(arg, msg, argName, ex);
			var argCount = arg.EnumerableCount();
			if (count <= argCount)
			{
				if (ex is null)
				{
					BadArg(
						argName ?? SR.Msg_NoArgName,
						msg ?? SR.Err_Collection_Count_MoreThanOrEqualTo.SF(argCount, count));
				}
				else
				{
					This(ex.Invoke(argName ?? SR.Msg_NoArgName));
				}
			}
			return arg;
		}


		/// <summary>
		///		Throws an exception if the collection referenced by <paramref name="arg"/> 
		///		contains the exact number of elements specified in <paramref name="count"/>.
		/// </summary>
		/// <typeparam name="TCollection">The type of elements in the collection.</typeparam>
		/// <param name="arg">The value or expression to evaluate.</param>
		/// <param name="count">The exact number of elements the collection should contain.</param>
		/// <param name="msg">The message to use for the exception.</param>
		/// <param name="argName">The name of the evaluated expression in <paramref name="arg"/>.</param>
		/// <param name="ex">
		///		A function that accepts the <paramref name="argName"/> 
		///		string and returns the exception instance to be thrown 
		///		(instead of the default exception type).
		/// </param>
		/// <returns>The value specified in <paramref name="arg"/>.</returns>
		/// <exception cref="ArgumentException">When <paramref name="arg"/> does not contain exactly <paramref name="count"/> elements.</exception>
		[Pure, MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static TCollection IfCountIs<TCollection>(
			[DisallowNull] TCollection arg, uint count, string? msg = default,
			[CallerArgumentExpression(nameof(arg))] string? argName = default,
			Func<string, Exception>? ex = default)
			where TCollection : IEnumerable
		{
			_ = IfNull(arg, msg, argName, ex);
			var argCount = arg.EnumerableCount();
			if (count == argCount)
			{
				if (ex is null)
				{
					BadArg(
						argName ?? SR.Msg_NoArgName,
						msg ?? SR.Err_Collection_Count_Is.SF(argCount, count));
				}
				else
				{
					This(ex.Invoke(argName ?? SR.Msg_NoArgName));
				}
			}
			return arg;
		}

		/// <summary>
		///		Throws an exception if the collection referenced by <paramref name="arg"/> 
		///		does not contain the exact number of elements specified in <paramref name="count"/>.
		/// </summary>
		/// <typeparam name="TCollection">The type of elements in the collection.</typeparam>
		/// <param name="arg">The value or expression to evaluate.</param>
		/// <param name="count">The exact number of elements the collection should contain.</param>
		/// <param name="msg">The message to use for the exception.</param>
		/// <param name="argName">The name of the evaluated expression in <paramref name="arg"/>.</param>
		/// <param name="ex">
		///		A function that accepts the <paramref name="argName"/> 
		///		string and returns the exception instance to be thrown 
		///		(instead of the default exception type).
		/// </param>
		/// <returns>The value specified in <paramref name="arg"/>.</returns>
		/// <exception cref="ArgumentException">When <paramref name="arg"/> does not contain exactly <paramref name="count"/> elements.</exception>
		[Pure, MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static TCollection IfCountIsNot<TCollection>(
			[DisallowNull] TCollection arg, uint count, string? msg = default,
			[CallerArgumentExpression(nameof(arg))] string? argName = default,
			Func<string, Exception>? ex = default)
			where TCollection : IEnumerable
		{
			_ = IfNull(arg, msg, argName, ex);
			var argCount = arg.EnumerableCount();
			if (count != argCount)
			{
				if (ex is null)
				{
					BadArg(
						argName ?? SR.Msg_NoArgName,
						msg ?? SR.Err_Collection_Count_IsNot.SF(argCount, count));
				}
				else
				{
					This(ex.Invoke(argName ?? SR.Msg_NoArgName));
				}
			}
			return arg;
		}


		/// <summary>
		///		Throws an exception if <paramref name="predicate"/> returns true
		///		for any element in the specified collection.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements in the collection.</typeparam>
		/// <param name="arg">The value or expression to evaluate.</param>
		/// <param name="predicate">The function to apply to the collection elements.</param>
		/// <param name="msg">The message to use for the exception.</param>
		/// <param name="argName">The name of the evaluated expression in <paramref name="arg"/>.</param>
		/// <param name="ex">
		///		A function that accepts the <paramref name="argName"/> 
		///		string and returns the exception instance to be thrown 
		///		(instead of the default exception type).
		/// </param>
		/// <returns>The value specified in <paramref name="arg"/>.</returns>
		/// <exception cref="ArgumentException">When any element in <paramref name="arg"/> causes the predicate function to return true.</exception>
		[Pure, MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IEnumerable<TElement?> IfAnyElement<TElement>(
			[DisallowNull] IEnumerable<TElement?> arg,
			Func<TElement?, bool> predicate, string? msg = default,
			[CallerArgumentExpression(nameof(arg))] string? argName = default,
			Func<string, Exception>? ex = default)
		{
			_ = IfNull(arg, msg, argName, ex);
			if (arg.Any(predicate))
			{
				if (ex is null)
				{
					BadArg(
						argName ?? SR.Msg_NoArgName,
						msg ?? SR.Err_Collection_Item_Any);
				}
				else
				{
					This(ex.Invoke(argName ?? SR.Msg_NoArgName));
				}
			}
			return arg;
		}

		/// <summary>
		///		Throws an exception if <paramref name="predicate"/> returns false
		///		for any element in the specified collection.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements in the collection.</typeparam>
		/// <param name="arg">The value or expression to evaluate.</param>
		/// <param name="predicate">The function to apply to the collection elements.</param>
		/// <param name="msg">The message to use for the exception.</param>
		/// <param name="argName">The name of the evaluated expression in <paramref name="arg"/>.</param>
		/// <param name="ex">
		///		A function that accepts the <paramref name="argName"/> 
		///		string and returns the exception instance to be thrown 
		///		(instead of the default exception type).
		/// </param>
		/// <returns>The value specified in <paramref name="arg"/>.</returns>
		/// <exception cref="ArgumentException">When any element in <paramref name="arg"/> causes the predicate function to return false.</exception>
		[Pure, MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IEnumerable<TElement?> IfAnyElementNot<TElement>(
			[DisallowNull] IEnumerable<TElement?> arg,
			Func<TElement?, bool> predicate, string? msg = default,
			[CallerArgumentExpression(nameof(arg))] string? argName = default,
			Func<string, Exception>? ex = default)
		{
			_ = IfNull(arg, msg, argName, ex);
			if (!arg.Any(predicate))
			{
				if (ex is null)
				{
					BadArg(
						argName ?? SR.Msg_NoArgName,
						msg ?? SR.Err_Collection_Item_AnyNot);
				}
				else
				{
					This(ex.Invoke(argName ?? SR.Msg_NoArgName));
				}
			}
			return arg;
		}


		/// <summary>
		///		Throws an exception if the collection referenced by <paramref name="arg"/> 
		///		contains any element that is a null or empty string.
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
		/// <exception cref="ArgumentException">When <paramref name="arg"/> contains an element that is null, empty, or whitespace.</exception>
		[Pure, MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IEnumerable<string> IfAnyElementNullOrEmpty(
			[DisallowNull, NotNull] IEnumerable<string?> arg, string? msg = default,
			[CallerArgumentExpression(nameof(arg))] string? argName = default,
			Func<string, Exception>? ex = default) =>
			(IEnumerable<string>) IfAnyElement(
				arg, string.IsNullOrEmpty,
				msg ?? SR.Err_Collection_Item_NullOrEmpty,
				argName, ex);

		/// <summary>
		///		Throws an exception if the collection referenced by <paramref name="arg"/> 
		///		contains any element that is a null string or contains only whitespace.
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
		/// <exception cref="ArgumentException">When <paramref name="arg"/> contains an element that is null, empty, or whitespace.</exception>
		[Pure, MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IEnumerable<string> IfAnyElementNullOrWhitespace(
			[DisallowNull, NotNull] IEnumerable<string?> arg, string? msg = default,
			[CallerArgumentExpression(nameof(arg))] string? argName = default,
			Func<string, Exception>? ex = default) =>
			(IEnumerable<string>) IfAnyElement(
				arg, string.IsNullOrWhiteSpace,
				msg ?? SR.Err_Collection_Item_NullOrWhitespace,
				argName, ex);


		#region Enumerable helpers...

		[Pure, MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static int EnumerableCount<TValue>(
			[DisallowNull] this TValue value)
			where TValue : IEnumerable
		{
			static int getEnumeratedCount(IEnumerable enumerable)
			{
				IEnumerator enumerator = enumerable.GetEnumerator();
				int count = 0;
				while (enumerator.MoveNext()) count++;
				return count;
			}

			return value switch
			{
				ICollection collection => collection.Count,
				string s => s.Length,
				_ => getEnumeratedCount(value)
			};
		}

		#endregion
	}
}
