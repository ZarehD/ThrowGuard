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
		///		if the Uri is absolute.
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
		/// <exception cref="ArgumentException">When <paramref name="arg"/> is empty or whitespace.</exception>
		[Pure, MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Uri IfAbsolute(
			Uri arg, string? msg = default,
			[CallerArgumentExpression(nameof(arg))] string? argName = default,
			Func<string, Exception>? ex = default)
		{
			if (arg.IsAbsoluteUri)
			{
				if (ex is null)
				{
					BadArg(
						argName ?? SR.Msg_NoArgName,
						msg ?? SR.Err_Uri_IsAbsolute);
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
		///		if the Uri is relative.
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
		/// <exception cref="ArgumentException">When <paramref name="arg"/> is empty or whitespace.</exception>
		[Pure, MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Uri IfRelative(
			Uri arg, string? msg = default,
			[CallerArgumentExpression(nameof(arg))] string? argName = default,
			Func<string, Exception>? ex = default)
		{
			if (!arg.IsAbsoluteUri)
			{
				if (ex is null)
				{
					BadArg(
						argName ?? SR.Msg_NoArgName,
						msg ?? SR.Err_Uri_IsRelative);
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
		///		if the Uri uses the specified scheme.
		/// </summary>
		/// <param name="arg">The value or expression to evaluate.</param>
		/// <param name="scheme">The uri scheme to compare with.</param>
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
		public static Uri IfSchemeIs(
			Uri arg, string scheme, string? msg = default,
			[CallerArgumentExpression(nameof(arg))] string? argName = default,
			Func<string, Exception>? ex = default)
		{
			if (arg.Scheme.Equals(scheme, StringComparison.OrdinalIgnoreCase))
			{
				if (ex is null)
				{
					BadArg(
						argName ?? SR.Msg_NoArgName,
						msg ?? SR.Err_Uri_SchemeIs.SF(scheme.ToUpperInvariant()));
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
		///		if the Uri does not use the specified scheme.
		/// </summary>
		/// <param name="arg">The value or expression to evaluate.</param>
		/// <param name="scheme">The uri scheme to compare with.</param>
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
		public static Uri IfSchemeIsNot(
			Uri arg, string scheme, string? msg = default,
			[CallerArgumentExpression(nameof(arg))] string? argName = default,
			Func<string, Exception>? ex = default)
		{
			if (!arg.Scheme.Equals(scheme, StringComparison.OrdinalIgnoreCase))
			{
				if (ex is null)
				{
					BadArg(
						argName ?? SR.Msg_NoArgName,
						msg ?? SR.Err_Uri_SchemeIsNot.SF(scheme.ToUpperInvariant()));
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
		///		if the Uri uses the specified port.
		/// </summary>
		/// <param name="arg">The value or expression to evaluate.</param>
		/// <param name="port">The port number.</param>
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
		public static Uri IfPortIs(
			Uri arg, int port, string? msg = default,
			[CallerArgumentExpression(nameof(arg))] string? argName = default,
			Func<string, Exception>? ex = default)
		{
			if (arg.Port == port)
			{
				if (ex is null)
				{
					BadArg(
						argName ?? SR.Msg_NoArgName,
						msg ?? SR.Err_Uri_PortIs.SF(port));
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
		///		if the Uri does not use the specified port.
		/// </summary>
		/// <param name="arg">The value or expression to evaluate.</param>
		/// <param name="port">The port number.</param>
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
		public static Uri IfPortIsNot(
			Uri arg, int port, string? msg = default,
			[CallerArgumentExpression(nameof(arg))] string? argName = default,
			Func<string, Exception>? ex = default)
		{
			if (arg.Port != port)
			{
				if (ex is null)
				{
					BadArg(
						argName ?? SR.Msg_NoArgName,
						msg ?? SR.Err_Uri_PortIsNot.SF(port));
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
		///		if the Uri uses the default port for the scheme.
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
		/// <exception cref="ArgumentException">When <paramref name="arg"/> is empty or whitespace.</exception>
		[Pure, MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Uri IfPortIsDefault(
			Uri arg, string? msg = default,
			[CallerArgumentExpression(nameof(arg))] string? argName = default,
			Func<string, Exception>? ex = default)
		{
			if (arg.IsDefaultPort)
			{
				if (ex is null)
				{
					BadArg(
						argName ?? SR.Msg_NoArgName,
						msg ?? SR.Err_Uri_PortIsDefault);
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
		///		if the Uri does not use the default port for the scheme.
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
		/// <exception cref="ArgumentException">When <paramref name="arg"/> is empty or whitespace.</exception>
		[Pure, MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Uri IfPortIsNotDefault(
			Uri arg, string? msg = default,
			[CallerArgumentExpression(nameof(arg))] string? argName = default,
			Func<string, Exception>? ex = default)
		{
			if (!arg.IsDefaultPort)
			{
				if (ex is null)
				{
					BadArg(
						argName ?? SR.Msg_NoArgName,
						msg ?? SR.Err_Uri_PortIsNotDefault);
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
		///		if the Uri is for the specified host.
		/// </summary>
		/// <param name="arg">The value or expression to evaluate.</param>
		/// <param name="host">The uri host</param>
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
		public static Uri IfHostIs(
			Uri arg, string host, string? msg = default,
			[CallerArgumentExpression(nameof(arg))] string? argName = default,
			Func<string, Exception>? ex = default)
		{
			if (arg.Host.Equals(host, StringComparison.OrdinalIgnoreCase))
			{
				if (ex is null)
				{
					BadArg(
						argName ?? SR.Msg_NoArgName,
						msg ?? SR.Err_Uri_HostIs.SF(host.ToLowerInvariant()));
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
		///		if the Uri is not for the specified host.
		/// </summary>
		/// <param name="arg">The value or expression to evaluate.</param>
		/// <param name="host">The uri host</param>
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
		public static Uri IfHostIsNot(
			Uri arg, string host, string? msg = default,
			[CallerArgumentExpression(nameof(arg))] string? argName = default,
			Func<string, Exception>? ex = default)
		{
			if (!arg.Host.Equals(host, StringComparison.OrdinalIgnoreCase))
			{
				if (ex is null)
				{
					BadArg(
						argName ?? SR.Msg_NoArgName,
						msg ?? SR.Err_Uri_HostIsNot.SF(host.ToLowerInvariant()));
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
		///		if the Uri uses the specified <see cref="UriHostNameType"/>.
		/// </summary>
		/// <param name="arg">The value or expression to evaluate.</param>
		/// <param name="hostNameType">The uri HostNameType</param>
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
		public static Uri IfHostNameTypeIs(
			Uri arg, UriHostNameType hostNameType, string? msg = default,
			[CallerArgumentExpression(nameof(arg))] string? argName = default,
			Func<string, Exception>? ex = default)
		{
			if (arg.HostNameType == hostNameType)
			{
				if (ex is null)
				{
					BadArg(
						argName ?? SR.Msg_NoArgName,
						msg ?? SR.Err_Uri_HostNameTypeIs.SF(hostNameType.ToString()));
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
		///		if the Uri does not use the specified <see cref="UriHostNameType"/>.
		/// </summary>
		/// <param name="arg">The value or expression to evaluate.</param>
		/// <param name="hostNameType">The uri HostNameType</param>
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
		public static Uri IfHostNameTypeIsNot(
			Uri arg, UriHostNameType hostNameType, string? msg = default,
			[CallerArgumentExpression(nameof(arg))] string? argName = default,
			Func<string, Exception>? ex = default)
		{
			if (arg.HostNameType != hostNameType)
			{
				if (ex is null)
				{
					BadArg(
						argName ?? SR.Msg_NoArgName,
						msg ?? SR.Err_Uri_HostNameTypeIsNot.SF(hostNameType.ToString()));
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
		///		if the Uri is a base of the specified other Uri.
		/// </summary>
		/// <param name="arg">The value or expression to evaluate.</param>
		/// <param name="otherUri">The uri to cpmpare with.</param>
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
		public static Uri IfBaseOf(
			Uri arg, Uri otherUri, string? msg = default,
			[CallerArgumentExpression(nameof(arg))] string? argName = default,
			Func<string, Exception>? ex = default)
		{
			if (arg.IsBaseOf(otherUri))
			{
				if (ex is null)
				{
					BadArg(
						argName ?? SR.Msg_NoArgName,
						msg ?? SR.Err_Uri_IsBaseOf.SF(arg.ToString(), otherUri.ToString()));
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
		///		if the Uri is not a base of the specified other Uri.
		/// </summary>
		/// <param name="arg">The value or expression to evaluate.</param>
		/// <param name="otherUri">The uri to cpmpare with.</param>
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
		public static Uri IfNotBaseOf(
			Uri arg, Uri otherUri, string? msg = default,
			[CallerArgumentExpression(nameof(arg))] string? argName = default,
			Func<string, Exception>? ex = default)
		{
			if (!arg.IsBaseOf(otherUri))
			{
				if (ex is null)
				{
					BadArg(
						argName ?? SR.Msg_NoArgName,
						msg ?? SR.Err_Uri_IsNotBaseOf.SF(arg.ToString(), otherUri.ToString()));
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
		///		if the Uri is a File Uri.
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
		/// <exception cref="ArgumentException">When <paramref name="arg"/> is empty or whitespace.</exception>
		[Pure, MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Uri IfFile(
			Uri arg, string? msg = default,
			[CallerArgumentExpression(nameof(arg))] string? argName = default,
			Func<string, Exception>? ex = default)
		{
			if (arg.IsFile)
			{
				if (ex is null)
				{
					BadArg(
						argName ?? SR.Msg_NoArgName,
						msg ?? SR.Err_Uri_IsFile);
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
		///		if the Uri is not a File Uri.
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
		/// <exception cref="ArgumentException">When <paramref name="arg"/> is empty or whitespace.</exception>
		[Pure, MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Uri IfNotFile(
			Uri arg, string? msg = default,
			[CallerArgumentExpression(nameof(arg))] string? argName = default,
			Func<string, Exception>? ex = default)
		{
			if (!arg.IsFile)
			{
				if (ex is null)
				{
					BadArg(
						argName ?? SR.Msg_NoArgName,
						msg ?? SR.Err_Uri_IsNotFile);
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
		///		if the Uri is a Unc Uri.
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
		/// <exception cref="ArgumentException">When <paramref name="arg"/> is empty or whitespace.</exception>
		[Pure, MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Uri IfUnc(
			Uri arg, string? msg = default,
			[CallerArgumentExpression(nameof(arg))] string? argName = default,
			Func<string, Exception>? ex = default)
		{
			if (arg.IsUnc)
			{
				if (ex is null)
				{
					BadArg(
						argName ?? SR.Msg_NoArgName,
						msg ?? SR.Err_Uri_IsUnc);
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
		///		if the Uri is not a Unc Uri.
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
		/// <exception cref="ArgumentException">When <paramref name="arg"/> is empty or whitespace.</exception>
		[Pure, MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Uri IfNotUnc(
			Uri arg, string? msg = default,
			[CallerArgumentExpression(nameof(arg))] string? argName = default,
			Func<string, Exception>? ex = default)
		{
			if (!arg.IsUnc)
			{
				if (ex is null)
				{
					BadArg(
						argName ?? SR.Msg_NoArgName,
						msg ?? SR.Err_Uri_IsNotUnc);
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
		///		if the Uri references the local host.
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
		/// <exception cref="ArgumentException">When <paramref name="arg"/> is empty or whitespace.</exception>
		[Pure, MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Uri IfLoopback(
			Uri arg, string? msg = default,
			[CallerArgumentExpression(nameof(arg))] string? argName = default,
			Func<string, Exception>? ex = default)
		{
			if (arg.IsLoopback)
			{
				if (ex is null)
				{
					BadArg(
						argName ?? SR.Msg_NoArgName,
						msg ?? SR.Err_Uri_IsLoopback);
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
		///		if the Uri does not reference the local host.
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
		/// <exception cref="ArgumentException">When <paramref name="arg"/> is empty or whitespace.</exception>
		[Pure, MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Uri IfNotLoopback(
			Uri arg, string? msg = default,
			[CallerArgumentExpression(nameof(arg))] string? argName = default,
			Func<string, Exception>? ex = default)
		{
			if (!arg.IsLoopback)
			{
				if (ex is null)
				{
					BadArg(
						argName ?? SR.Msg_NoArgName,
						msg ?? SR.Err_Uri_IsNotLoopback);
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
