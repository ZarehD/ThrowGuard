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
	/// <summary>
	///		Constants for know Uri schemes.
	/// </summary>
	public static class UriScheme
	{
		/// <summary>
		///		HTTP scheme.
		/// </summary>
		public static readonly string Http = "http";

		/// <summary>
		///		HTTPS scheme.
		/// </summary>
		public static readonly string Https = "https";

		/// <summary>
		///		FTP scheme.
		/// </summary>
		public static readonly string Ftp = "ftp";

		/// <summary>
		///		FTPS scheme.
		/// </summary>
		public static readonly string Ftps = "ftps";

		/// <summary>
		///		SFTP scheme.
		/// </summary>
		public static readonly string Sftp = "sftp";
	}
}
