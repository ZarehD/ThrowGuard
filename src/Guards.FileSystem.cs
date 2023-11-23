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
		///		Throws <see cref="DirectoryNotFoundException"/> 
		///		if specified path does not exist.
		/// </summary>
		/// <param name="folderPath">The folder path.</param>
		/// <param name="msg">The message to use for the exception.</param>
		/// <param name="argName">The name of the evaluated expression in <paramref name="folderPath"/>.</param>
		/// <param name="ex">
		///		A function that accepts the <paramref name="argName"/> 
		///		string and returns the exception instance to be thrown 
		///		(instead of the default exception type).
		/// </param>
		/// <returns>The value specified in <paramref name="folderPath"/>.</returns>
		/// <exception cref="DirectoryNotFoundException"/>
		[Pure, MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static string IfDirectoryNotFound(
			[AllowNull, NotNull] string? folderPath, string? msg = default,
			[CallerArgumentExpression(nameof(folderPath))] string? argName = default,
			Func<string, Exception>? ex = default)
		{
			_ = IfNullOrWhitespace(folderPath, msg, argName, ex);

			if (!Directory.Exists(folderPath))
			{
				if (ex is null)
				{
					DirectoryNotFound(
						msg ?? SR.Err_Directory_NotFound_Path.SF(folderPath));
				}
				else
				{
					This(ex.Invoke(argName ?? SR.Msg_NoArgName));
				}
			}

			return folderPath;
		}


		/// <summary>
		///		Throws <see cref="FileNotFoundException"/> 
		///		if specified pathname does not exist.
		/// </summary>
		/// <param name="pathName">The file pathname.</param>
		/// <param name="msg">The message to use for the exception.</param>
		/// <param name="argName">The name of the evaluated expression in <paramref name="pathName"/>.</param>
		/// <param name="ex">
		///		A function that accepts the <paramref name="argName"/> 
		///		string and returns the exception instance to be thrown 
		///		(instead of the default exception type).
		/// </param>
		/// <returns>The value specified in <paramref name="pathName"/>.</returns>
		/// <exception cref="FileNotFoundException"/>
		[Pure, MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static string IfFileNotFound(
			[AllowNull, NotNull] string? pathName, string? msg = default,
			[CallerArgumentExpression(nameof(pathName))] string? argName = default,
			Func<string, Exception>? ex = default)
		{
			_ = IfNullOrWhitespace(pathName, msg, argName, ex);

			if (!File.Exists(pathName))
			{
				if (ex is null)
				{
					FileNotFound(
						pathName,
						msg ?? SR.Err_File_NotFound_Path.SF(pathName));
				}
				else
				{
					This(ex.Invoke(argName ?? SR.Msg_NoArgName));
				}
			}

			return pathName;
		}
	}
}
