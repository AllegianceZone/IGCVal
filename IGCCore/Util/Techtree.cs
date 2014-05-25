using System;
using System.Collections;
using System.Text;

using FreeAllegiance.IGCCore.Util;

namespace FreeAllegiance.IGCCore
{
	/// <summary>
	/// A list of prerequisites and definitions
	/// </summary>
	public class Techtree
	{
		private BitArray _pres;
		private BitArray _defs;

		/// <summary>
		/// Constructs a new list of pres/defs
		/// </summary>
		/// <param name="reader">The DataReader to use to read the pre/def list</param>
		public Techtree (DataReader reader)
		{
			Parse(reader);
		}

		/// <summary>
		/// Retrieves the TechTree from the specified DataReader
		/// </summary>
		/// <param name="reader">The DataReader from which to obtain the TechTree bytes</param>
		private void Parse (DataReader reader)
		{
			_pres = new BitArray(reader.ReadBytes(50));
			_defs = new BitArray(reader.ReadBytes(50));
		}

		/// <summary>
		/// Retrieves all Prerequisites defined by this TechTree
		/// </summary>
		/// <returns>A string with space-separated values of each Prerequisite defined.</returns>
		public string GetPres ()
		{
			StringBuilder Builder = new StringBuilder();
			
			for (int i = 0; i < _pres.Length; i++)
			{
				if (_pres[i])
				{
					Builder.Append(i.ToString());
					Builder.Append(" ");
				}
			}
			Builder.Remove(Builder.Length - 1, 1);
			return Builder.ToString();
		}

		/// <summary>
		/// Retrieves all Definitions defined by this TechTree
		/// </summary>
		/// <returns>A string with space-separated values of each Definition defined.</returns>
		public string GetDefs ()
		{
			StringBuilder Builder = new StringBuilder();
			
			for (int i = 0; i < _defs.Length; i++)
			{
				if (_defs[i])
				{
					Builder.Append(i.ToString());
					Builder.Append(" ");
				}
			}
			Builder.Remove(Builder.Length - 1, 1);
			return Builder.ToString();
		}

		/// <summary>
		/// Determines if this TechTree requires the specified prerequisite value or not
		/// </summary>
		/// <param name="value">The value to check if is required as a prerequisite</param>
		/// <returns>True if the specified value is required as a prerequisute, false if not</returns>
		public bool HasPrerequisite (int value)
		{
			return _pres[value];
		}

		/// <summary>
		/// Determines if this TechTree defines the specified value or not
		/// </summary>
		/// <param name="value">The value to check if is defined</param>
		/// <returns>True if the specified value is defined, false if not</returns>
		public bool HasDefinition (int value)
		{
			return _defs[value];
		}

		/// <summary>
		/// Toggles the prerequisite value, returning its new state
		/// </summary>
		/// <param name="value">The Pre value to be toggled</param>
		/// <returns>True if the Pre value was added, or False if removed</returns>
		public bool TogglePrerequisite (int value)
		{
			_pres.Set(value, !_pres.Get(value));
			return _pres[value];
		}

		/// <summary>
		/// Toggles the defined value, returning its new state
		/// </summary>
		/// <param name="value">The Def value to be toggled</param>
		/// <returns>True if the Def value was added, or False if removed.</returns>
		public bool ToggleDefinition (int value)
		{
			_defs.Set(value, !_defs.Get(value));
			return _defs[value];
		}

		public bool PreEquals (BitArray bitArray)
		{
			return BitArrayEquals(_pres, bitArray);
		}

		public bool DefEquals (BitArray bitArray)
		{
			return BitArrayEquals(_defs, bitArray);
		}

		public static bool BitArrayEquals (BitArray one, BitArray two)
		{
			if (one.Length != two.Length)
				return false;

			bool Result = true;

			for (int i = 0; i < one.Length; i++)
			{
				if (one[i] != two[i])
				{
					Result = false;
					break;
				}
			}
			return Result;
		}
		
		public BitArray Defs
		{
			get {return _defs;}
		}

		public BitArray Pres
		{
			get {return _pres;}
		}
	}
}
