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
		///		Throws an exception if the type for <paramref name="arg"/> 
		///		is equal to the type specified in <paramref name="other"/>
		/// </summary>
		/// <typeparam name="T">The type of the <paramref name="arg"/> value.</typeparam>
		/// <param name="arg">The value to evaluate.</param>
		/// <param name="other">The type to compare with.</param>
		/// <param name="ex">
		///		A function that accepts the <paramref name="argName"/> 
		///		string and returns the exception instance to be thrown.
		/// </param>
		/// <param name="argName">The name of the evaluated expression in <paramref name="arg"/>.</param>
		[Pure, MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void IfTypeEquals<T>(
			T? arg, Type other, Func<string, Exception> ex,
			[CallerArgumentExpression(nameof(arg))] string? argName = default)
		{
			if (typeof(T) == other)
			{
				This(ex.Invoke(argName ?? SR.Msg_NoArgName));
			}
		}

		/// <summary>
		///		Throws an exception if the type for <paramref name="arg"/> 
		///		is not equal to the type specified in <paramref name="other"/>
		/// </summary>
		/// <typeparam name="T">The type of the <paramref name="arg"/> value.</typeparam>
		/// <param name="arg">The value to evaluate.</param>
		/// <param name="other">The type to compare with.</param>
		/// <param name="ex">
		///		A function that accepts the <paramref name="argName"/> 
		///		string and returns the exception instance to be thrown.
		/// </param>
		/// <param name="argName">The name of the evaluated expression in <paramref name="arg"/>.</param>
		[Pure, MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void IfTypeNotEquals<T>(
			T? arg, Type other, Func<string, Exception> ex,
			[CallerArgumentExpression(nameof(arg))] string? argName = default)
		{
			if (typeof(T) != other)
			{
				This(ex.Invoke(argName ?? SR.Msg_NoArgName));
			}
		}
	}
}
