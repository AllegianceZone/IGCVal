using System;
using System.IO;

namespace FreeAllegiance.IGCCore.Util
{
	/// <summary>
	/// Reads .NET data types from a stream.
	/// </summary>
	public class DataReader
	{
		private const int BYTELENGTH = 1;
		private const int SHORTLENGTH = 2;
		private const int INTLENGTH = 4;
		private const int LONGLENGTH = 8;

		private Stream _stream;

		public static bool FixInvalidMarkers = false;
		public static event InvalidMarkerDelegate InvalidMarkerEvent;

		/// <summary>
		/// Default constructor
		/// </summary>
		/// <param name="stream">The stream of bytes to be read</param>
		public DataReader (Stream stream)
		{
			_stream = stream;
		}

		#region Asserts
		/// <summary>
		/// Reads the next byte from the stream, and checks if it equals 'value'.
		/// </summary>
		/// <param name="value">The value to compare against the next byte from the stream</param>
		/// <param name="objectID">The ID of the marker (if known)</param>
		/// <param name="objectName">The name of the object being affected</param>
		/// <param name="objectType">The type of object (if known)</param>
		/// <param name="precedingProperty">The property immediately before the invalid marker</param>
		/// <returns>true or false, depending on whether the read byte is the same as the specified value</returns>
		public bool Assert (byte value, ushort objectID, string objectName, string objectType,
							string precedingProperty)
		{
			long Location = _stream.Position;

			Byte b = (byte)_stream.ReadByte();
			if (b != value)
			{
				InvalidMarkerEventArgs Args = new InvalidMarkerEventArgs(Location, 
																		objectID, 
																		objectName, 
																		objectType, 
																		precedingProperty, 
																		value, 
																		b);
				InvalidMarkerEvent(null, Args);
			}

			return true;
		}

		/// <summary>
		/// Reads the next short from the stream, and checks if it equals 'value'.
		/// </summary>
		/// <param name="value">The value to compare against the next short from the stream</param>
		/// <param name="objectID">The ID of the marker (if known)</param>
		/// <param name="objectName">The name of the object being affected</param>
		/// <param name="objectType">The type of object (if known)</param>
		/// <param name="precedingProperty">The property immediately before the invalid marker</param>
		/// <returns>true or false, depending on whether the read short is the same as the specified value</returns>
		public bool Assert (short value, ushort objectID, string objectName, string objectType,
			string precedingProperty)
		{
			long Location = _stream.Position;

			byte[] temp = new byte[SHORTLENGTH];
			_stream.Read(temp, 0, SHORTLENGTH);

			short Value = ByteConversion.ToShort(temp, 0);

			if (Value != value)
			{
				InvalidMarkerEventArgs Args = new InvalidMarkerEventArgs(Location, 
					objectID, 
					objectName, 
					objectType, 
					precedingProperty, 
					value, 
					Value);

				InvalidMarkerEvent(null, Args);
			}

			return true;
		}

		/// <summary>
		/// Reads the next short from the stream, and checks if it equals 'value'.
		/// </summary>
		/// <param name="value">The value to compare against the next short from the stream</param>
		/// <param name="objectID">The ID of the marker (if known)</param>
		/// <param name="objectName">The name of the object being affected</param>
		/// <param name="objectType">The type of object (if known)</param>
		/// <param name="precedingProperty">The property immediately before the invalid marker</param>
		/// <returns>true or false, depending on whether the read short is the same as the specified value</returns>
		public bool Assert (ushort value, ushort objectID, string objectName, string objectType,
			string precedingProperty)
		{
			long Location = _stream.Position;

			byte[] temp = new byte[SHORTLENGTH];
			_stream.Read(temp, 0, SHORTLENGTH);

			ushort Value = ByteConversion.ToUShort(temp, 0);

			if (Value != value)
			{
				InvalidMarkerEventArgs Args = new InvalidMarkerEventArgs(Location, 
					objectID, 
					objectName, 
					objectType, 
					precedingProperty, 
					value, 
					Value);

				InvalidMarkerEvent(null, Args);
			}

			return true;
		}

		/// <summary>
		/// Reads the next int from the stream, and checks if it equals 'value'.
		/// </summary>
		/// <param name="value">The value to compare against the next int from the stream</param>
		/// <param name="objectID">The ID of the marker (if known)</param>
		/// <param name="objectName">The name of the object being affected</param>
		/// <param name="objectType">The type of object (if known)</param>
		/// <param name="precedingProperty">The property immediately before the invalid marker</param>
		/// <returns>true or false, depending on whether the read byte is the same as the specified value</returns>
		public bool Assert (int value, ushort objectID, string objectName, string objectType,
			string precedingProperty)
		{
			long Location = _stream.Position;

			byte[] temp = new byte[INTLENGTH];
			_stream.Read(temp, 0, INTLENGTH);

			int Value = ByteConversion.ToInt(temp, 0);

			if (Value != value)
			{
				InvalidMarkerEventArgs Args = new InvalidMarkerEventArgs(Location, 
					objectID, 
					objectName, 
					objectType, 
					precedingProperty, 
					value, 
					Value);

				InvalidMarkerEvent(null, Args);
			}

			return true;
		}

		/// <summary>
		/// Reads the next int from the stream, and checks if it equals 'value'.
		/// </summary>
		/// <param name="value">The value to compare against the next int from the stream</param>
		/// <param name="objectID">The ID of the marker (if known)</param>
		/// <param name="objectName">The name of the object being affected</param>
		/// <param name="objectType">The type of object (if known)</param>
		/// <param name="precedingProperty">The property immediately before the invalid marker</param>
		/// <returns>true or false, depending on whether the read byte is the same as the specified value</returns>
		public bool Assert (uint value, ushort objectID, string objectName, string objectType,
			string precedingProperty)
		{
			long Location = _stream.Position;

			byte[] temp = new byte[INTLENGTH];
			_stream.Read(temp, 0, INTLENGTH);

			uint Value = ByteConversion.ToUInt(temp, 0);

			if (Value != value)
			{
				InvalidMarkerEventArgs Args = new InvalidMarkerEventArgs(Location, 
					objectID, 
					objectName, 
					objectType, 
					precedingProperty, 
					value, 
					Value);

				InvalidMarkerEvent(null, Args);
			}

			return true;
		}

		/// <summary>
		/// Reads the next long from the stream, and checks if it equals 'value'.
		/// </summary>
		/// <param name="value">The value to compare against the next long from the stream</param>
		/// <param name="objectID">The ID of the marker (if known)</param>
		/// <param name="objectName">The name of the object being affected</param>
		/// <param name="objectType">The type of object (if known)</param>
		/// <param name="precedingProperty">The property immediately before the invalid marker</param>
		/// <returns>true or false, depending on whether the read long is the same as the specified value</returns>
		public bool Assert (long value, ushort objectID, string objectName, string objectType,
			string precedingProperty)
		{
			long Location = _stream.Position;

			byte[] temp = new byte[LONGLENGTH];
			_stream.Read(temp, 0, LONGLENGTH);

			long Value = ByteConversion.ToLong(temp, 0);

			if (Value != value)
			{
				InvalidMarkerEventArgs Args = new InvalidMarkerEventArgs(Location, 
					objectID, 
					objectName, 
					objectType, 
					precedingProperty, 
					value, 
					Value);

				InvalidMarkerEvent(null, Args);
			}

			return true;
		}
		#endregion

		public void Skip (int amount)
		{
			_stream.Seek(amount, SeekOrigin.Current);
		}

		public void Seek (int amount)
		{
			_stream.Seek(amount, SeekOrigin.Current);
		}

		/// <summary>
		/// Reads a byte from the stream, and advances the index accordingly.
		/// </summary>
		/// <returns>the next byte from the stream</returns>
		public byte ReadByte ()
		{
			return (byte)_stream.ReadByte();
		}

		/// <summary>
		/// Reads a int from the stream, and advances the index accordingly.
		/// </summary>
		/// <returns>the next 4 bytes from the stream cast as a int</returns>
		public int ReadInt ()
		{
			byte[] temp = new byte[INTLENGTH];
			_stream.Read(temp, 0, INTLENGTH);

			return ByteConversion.ToInt(temp, 0);
		}

		/// <summary>
		/// Reads a uint from the stream, and advances the index accordingly.
		/// </summary>
		/// <returns>the next 4 bytes from the stream cast as a uint</returns>
		public uint ReadUInt ()
		{
			byte[] temp = new byte[INTLENGTH];
			_stream.Read(temp, 0, INTLENGTH);

			return ByteConversion.ToUInt(temp, 0);
		}

		/// <summary>
		/// Reads a short from the stream, and advances the index accordingly.
		/// </summary>
		/// <returns>the next 2 bytes from the stream cast as a short from</returns>
		public short ReadShort ()
		{
			byte[] temp = new byte[SHORTLENGTH];
			_stream.Read(temp, 0, SHORTLENGTH);

			return ByteConversion.ToShort(temp, 0);
		}

		/// <summary>
		/// Reads a ushort from the stream, and advances the index accordingly.
		/// </summary>
		/// <returns>the next 2 bytes from the stream cast as a ushort</returns>
		public ushort ReadUShort ()
		{
			byte[] temp = new byte[SHORTLENGTH];
			_stream.Read(temp, 0, SHORTLENGTH);

			return ByteConversion.ToUShort(temp, 0);
		}

		/// <summary>
		/// Reads a float from the stream, and advances the index accordingly.
		/// </summary>
		/// <returns>the next 4 bytes from the stream cast as a float</returns>
		public float ReadFloat ()
		{
			byte[] temp = new byte[INTLENGTH];
			_stream.Read(temp, 0, INTLENGTH);
			
			return ByteConversion.ToFloat(temp, 0);
		}

		/// <summary>
		/// Reads a long from the stream, and advances the index accordingly.
		/// </summary>
		/// <returns>the next 8 bytes from the stream cast as a long</returns>
		public long ReadLong ()
		{
			byte[] temp = new byte[LONGLENGTH];
			_stream.Read(temp, 0, LONGLENGTH);
			
			return ByteConversion.ToLong(temp, 0);
		}

		/// <summary>
		/// Reads a ulong from the stream, and advances the index accordingly.
		/// </summary>
		/// <returns>the next 8 bytes from the stream cast as a ulong</returns>
		public ulong ReadULong ()
		{
			byte[] temp = new byte[LONGLENGTH];
			_stream.Read(temp, 0, LONGLENGTH);
			
			return ByteConversion.ToULong(temp, 0);
		}

		/// <summary>
		/// Reads an array of bytes from the stream, and advances the index accordingly.
		/// </summary>
		/// <param name="length">The number of bytes to retrieve from the stream</param>
		/// <returns>the bytes retrieved from the stream</returns>
		public byte[] ReadBytes (int length)
		{
			byte[] temp = new byte[length];
			_stream.Read(temp, 0, length);
			return temp;
		}

		/// <summary>
		/// Reads a string from the stream, advancing the index accordingly
		/// </summary>
		/// <param name="length">The length of the string to be read</param>
		/// <returns>the string read from the stream</returns>
		public string ReadString (int length)
		{
			byte[] temp = new byte[length];
			_stream.Read(temp, 0, length);
			
			return ByteConversion.GetString(temp);
		}
	}
}
