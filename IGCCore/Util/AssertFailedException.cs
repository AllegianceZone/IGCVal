using System;

namespace FreeAllegiance.IGCCore.Util
{
	/// <summary>
	/// Thrown when an unexpected value was encountered while reading a core file.
	/// </summary>
	public class AssertFailedException : ApplicationException
	{
		/// <summary>
		/// Default Constructor
		/// </summary>
		/// <param name="message">A message describing this error</param>
		public AssertFailedException (string message) : base(message) {}
	}
}
