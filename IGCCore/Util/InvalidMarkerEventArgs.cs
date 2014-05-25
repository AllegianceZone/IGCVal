using System;

namespace FreeAllegiance.IGCCore.Util
{
	public delegate void InvalidMarkerDelegate (object sender, InvalidMarkerEventArgs e);

	/// <summary>
	/// The arguments of an InvalidMarkerEvent
	/// </summary>
	public class InvalidMarkerEventArgs : EventArgs
	{
		private long	_address = -1;
		private ushort	_objectID = 0;
		private string	_objectName = string.Empty;
		private string	_objectType = string.Empty;
		private string	_precedingProperty = string.Empty;

		private object _assertedValue = null;
		private object _actualValue = null;

		/// <summary>
		/// Constructs a new set of InvalidMarker event arguments
		/// </summary>
		/// <param name="address">The address of the invalid marker</param>
		/// <param name="objectID">The ID of the marker (if known)</param>
		/// <param name="objectName">The name of the object being affected</param>
		/// <param name="objectType">The type of object (if known)</param>
		/// <param name="precedingProperty">The property immediately before the invalid marker</param>
		/// <param name="assertedValue">The marker value that should exist at this location</param>
		/// <param name="actualValue">The marker value found at this location</param>
		public InvalidMarkerEventArgs (long address, ushort objectID, string objectName,
										string objectType, string precedingProperty,
										object assertedValue, object actualValue)
		{
			_address = address;
			_objectID = objectID;
			_objectName = objectName;
			_objectType = objectType;
			_precedingProperty = precedingProperty;
			_assertedValue = assertedValue;
			_actualValue = actualValue;
		}

		/// <summary>
		/// The address of the invalid marker within the IGC file
		/// </summary>
		public long Address
		{
			get {return _address;}
		}

		/// <summary>
		/// The ID of the object within the IGC file (if known)
		/// </summary>
		public ushort ObjectID
		{
			get {return _objectID;}
		}

		/// <summary>
		/// The name of the object being affected
		/// </summary>
		public string ObjectName
		{
			get {return _objectName;}
		}

		/// <summary>
		/// The type of this object (if known)
		/// </summary>
		public string ObjectType
		{
			get {return _objectType;}
		}

		/// <summary>
		/// The property immediately preceding this marker
		/// </summary>
		public string PrecedingProperty
		{
			get {return _precedingProperty;}
		}

		/// <summary>
		/// The marker value that should exist at this location
		/// </summary>
		public object AssertedValue
		{
			get {return _assertedValue;}
		}

		/// <summary>
		/// The marker value found at this location
		/// </summary>
		public object ActualValue
		{
			get {return _actualValue;}
		}
	}
}
