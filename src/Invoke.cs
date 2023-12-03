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
	///		Contains method for invoking actions.
	/// </summary>
	public static class Invoke
	{
		/// <summary>
		///		Executes the supplied action when the specified condition is true.
		/// </summary>
		/// <param name="condition">The condition to evaluate.</param>
		/// <param name="action">The action to execute.</param>
		public static void When(Func<bool> condition, Action action)
		{
			Throw.IfNull(condition);
			Throw.IfNull(action);
			if (condition.Invoke()) action.Invoke();
		}
	}
}
