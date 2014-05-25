using System;
using System.Runtime.InteropServices;

namespace FreeAllegiance.IGCCore
{
	/// <summary>
	/// Allows for simple conversions between the fundamental data types and
	/// byte arrays.
	/// </summary>
	public unsafe sealed class ByteConversion
	{
		private const int LONGLENGTH = 8;
		private const int INTLENGTH = 4;
		private const int SHORTLENGTH = 2;
		private const int BYTELENGTH = 1;

		/**************************************************************************************
		*									  Methods										  *
		**************************************************************************************/

		#region "GetString"
		/// <summary>
		/// Converts an array of bytes to a string up to the first encountered null byte.
		/// </summary>
		/// <param name="value">The array of bytes from which to parse the string.</param>
		/// <param name="startIndex">The position of the first character to parse into a string.</param>
		/// <param name="length">The length of the string.</param>
		/// <returns>A string representing the bytes specified.</returns>
		public static string GetString(byte[] value, int startIndex, int length)
		{
			return GetString(SubArray(value, startIndex, length));
		}
		/// <summary>
		/// Converts an array of bytes to a string up to the first encountered null byte.
		/// </summary>
		/// <param name="value">The array of bytes from which to parse the string.</param>
		/// <returns>A string representing the bytes provided.</returns>
		public static string GetString(byte[] value)
		{
			string ReturnVal;
			GCHandle ghValue = GCHandle.Alloc(value, GCHandleType.Pinned);
			ReturnVal = Marshal.PtrToStringAnsi(ghValue.AddrOfPinnedObject());
			ghValue.Free();
			return ReturnVal;
		}
		#endregion
		#region "ToBytes"
		/// <summary>
		/// Copies the specified number of bytes to a new array, reversing it if desired.
		/// </summary>
		/// <param name="position">The object to convert an array of bytes.</param>
		/// <param name="length">The length of the data to be parsed.</param>
		/// <returns>An array of bytes representing the provided object.</returns>
		internal static byte[] CopyBytes(byte* position, int length) 
		{
			byte* pByte = position;

            byte[] ReturnVal = new byte[length];

			for (int i = 0; i < length; i++) 
			{
				ReturnVal[i] = *pByte;
				pByte = pByte + 1;
			}

			return ReturnVal;
		}

		/// <summary>
		/// Converts a long into an array of bytes.
		/// </summary>
		/// <param name="value">The unsigned integer to convert into an array of bytes.</param>
		/// <returns>An array of bytes representing the provided unsigned integer.</returns>
		public static byte[] ToBytes(long value)
		{
			return CopyBytes((byte*)&value, LONGLENGTH);
		}
		/// <summary>
		/// Converts an integer into an array of bytes.
		/// </summary>
		/// <param name="value">The integer to convert into an array of bytes.</param>
		/// <returns>An array of bytes representing the provided integer.</returns>
		public static byte[] ToBytes(int value)
		{
			return CopyBytes((byte*)&value, INTLENGTH);
		}
		/// <summary>
		/// Converts an unsigned integer into an array of bytes.
		/// </summary>
		/// <param name="value">The unsigned integer to convert into an array of bytes.</param>
		/// <returns>An array of bytes representing the provided unsigned integer.</returns>
		public static byte[] ToBytes(uint value)
		{
			return CopyBytes((byte*)&value, INTLENGTH);
		}
		/// <summary>
		/// Converts a short into an array of bytes.
		/// </summary>
		/// <param name="value">The short to convert into an array of bytes.</param>
		/// <returns>An array of bytes representing the provided short.</returns>
		public static byte[] ToBytes(short value)
		{
			return CopyBytes((byte*)&value, SHORTLENGTH);
		}
		/// <summary>
		/// Converts an unsigned short into an array of bytes.
		/// </summary>
		/// <param name="value">The unsigned short to convert into an array of bytes.</param>
		/// <returns>An array of bytes representing the provided unsigned short.</returns>
		public static byte[] ToBytes(ushort value)
		{
			return CopyBytes((byte*)&value, SHORTLENGTH);
		}
		/// <summary>
		/// Converts a char into an array of bytes.
		/// </summary>
		/// <param name="value">The unsigned short to convert into an array of bytes.</param>
		/// <returns>An array of bytes representing the provided unsigned short.</returns>
		public static byte[] ToBytes(char value)
		{
			return CopyBytes((byte*)&value, SHORTLENGTH);
		}
		/// <summary>
		/// Converts a string into an array of bytes.
		/// </summary>
		/// <param name="value">The string to convert into an array of bytes.</param>
		/// <returns>An array of bytes representing the provided string.</returns>
		public static byte[] GetBytes(string value)
		{
			byte[] ReturnArray;

			fixed (char* ps = value)
			{
				ReturnArray = CopyBytes((byte*)ps, value.Length);
			}

			return ReturnArray;
		}
		#endregion
		#region "ToInt"
		/// <summary>
		/// Converts an array of 4 bytes to an Integer (Int32).
		/// </summary>
		/// <param name="value">The array of bytes to read.</param>
		/// <param name="startIndex">The starting position of the 4 bytes to convert.</param>
		/// <returns>A 32-bit integer representing the specified 4 bytes.</returns>
		public static int ToInt(byte[] value, int startIndex)
		{
			int ReturnVal = 0;
			if (!(value.Length - startIndex < INTLENGTH)) 
			{
				int* pInt;
				fixed (byte* pByte = &value[startIndex])
				{
					pInt = (int*)pByte;
					ReturnVal = *pInt;
				}
				return ReturnVal;
			} 
			else 
			{
				throw new IndexOutOfRangeException();
			}
		}
		/// <summary>
		/// Converts an array of bytes into a 16-bit short.
		/// </summary>
		/// <param name="value">The array of bytes to read.</param>
		/// <param name="startIndex">The starting position of the 2 bytes to convert.</param>
		/// <returns>A 16-bit integer representing the specified 2 bytes.</returns>
		public static short ToShort(byte[] value, int startIndex)
		{
			short ReturnVal = 0;
			if (!(value.Length - startIndex < SHORTLENGTH)) 
			{
				short* pShort;
				fixed (byte* pByte = &value[startIndex])
				{
					pShort = (short*)pByte;
					ReturnVal = *pShort;
				}
				return ReturnVal;
			}
			else 
			{
				throw new IndexOutOfRangeException();
			}
		}
		/// <summary>
		/// Converts an array of 4 bytes to a float.
		/// </summary>
		/// <param name="value">The array of bytes to read.</param>
		/// <param name="startIndex">The starting position of the 4 bytes to convert.</param>
		/// <returns>A 32-bit float representing the specified 4 bytes.</returns>
		public static float ToFloat(byte[] value, int startIndex)
		{
			float ReturnVal = 0;
			if (!(value.Length - startIndex < INTLENGTH)) 
			{
				float* pFloat;
				fixed (byte* pByte = &value[startIndex])
				{
					pFloat = (float*)pByte;
					ReturnVal = *pFloat;
				}
				return ReturnVal;
			} 
			else 
			{
				throw new IndexOutOfRangeException();
			}
		}
		/// <summary>
		/// Converts an array of bytes into a 32-bit unsigned integer.
		/// </summary>
		/// <param name="value">The array of bytes to read.</param>
		/// <param name="startIndex">The starting position of the 4 bytes to convert.</param>
		/// <returns>A 16-bit integer representing the specified 4 bytes.</returns>
		public static uint ToUInt(byte[] value, int startIndex)
		{
			uint ReturnVal = 0;
			if (!(value.Length - startIndex < INTLENGTH)) 
			{
				uint* pUInt;
				fixed (byte* pByte = &value[startIndex])
				{
					pUInt = (uint*)pByte;
					ReturnVal = *pUInt;
				}
				return ReturnVal;
			} 
			else 
			{
				throw new IndexOutOfRangeException();
			}
		}
		/// <summary>
		/// Converts an array of bytes into a 16-bit unsigned short.
		/// </summary>
		/// <param name="value">The array of bytes to read.</param>
		/// <param name="startIndex">The starting position of the 2 bytes to convert.</param>
		/// <returns>A 16-bit integer representing the specified 2 bytes.</returns>
		public static ushort ToUShort(byte[] value, int startIndex)
		{
			ushort ReturnVal = 0;
			if (!(value.Length - startIndex < SHORTLENGTH)) 
			{
				ushort* pUShort;
				fixed (byte* pByte = &value[startIndex])
				{
					pUShort = (ushort*)pByte;
					ReturnVal = *pUShort;
				}
				return ReturnVal;
			} 
			else 
			{
				throw new IndexOutOfRangeException();
			}
		}

		/// <summary>
		/// Converts an array of 8 bytes to an Long (Int64).
		/// </summary>
		/// <param name="value">The array of bytes to read.</param>
		/// <param name="startIndex">The starting position of the 8 bytes to convert.</param>
		/// <returns>A 64-bit integer representing the specified 8 bytes.</returns>
		public static long ToLong(byte[] value, int startIndex)
		{
			long ReturnVal = 0;
			if (!(value.Length - startIndex < LONGLENGTH)) 
			{
				long* pLong;
				fixed (byte* pByte = &value[startIndex])
				{
					pLong = (long*)pByte;
					ReturnVal = *pLong;
				}
				return ReturnVal;
			} 
			else 
			{
				throw new IndexOutOfRangeException();
			}
		}

		/// <summary>
		/// Converts an array of 8 bytes to an unsigned Long (UInt64).
		/// </summary>
		/// <param name="value">The array of bytes to read.</param>
		/// <param name="startIndex">The starting position of the 8 bytes to convert.</param>
		/// <returns>A 64-bit unsigned integer representing the specified 8 bytes.</returns>
		public static ulong ToULong(byte[] value, int startIndex)
		{
			ulong ReturnVal = 0;
			if (!(value.Length - startIndex < LONGLENGTH)) 
			{
				ulong* pULong;
				fixed (byte* pByte = &value[startIndex])
				{
					pULong = (ulong*)pByte;
					ReturnVal = *pULong;
				}
				return ReturnVal;
			} 
			else 
			{
				throw new IndexOutOfRangeException();
			}
		}
		#endregion
		
		/// <summary>
		/// Returns a specified section of the provided array.
		/// </summary>
		/// <param name="value">The array to retrieve a section of.</param>
		/// <param name="startIndex">The starting byte of the returned subarray.</param>
		/// <param name="length">The length of the returned subarray</param>
		/// <returns>A subsection of the specified array.</returns>
		public static byte[] SubArray(byte[] value, int startIndex, int length)
		{
			if (length > value.Length - startIndex)
				length = value.Length - startIndex;

			byte[] Output = new byte[length];
			Array.Copy(value, startIndex, Output, 0, length);
			return Output;
		}
	} //class ByteConversion

	
//	/// <summary>
//	/// A class used to read successive data structures from a single
//	/// array of bytes.
//	/// </summary>
//	public class ByteReader
//	{
//		private const int LONGLENGTH = 8;
//		private const int INTLENGTH = 4;
//		private const int SHORTLENGTH = 2;
//		private const int BYTELENGTH = 1;
//
//		int		_index = 0;
//		byte[]	_values;
//
//		public ByteReader (ref byte[] values)
//		{
//			_values = values;
//		}
//
//		public void Skip (int length)
//		{
//			_index += length;
//		}
//
//		public int ReadInt ()
//		{
//			int value = ByteConversion.ToInt(_values, _index);
//			_index += INTLENGTH;
//			return value;
//		}
//
//		public uint ReadUInt ()
//		{
//			uint value = ByteConversion.ToUInt(_values, _index);
//			_index += INTLENGTH;
//			return value;
//		}
//
//		public short ReadShort ()
//		{
//			short value = ByteConversion.ToShort(_values, _index);
//			_index += SHORTLENGTH;
//			return value;
//		}
//
//		public ushort ReadUShort ()
//		{
//			ushort value = ByteConversion.ToUShort(_values, _index);
//			_index += SHORTLENGTH;
//			return value;
//		}
//
//		public byte ReadByte ()
//		{
//			byte value = _values[_index];
//			_index += 1;
//			return value;
//		}
//
//		public byte[] ReadBytes (int length)
//		{
//			byte[] values = new byte[length];
//			Array.Copy(_values, _index, values, 0, length);
//			return values;
//		}
//
//		public float ReadFloat ()
//		{
//			float value = ByteConversion.ToFloat(_values, _index);
//			_index += INTLENGTH;
//			return value;
//		}
//
//		public long ReadLong ()
//		{
//			long value = ByteConversion.ToLong(_values, _index);
//			_index += LONGLENGTH;
//			return value;
//		}
//
//		public ulong ReadULong ()
//		{
//			ulong value = ByteConversion.ToULong(_values, _index);
//			_index += LONGLENGTH;
//			return value;
//		}
//
//		public string ReadString (int length)
//		{
//			string value = ByteConversion.GetString(_values, _index, length);
//			_index += length;
//			return value;
//		}
//	}
} //CoreTool.Core